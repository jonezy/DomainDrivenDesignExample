using System;

namespace DomainDrivenDesignExample.Infrastructure
{
    public interface IEmailSender
    {
        void SendMessage(object sender, SendMessageEventArgs e);
    }

    public class EmailSender : IEmailSender
    {
        public event EventHandler<LogEventArgs> LogEvent;
        private readonly ILogger _logger;

        public EmailSender(ILogger logger)
        {
            _logger = logger;

            this.LogEvent += _logger.LogEvent;

        }

        protected virtual void OnLogEvent(LogEventArgs e)
        {
            if (LogEvent != null)
            {
                LogEvent(this, e);
            }
        }

        public void SendMessage(object sender, SendMessageEventArgs e)
        {
            // do email sending things.

            SendMessageEventArgs args = e as SendMessageEventArgs;

            LogEvent(this, new LogEventArgs { Source = "EmailSender", Level = "Info", Message = "Sent a message" });
            
        }
    }
}
