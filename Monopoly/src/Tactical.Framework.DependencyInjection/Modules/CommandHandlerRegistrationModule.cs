using Autofac;
using System.Reflection;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.DependencyInjection.Modules
{
    public class CommandHandlerRegistrationModule : Autofac.Module
    {
        private readonly Assembly[] assemblies;

        public CommandHandlerRegistrationModule(params Assembly[] assemblies)
        {
            this.assemblies = assemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => t.GetInterface(nameof(ICommandHandler)) != null)
                    .AsImplementedInterfaces()
                    .InstancePerDependency();
            }
        }
    }
}
