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
                itr(myList);
                for (int i = 1; i <= Q; i++)
                {
                    // wczytaj instrukcję
                    StringBuilder sb = new StringBuilder(s);
                    Solution1(sb, i);
                    s = sb.ToString();
                    
                }
                myList.Clear();
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
                    myList.AddLast(z-2);
                }
                else if (  z == s.Length )
                {
                    myList.AddLast(z-1);

                }

                z++;

            }
        }

        static void Solution1(StringBuilder sb, int CaseNo)
        {
            //wczytaj instrukcje

            int queryType, h;   // h to index
            GetTask(out queryType, out h);// indeks
                                          // wykonaj i ew. wypisz wynik

            
            if (queryType == 2)
            {
                int prev = 0;
                foreach (var i in myList)
                {
                    LinkedListNode<int> current = myList.Find(i);
                    
                    
                    if (current.Previous == null)
                    {
                        prev = 0;

                    }
                    else prev = current.Previous.Value;

                    
                    //if (h == 0) // h to zadany index  i to wartość obecnego nodea   && h + 1 == i   OK
                    //{
                        
                    //    myList.AddBefore(current, h);
                    //    itr(myList);
                    //    break;

                    //}

                    if (prev + 1 < h && i > h+1)             
                    {
                        myList.AddBefore(current, h - 1);
                        myList.AddBefore(current, h);
                        myList.AddBefore(current, h + 1);
                        itr(myList);
                        break;

                    }
                    else if (h+1 == i)
                    {
                        myList.AddBefore(current, h - 1);
                        myList.AddBefore(current, h);
                        
                        itr(myList);
                        break;

                    }
                    else if (h  == i) // h to zadany index  i to wartość obecnego nodea  ok
                    {
                        myList.AddBefore(current, h - 1);
                        

                        itr(myList);
                        break;

                    }
                    else if (h == prev + 1) // h to zadany index  i to wartość obecnego nodea
                    {

                        myList.AddBefore(current, h);
                        itr(myList);
                        break;

                    }
                }
                



            }
            else if (queryType == 1)
            {
                //oblicz
                if (CaseNo == 1) wynik.Append($"Case {casse}:\n");
                int b = h;                // b h to zadany index  i to wartość obecnego nodea
                int segmentLength = 0;
                int prev = 0;

                foreach (var i in myList)
                {


                    LinkedListNode<int> current = myList.Find(i);
                    
                    if (current.Previous == null)
                    {
                        prev = 0;

                    }
                    else prev = current.Previous.Value;


                    if (b > prev && b <= i)
                    {

                        segmentLength = i - prev;




                    }
                    else if (b == 0) segmentLength = myList.First.Value+1;
                }
                
                wynik.Append($"{segmentLength}\n"); // (e - b) + 1
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

        private static void itr(LinkedList<int> lst)
        {

            foreach (var k in lst)
            {


                Console.WriteLine(k);




            }
        }
    }
}

