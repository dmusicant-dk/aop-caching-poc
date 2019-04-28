using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CachingUnitTests.Util
{
    public static class ReflectionTestUtils
    {
        public static void SetProperty<T>(object instance, string properyName, T value)
        {
            var type = instance.GetType();

            var propertyInfo = type.GetProperty(properyName);
            var accessors = propertyInfo.GetAccessors(true);

            // There is a setter, lets use that
            if (accessors.Any(x => x.Name.StartsWith("set_")))
            {
                propertyInfo.SetValue(instance, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
            else
            {
                // Try to find the backing field
                var fieldName = PropertyToField(properyName);
                var fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

                // Cant find a field
                if (fieldInfo == null)
                {
                    throw new ArgumentException("Cannot find anything to set.");
                }

                // Its a normal backing field
                if (fieldInfo.FieldType == typeof(T))
                {
                    throw new NotImplementedException();
                }

                // if its a field of type lazy
                if (fieldInfo.FieldType == typeof(Lazy<T>))
                {
                    var lazyValue = new Lazy<T>(() => value);
                    fieldInfo.SetValue(instance, lazyValue);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private static string PropertyToField(string propertyName)
        {
            return "_" + Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
        }
    }
}
