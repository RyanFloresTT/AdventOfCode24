using static AdventOfCode24.Utils.LineUtils;

namespace AdventOfCode24.Day2;

public static class Day2 
{
    static int CountLineSafetyPartOne(string line)
    {
        List<int> numbers = line.Split(" ").Select(int.Parse).ToList();
        return IsValidSequence(numbers) ? 1 : 0;
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

        if (IsValidSequence(numbers)) return 1;

        for (int i = 0; i < numbers.Count; i++)
        {
            var modifiedNumbers = numbers.Where((_, index) => index != i).ToList();
            if (IsValidSequence(modifiedNumbers)) return 1;
        }

        return 0;
    }

    
    static bool IsValidSequence(List<int> numbers)
    {
        bool isInitialDifferenceNegative = numbers[1] - numbers[0] < 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            int difference = numbers[i] - numbers[i - 1];
            bool isCurrentDifferenceNegative = difference < 0;

            if (Math.Abs(difference) > 3 || Math.Abs(difference) == 0 || isCurrentDifferenceNegative != isInitialDifferenceNegative)
            {
                return false;
            }
        }

        return true;
    }

    public static async Task<int> PartTwoAsync(string filename = "input.txt")
    {
        var sum = 0;

        await ProcessFileLinesAsync("Day2", filename, CountLineSafetyPartTwo, result => sum += result);
        
        return sum;
    }
}