using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Services
{
    public class MockMailService : IMailService
    {
        private readonly ILogger<MockMailService> logger;

        public MockMailService(ILogger<MockMailService> logger)
        {
            this.logger = logger;
        }
        public void SendMail(string to, string subject, string body)
        {
            logger.LogInformation($"To: {to}; Subject: {subject}; Body: {body}");
        }
    }
}
