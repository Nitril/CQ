using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics;   //później do usunięcia


namespace CONSEC
{
    class Program
    {
        static LinkedList<int> myList = new LinkedList<int>();
        static StringBuilder wynik = new StringBuilder(100000);
        static int casse = 1;
        static void Main()
        {


            int T = int.Parse(Console.ReadLine());   //get number of cases


            
            for (int dd = 0; dd < T; dd++)       //iterate T number of cases as index
            {
                //Debug.Assert(T >= 1 && T <= 15);   //warunek logiczny aby dalsza częśćsię wykonała

                string s = Console.ReadLine();   //get input string to iterate through 

                //Debug.Assert(s.Length >= 1 && s.Length <= 200000); //warunek logiczny aby dalsza część się wykonała

                int Q = int.Parse(Console.ReadLine());   //number of instructions
                int z = 0;
                char tmp = ' ';
                //Debug.Assert(Q >= 1 && Q <= 100000);                //warunek logiczny aby dalsza część się wykonała

                PopulateLinkedList(s, ref z, ref tmp);

                for (int i = 1; i <= Q; i++)
                {
                    // wczytaj instrukcję
                    StringBuilder sb = new StringBuilder(s);
                    Solution1(sb, i);
                    s = sb.ToString();
                }

                casse++;
            }
            Console.WriteLine(wynik.ToString());

        }

        private static void PopulateLinkedList(string s, ref int z, ref char tmp)
        {
            foreach (char a in s)
            {

                if (tmp != a && z == 0)
                {

                    tmp = a;
                    z = 1;

                }
                else if (tmp != a)
                {
                    tmp = a;
                    myList.AddLast(z);
                }

                z++;

            }
        }

        static void Solution1(StringBuilder sb, int CaseNo)
        {
            //wczytaj instrukcje

            int queryType, h;
            GetTask(out queryType, out h);// indeks
                                            // wykonaj i ew. wypisz wynik

                                          
            if (queryType == 2)
            {

                //zamien litere na #
                sb[h] = '#';   //string jest immutable wiec powinnismy to zrobić jako string builder

            }
            else if (queryType == 1)
            {
                //oblicz
                if (CaseNo == 1) wynik.Append($"Case {casse}:\n");
                int b = h;
                for (b = h; b >= 0; b--)                //sprawdź lewy index aż do zera
                {

                    if (sb[h] != sb[b]) break;
                }
                b++;

                int e = h;
                
                for (e = h; e < sb.Length; e++)                             //sprawdź prawy index aż do ostatniego indexu 
                {

                    if (sb[h] != sb[e]) break;


                }
                e--;
                wynik.Append($"{(e - b) + 1}\n");
            }
            else
            {

                throw new ArgumentException();
            }


        }

        private static void GetTask(out int queryType, out int h)
        {
            string[] tab = (Console.ReadLine()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            int[] tabInt = Array.ConvertAll(tab, int.Parse);
            queryType = tabInt[0];
            h = tabInt[1];
        }
    }
}

