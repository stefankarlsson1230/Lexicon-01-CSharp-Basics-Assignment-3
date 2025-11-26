using static System.Console;
using NAudio.Wave;
using NAudio.Vorbis;

// variables
string[] ones = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
string[] teens = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


// Local functions
string GetNumber(int i)
{
    // i varierar från 99 - 2
    string result ="";

    if (i < 10)
    {
        result = Convert.ToString(ones[i][0]).ToUpper() + ones[i].Substring(1);
    }
    else if (i > 10 && i < 20)
    {
        result = Convert.ToString(teens[i - 10][0]).ToUpper() + teens[i - 10].Substring(1);
    }
    else if (i % 10 == 0)
    {
        result = Convert.ToString(tens[i/10][0]).ToUpper() + tens[i/10].Substring(1);
    }
    else
    {
        result = Convert.ToString(tens[i / 10][0]).ToUpper() + tens[i / 10].Substring(1) + " " + ones[i % 10];
    }

    return result;
}

void PlayMusic()
{
    using VorbisWaveReader vorbisReader = new("99_bottles_of_beer.ogg");
    using WaveOutEvent outputDevice = new();

    outputDevice.Init(vorbisReader);
    outputDevice.Play();
}


// main program
PlayMusic();

for(int i = 99; i >= 0; i--)
{
    Thread.Sleep(75);

    if (i == 0)
    {
        WriteLine("No more bottles of beer on the wall, no more bottles of beer.");
        WriteLine($"\tGo to the store and buy some more, ninety nine bottles of beer on the wall.\n");
    }
    else if (i == 1)
    {
        WriteLine($"One bottle of beer on the wall, One bottle of beer.");
        WriteLine("\tTake one down and pass it around, no more bottles of beer on the wall.\n");
    }
    else
    {
        string number = GetNumber(i);
        string oneLess = GetNumber(i-1);
        
        WriteLine($"{number} bottles of beer on the wall, {number} bottles of beer.");
        WriteLine($"\tTake one down and pass it around, {oneLess} bottles of beer on the wall.\n");
    }
}


