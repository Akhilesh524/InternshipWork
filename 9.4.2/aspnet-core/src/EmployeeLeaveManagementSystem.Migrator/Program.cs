using System;
using Castle.Facilities.Logging;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Collections.Extensions;
using Abp.Dependency;
using EmployeeLeaveManagementSystem.Authorization; // ✅ Add this
using System.Threading.Tasks;
using EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed;

namespace EmployeeLeaveManagementSystem.Migrator
{
    public class Program
    {
        private static bool _quietMode;

        public static void Main(string[] args)
        {
            ParseArgs(args);

            using (var bootstrapper = AbpBootstrapper.Create<EmployeeLeaveManagementSystemMigratorModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(
                        f => f.UseAbpLog4Net().WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
                {
                    var migrationSucceeded = migrateExecuter.Object.Run(_quietMode);

                    if (migrationSucceeded)
                    {
                        // ✅ Run your Role Seeder after DB migrations
                        using (var scope = bootstrapper.IocManager.CreateScope())
                        {
                            var roleSeeder = scope.Resolve<RolesDataSeeder>();
                            roleSeeder.SeedAsync().GetAwaiter().GetResult(); // sync call in console app
                        }
                        Console.WriteLine("✅ Roles seeded successfully.");
                    }

                    if (_quietMode)
                    {
                        Environment.Exit(migrationSucceeded ? 0 : 1);
                    }
                    else
                    {
                        Console.WriteLine("Press ENTER to exit...");
                        Console.ReadLine();
                    }
                }
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty()) return;

            foreach (var arg in args)
            {
                if (arg == "-q")
                    _quietMode = true;
            }
        }
    }
}

