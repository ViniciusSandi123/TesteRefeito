using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TesteRefeito.Helpers
{
    public static class DescricaoEnum
    {
        public static string EnumDecricao(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString());
            if (member.Length > 0)
            {
                var display = member[0].GetCustomAttribute<DisplayAttribute>();
                return display?.Name ?? value.ToString();
            }
            return value.ToString();
        }
    }
}
