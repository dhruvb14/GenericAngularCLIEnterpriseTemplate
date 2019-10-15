Master Branch: [![Build Status](https://img.shields.io/appveyor/ci/dhruvb14/GenericAngularCLIEnterpriseTemplate/master.svg)](https://ci.appveyor.com/project/dhruvb14/GenericAngularCLIEnterpriseTemplate)

# Modern Web Application Baseline

- Install Node.js latest LTS release **https://nodejs.org/**
- Install Visual Studio Code **https://code.visualstudio.com/**
- Install the lastest dotnet core sdk from **https://www.microsoft.com/net/download/windows**

## Initial Application Baseline

This section will go through setting up your project for a Modern Web Applications which includes **all** the prerequisites for setting up builds in a disconnected environment. Dev enviroment is the only one that will require internet.

## Completed code includes

- Dotnet Core 2 Angular CLI template
- Entity Framework Core
- Windows auth with local application roles
- Automatic TS Interface generation for ViewModels
- Use of Yarn instead of NPM to allow for fully disconnected Builds in VSTS/TFS2017
- Kendo Angular integration (Only for builds, no demo code implemented)
- Component Level Unit Testing (E2E Comming Soon)

## How to build from scratch

- Open powershell and run the commands:

```powershell
mkdir brownbags
cd brownbags
dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
dotnet new angular -o 'Brownbag.Web' -f netcoreapp2.0
dotnet new classlib -o 'Brownbag.Data'
mkdir Brownbag.Web/ClientApp/offline-resources
mkdir Brownbag.Web/Models
mkdir Brownbag.Data/Models
mkdir Brownbag.Data/Interfaces
mkdir Brownbag.Web/Middleware
mkdir Brownbag.Web/Automapper
mkdir Brownbag.Web/ClientApp/src/shared
mkdir Brownbag.Web/ClientApp/src/shared/service
mkdir Brownbag.Web/ClientApp/src/app/blog
mkdir Brownbag.Web/ClientApp/src/app/blog-view
mkdir Brownbag.Web/ClientApp/src/app/post
mkdir Brownbag.Web/Extensions
code nuget.config
```

Paste in the following Nuget Config in VSCode window that opened

```xml

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="NuGet official package source" value="https://api.nuget.org/v3/index.json" />
    <add key="Telerik" value=".\Brownbag.Web\ClientApp\offline-resources" />
    <add key="DNX2-EFCore2-Angular-Template" value="http://localTFSServer:8080/tfs/esd/_packaging/DNX2-EFCore2-Angular-Template/nuget/v3/index.json" />
  </packageSources>
</configuration>

```

Save and close vscode

**If not using Kendo remember to comment out line 50 in startup.cs and line and line 22 in Brownbag.Web.csproj or you will have build errors**

Go to **https://www.telerik.com/account/product-download?product=UIASPCORE** and download the Telerik.UI.for.AspNet.Core*.nupkg and save it in the path listed below relative to the project directory:

`.\Brownbag.Web\ClientApp\offline-resources`

Go to **https://github.com/yarnpkg/yarn/releases/latest** and download the lastest yarn-1.X.X.js and save it with the name `yarn.js` in the path listed below relative to the project directory:

`.\Brownbag.Web\ClientApp`

Go back in Powershell window

```
dotnet new sln
dotnet sln brownbags.sln add .\Brownbag.Web\Brownbag.Web.csproj .\Brownbag.Data\Brownbag.Data.csproj
code .\Brownbag.Data\Brownbag.Data.csproj
```

Update the file in VSCode window that opened:

```xml
  <Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
      <TargetFramework>netcoreapp2.0</TargetFramework>
      <Configurations>Debug;Release;Integrated</Configurations>
      <RuntimeFrameworkVersion>2.0.6</RuntimeFrameworkVersion>
    </PropertyGroup>

    <ItemGroup>
      <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="2.0.2" />
      <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.2" />
      <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.0.2" />
      <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.0.3" />
      <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.1" />

    </ItemGroup>

    <ItemGroup>
      <Reference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore">
        <HintPath>C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.aspnetcore.identity.entityframeworkcore\2.0.0\lib\netstandard2.0\Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll</HintPath>
      </Reference>
      <Reference Include="Microsoft.Extensions.Identity.Stores">
        <HintPath>C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.extensions.identity.stores\2.0.0\lib\netstandard2.0\Microsoft.Extensions.Identity.Stores.dll</HintPath>
      </Reference>
      <Reference Include="System">
        <HintPath>System</HintPath>
      </Reference>
      <Reference Include="System.Data">
        <HintPath>System.Data</HintPath>
      </Reference>
      <Reference Include="System.Xml">
        <HintPath>System.Xml</HintPath>
      </Reference>
    </ItemGroup>

  </Project>


```


Close vscode ang go back in Powershell window

```powershell
code .\Brownbag.Web\Brownbag.Web.csproj
```

Update the file in VSCode window that opened:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <TypeScriptCompileBlocked>true</TypeScriptCompileBlocked>
    <TypeScriptToolsVersion>Latest</TypeScriptToolsVersion>
    <IsPackable>false</IsPackable>
    <SpaRoot>ClientApp\</SpaRoot>
    <DefaultItemExcludes>$(DefaultItemExcludes);$(SpaRoot)node_modules\**</DefaultItemExcludes>

    <!-- Set this to true if you enable server-side prerendering -->
    <BuildServerSideRenderer>false</BuildServerSideRenderer>
    <Configurations>Debug;Release;Integrated</Configurations>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.SpaServices.Extensions" Version="2.0.0" />
    <PackageReference Include="Reinforced.Typings" Version="1.4.91" />
    <PackageReference Include="AutoMapper" Version="6.2.2" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="3.2.0" />
    <PackageReference Include="Telerik.UI.for.AspNet.Core" Version="2018.1.221" />
  </ItemGroup>

  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.1" />
  </ItemGroup>

  <ItemGroup>
    <!-- Don't publish the SPA source files, but do show them in the project files list -->
    <Content Remove="$(SpaRoot)**" />
    <None Include="$(SpaRoot)**" Exclude="$(SpaRoot)node_modules\**" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Brownbag.Data\Brownbag.Data.csproj" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="ClientApp\src\models\" />
    <Folder Include="wwwroot\images\" />
  </ItemGroup>

  <Target Name="DebugEnsureNodeEnv" BeforeTargets="Build" Condition=" '$(Configuration)' == 'Debug' And !Exists('$(SpaRoot)node_modules') ">
    <!-- Ensure Node.js is installed -->
    <Exec Command="node --version" ContinueOnError="true">
      <Output TaskParameter="ExitCode" PropertyName="ErrorCode" />
    </Exec>
    <Error Condition="'$(ErrorCode)' != '0'" Text="Node.js is required to build and run this project. To continue, please install Node.js from https://nodejs.org/, and then restart your command prompt or IDE." />
    <Message Importance="high" Text="Restoring dependencies using 'yarn'. This may take several minutes..." />
    <Exec WorkingDirectory="$(SpaRoot)" Command="node yarn install" />
  </Target>

  <Target Name="PublishRunWebpack" AfterTargets="ComputeFilesToPublish">
    <!-- As part of publishing, ensure the JS resources are freshly built in production mode -->
    <Exec WorkingDirectory="$(SpaRoot)" Command="node yarn install" />
    <Exec WorkingDirectory="$(SpaRoot)" Command="npm run build -- --prod" />
    <Exec WorkingDirectory="$(SpaRoot)" Command="npm run build:ssr -- --prod" Condition=" '$(BuildServerSideRenderer)' == 'true' " />

    <!-- Include the newly-built files in the publish output -->
    <ItemGroup>
      <DistFiles Include="$(SpaRoot)dist\**; $(SpaRoot)dist-server\**" />
      <DistFiles Include="$(SpaRoot)node_modules\**" Condition="'$(BuildServerSideRenderer)' == 'true'" />
      <ResolvedFileToPublish Include="@(DistFiles->'%(FullPath)')" Exclude="@(ResolvedFileToPublish)">
        <RelativePath>%(DistFiles.Identity)</RelativePath>
        <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
      </ResolvedFileToPublish>
    </ItemGroup>
  </Target>

</Project>


```

Close vscode and go back in Powershell window

```powershell
code .\Brownbag.Web\.yarnrc
```

Update the file in VSCode window that opened:

```xml
# THIS IS AN AUTOGENERATED FILE. DO NOT EDIT THIS FILE DIRECTLY.
# yarn lockfile v1


lastUpdateCheck 1522867435582
yarn-offline-mirror ".\\ClientApp\\offline-resources\\yarn"
```

Close vscode and go back in Powershell window

```powershell
code .\Brownbag.Web\Reinforced.Typings.settings.xml
```

Update the file in VSCode window that opened:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
	<!-- 
		Hi! This is settings file for Reinforced.Typings.
		Since Reinforced.Typings is not a framework itself but build process extension,
		therefore settings file is basically piece of MSBuild script.
		This file is being imported to your .csproj during each build the same way
		as Reinforced.Typings.targets that is located in its package /build directory.
		
		Reinforced.Typings has completely few parameters. So, here we go.
	-->
	
	<PropertyGroup>
	
		<!-- 
			This property points target file where to put generated sources. 
			It is not used if RtDivideTypesAmongFiles='true' specified.
			Important! Do not forget to include generated file to solution.
		-->
		<RtTargetFile>$(ProjectDir)\ClientApp\src\models\project.ts</RtTargetFile>
		
		<!--
			This property sets RT configuration method for fluent configuration.
			If you dont want to use attributes for some reason then here you can
			specify full-qualified configuration method name (including namespace, 
			type and method name, e.g. My.Assembly.Configuration.ConfigureTypings) 
			of method that consumes Reinforce.Typings.Fluent.ConfigurationBuilder type
			and is void (nothing returns). This method will be executed to build 
			types exporting configuration in fluent manner.
			Surely you can continue using attributes. Also fluent configuration methods
			could not provide a way to configure some specific things (generics parameters
			override and classes' TsBaseParam). However in this case fluent configuration
			would be preferred. It means that if member configuration is supplied both 
			in attributes and in fluent methods then configuration from fluent methods will
			be used.
		-->
		<RtConfigurationMethod></RtConfigurationMethod>
		
		<!--
			By default all of your typings will be located in single file specified by RtTargetFile.
			It may be heavy for large projects because you will get single large file containing signinficant
			part of TS sources. It could lead to various problems (e.g. monstrous SCM merges). 
			So here we have RtDivideTypesAmongFiles parameter that will make Reinforced.Typings 
			generate TS sources in C#/Java/somewhat-OO-language-manner (class per file) when set to true.
			
			Important! In case of using this setting, do not forget to add generated files to solution manually.
		-->
		<RtDivideTypesAmongFiles>false</RtDivideTypesAmongFiles>
		
		<!--
			... and if you use RtDivideTypesAmongFiles then please specify target directory
			where to put all generated stuff. Reinforced.Typings will automatically create
			directories structure according to used namespaces.
			Note that in case of using RtDivideTypesAmongFiles, RtTargetFile parameter will 
			NOT be used anymore.
		-->
		<RtTargetDirectory>$(ProjectDir)\ClientApp\src\models</RtTargetDirectory>
		
		
		<!--
			Disables typescript compilation in solution. 
			Use it when your TypeScripts are broken and you need to rebuild project and then regenerate typings 
			to fix it, but TypeScript compilation fails and failing project build. This option will temporary 
			disable typescripts build.
		-->
		<RtBypassTypeScriptCompilation>false</RtBypassTypeScriptCompilation>				
		
		<!--
			Disables Reinforced.Typings generation on build. Use it when it is necessary to temporary disable 
			typings generation.
		-->
		<RtDisable>false</RtDisable>		
		
	</PropertyGroup>
	
	<!--
		If you want Reinforced.Typings to lookup for attributed classes not only current
		project's assembly but also another assembly then you can specify it in RtAdditionalAssembly
		item group. 
		
		Reinforced.Typings receives reference assemblies list from CoreCompile task so you
		can specify here assemblies from your project's references (with or without .dll extension).
		If desired assembly is not in references list of current project then you will have
		to specify full path to it.
	
	<ItemGroup>
		<RtAdditionalAssembly Include="My.Project.Assembly"/>
		<RtAdditionalAssembly Include="My.Project.Assembly.dll"/>
		<RtAdditionalAssembly Include="C:\Full\Path\To\Assembly\My.Project.Assembly.dll"/>
		<RtAdditionalAssembly Include="$(SolutionDir)\AnotherProject\bin\Debug\AnotherProject.dll"/>
	</ItemGroup>
	-->
</Project>
```

Close vscode and go back in Powershell window

``` Powershell
cd Brownbag.Web\ClientApp
node yarn add primeng
node yarn add primeng-advanced-growl
node yarn add web-animations-js
node yarn add primeng-advanced-growl
node yarn add font-awesome@^4.7
node yarn add quill@^1.3.6
dotnet restore
dotnet build
cd ../..
code Brownbag.code-workspace
```

Paste in the following and hit save:

```JSON

{
	"folders": [
		{
			"path": "."
		}
	],
	"settings": {
		"csharpfixformat.style.spaces.beforeParenthesis": false,
		"npm.enableScriptExplorer": true
	},
	"extensions": {
		"recommendations": [
			"alexiv.vscode-angular2-files",
			"Angular.ng-template",
			"ms-vscode.csharp",
			"jchannon.csharpextensions",
			"Leopotam.csharpfixformat",
			"msjsdiag.debugger-for-chrome",
			"xykong.format-all-files",
			"eamodio.gitlens",
			"yzhang.markdown-all-in-one",
			"DavidAnson.vscode-markdownlint",
			"stringham.move-ts",
			"tintoy.msbuild-project-tools",
			"miclo.sort-typescript-imports",
			"eg2.tslint",
			"rbbit.typescript-hero",
            "robertohuertasm.vscode-icons",
			"hbenl.vscode-firefox-debug"            
		]
	}
}

```

Close VSCode and navigate to the files in explorer

Double click the file we just created.

Wait until you see a notification from VSCode that looks like this and click **yes**

![Add Resources Image](Assets\Add-Resources.png)

Click the Extensions tab and click the 3 dots in the top right of the tab. Click 'Show recommended extensions' and install all of them. Once all of them are installed click reload.

## Creating Datamodel

- This entire section will be inside the Brownbag.Data folder
- remove class1.cs

## Creating Auditing Pieces

Create file in Interfaces folder named `IAuditable.cs` with following content:

```Csharp
using System;

namespace Brownbag.Data.Interfaces {
  public interface IAuditable {
    Guid CreatedBy { get; set; }

    DateTime CreatedDate { get; set; }

    Guid? UpdatedBy { get; set; }

    DateTime? UpdatedDate { get; set; }
  }
}
```

## Creating Blog and Posts Model

Create file in Models folder named `Blog.cs` with following content:

```Csharp
using System;
using System.Collections.Generic;
using Brownbag.Data.Interfaces;

namespace Brownbag.Data.Models
{
    public class Blog : IAuditable
    {
        public Blog()
        {
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
```

Create file in Models folder named `Post.cs` with following content:

```Csharp
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Brownbag.Data.Interfaces;

namespace Brownbag.Data.Models {
    public class Post : IAuditable {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        [ForeignKey ("CreatedByUser")]
        public Guid CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey ("UpdatedByUser")]
        public Guid? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
```

## Creating Users Model

- Create file in Models folder named `User.cs` with following content:

```Csharp
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Brownbag.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        public string UserFullName { get; set; }

        /// Add back legacy Virtuals to support old Identity Style Queries

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<Guid>> Roles { get; } = new List<IdentityUserRole<Guid>>();
    }
}
```

## Creating Data Context with Auditing

- Create file in Models folder named `ApplicationDataContext.cs` with following content: 

```Csharp
using System;
using Brownbag.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brownbag.Data.Models
{
    public partial class ApplicationDataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private IHttpContextAccessor _context { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _context = contextAccessor;
        }
        public override int SaveChanges()
        {
            // https://stackoverflow.com/questions/36401026/how-to-get-user-information-in-dbcontext-using-net-core
            // https://stackoverflow.com/questions/35765204/how-can-i-get-user-and-claim-information-using-action-filters/35826744
            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {

                    auditableEntity.Entity.UpdatedDate = DateTime.Now;
                    auditableEntity.Entity.UpdatedBy = new Guid(_context.HttpContext.User.FindFirst("userId").Value);

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = DateTime.Now;
                        auditableEntity.Entity.CreatedBy = new Guid(_context.HttpContext.User.FindFirst("userId").Value);
                    }
                    else
                    {
                        auditableEntity.Property(p => p.CreatedDate).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetUsers");
            });

            modelBuilder.Entity<IdentityRole<Guid>>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity => {
                entity.HasKey(r => new { r.Id });
                entity.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(entity => {
                entity.HasKey(r => new { r.UserId, r.RoleId });
                entity.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity => {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
                entity.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(entity => {
                entity.HasKey(r => r.UserId);
                entity.ToTable("AspNetUserTokens");
            });
        }
    }
}
```

## Wiring up Datamodel and Middleware

- This entire section will be inside the Brownbag.Web folder

## Creating Middleware Pieces

Create file in Middleware folder named `RolesAuthorizationMiddleware.cs` with following content:

```Csharp
using Brownbag.Data.Models;
using Brownbag.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Brownbag.Web.Middleware
{
    public class RolesAuthorizationMiddleware : IMiddleware {
        private readonly ApplicationDataContext _db;

        public RolesAuthorizationMiddleware(ApplicationDataContext db) {
            _db = db;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
            try {
                User user = _db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(context.User.Identity.Name, StringComparison.CurrentCultureIgnoreCase));
                if (user != null) {
                    var roles = from ur in user.Roles
                    from r in _db.Roles
                    where ur.RoleId.Equals(r.Id)
                    select r.Name;

                    var UserRoleClaims = roles.Select(i => new Claim(ClaimTypes.Role, i));
                    ((ClaimsIdentity) context.User.Identity).AddClaims(UserRoleClaims);
                    ((ClaimsIdentity) context.User.Identity).AddClaim(new Claim("userId", user.Id.ToString()));
                }
            } catch (Exception e) {
                Console.Write(e);
            }

            await next(context);
        }

    }
    public static class RolesAuthorizationMiddlewareExtensions {
        public static IApplicationBuilder RolesAuthorization(
            this IApplicationBuilder builder) {
            return builder.UseMiddleware<RolesAuthorizationMiddleware>();
        }
    }
}
```

Create file in Middleware folder named `IBrownbagRoleProvider.cs` with following content:

```Csharp
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Brownbag.Web.Models;

namespace Brownbag.Web.Middleware
{
    public interface IBrownbagRoleProvider
    {
        string[] GetRolesForUser(string username);
        string GetRolesForUserFlat(string username);
        IList<GuidLookupViewModel> GetRolesForUserManagement(string username);
    }
}
```

Create file in Middleware folder named `BrownbagRoleProvider.cs` with following content:

```Csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Brownbag.Data.Models;
using Brownbag.Web.Middleware;
using Brownbag.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Brownbag.Web.Middleware {
    public class BrownbagRoleProvider: IBrownbagRoleProvider {
        private readonly ApplicationDataContext db;

        public BrownbagRoleProvider (ApplicationDataContext context) {
            db = context;
        }

        public string[] GetRolesForUser(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                //db.Use
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r.Name;
                if (roles != null)
                    return roles.ToArray();
                else
                    return new string[] { };
            }
            return new string[] { };
        }
        public IList<GuidLookupViewModel> GetRolesForUserManagement(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r;
                if (roles != null)
                    return roles.Select(r => new GuidLookupViewModel { Value = r.Name, ID = r.Id }).ToList();
                else
                    return new List<GuidLookupViewModel>();
            }
            return new List<GuidLookupViewModel>();
        }
        public string GetRolesForUserFlat(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r.Name;
                if (roles != null)
                    return roles.ToString();
                else
                    return "";
            }
            return "";
        }

        public string[] GetUsersInRole(string roleName) {
            var roleID = db.Roles
                .Where(role => role.Name == roleName)
                .FirstOrDefault();

            var users = db.Users.Where(x => x.Roles.Where(a => a.RoleId.Equals(roleID.Id)).Any()).Select(x => x.UserFullName).ToArray();
            return users;
        }

        public bool IsUserInRole(string username, string roleName) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));

            var roles = from ur in user.Roles
            from r in db.Roles
            where ur.RoleId.Equals(r.Id)
            select r.Name;
            if (user != null)
                return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            else
                return false;
        }

        public Guid GetUserId(string username) {
            User user = db.Users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));

            if (user != null)
                return user.Id;
            else
                return Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
    }
}

```

Edit `Startup.cs` to look like:

```Csharp
using System;
using System.Security.Claims;
using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Middleware;
using Brownbag.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Brownbag.Web {
    public class Startup {
        public Startup (IHostingEnvironment env) {
            IConfigurationBuilder builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional : false, reloadOnChange : true);
            this.Configuration = builder.Build ();
        }
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();

            services.AddDbContext<ApplicationDataContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ApiDb")));
            services.AddIdentity<User, IdentityRole<Guid>> (options =>
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@/\\")
                .AddEntityFrameworkStores<ApplicationDataContext> ();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddMvc ()
                .AddJsonOptions (options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver ();
                });

            services.AddKendo ();
            services.AddScoped<IBrownbagRoleProvider, BrownbagRoleProvider> ();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper ();
            services.AddTransient<RolesAuthorizationMiddleware> ();

            services.AddAuthorization (options => {
                options.AddPolicy ("Admin",
                    policy => {
                        policy.RequireAuthenticatedUser ();
                        policy.RequireClaim (ClaimTypes.Role, "Admin");
                    });
            });
            services.Configure<IISOptions> (options => {
                options.AutomaticAuthentication = true;
            });
            services.AddAuthentication (IISDefaults.AuthenticationScheme);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.RolesAuthorization ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa (spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
#if DEBUG
                    spa.UseProxyToSpaDevelopmentServer ("http://localhost:4200");
#endif
#if INTEGRATED || RELEASE
                    spa.UseAngularCliServer (npmScript: "start");
#endif
                }
            });
            app.UseAuthentication ();
        }
    }
}
```

Edit `Program.cs` to look like:

```Csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Brownbag.Data.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Brownbag.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                // Retrieve your DbContext instance here
                var dbContext = scope.ServiceProvider.GetService<ApplicationDataContext>();

                // place your DB seeding code here
                /*
                NEED TO ADD BACK IN SEEDING METHOD!
                https://www.ryadel.com/en/buildwebhost-unable-to-create-an-object-of-type-applicationdbcontext-error-idesigntimedbcontextfactory-ef-core-2-fix/
                 */
                // DbSeeder.Seed(dbContext);
            }
            host.Run();

            // ref.: https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
#if DEBUG || INTEGRATED
            .UseHttpSys(options => {
                options.Authentication.Schemes =
                    AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
                options.Authentication.AllowAnonymous = false;
            })
#endif
            .UseStartup<Startup>()
            .Build();
    }
}

```

Create file in Controllers folder named `AccountController.cs` with following content:

```Csharp
using System;
using Brownbag.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Brownbag.Web.Middleware;

namespace Brownbag.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDataContext db;
        private readonly IBrownbagRoleProvider BrownbagRoleProvider;

        public AccountController(ApplicationDataContext context, IBrownbagRoleProvider rp)
        {
            db = context;
            BrownbagRoleProvider = rp;
        }
        public ActionResult Denied()
        {
            return View();
        }
        [Route("api/account/user")]
        public ActionResult GetRoles()
        {
            return Json(new { name = User.Identity.Name, roles = BrownbagRoleProvider.GetRolesForUser(User.Identity.Name) });
        }
    }
}
```


Create file in Controllers folder named `BlogController.cs` with following content:

```Csharp
using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Extensions;
using Brownbag.Web.Models;
using Brownbag.Web.Models.PrimeNG.Grid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Brownbag.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy="Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public BlogController(IMapper mapper, ApplicationDataContext appDbContext)
        {
            _mapper = mapper;
            _context = appDbContext;
        }

        // GET api/Admin/[controller]?{currentPage}&{rows}&{searchQuery}
        [HttpGet]
        public GridViewModel<BlogViewModel> Read(int currentPage, int rows, string searchQuery)
        {
            GridViewModel<BlogViewModel> vm = new GridViewModel<BlogViewModel>();

            try
            {
                int maxRows = rows == 0 ? 10 : rows;
                currentPage = currentPage == 0 ? 1 : currentPage;

                IQueryable<Blog> query = _context.Blogs.Include(x=>x.Posts);

                if (searchQuery != null)
                {
                    query = query.Where(
                        e => e.Url.CaseInsensitiveContains(searchQuery));
                    // Returns the search query to help maintain state
                    vm.SearchQuery = searchQuery;
                }
                double pageCount = (double)((decimal)query.Count() / Convert.ToDecimal(maxRows));
                vm.PageCount = (int)Math.Ceiling(pageCount);

                query = query
                        .OrderBy(item => item.Id).Skip((currentPage - 1) * maxRows)
                        .Take(maxRows);

                var mapped = _mapper.Map<BlogViewModel[]>(query);
                vm.Data = mapped;

                vm.Page = currentPage;
                vm.Rows = maxRows;

                return vm;
            }
            catch (Exception ex)
            {
                vm.Errors = ex.ToString();
                return vm;
            }

        }

        // GET api/Admin/[controller]/{id}
        [HttpGet("{id:int}")]
        public Blog Edit([FromRoute]int id)
        {
            /*
            We are NOT using automapper here even because we can just return the entity because
            it has no has virtual or irrelevant properties which should not be sent for no reason.
            If you look at OccupationalSpecialtyController it does the opposite
             */
            return _context.Blogs.Include(x => x.Posts).Where(y => y.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/Admin/[controller]
        [HttpPost()]
        public ActionResult Create([FromBody]Blog entity)
        {
            /*
            To follow Microsoft API Guidance Post method is left here. 
            However since our add and update methods are basically
            the same, to save a step they share a save and update 
            method. This method simply passes the data to the update
            method.
            Source: http://aka.ms/RestApiGuidance
             */
            return Update(entity);
        }

        // PUT api/Admin/[controller]
        [HttpPut()]
        public ActionResult Update([FromBody]Brownbag.Data.Models.Blog entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                /*
                EF Core 2.0+ Assumes if Id = 0 then you want to add.
                So we can effectively use the same method for create
                and update since leaving out the Id or explicitly 
                setting it to 0 will let EF know that its an add not
                update
                 */
                _context.Blogs.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
                return BadRequest(ModelState);
            }
            return Json(new[] { entity });
        }



    }
}
```

Create file in Controllers folder named `BlogViewController.cs` with following content:

```Csharp

using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Extensions;
using Brownbag.Web.Models;
using Brownbag.Web.Models.PrimeNG.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Brownbag.Web.Controllers
{
    [Route("api/[controller]")]
    public class BlogViewController : Controller
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public BlogViewController(IMapper mapper, ApplicationDataContext appDbContext)
        {
            _mapper = mapper;
            _context = appDbContext;
        }

        // GET api/Admin/[controller]?{currentPage}&{rows}&{searchQuery}
        [HttpGet]
        public GridViewModel<BlogPostsViewModel> Read(int currentPage, int rows, int blogId)
        {
            GridViewModel<BlogPostsViewModel> vm = new GridViewModel<BlogPostsViewModel>();

            try
            {
                int maxRows = rows == 0 ? 10 : rows;
                currentPage = currentPage == 0 ? 1 : currentPage;

                IQueryable<Post> query = _context.Posts.Include(y=> y.CreatedByUser).Include(z=>z.UpdatedByUser);

                if (blogId != 0)
                {
                    query = query.Where(
                        e => e.BlogId.Equals(blogId));
                    // Returns the search query to help maintain state
                    vm.SearchQuery = blogId.ToString();
                }
                double pageCount = (double)((decimal)query.Count() / Convert.ToDecimal(maxRows));
                vm.PageCount = (int)Math.Ceiling(pageCount);

                query = query
                        .OrderBy(item => item.Id).Skip((currentPage - 1) * maxRows)
                        .Take(maxRows);

                var mapped = _mapper.Map<BlogPostsViewModel[]>(query);
                vm.Data = mapped;

                vm.Page = currentPage;
                vm.Rows = maxRows;

                return vm;
            }
            catch (Exception ex)
            {
                vm.Errors = ex.ToString();
                return vm;
            }

        }

        // GET api/Admin/[controller]/{id}
        [HttpGet("{id:int}")]
        public Blog Edit([FromRoute]int id)
        {
            /*
            We are NOT using automapper here even because we can just return the entity because
            it has no has virtual or irrelevant properties which should not be sent for no reason.
            If you look at OccupationalSpecialtyController it does the opposite
             */
            return _context.Blogs.Include(x => x.Posts).Where(y => y.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/Admin/[controller]
        [HttpPost()]
        public ActionResult Create([FromBody]Blog entity)
        {
            /*
            To follow Microsoft API Guidance Post method is left here. 
            However since our add and update methods are basically
            the same, to save a step they share a save and update 
            method. This method simply passes the data to the update
            method.
            Source: http://aka.ms/RestApiGuidance
             */
            return Update(entity);
        }

        // PUT api/Admin/[controller]
        [HttpPut()]
        public ActionResult Update([FromBody]Brownbag.Data.Models.Blog entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                /*
                EF Core 2.0+ Assumes if Id = 0 then you want to add.
                So we can effectively use the same method for create
                and update since leaving out the Id or explicitly 
                setting it to 0 will let EF know that its an add not
                update
                 */
                _context.Blogs.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
                return BadRequest(ModelState);
            }
            return Json(new[] { entity });
        }



    }
}

```

Create file in Controllers folder named `LookupsController.cs` with following content:

```Csharp

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brownbag.Web.Controllers {

    [Route ("api/[controller]")]
    public class LookupsController : Controller {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;
        public LookupsController (IMapper mapper, ApplicationDataContext appDbContext) {
            _mapper = mapper;
            _context = appDbContext;
        }

        [HttpGet ("[action]")]
        public IEnumerable<LookupViewModel> Blogs () {
            return _context.Blogs.Select (blog => new LookupViewModel {
                ID = blog.Id,
                    Value = blog.Url
            });
        }

    }
}

```

Create file in Controllers folder named `PostController.cs` with following content:

```Csharp

using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Extensions;
using Brownbag.Web.Models;
using Brownbag.Web.Models.PrimeNG.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Brownbag.Web.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper, ApplicationDataContext appDbContext)
        {
            _mapper = mapper;
            _context = appDbContext;
        }

        // GET api/Admin/[controller]?{currentPage}&{rows}&{searchQuery}
        [HttpGet]
        public GridViewModel<PostViewModel> Read(int currentPage, int rows, string searchQuery)
        {
            GridViewModel<PostViewModel> vm = new GridViewModel<PostViewModel>();

            try
            {
                int maxRows = rows == 0 ? 10 : rows;
                currentPage = currentPage == 0 ? 1 : currentPage;

                IQueryable<Post> query = _context.Posts.Include(x=>x.Blog);

                if (searchQuery != null)
                {
                    query = query.Where(
                        e => e.Content.CaseInsensitiveContains(searchQuery) ||
                        e.Title.CaseInsensitiveContains(searchQuery) ||
                        e.Blog.Url.CaseInsensitiveContains(searchQuery)
                        );
                    // Returns the search query to help maintain state
                    vm.SearchQuery = searchQuery;
                }
                double pageCount = (double)((decimal)query.Count() / Convert.ToDecimal(maxRows));
                vm.PageCount = (int)Math.Ceiling(pageCount);

                query = query
                        .OrderBy(item => item.Id).Skip((currentPage - 1) * maxRows)
                        .Take(maxRows);

                var mapped = _mapper.Map<PostViewModel[]>(query);
                vm.Data = mapped;

                vm.Page = currentPage;
                vm.Rows = maxRows;

                return vm;
            }
            catch (Exception ex)
            {
                vm.Errors = ex.ToString();
                return vm;
            }

        }

        // GET api/Admin/[controller]/{id}
        [HttpGet("{id:int}")]
        public Post Edit([FromRoute]int id)
        {
            /*
            We are NOT using automapper here even because we can just return the entity because
            it has no has virtual or irrelevant properties which should not be sent for no reason.
            If you look at OccupationalSpecialtyController it does the opposite
             */
            return _context.Posts.Include(x => x.Blog).Where(y => y.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/Admin/[controller]
        [HttpPost()]
        public ActionResult Create([FromBody]Post entity)
        {
            /*
            To follow Microsoft API Guidance Post method is left here. 
            However since our add and update methods are basically
            the same, to save a step they share a save and update 
            method. This method simply passes the data to the update
            method.
            Source: http://aka.ms/RestApiGuidance
             */
            return Update(entity);
        }

        // PUT api/Admin/[controller]
        [HttpPut()]
        public ActionResult Update([FromBody]Brownbag.Data.Models.Post entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                /*
                EF Core 2.0+ Assumes if Id = 0 then you want to add.
                So we can effectively use the same method for create
                and update since leaving out the Id or explicitly 
                setting it to 0 will let EF know that its an add not
                update
                 */
                _context.Posts.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Generic Error", "Something went wrong, please contact administrator" + ex);
                return BadRequest(ModelState);
            }
            return Json(new[] { entity });
        }



    }
}

```

Create file in Extensions folder named `PostController.cs` with following content:

```Csharp

using System;

namespace Brownbag.Web.Extensions
{
    public static class SearchExtensions
    {
        public static bool CaseInsensitiveContains(this string text, string value)
        {
            if (text != null && value!= null)
            {
                return text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
            else
            {
                return false;
            }
        }
    }
}

```

## Lets configure VSCode

- create .vscode/settings.json and edit to look like:

```JSON
{
    "tslint.exclude": [
        "./Brownbag.Web/ClientApp/src/models/project.ts",
        "**/node_modules/**"
    ],
    "editor.codeActionsOnSave": {
        "source.organizeImports": true
    },
    "npm.enableScriptExplorer": true,
    "csharpfixformat.sort.usings.enabled": true,
}
```

- Open .vscode/launch.json and edit to look like:

```json
{
    // Use IntelliSense to find out which attributes exist for C# debugging
    // Use hover for the description of the existing attributes
    // For further information visit https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md
    "version": "0.2.0",
    "compounds": [
        {
            "name": ".Net and Browser",
            "configurations": [
                "Launch Chrome",
                ".NET Core Launch (web)"
            ]
        },
        {
            "name": ".Net and FF Browser",
            "configurations": [
                "Launch FF",
                ".NET Core Launch (web)"
            ]
        }
    ],
    "configurations": [
        {
            "name": ".NET Core Launch (web)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            // If you have changed target frameworks, make sure to update the program path.
            "program": "${workspaceFolder}/Brownbag.Web/bin/Debug/netcoreapp2.0/Brownbag.Web.dll",
            "args": [],
            "cwd": "${workspaceFolder}/Brownbag.Web",
            "stopAtEntry": false,
            "internalConsoleOptions": "openOnSessionStart",
            "env": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            },
            "sourceFileMap": {
                "/Views": "${workspaceFolder}/Views"
            }
        },
        {
            "name": ".NET Core Attach",
            "type": "coreclr",
            "request": "attach",
            "processId": "${command:pickProcess}"
        },
        {
            "type": "chrome",
            "request": "launch",
            "name": "Launch Chrome",
            "url": "http://localhost:5000",
            "webRoot": "${workspaceRoot}/wwwroot",
            "sourceMaps": true,
            "sourceMapPathOverrides": {
                "/Views": "${workspaceRoot}/Views",
            }
        },
        {
            "type": "firefox",
            "request": "launch",
            "name": "Launch FF",
            "url": "http://localhost:5000",
            "webRoot": "${workspaceRoot}/wwwroot",
            "sourceMaps": "client",
            "pathMappings": [
                {
                    "url": "webpack:///src/",
                    "path": "${workspaceRoot}/Brownbag.Web/ClientApp/src/"
                },
                {
                    "url": "webpack-internal:///./src/",
                    "path": "${workspaceRoot}/Brownbag.Web/ClientApp/src/"
                }
            ]
        }
    ]
}

```

- Open .vscode/task.json and edit to look like:

```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceRoot}/Brownbags.sln"
            ],
            "problemMatcher": "$msCompile"
        }    
    ]
}
```

## Building out Angular with Strong Typing

Earlier when setting up the project we installed and configured Reinforced Typings plugin.

In this section we will create ViewModels, AutoMapper Profiles, and Base services to assist in creating Angular components

## Creating our first ViewModel with AutoGen Typescript

This entire section will be inside the Brownbag.Web folder

Create file in Models folder named `PostViewModel.cs` with following content:

```Csharp
using Brownbag.Data.Models;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models {
    [TsInterface (AutoI = false)]
    public class PostViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
```

Create file in Models folder named `BlogViewModel.cs` with following content:

```Csharp
using System;
using Brownbag.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Brownbag.Web.Middleware;
using System.Collections.Generic;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface(AutoI = false)]
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }

    }
}
```

Create file in Models folder named `WeatherForecast.cs` with following content:

```Csharp
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface(AutoI=false)]
    public class WeatherForecast
    {
        public string DateFormatted { get; set; }   
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
```

Create file in Models folder named `BlogPostsViewModel.cs` with following content:

```Csharp
using System;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models {
    [TsInterface (AutoI = false)]
    public class BlogPostsViewModel : PostViewModel {
        public UsersViewModel CreatedByUser { get; set; }
        public UsersViewModel UpdatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
```

Create file in Models folder named `GuidLookupViewModel.cs` with following content:

```Csharp
using System;
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]    
    public class GuidLookupViewModel
    {
        public Guid ID { get; set; }
        public string Value { get; set; }
    }
}
```

Create file in Models folder named `LookupViewModel.cs` with following content:

```Csharp
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]
    public class LookupViewModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
```

Create file in Models folder named `UsersViewModel.cs` with following content:

```Csharp
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models
{
    [TsInterface (AutoI = false)]
    public class UsersViewModel
    {
        public string UserFullName { get; set; }
    }
}
```

Create file in Models folder named `PrimeNG/Grid/GridPaginator.cs` with following content:

```Csharp
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models.PrimeNG.Grid
{
    [TsInterface(AutoI=false)]
    public class GridPaginator
    {
        ///<summary>
        /// First Item in PrimeNG Grid Data
        ///</summary>
        public int First { get; set; }
        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int Page { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
        ///<summary>
        /// Gets or sets Rows
        ///</summary>
        public int Rows { get; set; }
    }
}
```

Create file in Models folder named `PrimeNG/Grid/GridViewModel.cs` with following content:

```Csharp
using Reinforced.Typings.Attributes;

namespace Brownbag.Web.Models.PrimeNG.Grid
{
    [TsInterface(AutoI=false)]
    public class GridViewModel<T> : GridPaginator
    {
        ///<summary>
        /// Generic Data responce holder for PrimeNG Grid Data
        ///</summary>
        public T[] Data { get; set; }
        ///<summary>
        /// Generic Error responce holder for PrimeNG Grid Data
        ///</summary>
        public string Errors { get; set; }
        ///<summary>
        /// Passes back the search query
        ///</summary>
        public string SearchQuery { get; set; }
    }
}
```

Create file in Automapper folder named `BrownbagMappingProfile.cs` with following content:

```Csharp
using Brownbag.Data.Models;
using Brownbag.Web.Models;

namespace Brownbag.Web.Automapper
{
    public class BrownbagMappingProfile : AutoMapper.Profile
    {
        public BrownbagMappingProfile()
        {
            CreateMap<Blog, BlogViewModel>()
           .ReverseMap();
            CreateMap<Post, PostViewModel>()
           .ReverseMap();
           CreateMap<Post, BlogPostsViewModel>();
        }
    }
}
```

## Lets add our initial migration for Entity Framework

- Open `Brownbag.Web/appsettings.Development.json` and update to look like this so EF knows what DB to connect to:

```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ConnectionStrings": {
    "ApiDb": "Server=Localhost;Database=Brownbag;Trusted_Connection=True"
  }
}

```

Press Ctrl+` to toggle the terminal window inside VSCode

```powershell
cd Brownbag.Data
dotnet ef --startup-project ../Brownbag.Web migrations add InitialMigration
dotnet ef --startup-project ../Brownbag.Web database update
```

## Open SQL Management Studio and create yourself a user, role (Admin) and update your usersrole table

## Launch

- Open the NPM Scripts section and right click `start` then click `run`

![Run NPM Scripts Image](Assets\NPMScripts.png)

- Lets launch the application. Go to Debug tab (4th tab in vscode) and choose `.Net and FF Browser` profile then click green button to start

## Lets fix the fetch data component

- Open `ClientApp/src/app/fetch-data/fetch-data.component.ts`: lets use the new ViewModels:
- **Notice we removed the WeatherForecast interface and replaced it with our new autogenerated one**

```typescript
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Brownbag.Web.Models.WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Brownbag.Web.Models.WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

```

- Open `ClientApp/src/app/fetch-data/fetch-data.component.html` and notice that line 18-21 has red intellisence saying the properties don't exist. This is because we updated casing thats JSON is produced by Newtonsoft so it follows the ViewModel casing. We need to capatialize all of the Variables to fix the error and match our new ViewModels:

```HTML
<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from the server.</p>

<p *ngIf="!forecasts"><em>Loading...</em></p>

<table class='table' *ngIf="forecasts">
  <thead>
    <tr>
      <th>Date</th>
      <th>Temp. (C)</th>
      <th>Temp. (F)</th>
      <th>Summary</th>
    </tr>
  </thead>
  <tbody>
    <tr *ngFor="let forecast of forecasts">
      <td>{{ forecast.DateFormatted }}</td>
      <td>{{ forecast.TemperatureC }}</td>
      <td>{{ forecast.TemperatureF }}</td>
      <td>{{ forecast.Summary }}</td>
    </tr>
  </tbody>
</table>
```

## Lets build out Grid Services and Helper Classes Without Kendo

Create file in `Brownbag.Web/ClientApp/src/shared/service` folder named `base.service.ts` with following content:

```TS
import { HttpErrorResponse } from '@angular/common/http/src/response';
import { Observable } from 'rxjs/Observable';

export abstract class BaseService {

    constructor() {    }

    protected handleError(error: HttpErrorResponse) {

        const applicationError = error.error;
        let errorMessage = '';
        if (error.status === 401) {
            errorMessage = 'Your Login token has expired. Please reload the page. All changes will be lost\n';
            return Observable.throw(errorMessage);
        }
        if (error.status === 403) {
            errorMessage = 'You are not authorized to access that data\n';
            return Observable.throw(errorMessage);
        }
        // tslint:disable-next-line:forin
        for (const e in applicationError) {
            errorMessage += e + ': ' + applicationError[e] + '\n';
        }
        // either applicationError in header or model error in body
        if (errorMessage) {
            return Observable.throw(errorMessage);
        }

        let modelStateErrors = '';
        const serverError = error.error;

        if (!serverError.type) {
            for (const key in serverError) {
                if (serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return Observable.throw(errorMessage || 'Server error');
    }
}
```

Create file in `Brownbag.Web/ClientApp/src/shared/service` folder named `grid-base-rest.service.ts` with following content:

```TS
import { BaseService } from './base.service';
// import { ConfigService } from '../utils/config.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';


@Injectable()
export abstract class GridRestCallsBaseService extends BaseService {

    baseUrl = '';
    endpoint = '';

    constructor(public http: HttpClient) {
        super();
    }
    getGrid<T>(page: number, rows: number, searchQuery: string, optionalHttpParams?: { param: string, value: string }[]): Observable<T> {
        // All grids will have paging and row count so we check them and set defaults
        const pageNumber = page ? page.toString() : '0';
        const rowNumber = rows ? rows.toString() : '10';
        let myParams = new HttpParams();

        // Append the page and row counts
        myParams = myParams.append('currentPage', pageNumber);
        myParams = myParams.append('rows', rowNumber);

        // Check if a search query is being performed and apped it
        if (searchQuery) {
            myParams = myParams.append('searchQuery', searchQuery);
        }

        // This allows for additional overrides for one off grid implementations
        if (optionalHttpParams) {
            optionalHttpParams.forEach(param => {
                myParams = myParams.append(param.param, param.value);
            });
        }
        return this.http.get<T>((this.baseUrl + this.endpoint), { params: myParams })
            .catch(this.handleError);
    }
    getGridItemDetails<T>(id: string): Observable<T> {
        return this.http.get<T>((this.baseUrl + this.endpoint + id))
            .catch(this.handleError);
    }
    updateGridItem<T>(entity: T) {
        return this.http.put(this.baseUrl + this.endpoint, entity)
            .catch(this.handleError);
    }
}

```

Create file in `Brownbag.Web/ClientApp/src/shared/service` folder named `grid-component-base.service.ts` with following content:

```TS
import { AdvGrowlService } from 'primeng-advanced-growl';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import { GridRestCallsBaseService } from './grid-base-rest.service';

export abstract class GridComponentBaseService<T> {
    public state: Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>;
    public displayDialog: boolean;
    public selectedGridItem: T;
    public isNew: boolean;
    public editErrors: string;
    public searchQueryDebouncer: Subject<string> = new Subject<string>();

    // These are the default titles used if you do not override them in implementation
    public entityTitleSingular = 'Generic Entity';
    public entityTitlePlural = 'Generic Entities';
    /*
    This constructor expects a service handed to it which knows about the correct endpoints
    to communicate with. For examples look at the admin folder as all services in there
    are setup to use this grid base class correctly.
    */
    constructor(public gridService: GridRestCallsBaseService, public notificationsService: AdvGrowlService) {
        /*
        How to debounce search queries in angular without touch @angular/forms
        https://stackoverflow.com/a/40777621
        This SearchQueryDebouncer doesnt fire off search queries until after 500ms
        this helps reduce database load. It is not important for local but will be
        once we move to server client setup. This does NOT however deal with problems
        related to a query which was fired first returning second and overwriting the
        results of the correct (second) query.
        */
        this.searchQueryDebouncer
            .debounceTime(500) // wait 500ms after the last event before emitting last event
            .distinctUntilChanged() // only emit if value is different from previous value
            .subscribe(model => {
                this.state.SearchQuery = model;
                this.globalSearch(model);
            });
        /*
        This creates empty objects to prevent errors,
        this also adds intellisense to HTML templates
        since baseclass uses ANY as the type and we
        want strong typing
        */
        this.state = <Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>>{};
    }
    showDialogToAdd() {
        this.editErrors = undefined;
        this.isNew = true;
        this.selectedGridItem = <T>{};
        this.displayDialog = true;
    }
    paginate(event: GridPaginatorEvent) {
        this.state.Page = event.page + 1;
        this.state.Rows = event.rows;
        this.getGridData();
    }
    onRowSelect(event: any) {
        this.isNew = false;
        this.editErrors = undefined;
        this.selectedGridItem = this.clone(event.data);
        // Below check is to see if the data has already been fetched in previous
        // Call, if already in the selectd plan no need to refetch data
        this.gridService.getGridItemDetails<T>((<any>this.selectedGridItem).Id)
            .subscribe(
                result => {
                    if (result != null) {
                        this.selectedGridItem = result;
                        this.displayDialog = true;
                    }
                },
                error => {
                    this.state.Errors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }
    getGridData(optionalHttpParams?: { param: string, value: string }[]) {
        // tslint:disable-next-line:max-line-length
        this.gridService.getGrid<Brownbag.Web.Models.PrimeNG.Grid.GridViewModel<T>>(this.state.Page || undefined, this.state.Rows || undefined, this.state.SearchQuery || undefined, optionalHttpParams || undefined)
            .subscribe(
                result => {
                    if (result != null) {
                        this.state = result;
                    }
                },
                error => {
                    this.state.Errors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }
    searchDebouncer(text: string) {
        this.searchQueryDebouncer.next(text);
    }
    globalSearch(event: string) {
        if (event) {
            this.state.SearchQuery = event;
        }
        this.state.Page = undefined;
        this.state.Rows = undefined;
        this.state.First = undefined;
        this.state.PageCount = undefined;
        this.getGridData();
    }
    /*
    This clone method does NOT work for > single dimensional objects
    If you find you need a multi-dimensional clone please override it
    in your implemented class not this base class;
    */
    clone(e: T): T {
        const entity = <T>{};
        // tslint:disable-next-line:forin
        for (const prop in e) {
            if ((<any>prop) instanceof Object) {
                entity[<any>prop] = this.clone(<any>prop);
            }
            entity[prop] = e[prop];
        }
        return entity;
    }
    /*
    This method assumes that you use the EXACT same name attribute in
    the edit/add form as you do in the database. If you follow this
    assumption then just submitting the form data allows for basic CRUD
    without need to create a new object to send
    */
    save(formData: T) {
        this.editErrors = undefined;
        this.gridService.updateGridItem<T>(formData)
            .subscribe(
                result => {
                    if (result != null && !this.editErrors) {
                        this.displayDialog = false;
                        this.selectedGridItem = undefined;
                        this.editErrors = undefined;
                        this.notificationsService.createSuccessMessage('Save Successful', '');
                        this.getGridData();
                    }
                },
                error => {
                    this.editErrors = error;
                    this.notificationsService.createTimedErrorMessage(error, 'Error!', 0);
                });
    }

    close() {
        this.selectedGridItem = <T>{};
        this.displayDialog = false;
        this.getGridData();
    }

}
export interface GridPaginatorEvent {
    first: number;
    rows: number;
    page: number;
    pageCount: number;
}

```

Create file in `Brownbag.Web/ClientApp/src/shared/service` folder named `lookups.service.ts` with following content:

```TS

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class LookupsService {

    baseUrl = '/api/Lookups';

    constructor(private http: HttpClient) {
    }
    getBlogs() {
        return this.http.get<Brownbag.Web.Models.LookupViewModel[]>(this.baseUrl + '/Blogs');
    }
}

```

## Lets build out Our Blog and Posts editor along with services to provide data

Create file in `Brownbag.Web/ClientApp/src/app/blog` folder named `blog.service.ts` with following content:

```TS

import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BlogService extends GridRestCallsBaseService {
    constructor(http: HttpClient) {
        super(http);
        this.baseUrl = '/api';
        this.endpoint = '/Blog/';
    }
}


```

Create file in `Brownbag.Web/ClientApp/src/app/blog` folder named `blog.component.ts` with following content:

```TS

import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { BlogService } from './blog.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent extends GridComponentBaseService<Brownbag.Web.Models.BlogViewModel> implements OnInit {
  public PostsCols: any[];
  constructor(gridService: BlogService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Blog';
    this.entityTitlePlural = 'Blogs';
    this.PostsCols = [
      { field: 'Title', header: 'Title' },
      { field: 'Content', header: 'Content' },
  ];

  }
  ngOnInit() {
    this.getGridData();
    this.notificationsService.createSuccessMessage('Init Success', 'Blog Component');
  }
}



```

Create file in `Brownbag.Web/ClientApp/src/app/blog` folder named `blog.component.html` with following content:

```HTML

<h2>{{entityTitlePlural}}</h2>
<div *ngIf="state.Errors" class="alert alert-danger" role="alert">
  <strong>Oops!</strong>
  <pre>{{state.Errors}}</pre>
</div>
<div class="row">
  <div class="col-12">
    <p-table #dt [value]="state.Data" [rows]="state.Rows" selectionMode="single" [(selection)]="selectedGridItem" (onRowSelect)="onRowSelect($event)">
      <ng-template pTemplate="caption">
        <div style="text-align: right">
          <button type="button" style="text-align:left" class="pull-left" (click)="showDialogToAdd()" label="Add">
            <i class="fa fa-plus"></i> Add {{entityTitleSingular}}</button>
          <i class="fa fa-search" style="margin:4px 4px 0 0"></i>
          <input type="text" pInputText size="50" placeholder="Global Filter" [ngModel]='state.SearchQuery' (ngModelChange)="searchDebouncer($event)"
            style="width:auto">
        </div>
      </ng-template>
      <ng-template pTemplate="header">
        <tr>
          <th>Id</th>
          <th>Url</th>
          <th>Rating</th>
        </tr>
      </ng-template>
      <ng-template pTemplate="body" let-selectedGridItem>
        <tr [pSelectableRow]="selectedGridItem">
          <td>{{selectedGridItem.Id}}</td>
          <td>{{selectedGridItem.Url}}</td>
          <td>
            <p-rating cancel="false" stars="10" readonly="true" [(ngModel)]="selectedGridItem.Rating"></p-rating>
          </td>
        </tr>
      </ng-template>

    </p-table>
    <p-paginator rows="10" [totalRecords]="state.PageCount * state.Rows" (onPageChange)="paginate($event)" [rowsPerPageOptions]="[10,20,30,40,50]"></p-paginator>

  </div>
</div>
<p-dialog header="{{isNew ? 'Add':'Edit'}} {{entityTitleSingular}}" [(visible)]="displayDialog" *ngIf="selectedGridItem"
  [responsive]="true" showEffect="fade" [modal]="true" [width]="500">
  <div *ngIf="editErrors" class="alert alert-danger" role="alert">
    <strong>Oops!</strong>
    <pre>{{editErrors}}</pre>
  </div>
  <form #formEdit="ngForm" (ngSubmit)="save(formEdit.value)">
    <div class="ui-g ui-fluid" *ngIf="selectedGridItem">
      <div class="ui-g-12">
        <div class="ui-g-4">
          Id
        </div>
        <div class="ui-g-8">
          <input type="text" size="50" name="Id" class="form-control" readonly [ngModel]="selectedGridItem.Id">
        </div>
      </div>
      <div class="ui-g-12">
        <div class="ui-g-4">
          Url*
        </div>
        <div class="ui-g-8">
          <input type="text" size="50" name="Url" class="form-control" required [ngModel]="selectedGridItem.Url">
        </div>
      </div>
      <div class="ui-g-12">
        <div class="ui-g-4">
          Rating*
        </div>
        <div class="ui-g-8">
          <p-rating name="Rating" stars="10" [(ngModel)]="selectedGridItem.Rating"></p-rating>
        </div>
      </div>
    </div>
    <h4>Associated Blog Posts</h4>
    <p-table [columns]="PostsCols" [value]="selectedGridItem.Posts" [paginator]="true" [rows]="5">
      <ng-template pTemplate="header" let-columns>
        <tr>
          <th *ngFor="let col of columns">
            {{col.header}}
          </th>
        </tr>
      </ng-template>
      <ng-template pTemplate="body" let-rowData let-columns="columns">
        <tr>
          <td *ngFor="let col of columns">
            <div [innerHTML]="rowData[col.field]"></div>

          </td>
        </tr>
      </ng-template>
    </p-table>
    <p-footer *ngIf="selectedGridItem">
      <div class="ui-dialog-buttonpane ui-helper-clearfix">
        <button type="submit" [disabled]="!formEdit.form.valid" required class="btn btn-primary">
          <span [ngClass]="isNew ? 'fa fa-plus' : 'fa fa-save'"></span> {{isNew ? 'Add ' + entityTitleSingular: 'Save ' + entityTitleSingular}}
        </button>
        <button type="button" class="btn btn-danger" (click)="close()">
          <span class="fa fa-close"></span> Close
        </button>

      </div>

    </p-footer>
  </form>
</p-dialog>


```

Create an empty file in `Brownbag.Web/ClientApp/src/app/blog-view` folder named `blog.component.css`

Create file in `Brownbag.Web/ClientApp/src/app/blog` folder named `blog-view.service.ts` with following content:

```TS

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

@Injectable()
export class BlogViewService extends GridRestCallsBaseService {
    constructor(http: HttpClient) {
        super(http);
        this.baseUrl = '/api';
        this.endpoint = '/BlogView/';
    }
}



```

Create file in `Brownbag.Web/ClientApp/src/app/blog-view` folder named `blog-view.component.ts` with following content:

```TS

import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { BlogViewService } from './blog-view.service';

@Component({
  selector: 'app-blog-view',
  templateUrl: './blog-view.component.html',
  styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent extends GridComponentBaseService<Brownbag.Web.Models.BlogPostsViewModel> implements OnInit {
  public BlogLookups: Brownbag.Web.Models.LookupViewModel[];
  public CurrentBlogId = 1;
  constructor(private lookupsService: LookupsService, gridService: BlogViewService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Blog View';
    this.entityTitlePlural = 'Blogs Content';
  }
  initilizeLookups() {
    this.lookupsService.getBlogs().subscribe(
      result => {
        if (result != null) {
          this.BlogLookups = result;
          this.getGridData();
        }
      });
  }

  getGridData() {
    super.getGridData([{ param: 'blogId', value: this.CurrentBlogId.toString() }]);
  }
  ngOnInit() {
    this.initilizeLookups();
    this.notificationsService.createSuccessMessage('Init Success', 'Blog View Component');
  }
}




```

Create file in `Brownbag.Web/ClientApp/src/app/blog-view` folder named `blog-view.component.html` with following content:

```HTML

<h2>{{entityTitlePlural}}</h2>
<div *ngIf="state.Errors" class="alert alert-danger" role="alert">
  <strong>Oops!</strong>
  <pre>{{state.Errors}}</pre>
</div>
<div class="row">
  <div class="col-12">
    <div class="ui-g-3">
      Current Blog
    </div>
    <div class="ui-g-9">
      <select class="form-control" name="CurrentBlogId" required [(ngModel)]="CurrentBlogId" (change)="getGridData()">
        <option *ngFor="let item of BlogLookups" [value]="item.ID">{{item.Value}}</option>
      </select>
    </div>
  </div>
</div>
<div class="row">
  <div class="col-12">
    <p-dataGrid [value]="state.Data" [rows]="state.Rows">
      <ng-template let-car pTemplate="item">
        <div class="ui-g-12">
          <p-card [header]="car.Title" [subheader]="'Written by: '+ car?.CreatedByUser?.UserFullName">
            <div class="ui-card-subtitle"> {{car?.CreatedDate | date:'short'}}</div>
            <div class="ui-card-content" [innerHTML]="car.Content"></div>
            <p-footer *ngIf="car?.UpdatedByUser?.UserFullName !== car?.CreatedByUser?.UserFullName">
              Updated by: {{car?.UpdatedByUser?.UserFullName}} on {{car?.UpdatedDate | date:'short'}}
            </p-footer>
          </p-card>
        </div>
      </ng-template>
    </p-dataGrid>
    <p-paginator rows="10" [totalRecords]="state.PageCount * state.Rows" (onPageChange)="paginate($event)" [rowsPerPageOptions]="[10,20,30,40,50]"></p-paginator>
  </div>
</div>



```

Create an empty file in `Brownbag.Web/ClientApp/src/app/blog-view` folder named `blog-view.component.css`

Create file in `Brownbag.Web/ClientApp/src/app/post` folder named `post.service.ts` with following content:

```TS

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GridRestCallsBaseService } from '../../shared/service/grid-base-rest.service';

@Injectable()
export class PostService extends GridRestCallsBaseService {
    constructor(http: HttpClient) {
        super(http);
        this.baseUrl = '/api';
        this.endpoint = '/Post/';
    }
}

```

Create file in `Brownbag.Web/ClientApp/src/app/post` folder named `post.component.ts` with following content:

```TS

import { Component, OnInit } from '@angular/core';
import { AdvGrowlService } from 'primeng-advanced-growl';
import { GridComponentBaseService } from '../../shared/service/grid-component-base.service';
import { LookupsService } from '../../shared/service/lookups.service';
import { PostService } from './post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent extends GridComponentBaseService<Brownbag.Web.Models.PostViewModel> implements OnInit {
  public BlogLookups: Brownbag.Web.Models.LookupViewModel[];

  constructor(private lookupsService: LookupsService, gridService: PostService, notificationsService: AdvGrowlService) {

    /*
    Calls base service which does all CRUD for a generic
    Grid. Any functions can be overridden as needed.
    */
    super(gridService, notificationsService);

    // This Overrides the Title used on the Grid
    this.entityTitleSingular = 'Post';
    this.entityTitlePlural = 'Posts';

  }
  initilizeLookups() {
    this.lookupsService.getBlogs().subscribe(
      result => {
        if (result != null) {
          this.BlogLookups = result;
        }
      });
  }
  ngOnInit() {
    this.getGridData();
    this.initilizeLookups();
    this.notificationsService.createSuccessMessage('Init Success', 'Post Component');
  }
}


```

Create file in `Brownbag.Web/ClientApp/src/app/post` folder named `post.component.html` with following content:

```HTML

<h2>{{entityTitlePlural}}</h2>
<div *ngIf="state.Errors" class="alert alert-danger" role="alert">
  <strong>Oops!</strong>
  <pre>{{state.Errors}}</pre>
</div>
<div class="row">
  <div class="col-12">
    <p-table #dt [value]="state.Data" [rows]="state.Rows" selectionMode="single" [(selection)]="selectedGridItem" (onRowSelect)="onRowSelect($event)">
      <ng-template pTemplate="caption">
        <div style="text-align: right">
          <button type="button" style="text-align:left" class="pull-left" (click)="showDialogToAdd()" label="Add">
            <i class="fa fa-plus"></i> Add {{entityTitleSingular}}</button>
          <i class="fa fa-search" style="margin:4px 4px 0 0"></i>
          <input type="text" pInputText size="50" placeholder="Global Filter" [ngModel]='state.SearchQuery' (ngModelChange)="searchDebouncer($event)"
            style="width:auto">
        </div>
      </ng-template>
      <ng-template pTemplate="header">
        <tr>
          <th>Id</th>
          <th>Title</th>
          <th>Content</th>
          <th>Associated Blog</th>
        </tr>
      </ng-template>
      <ng-template pTemplate="body" let-selectedGridItem>
        <tr [pSelectableRow]="selectedGridItem">
          <td>{{selectedGridItem.Id}}</td>
          <td>{{selectedGridItem.Title}}</td>
          <td [innerHTML]="selectedGridItem.Content"></td>
          <td>{{selectedGridItem.Blog.Url}}</td>
        </tr>
      </ng-template>

    </p-table>
    <p-paginator rows="10" [totalRecords]="state.PageCount * state.Rows" (onPageChange)="paginate($event)" [rowsPerPageOptions]="[10,20,30,40,50]"></p-paginator>

  </div>
</div>
<p-dialog header="{{isNew ? 'Add':'Edit'}} {{entityTitleSingular}}" [(visible)]="displayDialog" *ngIf="selectedGridItem"
  [responsive]="true" showEffect="fade" [modal]="true" [width]="500">
  <div *ngIf="editErrors" class="alert alert-danger" role="alert">
    <strong>Oops!</strong>
    <pre>{{editErrors}}</pre>
  </div>
  <form #formEdit="ngForm" (ngSubmit)="save(formEdit.value)">
    <div class="ui-g ui-fluid" *ngIf="selectedGridItem">
      <div class="ui-g-12">
        <div class="ui-g-4">
          Id
        </div>
        <div class="ui-g-8">
          <input type="text" size="50" name="Id" class="form-control" readonly [ngModel]="selectedGridItem.Id">
        </div>
      </div>
      <div class="ui-g-12">
        <div class="ui-g-4">
          Title*
        </div>
        <div class="ui-g-8">
          <input type="text" size="50" name="Title" class="form-control" required [ngModel]="selectedGridItem.Title">
        </div>
      </div>
      <div class="ui-g-12">
        <div class="ui-g-4">
          Content*
        </div>
        <div class="ui-g-8">
          <p-editor name="Content" [(ngModel)]="selectedGridItem.Content" [style]="{'height':'320px'}">
          </p-editor>
          <!-- <textarea [rows]="5" [cols]="30" pInputTextarea class="form-control" name="Content" [(ngModel)]="selectedGridItem.Content" autoResize="autoResize"></textarea> -->
        </div>
      </div>

      <div class="ui-g-12">
        <div class="ui-g-4">
          Blog
        </div>
        <div class="ui-g-8">
          <select class="form-control" name="BlogId" required [(ngModel)]="selectedGridItem.BlogId">
            <option *ngFor="let item of BlogLookups" [value]="item.ID">{{item.Value}}</option>
          </select>
        </div>
      </div>
    </div>


    <p-footer *ngIf="selectedGridItem">
      <div class="ui-dialog-buttonpane ui-helper-clearfix">
        <button type="submit" [disabled]="!formEdit.form.valid" required class="btn btn-primary">
          <span [ngClass]="isNew ? 'fa fa-plus' : 'fa fa-save'"></span> {{isNew ? 'Add ' + entityTitleSingular: 'Save ' + entityTitleSingular}}
        </button>
        <button type="button" class="btn btn-danger" (click)="close()">
          <span class="fa fa-close"></span> Close
        </button>

      </div>

    </p-footer>
  </form>
</p-dialog>




```

Create an empty file in `Brownbag.Web/ClientApp/src/app/post` folder named `post.component.css`


Edit file in `Brownbag.Web/ClientApp/src/app/` folder named `app.module.ts`

```TS

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AdvGrowlModule } from 'primeng-advanced-growl';
import { CardModule } from 'primeng/card';
import { DataGridModule } from 'primeng/datagrid';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { PaginatorModule } from 'primeng/paginator';
import { RatingModule } from 'primeng/rating';
import { TableModule } from 'primeng/table';
import { LookupsService } from '../shared/service/lookups.service';
import { AppComponent } from './app.component';
import { BlogViewComponent } from './blog-view/blog-view.component';
import { BlogViewService } from './blog-view/blog-view.service';
import { BlogComponent } from './blog/blog.component';
import { BlogService } from './blog/blog.service';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PostComponent } from './post/post.component';
import { PostService } from './post/post.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BlogComponent,
    PostComponent,
    BlogViewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DropdownModule,
    TableModule,
    DialogModule,
    PaginatorModule,
    InputTextareaModule,
    RatingModule,
    EditorModule,
    DataGridModule,
    CardModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'blog', component: BlogComponent },
      { path: 'post', component: PostComponent },
      { path: 'blogview', component: BlogViewComponent },
    ]),
    AdvGrowlModule
  ],
  providers: [BlogService, BlogViewService, PostService, LookupsService],
  bootstrap: [AppComponent]
})
export class AppModule { }


