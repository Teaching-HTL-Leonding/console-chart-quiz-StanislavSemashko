using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ConsoleChartExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupingColumn = args[0];
            var numericColumn = args[1];
            int count = -1;

            if (args.Length == 3) count = Convert.ToInt32(args[2]);

            Dictionary<string, int> dict = getDictOfAttacks(groupingColumn);


            printBlanks(dict,count);
        }

        private static Dictionary<string, int> getDictOfAttacks(string groupingColumn)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string line;

            //Skipping the first line
            line = Console.ReadLine();
            int tmp = 0;
            int column = 0;
            switch (groupingColumn.ToLower())
            {
                case "country":
                    column = 0;
                    break;
                case "time_of_day":
                    column = 1;
                    break;
                case "animal":
                    column = 2;
                    break;
                default:
                    column = 2;
                    break;
            }
            while ((line = Console.ReadLine()) != null)
            {
                var result = line.Split("	");
                if (dict.ContainsKey(result[column]))
                {
                    tmp = dict.GetValueOrDefault(result[column]);
                    tmp += Convert.ToInt32(result[3]);
                    dict.Remove(result[column]);
                    dict.Add(result[column], Convert.ToInt32(tmp));
                }
                else
                {
                dict.Add(result[column], Convert.ToInt32(result[3]));
                }
            }

            return dict;
        }
        private static void printBlanks(Dictionary<string, int> dic, int linesToPrint)
        {
            var maxAttacks = getMaxAttacks(dic);
            double blanks = 0;

            var sortedDict = from entry in dic orderby entry.Value descending select entry;

            if (linesToPrint == -1) linesToPrint = 10000;
 

            foreach (KeyValuePair<string, int> item in sortedDict)
            {
                if (linesToPrint == 0)
                {
                    break;
                }
                else
                {
                    linesToPrint--;
                }
                blanks = ((double)item.Value / maxAttacks) * 100.0;
                Console.Write($"{item.Key,-45}|\t");
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i = 0; i < (int)Math.Round(blanks); i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }

        }
        private static int getMaxAttacks(Dictionary<string, int> dict)
        {
            return dict.Values.Max();
        }
    }
}
