using DomainDrivenDesignExample.BusinessLogic;
using DomainDrivenDesignExample.DomainServices;
using DomainDrivenDesignExample.Entity;
using DomainDrivenDesignExample.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class PressReleaseApplicationServiceTest
    {
        private IRepository<PressRelease> _pressReleaseRepository;
        private PressReleaseService _pressReleaseService;

        [SetUp]
        public void Setup()
        {
            _pressReleaseRepository = new Repository<PressRelease>();
            _pressReleaseRepository.Add(new PressRelease { PressReleaseId = 1, Headline = "This is a test", Body = "Test", IsActive = true, IsDeleted = false });

            _pressReleaseService = new PressReleaseService(_pressReleaseRepository);

            Configure.Initialize();
        }

        [Test]
        public void GetAllPressReleasesShouldHaveNoInactiveOrDeletedPressReleases()
        {
            List<PressRelease> releases = _pressReleaseService.GetAllActiveNotDeletedPressReleases();

            int count = releases.Where(r => !r.IsActive && r.IsDeleted).Count();

            Assert.AreEqual(0, count);
        }

        [Test]
        public void AlertServiceTest()
        {

            User user = new User {
                UserId = 1,
                EmailAddress = "chris@jonezy.org"
            };

            MailingList pressReleaseList= new MailingList();
            pressReleaseList.Subscribers.Add(user);

            PressRelease pressRelease = new PressRelease{
                PressReleaseId = 1,
                 Headline = "Test Release",
                 Body = "Press release body",
                 IsActive = true,
                 IsDeleted = false,
                 MailingList = pressReleaseList
            };

            Logger logger = new Logger();
            EmailSender emailSender = new EmailSender(logger);
            PressReleaseAlertService pressReleaseAlertService = new PressReleaseAlertService(emailSender);
            
            pressReleaseAlertService.SendAlerts(pressRelease);
        }

        [Test]
        public void PasswordReminderTest()
        {
            User user = new User
            {
                UserId = 1,
                EmailAddress = "chris@jonezy.org"
            };
            Logger logger = new Logger();
            EmailSender emailSender = new EmailSender(logger);
            PasswordReminderService reminderService = new PasswordReminderService(logger, emailSender);

            reminderService.SendReminder(user);
        }
        
    }
}
