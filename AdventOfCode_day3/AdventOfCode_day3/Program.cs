using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../TextFile1.txt");
            char[,] bins = new char[1000, 12];

            //
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    bins[i, j] = lines[i][j];
                }
            }
            //
            int ZeroCounter = 0;
            int OneCounter = 0;

            string GammaRate = "";
            string EpsilonRate = "";

            for (int i = 0; i < 12; i++)
            {
                ZeroCounter = 0;
                OneCounter = 0;
                for (int j = 0; j < 1000; j++)
                {
                    if (bins[j, i] == '1')
                    {
                        OneCounter++;
                    }
                    else
                    {
                        ZeroCounter++;
                    }
                }
                if (ZeroCounter > OneCounter)
                {
                    GammaRate += "0";
                }
                else
                {
                    GammaRate += "1";
                }
            }
            for (int i = 0; i < GammaRate.Length; i++)
            {
                if (GammaRate[i] == '1')
                {
                    EpsilonRate += "0";
                }
                else
                {
                    EpsilonRate += "1";
                }
            }

            int GammaInt = Convert.ToInt32(GammaRate, 2);
            int EpsilonInt = Convert.ToInt32(EpsilonRate, 2);

            Console.WriteLine("Part 1: \n" + GammaInt * EpsilonInt);

            int OxygenCounter = 0;
            int Co2Counter = 0;

            int ZeroCounter2 = 0;
            int OneCounter2 = 0;
            //seru na to bez linqu to nebudu delat
            List<List<char>> binList = new List<List<char>>();
            for(int i = 0; i < 1000; i++)
            {
                List<char> chars = new List<char>();
                for (int j = 0; j < 12; j++)
                {
                    
                    chars.Add(bins[i, j]);
                    
                }
                binList.Add(chars);
            }
            var binList2 = binList; //udelam to hloupe specham :)
            for(int i = 0; i < 12; i++)
            {
                ZeroCounter2 = 0;
                OneCounter2 = 0;
                for(int j = 0; j < binList.Count; j++)
                {
                    if(binList[j][i] == '0')
                    {
                        ZeroCounter2++;
                    }
                    else
                    {
                        OneCounter2++;
                    }
                }
                if(binList.Count > 1)
                {

                    if (ZeroCounter2 > OneCounter2)
                    {
                        binList = binList.Where(x => x[i] == '0').ToList();
                    }
                    else if(ZeroCounter2 == OneCounter2)
                    {

                        binList = binList.Where(x => x[i] == '1').ToList();
                    }
                    else
                    {
                        binList = binList.Where(x => x[i] == '1').ToList();
                    }
                }
                else { break; }
            }
    
           for (int i = 0; i < 12; i++)
            {
                ZeroCounter2 = 0;
                OneCounter2 = 0;
                for (int j = 0; j < binList2.Count; j++)
                {
                    if (binList2[j][i] == '0')
                    {
                        ZeroCounter2++;
                    }
                    else
                    {
                        OneCounter2++;
                    }
                }
                if(binList2.Count > 1)
                {

                    if (ZeroCounter2 > OneCounter2)
                    {
                        binList2 = binList2.Where(x => x[i] == '1').ToList();
                    }
                    else if (ZeroCounter2 == OneCounter2)
                    {

                        binList2 = binList2.Where(x => x[i] == '0').ToList();
                    }
                    else
                    {
                        binList2 = binList2.Where(x => x[i] == '0').ToList();
                    }
                }
                else { break; }
            }
            string OxStr = "";
            string Co2Str = "";
            foreach(var i in binList[0])
            {
                OxStr += i.ToString();
            }
            foreach (var i in binList2[0])
            {
                Co2Str += i.ToString();
            }
            int OxygenInt = Convert.ToInt32(OxStr, 2);
            int Co2Int = Convert.ToInt32(Co2Str, 2);
            Console.WriteLine(OxygenInt * Co2Int);


        }
    }
}