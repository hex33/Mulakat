///////////////////////////////////////////////////////////////////////////////////
///
///Girilen parantezlerin açış kapanışlarını kontrol ediyor. Her açılan parantein-
///kapatılıp kapatılmadığına bakıyor.
//
///////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Parentez giriniz :");
            var text = Console.ReadLine();
            string check = Kontrol(text) ? "Sıralı" : "Sırasız";
            Console.Write($"Girdiğiniz parantezler {check}");
            Console.ReadLine();
        }

        private static char[,] parantezler = new char[3, 2] { { '(', ')' }, { '{', '}' }, { '[', ']' } };

        private static bool Kontrol(string text)
        {
            Stack<char> list = new Stack<char>(); //Yığın LIFO
            foreach (var s in text)
            {
                if (Enumerable.Range(0, 3).Select(x => parantezler[x, 0]).ToList().Any(z => z == s))
                {
                    list.Push(s);
                }
                else
                {
                    if (list.Count == 0)
                        return false;
                    char c = list.Pop();
                    var index = Enumerable.Range(0, 3).Select((x, i) => new { Index = i, Value = parantezler[x, 0] }).ToList().Where(w => w.Value == c).FirstOrDefault();
                    if (parantezler[index.Index, 1] != s)
                        return false;
                }
            }
            return list.Count == 0;
        }

    }
}
