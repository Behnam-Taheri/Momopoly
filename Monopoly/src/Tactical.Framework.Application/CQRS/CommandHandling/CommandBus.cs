using Microsoft.Extensions.DependencyInjection;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.CommandHandling;

public class CommandBus : ICommandBus, ICommandFluent
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    private readonly dynamic _commandToDispatch;

    public CommandBus(IServiceProvider serviceProvider, IEventBus eventBus, IUnitOfWork unitOfWork)
    {
        _serviceProvider = serviceProvider;
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }

    private CommandBus(IServiceProvider serviceProvider, IEventBus eventBus, IUnitOfWork unitOfWork, dynamic commandToDispatch) : this(serviceProvider, eventBus, unitOfWork)
    {
        _commandToDispatch = commandToDispatch;
    }

    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
    {

        var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>() 
            ?? throw new InvalidOperationException($"No CommandHandler is registered for {typeof(TCommand).Name}");

        await new UnitOfWorkDecorator<TCommand>(handler, _unitOfWork).HandleAsync(command, cancellationToken);
    }

    public ICommandFluent Execute<TCommand>(TCommand command) where TCommand : ICommand
    {
        return new CommandBus(_serviceProvider, _eventBus,_unitOfWork, command);
    }

    public ICommandFluent On<TEvent>(Action<TEvent> action) where TEvent : IEvent
    {
        _eventBus.Subscribe(action);
        return this;
    }

    public async Task DispatchAsync(CancellationToken cancellationToken)
    {
        await DispatchAsync(_commandToDispatch, cancellationToken);
    }
}