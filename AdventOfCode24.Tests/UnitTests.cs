using AdventOfCode24.Day1;

namespace AdventOfCode24.Tests;

public class Tests
{
    [Test]
    public async Task Day1_Part1()
    {
        int result = await Day1.Day1.PartOneAsync("example.txt");
        Assert.That(result, Is.EqualTo(11));
    }
    
    [Test]
    public async Task Day1_Part2()
    {
        int result = await Day1.Day1.PartTwoAsync("example.txt");
        Assert.That(result, Is.EqualTo(31));
    }
    [Test]
    public async Task Day2_Part1()
    {
        int result = await Day2.Day2.PartOneAsync("example.txt");
        Assert.That(result, Is.EqualTo(2));
    }
    [Test]
    public async Task Day2_Part2()
    {
        int result = await Day2.Day2.PartTwoAsync("example.txt");
        Assert.That(result, Is.EqualTo(4));
    }
}