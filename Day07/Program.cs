Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllText(@".\input.txt").Split(',');
    var sw = System.Diagnostics.Stopwatch.StartNew();

    var positions = input.Select(int.Parse);
    var median = positions.GetMedian(); //this happens to work in my case but may not always work
    var fuel = 0;
    foreach (var pos in positions)
    {
        fuel += Math.Abs(pos - median);
    }

    sw.Stop();
    Console.WriteLine($"Part 1: {fuel}");
    System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
}

static void Part2()
{
    var input = File.ReadAllText(@".\input.txt").Split(',');
    var sw = System.Diagnostics.Stopwatch.StartNew();

    var positions = input.Select(int.Parse);
    var min = positions.Min();
    var max = positions.Max();
    var minFuel = int.MaxValue;

    for (var targetPos = min; targetPos <= max; targetPos++)
    {
        var currentFuel = 0;
        foreach (var startingPos in positions)
        {
            var difference = Math.Abs(targetPos - startingPos);
            currentFuel += TriangleNumber(difference);
            if (currentFuel > minFuel) break;
        }
        minFuel = Math.Min(minFuel, currentFuel);
    }

    sw.Stop();
    Console.WriteLine($"Part 2: {minFuel}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
}

static int TriangleNumber(int n)
{
    return (n * (n + 1)) / 2;
}

public static class CollectionExtensions
{
    public static T GetMedian<T>(this IEnumerable<T> collection)
    {
        var list = collection.ToList();
        list.Sort();
        return list[list.Count / 2];
    }
}
