using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace EmployeeLeaveManagementSystem.Localization
{
    public static class EmployeeLeaveManagementSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(EmployeeLeaveManagementSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(EmployeeLeaveManagementSystemLocalizationConfigurer).GetAssembly(),
                        "EmployeeLeaveManagementSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
