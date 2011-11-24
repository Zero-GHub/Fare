﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using Rex;
using Xunit;
using Xunit.Extensions;

namespace Fare.Tests.Integration.Rex
{
    public class RexEngineTests
    {
        [Theory]
        [ClassData(typeof(RegexPatternTestCases))]
        public void GeneratedTextWithRexIsCorrect(string pattern)
        {
            var settings = new RexSettings(pattern) { encoding = CharacterEncoding.ASCII };
            var result = Enumerable.Range(1, 3).Select(i => RexEngine.GenerateMembers(settings).Single()).ToArray();
            Array.ForEach(result, regex => Assert.True(Regex.IsMatch(regex, pattern)));
        }
    }
}