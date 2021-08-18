using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface ITransientService : IService { }

    public class TransientService : ITransientService, IDisposable
    {
        private string id;
        private ILogger<TransientService> logger;

        public TransientService(ILogger<TransientService> logger)
        {
            id = Guid.NewGuid().ToString();
            this.logger = logger;
            this.logger.LogInformation("Transient service with instance id {0} start", id);
        }

        public void Dispose()
        {
            this.logger.LogInformation("Transient service with instance id {0} dispose", id);
        }

        public string GetId()
        {
            return id;
        }
    }
}
