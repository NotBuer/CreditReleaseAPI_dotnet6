using System.Reflection;

namespace CreditRelease.Application.Common
{
    public abstract class BaseConfig
    {
        public static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
    }
}
