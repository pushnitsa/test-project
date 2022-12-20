using Xunit;

namespace TestProject;
public class StarRatingTests
{

    [Theory]
    [InlineData("0.34", "half empty empty empty empty")]
    [InlineData("0.94", "half empty empty empty empty")]
    [InlineData("1.34", "full half empty empty empty")]
    [InlineData("2.34", "full full half empty empty")]
    [InlineData("3.34", "full full full half empty")]
    [InlineData("4.34", "full full full full half")]
    [InlineData("5", "full full full full full")]
    [InlineData("5.12", "full full full full full")]
    [InlineData("55646486", "full full full full full")]
    [InlineData("badData", "empty empty empty empty empty")]
    [InlineData(null, "empty empty empty empty empty")]
    [InlineData("-246466", "empty empty empty empty empty")]
    [InlineData("-79228162514264337593543950335", "empty empty empty empty empty")]
    [InlineData("1231231279228162514264337593543950335", "empty empty empty empty empty")]
    public void RateStarTests(string rating, string expected)
    {
        var result = StarRate(rating);

        Assert.Equal(expected, result);
    }

    string StarRate(string rating)
    {
        if (!decimal.TryParse(rating, out var decimalRating) || decimalRating < 0)
        {
            decimalRating = 0M;
        }

        const int starCount = 5;
        var result = new string[starCount];

        for (var i = 0; i < starCount; i++)
        {
            var currentStar = decimalRating - i;

            var starString = currentStar switch
            {
                >= 1 => "full",
                > 0 => "half",
                _ => "empty"
            };

            result[i] = starString;
        }

        return string.Join(' ', result);
    }
}
