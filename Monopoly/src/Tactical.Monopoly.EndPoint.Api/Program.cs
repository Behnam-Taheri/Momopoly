using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Framework.Core.Abstractions;
using Tactical.Framework.Persistence.EF;
using Tactical.Monopoly.Application.Boards.CommandHandlers;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;
using Tactical.Monopoly.Persistence.EF.Boards;
using Tactical.Monopoly.Persistence.EF.Contexts;
using Tactical.Monopoly.Queries.Contracts;
using Tactical.Monopoly.Queries.EF;
using Tactical.Monopoly.Queries.Retrieval.EF;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed(o => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IBoardReadRepository, BoardReadRepository>();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICommandHandler<CreateBoardCommand>, CreateBoardCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteBoardCommand>, DeleteBoardCommandHandler>();
builder.Services.AddTransient<ICommandHandler<MovePlayerCommand>, MovePlayerCommandHandler>();


builder.Configuration.GetSection("ConnectionStrings.MonopolyConnectionString");

AddDbContext(builder);

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseSwagger();
app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDbContext(WebApplicationBuilder webApplicationBuilder)
{

    webApplicationBuilder.Services.AddDbContext<DbContext, MonopolyContext>(options =>
    {
        options.UseNpgsql(Environment.GetEnvironmentVariable("MonopolyConnectionString"));
#if DEBUG
        options.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("MonopolyConnectionString"));
#endif
        if (webApplicationBuilder.Environment.IsProduction()) return;

        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(warningLog =>
        {
            warningLog.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning,
                CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        });
    });

    webApplicationBuilder.Services.AddDbContext<RetrievalDbContext>(options =>
    {
        options.UseNpgsql(Environment.GetEnvironmentVariable("MonopolyConnectionString"),
            sqlOptions => { sqlOptions.MigrationsAssembly(typeof(RetrievalDbContext).Assembly.FullName); });

#if DEBUG
        options.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("MonopolyConnectionString"),
                    sqlOptions => { sqlOptions.MigrationsAssembly(typeof(RetrievalDbContext).Assembly.FullName); });
#endif

        if (webApplicationBuilder.Environment.IsProduction()) return;

        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(warningLog =>
        {
            warningLog.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning,
                CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        });
    });
}