```

Edit file in `Brownbag.Web/ClientApp/src/app/` folder named `app.component.html`

```HTML

<adv-growl [life]="3000" freezeMessagesOnHover="true"></adv-growl>
<div class='container-fluid'>
  <div class='row'>
    <div class='col-sm-3'>
      <app-nav-menu></app-nav-menu>
    </div>
    <div class='col-sm-9 body-content'>
      <router-outlet></router-outlet>
    </div>
  </div>
</div>

```

Edit file in `Brownbag.Web/ClientApp/src/app/` folder named `app.component.css`

```CSS

@media (max-width: 767px) {
  /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */
  .body-content {
    padding-top: 50px;
  }
}
.ui-growl {
  z-index:99999!important;
}

```

Edit file in `Brownbag.Web/ClientApp/src/app/nav-menu` folder named `nav-menu.component.html`

```HTML

<div class='main-nav'>
    <div class='navbar navbar-inverse'>
        <div class='navbar-header'>
            <button type='button' class='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse' [attr.aria-expanded]='isExpanded' (click)='toggle()'>
                <span class='sr-only'>Toggle navigation</span>
                <span class='icon-bar'></span>
                <span class='icon-bar'></span>
                <span class='icon-bar'></span>
            </button>
            <a class='navbar-brand' [routerLink]='["/"]'>Brownbag.Web</a>
        </div>
        <div class='clearfix'></div>
        <div class='navbar-collapse collapse' [ngClass]='{ "in": isExpanded }'>
            <ul class='nav navbar-nav'>
                <li [routerLinkActive]='["link-active"]' [routerLinkActiveOptions]='{ exact: true }'>
                    <a [routerLink]='["/"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-home'></span> Home
                    </a>
                </li>
                <li [routerLinkActive]='["link-active"]'>
                    <a [routerLink]='["/counter"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-education'></span> Counter
                    </a>
                </li>
                <li [routerLinkActive]='["link-active"]'>
                    <a [routerLink]='["/fetch-data"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-th-list'></span> Fetch data
                    </a>
                </li>
                <li [routerLinkActive]='["link-active"]'>
                    <a [routerLink]='["/blog"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-th-list'></span> Blog
                    </a>
                </li>
                <li [routerLinkActive]='["link-active"]'>
                    <a [routerLink]='["/post"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-th-list'></span> Post
                    </a>
                </li>
                <li [routerLinkActive]='["link-active"]'>
                    <a [routerLink]='["/blogview"]' (click)='collapse()'>
                        <span class='glyphicon glyphicon-th-list'></span> Blog View
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>


