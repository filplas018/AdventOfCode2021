using System;



using System.IO;

int _horizontal = 0;
int _depth = 0;
int _aim = 0;
string[] lines = File.ReadAllLines("../../../TextFile1.txt");

foreach (string line in lines)
{
    string[] str = line.Split(" ");
    if (str[0] == "forward")
    {
        forward(Int32.Parse(str[1].ToString()));
    }
    if (str[0] == "down")
    {
        down(Int32.Parse(str[1].ToString()));
    }
    if (str[0] == "up")
    {
        up(Int32.Parse(str[1].ToString()));
    }
}
void forward(int x)
{
    _horizontal += x;
    int y = _aim * x;
    _depth += y;
}
void up(int x)
{
    _aim -= x;
}
void down(int x)
{
    _aim += x;
}




Console.WriteLine("Multiplied: " + _horizontal * _depth);
