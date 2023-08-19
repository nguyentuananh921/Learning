using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Enums
{
    /*
     * https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
     */
    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }
}
