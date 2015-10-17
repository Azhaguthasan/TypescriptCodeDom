using System.CodeDom;

namespace TypescriptCodeDom.CodeTypeMembers
{
    public static class Extensions
    {
        public static string GetAccessModifier(this CodeTypeMember member)
        {
            switch (member.Attributes)
            {
                case MemberAttributes.Private:
                    return "private ";
                case MemberAttributes.Public:
                   return "public ";
                default:
                    return string.Empty;
            }


        }
    }
}
