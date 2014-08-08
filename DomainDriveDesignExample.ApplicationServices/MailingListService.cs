using DomainDrivenDesignExample.Entity;
using DomainDrivenDesignExample.Infrastructure;

namespace DomainDrivenDesignExample.BusinessLogic
{
    public class MailingListService
    {
        private readonly IRepository<MailingList> _mailingListRepository;

        public MailingListService(IRepository<MailingList> mailingListRepository)
        {
            _mailingListRepository = mailingListRepository;
        }

        public MailingList GetMailingListById(int id)
        {
            return _mailingListRepository.Get(ml => ml.MailingListId == id);
        }
    }
}
