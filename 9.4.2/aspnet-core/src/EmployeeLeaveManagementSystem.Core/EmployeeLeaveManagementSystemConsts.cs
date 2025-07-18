using EmployeeLeaveManagementSystem.Debugging;

namespace EmployeeLeaveManagementSystem
{
    public class EmployeeLeaveManagementSystemConsts
    {
        public const string LocalizationSourceName = "EmployeeLeaveManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fe56fb7e4b524a61b6c70c675cb61a77";
    }
}
