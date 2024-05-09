using System.Drawing;
using System.Windows.Forms;

namespace KainmunityClient.Forms
{
    class ErrorHandling
    {
        public static bool IsContactNumber(string text)
        {
            if (text.Length != 11)
                return false;

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return text[0] == '0' && text[1] == '9';
        }

        public static bool IsNumber(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public static bool IsNotBlank(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}