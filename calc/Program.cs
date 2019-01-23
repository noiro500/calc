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
        private List<string> parseStr;
        private Queue<string> queue;

        public CParser(string inputString)
        {
            this.inputString = inputString;
            parseStr=new List<string>();
            queue=new Queue<string>();
            tmp = 0;
        }

        public List<string> ReturnParsedString()
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
                        parseStr.Add(Temp);
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
                    parseStr.Add(Temp);
                    Temp = null;
                    parseStr.Add(inputString[i].ToString());
                }
            }

            return parseStr;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            var parseStr=new CParser(inputString);
            var parsedStr = parseStr.ReturnParsedString();
            List<string> outList=new List<string>();

            var stack = new Stack<string>();

            var tmp = 0;
            foreach (var i in parsedStr)
            {
                if (int.TryParse(i,
                    out tmp))
                {
                    outList.Add(i);
                    continue;
                }

                if (i == "/" || i == "*")
                {
                    if (stack.Count == 0 || stack.Peek() == "+" || stack.Peek() == "-")
                    {
                        stack.Push(i);
                        continue;
                    }
                    else
                    {
                        string strTemp = null;
                        while (stack.TryPeek(out strTemp))
                        {
                            //string temp = stack.Peek();
                            if ((strTemp != "-") & (strTemp != "+"))
                                outList.Add(stack.Pop());
                            break;
                        }
                        stack.Push(i);
                    }
                }

                if (i == "+" || i == "-")
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                        continue;
                    }
                    else
                    {
                        string strTemp = null;
                        while (stack.TryPeek(out strTemp))
                            outList.Add(stack.Pop());
                    }

                    stack.Push(i);
                }
            }

            while (stack.Count != 0)
                outList.Add(stack.Pop());

            foreach (var i in outList)
            {
                Console.Write(i+" ");
            }

            Console.ReadLine();
        }
    }
}
                
