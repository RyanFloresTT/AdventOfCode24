using static AdventOfCode24.Utils.LineUtils;

namespace AdventOfCode24.Day2;

public static class Day2 
{
    static int CountLineSafetyPartOne(string line)
    {
        List<int> numbers = line.Split(" ").Select(int.Parse).ToList();

        bool isInitialDifferenceNegative = numbers[1] - numbers[0] < 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            int difference = numbers[i] - numbers[i - 1];
            bool isCurrentDifferenceNegative = difference < 0;

            if (Math.Abs(difference) > 3 || Math.Abs(difference) == 0 || isCurrentDifferenceNegative != isInitialDifferenceNegative)
            {
                return 0;
            }
        }

        return 1;
    }

    public static async Task<int> PartOneAsync(string filename = "input.txt")
    {
        var sum = 0;

        await ProcessFileLinesAsync("Day2", filename, CountLineSafetyPartOne, result => sum += result);
        
        return sum;
    }
    
    static int CountLineSafetyPartTwo(string line)
    {
        List<int> numbers = line.Split(" ").Select(int.Parse).ToList();

        bool hasForgiven = false;
        bool isInitialDifferenceNegative = numbers[1] - numbers[0] < 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            int difference = numbers[i] - numbers[i - 1];
            bool isCurrentDifferenceNegative = difference < 0;
            
            Console.WriteLine($"Comparing {numbers[i]} - {numbers[i - 1]}");

            if (Math.Abs(difference) <= 3 && Math.Abs(difference) != 0 &&
                isCurrentDifferenceNegative == isInitialDifferenceNegative)
            {
                continue;
            }

            if (hasForgiven) return 0;
            
            numbers.RemoveAt(i);
            hasForgiven = true;
            i--;
        }

        return 1;
    }

    public static async Task<int> PartTwoAsync(string filename = "input.txt")
    {
        var sum = 0;

        await ProcessFileLinesAsync("Day2", filename, CountLineSafetyPartTwo, result => sum += result);
        
        return sum;
    }
}