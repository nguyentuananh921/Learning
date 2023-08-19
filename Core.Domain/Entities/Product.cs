using Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    /*
     * https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
     * https://codewithmukesh.com/blog/onion-architecture-in-aspnet-core/
     */

    public class Product: BaseEntity
    {
        //public string Id { get; set; } //No More Id Needed if You Inherit from BaseEntity
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
