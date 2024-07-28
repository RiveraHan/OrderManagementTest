using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using UserService.Application.Handlers;
using UserService.Infrastructure.Data;
using UserService.Infrastructure.Repositories;
using System.Reflection;
using UserService.Infrastructure.MessageBus;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("UserServiceDb"));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IUserRepository, UserRepository>();

        // services.AddHostedService(sp => new RabbitMQMessageConsumer("rabbitmq", "order-created"));
        services.AddSingleton(sp => new RabbitMQMessageConsumer("rabbitmq", "order-created"));

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService v1"));

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
