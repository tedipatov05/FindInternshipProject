using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FindInternship.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetAbilityName(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if ((attribs != null && attribs.Count() > 0))
                {
                    return ((DisplayAttribute)attribs.ElementAt(0)).Name!;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
