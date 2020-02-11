///////////////////////////////////////////////////////////////////////////////////
///
/// Sezar şifreleme yöntemi ile girelen metni verilen şifre şifreler.
//
///////////////////////////////////////////////////////////////////////////////////
using System;
using System.Linq;

namespace Ornek3
{
    class Program
    {
        private static readonly char[] alphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static char Converter(char ch, int key)
        {
            if (!alphabet.Any(c => c == ch)) //Alfabe de olmayanları geri dön
                return ch;
            int oldIndex = Array.IndexOf(alphabet, ch);
            int step = (oldIndex + key) % alphabet.Length;
            int newIndex = step >= 0 ? step : alphabet.Length + step;
            return alphabet[newIndex];
        }

        public static string Encoder(string input, int key)
        {
            string output = string.Empty;
            foreach (char ch in input)
                output += Converter(ch, key);
            return output;
        }

        public static string Decoder(string input, int key)
        {
            return Encoder(input, alphabet.Length - key);
        }

        static void Main(string[] args)
        {
            #region Dosya 
            Console.Write("Text : ");
            string text = Console.ReadLine().ToUpper();
            #endregion
            #region Key
            Console.Write("Key girin : ");
            string sKey = Console.ReadLine();
            int key = 0;
            if (!int.TryParse(sKey, out key))
            {
                Console.Clear();
                Console.Write("Key integer olmalı.");
                Console.ReadKey();
                return;
            }
            #endregion
            string newText = Encoder(text, key);
            Console.Clear();
            Console.Write($"Orjinal hali\n{text}\nYeni hali(Anahtar: {key})\n{newText}");
            Console.ReadKey();
        }
    }
}
