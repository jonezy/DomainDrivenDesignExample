
namespace DomainDrivenDesignExample.Entity
{
    public class PressRelease
    {
        public int PressReleaseId { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public MailingList MailingList { get; set; }
    }
}
