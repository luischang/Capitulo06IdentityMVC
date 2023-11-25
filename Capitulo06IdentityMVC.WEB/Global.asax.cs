using Capitulo06IdentityMVC.CORE.Repository;
using Capitulo06IdentityMVC.WEB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Capitulo06IdentityMVC.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region Roles
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            // Crear roles en caso no existen
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Marketing"))
                roleManager.Create(new IdentityRole("Marketing"));

            if (!roleManager.RoleExists("Finanzas"))
                roleManager.Create(new IdentityRole("Finanzas"));

            #endregion

            #region Dependencias

            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            var connectionString = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;

            container.Register<IDbConnection>(() => new SqlConnection(connectionString), Lifestyle.Scoped);
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>
                (container.GetInstance<ApplicationDbContext>()), Lifestyle.Singleton);
            //Registro del repositorio
            container.Register<ICustomerRepository>
                (() => new CustomerRepository(container.GetInstance<IDbConnection>()));

            container.Register<IAuthenticationManager>
                (() => HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Singleton);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Register<ApplicationUserManager>(Lifestyle.Singleton);
            container.Register<ApplicationSignInManager>(Lifestyle.Singleton);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            #endregion
        }
    }
}
