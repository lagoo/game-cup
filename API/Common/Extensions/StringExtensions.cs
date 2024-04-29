namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string TextBetweenBrackets(this string text)
        {
            int startindex = text.IndexOf('(');
            int endindex = text.IndexOf(')');

            if (startindex == -1 || endindex == -1)
                return "-";

            return text.Substring(startindex + 1, endindex - startindex - 1);
        }
    }
}
