using Xunit;

namespace TestProject;
public class ArrayAggregationTests
{
    [Theory]
    [InlineData(new[] { 5, 7, 16, 1, 2 }, 7)]
    [InlineData(new[] { 4, 5, 1, 2, 7 }, 1)]
    public void TestAggregation(int[] arrayValues, int expectedResult)
    {
        var result = arrayValues.CalculateValue();

        Assert.Equal(expectedResult, result);
    }
}

public static class Exts
{
    public static int[] SumAbs(this int[] source)
    {
        if (source.Length > 1)
        {
            return source
                .Skip(1)
                .Select((x, index) => Math.Abs(x - source[index]))
                .ToArray()
                .SumAbs();
        }
        else
        {
            return source;
        }
    }

    public static int CalculateValue(this int[] source)
    {
        var result = source.SumAbs().First();

        return result;
    }
}
