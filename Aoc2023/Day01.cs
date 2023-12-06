namespace Aoc2023;

public sealed class Day01 : AoCHelper.BaseDay
{
    private readonly string[] _input;

    private readonly Dictionary<string, int> _numberMap = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>($"{Part_1()}");
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>($"{Part_2()}");
    }

    private int Part_1()
    {
        var result = 0;

        foreach (var item in _input)
        {
            var firstVal = item.First(ch => int.TryParse(ch.ToString(), out _));
            var lastVal = item.Last(ch => int.TryParse(ch.ToString(), out _));

            result += int.Parse($"{firstVal}{lastVal}");
        }

        return result;
    }

    private int Part_2()
    {
        var result = 0;

        foreach (var item in _input)
        {
            var charList = new List<char>();
            int firstVal = 0;
            
            foreach (var ch in item)
            {

                if (int.TryParse(ch.ToString(), out var value))
                {
                    firstVal = value;
                    break;
                }

                charList.Add(ch);
                var str = string.Concat(charList);

                foreach (var i in _numberMap)
                {
                    if (str.Contains(i.Key))
                    {
                        firstVal = i.Value;
                        charList.Clear();
                        break;
                    }
                }

                if (firstVal > 0)
                {
                    break;
                }

            }

            int lastVal = 0;

            var reversed = string.Concat(item.Reverse());
            foreach (var ch in reversed)
            {
                if (int.TryParse(ch.ToString(), out var value))
                {
                    lastVal = value;
                    break;
                }

                charList.Insert(0, ch);
                var str = string.Concat(charList);

                foreach (var i in _numberMap)
                {
                    if (str.Contains(i.Key))
                    {
                        lastVal = i.Value;
                        charList.Clear();
                        break;
                    }
                }

                if (lastVal > 0)
                {
                    break;
                }

            }
            
            result += int.Parse($"{firstVal}{lastVal}");
        }

        return result;
    }
}