```

Edit file in `Brownbag.Web/ClientApp/src/` folder named `style.css`

```CSS

/* You can add global styles to this file, and also import other style files */
@import 'primeng/resources/themes/omega/theme.css';
@import 'primeng/resources/primeng.min.css';
@import 'font-awesome/css/font-awesome.css';
@import 'quill/dist/quill.core.css';
@import 'quill/dist/quill.snow.css';

```

Edit file in `Brownbag.Web/ClientApp/` folder named `.angular-cli.json`

```JSON

{
  "$schema": "./node_modules/@angular/cli/lib/config/schema.json",
  "project": {
    "name": "Brownbag.Web"
  },
  "apps": [
    {
      "root": "src",
      "outDir": "dist",
      "assets": [
        "assets"
      ],
      "index": "index.html",
      "main": "main.ts",
      "polyfills": "polyfills.ts",
      "test": "test.ts",
      "tsconfig": "tsconfig.app.json",
      "testTsconfig": "tsconfig.spec.json",
      "prefix": "app",
      "styles": [
        "styles.css",
        "../node_modules/bootstrap/dist/css/bootstrap.min.css"
      ],
      "scripts": ["../node_modules/quill/dist/quill.js"],
      "environmentSource": "environments/environment.ts",
      "environments": {
        "dev": "environments/environment.ts",
        "prod": "environments/environment.prod.ts"
      } 
    }
  ],
  "e2e": {
    "protractor": {
      "config": "./protractor.conf.js"
    }
  },
  "lint": [
    {
      "project": "src/tsconfig.app.json",
      "exclude": "**/node_modules/**"
    },
    {
      "project": "src/tsconfig.spec.json",
      "exclude": "**/node_modules/**"
    },
    {
      "project": "e2e/tsconfig.e2e.json",
      "exclude": "**/node_modules/**"
    }
  ],
  "test": {
    "karma": {
      "config": "./karma.conf.js"
    }
  },
  "defaults": {
    "styleExt": "css",
    "component": {},
    "build": {
      "progress": true
    }
  }
}


```
