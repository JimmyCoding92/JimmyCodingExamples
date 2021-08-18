using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface ISingletonService : IService { }

    public class SingletonService : ISingletonService, IDisposable
    {
        private string id;
        private ILogger logger;

        public SingletonService(ILogger<SingletonService> logger)
        {
            id = Guid.NewGuid().ToString();
            this.logger = logger;
            this.logger.LogInformation("SingletonService with instance id {0} Start", id);
        }

        public string GetId()
        {
            return id;
        }

        public void Dispose()
        {
            this.logger.LogInformation("SingletonService with instance id {0} Dispose", id);
        }
    }
}
