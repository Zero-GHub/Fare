﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Extensions;

namespace Fare.Tests.Integration
{
    /// <summary>
    /// Regex pattern test cases for Xeger (.NET port through Fare package).
    /// </summary>
    public sealed class XegerTests
    {
        [Theory]
        [ClassData(typeof(RegexPatternTestCases))]
        public void GeneratedTextIsCorrect(string pattern)
        {
            var sut = new Fare.Xeger(pattern);
            var result = Enumerable.Range(1, 3).Select(i => sut.Generate()).ToArray();
            Array.ForEach(result, regex => Assert.True(Regex.IsMatch(regex, pattern)));
        }
    }
}