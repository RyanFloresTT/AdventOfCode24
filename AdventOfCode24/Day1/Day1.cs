using static AdventOfCode24.Utils.LineUtils;

namespace AdventOfCode24.Day1;

public static class Day1
{
    static (int, int) SeparateList(string line)
    {
        int[] nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        if (nums.Length != 2) throw new Exception("Invalid number of lines");
        return (nums[0], nums[1]);
    }

    public static async Task<int> PartOneAsync(string filename = "input.txt")
    {
        IdLists idLists = new()
        {
            LeftList = [],
            RightList = []
        };
        int difference = 0;

        await ProcessFileLinesAsync("Day1", filename, SeparateList, result =>
        {
            var (x, y) = result;
            idLists.LeftList.Add(x);
            idLists.RightList.Add(y);
        });

        idLists.LeftList.Sort();
        idLists.RightList.Sort();

        for (var i = 0; i < idLists.LeftList.Count; i++)
        {
            difference += Math.Abs(idLists.RightList[i] - idLists.LeftList[i]);
        }

        return difference;
    }

    public static async Task<int> PartTwoAsync(string filename = "input.txt")
    {
        IdLists idLists = new()
        {
            LeftList = [],
            RightList = []
        };
        int similarityScore = 0;

        await ProcessFileLinesAsync("Day1", filename, SeparateList, result =>
        {
            var (x, y) = result;
            idLists.LeftList.Add(x);
            idLists.RightList.Add(y);
        });

        Dictionary<int, int> similarities = new();
        
        foreach (var id in idLists.LeftList)
        {
            if (similarities.TryGetValue(id, out var similarity))
            {
                similarityScore += similarity * id;
                continue;
            }

            int numCount = idLists.RightList.Count(x => x == id);
            similarities.Add(id, numCount);
            similarityScore += numCount * id;
        }
        
        return similarityScore;
    }
}

struct IdLists
{
    public List<int> LeftList { get; set; }
    public List<int> RightList { get; set; }
}