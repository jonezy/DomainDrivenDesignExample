using DomainDrivenDesignExample.Entity;
using DomainDrivenDesignExample.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenDesignExample.BusinessLogic
{
    public class PressReleaseService
    {
        private readonly IRepository<PressRelease> _pressReleaseRepository;

        public PressReleaseService(IRepository<PressRelease> pressReleaseRepository)
        {
            _pressReleaseRepository = pressReleaseRepository;
        }

        public List<PressRelease> GetAllActiveNotDeletedPressReleases()
        {
            return _pressReleaseRepository.GetAll(pr => pr.IsActive && !pr.IsDeleted).ToList();
        }

        public void Save(PressRelease entity)
        {
            if (entity.IsDeleted) { 
                // maybe do somethings like alert admins that a press release is being deleted.
            }

            _pressReleaseRepository.Add(entity);
        }
    }
}
