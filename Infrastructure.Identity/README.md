# Infrastructure.Identity
+Package Needed 
    Install-Package Microsoft.AspNetCore.Identity
    Install-Package Microsoft.AspNetCore.Mvc.Core  To validate on ApplicationUser
    Install-Package Microsoft.Extensions.Identity.Stores 
    Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore   


    Install-Package Microsoft.EntityFrameworkCore.SqlServer  
    Install-Package Microsoft.EntityFrameworkCore.Tools
    Install-Package Microsoft.EntityFrameworkCore.Design 

-- If you want to use the default UI offered by ASP, install the following library
    Install-Package Microsoft.AspNetCore.Identity.UI 

-- For scaffold
    Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
    Install-Package Microsoft.Extensions.Options.ConfigurationExtensions 


    Microsoft.AspNetCore.Authentication.JwtBearer
    System.IdentityModel.Tokens.Jwt    
      
    

+ To separate the Database Context
add-migration "Initial-Identity" -Context IdentityContext
update-database -Context IdentityContext

add-migration "Initial-DataContact" -Context ApplicationDbContext
update-database -Context ApplicationDbContext 


Migration
Add-Migration MyMigration -context IdentityDbContext
Add-Migration MyMigration -context ApplicationDbContext
update-database -context IdentityDbContext
update-database -context ApplicationDbContext

Add-Migration Initial -context IdentityDbContext
Add-Migration Initial -context ApplicationDbContext