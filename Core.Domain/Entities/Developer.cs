using Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    /*
     * https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
     */
    public class Developer:BaseEntity
    {
        public string Name { get; set; }
        public int Followers { get; set; }
    }
}
