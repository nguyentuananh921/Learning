using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Infrastructure.Share
{

    /*
     * https://github.com/dotnet/aspnetcore/issues/49681#issuecomment-1679268319
     * IEmailSender exists in both 'Microsoft.AspNetCore.Identity.UI' and 'Microsoft.Extensions.Identity.Core
     */
    public interface IAppEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
