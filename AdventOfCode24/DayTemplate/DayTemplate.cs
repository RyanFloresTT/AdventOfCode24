using static AdventOfCode24.Utils.LineUtils;
namespace AdventOfCode24.DayTemplate;

public static class DayTemplate 
{
    static int PartOneHelper(string? line)
    {
        return 0;
    }
    public static async Task<int> PartOneAsync(string filename = "input.txt")
    {
        int sum = 0;
        
        await ProcessFileLinesAsync("Day3", filename, PartOneHelper, result => sum += result);

        return sum;
    }
    static int PartTwoHelper(string? line)
    {
        return 0;
    }
    public static async Task<int> PartTwoAsync(string filename = "input.txt")
    {
        int sum = 0;
        
        await ProcessFileLinesAsync("Day3", filename, PartTwoHelper, result => sum += result);

        return sum;
    }
}