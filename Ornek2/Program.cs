///////////////////////////////////////////////////////////////////////////////////
///
///Girilen metin içerisinde,aranacak olan metinden kaç adet geçtiğini hesaplıyor.
///
//
///////////////////////////////////////////////////////////////////////////////////


using System;
using System.Text.RegularExpressions;

namespace Ornek2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "diGİTuRk";
            string s2 = @"Yeni kanallar, yepyeni içerikler, modern stüdyolar ve ünlü isimlerle Digiturk şimdi çok daha güçlü. Futboldan tenise ve basketbola Türkiye ve dünyadaki spor karşılaşmaları, aksiyondan komediye her duyguya hitap eden filmler, sevilen yabancı diziler ve ulusal kanallar Digiturk’te!";
            int count = Count(s1, s2);
            //int count = Count(s1, s2,RegexOptions.Singleline);
            Compare(ref s1, ref s2); // bilgilendirme amaçlı
            Console.WriteLine($"{s1} \niçerisinde \n{s2}' den \n{count} adet bulunuyor.");
            Console.ReadLine();


            //int count = Kontrol(s1, s2);
            //Compare(ref s1, ref s2); // bilgilendirme amaçlı
            //Console.WriteLine($"{s1} \niçerisinde \n{s2}' den \n{count} adet bulunuyor.");
            //Console.ReadLine();
        }

        /// <summary>
        /// Uzun olan string içerisinde, kısa olan stringden kaç adet bulunduğunu hesaplar.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="regexOptions"></param>
        /// <returns></returns>
        public static int Count(string s1, string s2, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            if (string.IsNullOrEmpty(s1)) return 0;
            if (string.IsNullOrEmpty(s2)) return 0;
            Compare(ref s1, ref s2);
            return Regex.Matches(s1, Regex.Escape(s2), regexOptions).Count;
        }

        /// <summary>
        /// strin karşılaştırma. Daima s1 uzun olan string, s2 küçük olan string döner.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        private static void Compare(ref string s1, ref string s2)
        {
            if (s2.Length > s1.Length)
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
            }
        }


        private static int Kontrol(string s1, string s2)
        {
            Compare(ref s1, ref s2);
            int count = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                int length = (i + s2.Length) > s1.Length ? s1.Length - i : s2.Length;
                if (s1.Substring(i, length).ToLower() == s2.ToLower())
                    count++;
            }
            return count;
        }

    }
}
