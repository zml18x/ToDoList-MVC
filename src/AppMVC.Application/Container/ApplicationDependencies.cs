using AppMVC.Application.Interfaces;
using AppMVC.Application.Mappers;
using AppMVC.Application.Services;
using AppMVC.Domain.Builders;
using AppMVC.Domain.Entities;
using AppMVC.Domain.Specifications;
using Microsoft.Extensions.DependencyInjection;

namespace AppMVC.Application.Container;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .ConfigureServices()
            .ConfigureAutoMapper();
        
        return services;
    }
    
    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoItemService, ToDoItemService>();
        services.AddScoped<ISpecification<ToDoItem>, ToDoItemSpec>();
        services.AddScoped<ToDoItemBuilder>();
            
        return services;
    }
    
    private static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        
        return services;
    }
}