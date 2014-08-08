
namespace DomainDrivenDesignExample.Infrastructure
{
    public interface ILogger
    {
        void LogEvent(object sender, LogEventArgs e);
    }

    public class Logger : ILogger
    {
        public void LogEvent(object sender, LogEventArgs e)
        {
            // do logging related things.
        }
    }
}
