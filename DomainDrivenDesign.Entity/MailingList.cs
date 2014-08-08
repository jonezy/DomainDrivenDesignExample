using System.Collections.Generic;

namespace DomainDrivenDesignExample.Entity
{
    public class MailingList
    {
        public int MailingListId { get; set; }
        public List<User> Subscribers { get; set; } 

        public MailingList()
        {
            Subscribers = new List<User>();
        }
    }
}
