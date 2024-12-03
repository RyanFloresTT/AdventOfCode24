namespace AdventOfCode24.Utils;
using static Utils.FilePathUtils;
public static class LineUtils
{
    /// <summary>
    /// Processes each line in a given file, applying a generic function to each line and handling the result.
    /// </summary>
    /// <typeparam name="T">The type of the result after processing each line.</typeparam>
    /// <param name="directoryName">The directory for the input file.</param>
    /// <param name="filename">The file's name.</param>
    /// <param name="processLine">The function to process each file line with.</param>
    /// <param name="handleResult">The function to handle the result of each processed line.</param>
    public static async Task ProcessFileLinesAsync<T>(string directoryName, string filename, Func<string, Task<T>> processLine, Func<T, T> handleResult)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(GetWorkingDirectory() + directoryName + "/" + filename);

            foreach (var line in lines)
            {
                var res = await processLine(line);
                handleResult(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
    public static async Task ProcessFileLinesAsync<T>(string directoryName, string filename, Func<string, T> processLine, Func<T, T> handleResult)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(GetWorkingDirectory() + directoryName + "/" + filename);

            foreach (var line in lines)
            {
                var res = processLine(line);
                handleResult(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
    
    public static async Task ProcessFileLinesAsync<T>(string directoryName, string filename, Func<string, Task<T>> processLine, Action<T> handleResult)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(GetWorkingDirectory() + directoryName + "/" + filename);

            foreach (var line in lines)
            {
                var res = await processLine(line);
                handleResult(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
    public static async Task ProcessFileLinesAsync<T>(string directoryName, string filename, Func<string, T> processLine, Action<T> handleResult)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(GetWorkingDirectory() + directoryName + "/" + filename);

            foreach (var line in lines)
            {
                var res = processLine(line);
                handleResult(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}