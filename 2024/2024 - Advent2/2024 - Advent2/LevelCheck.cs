using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024___Advent2
{
    internal static class LevelCheck
    {
        internal static bool SingleLevelCheck(string Input, bool TollerateOnError = false)
        {
            bool Result = false;

            string[] SplittedValue = Input.Split(" ");
            List<int> Values = SplittedValue.Select(item => int.Parse(item)).ToList();

            List<bool> Absteigend = new List<bool>();
            List<bool> Aufsteigend = new List<bool>();
            int StartAbsteigend = Values.First();
            int StartAufsteigend = Values.First();

            foreach (int SingleValueInt in Values.Skip(1))
            {
                if (StartAbsteigend > SingleValueInt)
                {
                    int Distance = StartAbsteigend - SingleValueInt;
                    if (Distance <= 3)
                    {
                        Absteigend.Add(true);
                    }
                    else
                    {
                        Absteigend.Add(false);
                    }
                }
                else
                {
                    Absteigend.Add(false);
                }
                StartAbsteigend = SingleValueInt;
            }

            foreach (int SingleValueInt in Values.Skip(1))
            {
                if (StartAufsteigend < SingleValueInt)
                {
                    int Distance = SingleValueInt - StartAufsteigend;
                    if (Distance <= 3)
                    {
                        Aufsteigend.Add(true);
                    }
                    else
                    {
                        Aufsteigend.Add(false);
                    }
                }
                else
                {
                    Aufsteigend.Add(false);
                }
                StartAufsteigend = SingleValueInt;
            }

            if(TollerateOnError == false)
            {
                if (Absteigend.Where(item => item == false).Count() == 0)
                {
                    Result = true;
                }

                if (Aufsteigend.Where(item => item == false).Count() == 0)
                {
                    Result = true;
                }
            }          

            return Result;
        }

        public static int CountSafeDampened(List<List<int>> reports)
        {
            int count = 0;

            foreach (var report in reports)
            {
                if (IsReportSafe(report))
                {
                    count++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        if (IsReportSafe(report.Where((x, index) => index != i).ToList()))
                        {
                            count++;
                            break;
                        }
                    }
                }
            }

            return count;
        }

        private static bool IsReportSafe(List<int> report)
        {
            bool increasing = false;

            for (int i = 0; i < report.Count; i++)
            {
                if (i == 0)
                {
                    if (report[1] > report[0])
                    {
                        increasing = true;
                    }
                    else
                    {
                        increasing = false;
                    }
                }
                else
                {
                    if ((increasing && report[i - 1] > report[i]) || (!increasing && report[i - 1] < report[i]))
                    {
                        return false;
                    }

                    if (Math.Abs(report[i - 1] - report[i]) < 1 || Math.Abs(report[i - 1] - report[i]) > 3)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static bool SingleLevelCheckWithTolerate(string Input)
        {
            bool Result = false;
            List<int> SingleLevel = Input.Split(" ").Select(item => int.Parse(item)).ToList();

            foreach (int SingleLevelInt in SingleLevel)
            {

            }

            return Result;
        }
    }
}
