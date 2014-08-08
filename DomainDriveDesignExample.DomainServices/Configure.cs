using Autofac;
using DomainDrivenDesignExample.Infrastructure;

namespace DomainDrivenDesignExample.DomainServices
{
    public static class Configure
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var logger = container.Resolve<ILogger>();
                
                var sender = container.Resolve<IEmailSender>();
            }
        }
    }
}
