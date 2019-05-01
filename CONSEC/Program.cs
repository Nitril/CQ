using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;   //później do usunięcia


namespace CONSEC
{
    class Program
    {

        static StringBuilder wynik = new StringBuilder(100000);

        static void Main(string[] args)
        {


            int T = int.Parse(Console.ReadLine());

            Debug.Assert(T >= 1 && T <= 15);   //warunek logiczny aby dalsza częśćsię wykonała

            string s = Console.ReadLine();

            Debug.Assert(s.Length >= 1 && s.Length <= 200000);

            int Q = int.Parse(Console.ReadLine());

            Debug.Assert(Q >= 1 && Q <= 100000);

            for (int i = 1; i <= Q; i++)
            {
                // wczytaj instrukcję

                Solution1(s, i);

            }

            Console.WriteLine(wynik.ToString());



        }

        static void Solution1(string s, int CaseNo)
        {
            //wczytaj instrukcje
            wynik.Append($"Case {CaseNo}:");
            string[] tab = (Console.ReadLine()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            int[] tabInt = Array.ConvertAll(tab, int.Parse);
            int queryType = tabInt[0];

            int i = tabInt[1];
            // wykonaj i ew. wypisz wynik

            StringBuilder sb = new StringBuilder(s);  // !!!! pamięć

            //


            if (queryType == 2)
            {

                //samien litere na #
                sb[i] = '#';   //string jest immutable wiec powinnismy to zrobić jako string builder
            }
            else if (queryType == 1)
            {
                //oblicz

                int b = i;
                for (b = i; b >= 0; b++)
                {
                    if (sb[i] != sb[b]) break;
                }
                b++;

                int e = i;

                for (e = i; e < sb.Length; e++)
                {
                    if (sb[i] != sb[e]) break;


                }
                e--;
                wynik.Append($"{e - b + 1}\n");
            }
            else
            {

                throw new ArgumentException();
            }
        }
    }
}

