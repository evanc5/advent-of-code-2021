Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllText(@".\input.txt");
    var sw = System.Diagnostics.Stopwatch.StartNew();

    var rawFishList = input.Split(',').Select(int.Parse);
    var fishCounts = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };
    foreach (var fish in rawFishList)
    {
        fishCounts[fish]++;
    }

    for (int day = 0; day < 80; day++)
    {
        var newFish = fishCounts[0];
        fishCounts[0] = fishCounts[1];
        fishCounts[1] = fishCounts[2];
        fishCounts[2] = fishCounts[3];
        fishCounts[3] = fishCounts[4];
        fishCounts[4] = fishCounts[5];
        fishCounts[5] = fishCounts[6];
        fishCounts[6] = fishCounts[7];
        fishCounts[7] = fishCounts[8];
        fishCounts[6] += newFish;
        fishCounts[8] = newFish;
    }

    sw.Stop();
    Console.WriteLine($"Part 1: {fishCounts.Sum(v => v.Value)}");
    System.Diagnostics.Debug.WriteLine($"Part 1: {sw.Elapsed}");
}

static void Part2()
{
    var input = File.ReadAllText(@".\input.txt");
    var sw = System.Diagnostics.Stopwatch.StartNew();

    var rawFishList = input.Split(',').Select(int.Parse);
    var fishCounts = new Dictionary<int, long>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };
    foreach (var fish in rawFishList)
    {
        fishCounts[fish]++;
    }

    for (int day = 0; day < 256; day++)
    {
        var newFish = fishCounts[0];
        fishCounts[0] = fishCounts[1];
        fishCounts[1] = fishCounts[2];
        fishCounts[2] = fishCounts[3];
        fishCounts[3] = fishCounts[4];
        fishCounts[4] = fishCounts[5];
        fishCounts[5] = fishCounts[6];
        fishCounts[6] = fishCounts[7];
        fishCounts[7] = fishCounts[8];
        fishCounts[6] += newFish;
        fishCounts[8] = newFish;
    }

    sw.Stop();
    Console.WriteLine($"Part 2: {fishCounts.Sum(v => v.Value)}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {sw.Elapsed}");
}
