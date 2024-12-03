using System.Text.RegularExpressions;
using static AdventOfCode24.Utils.LineUtils;

namespace AdventOfCode24.Day3;

public static class Day3 
{
    static int PartOneHelper(string? line)
    {
        int product = 0;
        string pattern = @"mul\(\d+,\d+\)";
        MatchCollection matches = Regex.Matches(line, pattern);

        // mul(4,3)
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
            List<int> nums = match.Value[4..^1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (nums.Count != 2) throw new Exception("Invalid number of numbers found");
            product += nums[1] * nums[0];
        }
        
        return product;
    }
    public static async Task<int> PartOneAsync(string filename = "input.txt")
    {
        int sum = 0;
        
        await ProcessFileLinesAsync("Day3", filename, PartOneHelper, result => sum += result);

        return sum;
    }
    static int PartTwoHelper(string line)
    {
        int product = 0;
        string pattern = @"mul\(\d+,\d+\)|(do|don\'t)\(\)";
        MatchCollection matches = Regex.Matches(line.Trim(), pattern);

        bool doing = true;

        foreach (Match match in matches)
        {
            string instruction = match.Value[..match.Value.IndexOf('(')];

            doing = instruction switch
            {
                "do" => true,
                "don't" => false,
                "mul" => doing
            };

            if (instruction != "mul" || !doing) continue;

            List<int> nums = match.Value[4..^1]
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (nums.Count != 2)
            {
                throw new Exception("Invalid number of numbers found");
            }

            product += nums[1] * nums[0];
        }

        return product;
    }

    public static async Task<int> PartTwoAsync(string filename = "input.txt")
    {
        int sum = 0;
        
        await ProcessFileLinesAsync("Day3", filename, PartTwoHelper, result => sum += result);

        return sum;
    }
}