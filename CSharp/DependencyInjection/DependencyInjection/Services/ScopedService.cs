using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface IScopedService : IService { }

    public class ScopedService : IScopedService, IDisposable
    {
        private ILogger logger;
        private string id;

        public ScopedService(ILogger<ScopedService> logger)
        {
            this.logger = logger;
            id = Guid.NewGuid().ToString();

            this.logger.LogInformation("ScopedService with instance id {0} Start", id);
        }

        string IService.GetId()
        {
            return id;
        }
        public void Dispose()
        {
            this.logger.LogInformation("ScopedService with instance id {0} Dispose", id);
        }
    }
}
