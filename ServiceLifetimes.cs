using System;
using Microsoft.Extensions.DependencyInjection;

namespace LifetimeScopesExample
{
    // This class demonstrates the concept of service lifetimes (also known as lifetime scopes) in ASP.NET Core.
    // Service lifetimes determine how long an instance of a service is kept alive and when it gets disposed of.
    // Yes, these are often referred to as service lifetimes or lifetime scopes in the context of dependency injection,
    // particularly in frameworks like ASP.NET Core. The term "lifetime scope" is used to describe how long an instance
    // of a service is kept alive and when it gets disposed of within the application's dependency injection container.
    public class LifetimeScopes
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Transient: A new instance of MyTransientService is created every time it is requested.
            // Use this for lightweight, stateless services.
            // Service Lifetime: Transient (Short-lived)
            services.AddTransient<IMyService, MyTransientService>();

            // Scoped: A new instance of MyScopedService is created once per HTTP request.
            // Use this when you need to maintain a consistent state within a single request.
            // Service Lifetime: Scoped (Per-request)
            services.AddScoped<IMyService, MyScopedService>();

            // Singleton: Only one instance of MySingletonService is created for the entire lifetime of the application.
            // Use this for services that need to maintain global state or are expensive to create.
            // Service Lifetime: Singleton (Application-wide)
            services.AddSingleton<IMyService, MySingletonService>();
        }
    }

    // Example interface that our services will implement.
    public interface IMyService
    {
        void DoWork();
    }

    // Example Transient service
    public class MyTransientService : IMyService
    {
        public void DoWork()
        {
            Console.WriteLine("Transient service is doing work.");
        }
    }

    // Example Scoped service
    public class MyScopedService : IMyService
    {
        public void DoWork()
        {
            Console.WriteLine("Scoped service is doing work.");
        }
    }

    // Example Singleton service
    public class MySingletonService : IMyService
    {
        public void DoWork()
        {
            Console.WriteLine("Singleton service is doing work.");
        }
    }

    // Summary Table:
    // ----------------------------------------
    // | **Service Lifetime** | **Instance Count** | **When Created**         | **Use Case**                       |
    // |----------------------|--------------------|--------------------------|------------------------------------|
    // | **Transient**        | New instance every time | Whenever requested  | Lightweight, stateless services    |
    // | **Scoped**           | One per request    | Once per HTTP request    | Services needing state per request |
    // | **Singleton**        | Single instance for the app | When the app starts or when first requested | Expensive-to-create services, global state |
    // ----------------------------------------

    // Explanation:
    // - Transient: The service is created anew each time it is requested. Best for services that do not maintain state.
    // - Scoped: A service is created once per request. It shares the same instance throughout a single HTTP request.
    // - Singleton: Only one instance exists throughout the application's lifetime. It is shared across all requests.
    // - These lifetimes help manage how services are created and disposed, optimizing memory use and performance.
    // - The term "lifetime scope" is used to describe how long an instance of a service is kept alive and when it gets
    //   disposed of within the application's dependency injection container.
    // - This is a crucial concept in ASP.NET Core's dependency injection system, allowing developers to control the 
    //   lifecycle of their services and improve application performance.
}
