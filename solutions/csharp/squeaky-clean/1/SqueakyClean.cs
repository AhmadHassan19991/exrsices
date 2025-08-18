using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        bool makeUpper = false;

        foreach (var ch in identifier)
        {
            if (ch == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(ch))
            {
                sb.Append("CTRL");
            }
            else if (ch == '-')
            {
                makeUpper = true;
            }
            else if (!char.IsLetter(ch) && ch != '_')
            {
                continue;
            }
            else if (ch >= 'α' && ch <= 'ω')
            {
                continue;
            }
            else
            {
                if (makeUpper)
                {
                    sb.Append(char.ToUpperInvariant(ch));
                    makeUpper = false;
                }
                else
                {
                    sb.Append(ch);
                }
            }
        }

        return sb.ToString();
    }
}
