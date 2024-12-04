using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2024___Advent4
{
    internal class StringChecker
    {
        private static Regex _regexCorrect = new Regex("XMAS");
        private static Regex _regexReverse = new Regex("SAMX");

        internal static int CountInString(string Input)
        {
            int Count = 0; 
            Count += _regexCorrect.Count(Input);
            Count += _regexReverse.Count(Input);

            return Count;
        }

        internal static string GetStringFromHorizontal(List<string> Input)
        {
            StringBuilder Data = new StringBuilder();

            foreach (string InputItem in Input)
            {
                Data.Append(InputItem);
            }

            return Data.ToString();
        }

        internal static string GetStringFromVertical(List<List<string>> Input, int Index)
        {
            StringBuilder Data = new StringBuilder();
            
            foreach(List<string> SingleLine in Input)
            {
                Data.Append(SingleLine[Index]);
            }

            return Data.ToString();
        }

        internal static List<string> GetStringFromDiagonalLeftToRight(List<List<string>> Input)
        {
            List<string> Result = new List<string>();
            string[][] RawData = Input.SelectMany((row, rowIdx) => row.Select((x, colIdx) => new { Key = rowIdx - colIdx, Value = x })).GroupBy(x => x.Key, (key, values) => values.Select(i => i.Value).ToArray()).ToArray();

            foreach(string[] InputItem in RawData)
            {
                StringBuilder Builder = new StringBuilder();

                foreach(string SingleData in InputItem)
                {
                    Builder.Append(SingleData);
                }
                Result.Add(Builder.ToString());
            }

            return Result;
        }

        internal static List<string> GetStringFromDiagonalRightToLeft(List<List<string>> Input)
        {
            List<string> Result = new List<string>();
            string[][] RawData = Input.SelectMany((row, rowIdx) => row.Select((x, colIdx) => new { Key = rowIdx + colIdx, Value = x })).GroupBy(x => x.Key, (key, values) => values.Select(i => i.Value).ToArray()).ToArray();

            foreach (string[] InputItem in RawData)
            {
                StringBuilder Builder = new StringBuilder();

                foreach (string SingleData in InputItem)
                {
                    Builder.Append(SingleData);
                }
                Result.Add(Builder.ToString());
            }

            return Result;
        }
        
        internal static int FindXInString(string[] Input)
        {
            int Result = 0;

            int MaxCount = Input.Length - 1;
            int Count = 0;

            while(Count <= MaxCount)
            {
                int MaxCharCount = Input[Count].Length - 1;
                int CharCount = 0;

            }

            return Result;
        }
    }
}
