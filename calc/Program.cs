using System;
using System.Collections.Generic;
using System.Linq;

namespace calc
{
    public class CParser
    {
        private int tmp;
        private string Temp { get; set; }
        private string inputString { get; set; }
        private List<string> parserStr;
        private Queue<string> queue;

        public CParser(string inputString)
        {
            this.inputString = inputString;
            parserStr=new List<string>();
            queue=new Queue<string>();
            tmp = 0;
        }

        public List<string> ReturnParserString()
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (Int32.TryParse(inputString[i].ToString(), out tmp))
                {
                    queue.Enqueue(inputString[i].ToString());
                    if (i == inputString.Length - 1)
                    {
                        foreach (var j in queue)
                        {
                            Temp += j.ToString();
                        }
                        parserStr.Add(Temp);
                    }
                    continue;
                }
                else
                {
                    foreach (var j in queue)
                    {
                        Temp += j.ToString();
                    }
                    queue.Clear();
                    parserStr.Add(Temp);
                    Temp = null;
                    parserStr.Add(inputString[i].ToString());
                }
            }

            return parserStr;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            //List<String> parserStr=new List<string>();
            var parsedStr=new CParser(inputString);
            var parseredStr = parsedStr.ReturnParserString();
            

            Console.ReadKey();
        }
    }
}
                
