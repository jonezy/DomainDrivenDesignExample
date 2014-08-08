using System;

namespace DomainDrivenDesignExample.Infrastructure
{
    public class SendMessageEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }

    public class LogEventArgs : EventArgs
    {
        public string Source { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }

}
