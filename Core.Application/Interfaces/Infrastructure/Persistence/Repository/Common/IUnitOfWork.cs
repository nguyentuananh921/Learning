using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Infrastructure.Persistence.Repository.Common
{
    /*
     * https://www.youtube.com/watch?v=AopeJjkcRvU&t=29374s
     * https://github.com/bhrugen/Bulky_MVC/tree/15a896555835fae1482fb1536e549dc132c92249
     * 
     * https://github.com/iammukeshm/RepositoryPattern.WebApi
     * https://github.com/iammukeshm/RepositoryPattern.WebApi/blob/master/DataAccess.EFCore/UnitOfWorks/UnitOfWork.cs
     */
    public interface IUnitOfWork: IDisposable
    {
        IDeveloperRepository Developers { get; }
        IProjectRepository Projects { get; }
        int Complete();
        Task<int> Save(CancellationToken cancellationToken);

        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
