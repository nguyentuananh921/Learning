using Core.Application.Interfaces.Infrastructure.Persistence.Repository.Common;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Infrastructure.Persistence.Repository
{
    public interface IDeveloperRepository:IAsyncRepository<Developer>
    {
        IEnumerable<Developer> GetPopularDevelopers(int count);
    }
}
