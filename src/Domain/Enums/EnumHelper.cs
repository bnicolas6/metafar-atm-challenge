using System.ComponentModel;
using System.Reflection;

namespace Metafar.ATM.Challenge.Domain.Enums
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(int value) where TEnum : Enum
        {
            TEnum enumValue = (TEnum)(object)value;
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? enumValue.ToString() : attribute.Description;
        }
    }
}
