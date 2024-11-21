using System;

public class NumberConverter
{
    public static string Convert(decimal number)
    {
        string[] suffixes = { "", "k", "M", "B", "T" };

        if (number == 0) return "0";

        int sign = Math.Sign(number);
        decimal num = Math.Abs(number);
        int suffixIndex = 0;

        while (num >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            num /= 1000;
            suffixIndex++;
        }

        return $"{sign * num:F2}{suffixes[suffixIndex]}";
    }
}