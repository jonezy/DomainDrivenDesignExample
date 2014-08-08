using DomainDrivenDesignExample.Entity;
using DomainDrivenDesignExample.Infrastructure;
using System;

namespace DomainDrivenDesignExample.DomainServices
{
    public class PressReleaseAlertService
    {
        public event EventHandler<SendMessageEventArgs> SendMessage;
        private readonly IEmailSender _emailSender;

        public PressReleaseAlertService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            SendMessage += _emailSender.SendMessage;
        }

        protected virtual void OnSendMessage(SendMessageEventArgs e)
        {
            if(SendMessage != null)
            {
                SendMessage(this, e);
            }
        }

        public void SendAlerts(PressRelease release)
        {
            foreach (var user in release.MailingList.Subscribers)
            {
                SendMessage(this, new SendMessageEventArgs { Email = user.EmailAddress, Message = "this is the message!" });
            }
        }
    }


}
