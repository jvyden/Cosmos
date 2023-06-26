using IL2CPU.API.Attribs;
using Cosmos.Common;
using Cosmos.Core;

namespace Cosmos.System_Plugs.System
{
    [Plug(Target = typeof(byte))]
    public static class ByteImpl
    {
        public static string ToString(ref byte aThis) => StringHelper.GetNumberString(aThis);

        public static string ToString(ref byte aThis, string format, IFormatProvider provider) => aThis.ToString();

        public static byte Parse(string s)
        {
            const string digits = "0123456789";
            byte result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                short ind = (short)digits.IndexOf(s[i]);
                if (ind == -1)
                {
                    if (s[i] == '\0')
                    {
                        break;
                    }

                    string error = $"Digit '{s[i]}' not found!";
                    Console.WriteLine(error);
                    throw new FormatException(error);
                }

                result = (byte)(result * 10 + ind);
            }

            return result;
        }
    }
}