using System;
using System.IO;

namespace AdventOfCode_day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../TextFile1.txt");
            char[,] bins = new char[1000, 12];

            //
            for(int i = 0; i < lines.Length;i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    bins[i, j] = lines[i][j];
                }
            }
            //
            int ZeroCounter = 0;
            int OneCounter = 0;

            string GammaRate = "";
            string EpsilonRate = "";

            for(int i = 0; i < 12; i++)
            {
                ZeroCounter = 0;
                OneCounter = 0;
                for(int j = 0; j < 1000; j++)
                {
                    if(bins[j,i] == '1')
                    {
                        OneCounter++;
                    }
                    else
                    {
                        ZeroCounter++;
                    }
                }
                if(ZeroCounter > OneCounter)
                {
                    GammaRate += "0";
                }
                else
                {
                    GammaRate += "1";
                }
            }
            for(int i = 0; i < GammaRate.Length; i++)
            {
                if(GammaRate[i] == '1')
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

            Console.WriteLine(GammaInt * EpsilonInt);
    }
}
