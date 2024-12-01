using AdventOfCode24.Day1;

namespace AdventOfCode24.Tests;

public class Tests
{
    [Test]
    public async Task Day1_Part1()
    {
        int result = await DayOne.PartOneAsync("example.txt");
        Assert.That(result, Is.EqualTo(11));
    }
    
    [Test]
    public async Task Day1_Part2()
    {
        int result = await DayOne.PartTwoAsync("example.txt");
        Assert.That(result, Is.EqualTo(31));
    }
}