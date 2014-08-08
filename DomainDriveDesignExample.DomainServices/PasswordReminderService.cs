using DomainDrivenDesignExample.Entity;
using DomainDrivenDesignExample.Infrastructure;
using System;

namespace DomainDrivenDesignExample.DomainServices
{
    public interface IPasswordReminderService
    {
        void SendReminder(User user);
    }

    public class PasswordReminderService : IPasswordReminderService
    {
        EventHandler<LogEventArgs> HandleLogEvent;
        EventHandler<SendMessageEventArgs> HandleSendEmail;
        
        public PasswordReminderService(ILogger logger, IEmailSender emailSender)
        {
            this.HandleLogEvent += logger.LogEvent;
            this.HandleSendEmail += emailSender.SendMessage;
        }
        
        protected virtual void OnLogEvent(object sender, LogEventArgs e)
        {
            if (HandleLogEvent != null)
                HandleLogEvent(this, e);
        }

        public void SendReminder(User user)
        {
            // generate a token to attach to the link to reset password

            // 
            HandleSendEmail(this, new SendMessageEventArgs { Email = user.EmailAddress, Message = "Test!" });
        }

    }
}
