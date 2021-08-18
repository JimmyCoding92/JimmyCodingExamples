using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface IDependencyService
    {
        public string GetSingletonId();

        public string GetTransientId();

        public string GetScopedId();
    }

    public class DependencyService : IDependencyService
    {
        public ISingletonService singletonService;
        public ITransientService transientService;
        public IScopedService scopedService;

        public DependencyService(ISingletonService singletonService, ITransientService transientService, IScopedService scopedService)
        {
            this.singletonService = singletonService;
            this.transientService = transientService;
            this.scopedService = scopedService;
        }

        public string GetScopedId()
        {
            return scopedService.GetId();
        }

        public string GetSingletonId()
        {
            return singletonService.GetId();
        }

        public string GetTransientId()
        {
            return transientService.GetId();
        }
    }
}
