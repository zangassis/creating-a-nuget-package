using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Dango.BlogUtils;

public static class SlugGen
{
    public static string GenerateSlug(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string normalized = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        result = Regex.Replace(result.ToLowerInvariant(), @"[^a-z0-9\s-]", "");
        result = Regex.Replace(result, @"\s+", "-").Trim('-'); 
        result = Regex.Replace(result, @"-+", "-");

        return result;
    }
}
