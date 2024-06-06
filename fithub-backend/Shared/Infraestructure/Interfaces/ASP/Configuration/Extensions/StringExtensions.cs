﻿using System.Text.RegularExpressions;

namespace fithub_backend.Shared.Infraestructure.Interfaces.ASP.Configuration.Extensions.Extensions;

public static partial class StringExtensions
{
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }

    [GeneratedRegex("(?<!ˆ)([A-Z)[a-z] | (?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}