﻿using System;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using TagsCloud.Spliters;

namespace TagsCloudTests
{
    class SpliterByWhiteSpace_Should
    {
        private SpliterByWhiteSpace spliterByWhiteSpace;

        [SetUp]
        public void SetUp()
        {
            spliterByWhiteSpace = new SpliterByWhiteSpace();
        }

        [Test]
        public void SplitText_Should_SplitStringByEnviromentNewLine()
        {
            var words = new List<string>() { "съешь", "ещё", "этих", "мягких", "французских", "булок", "да", "выпей", "чаю" };
            var inputString = "съешь:ещё!этих,мягких.французских!булок?да.выпей:чаю";
            var result = spliterByWhiteSpace.SplitText(inputString);
            result.IsSuccess.Should().BeTrue();
            result.GetValueOrThrow().Should().BeEquivalentTo(words);
        }

        [Test]
        public void SplitText_Should_RemoveEmptyLines()
        {
            var wordsWithoutEmptyLines = new List<string>() { "съешь", "ещё", "этих", "мягких", "французских", "булок", "да", "выпей", "чаю" };
            var inputString = "съешь ещё! " + Environment.NewLine +
                " !" + Environment.NewLine +
                "этих мягких французских булок? " + Environment.NewLine +
                "да. " + Environment.NewLine +
                "выпей" + Environment.NewLine +
                ":" + Environment.NewLine +
                "чаю";
            var result = spliterByWhiteSpace.SplitText(inputString);
            result.IsSuccess.Should().BeTrue();
            result.GetValueOrThrow().Should().BeEquivalentTo(wordsWithoutEmptyLines);
        }

        [Test]
        public void SplitText_Should_ReturnResultFail_When_InputTextEqualNull()
        {
            var result = spliterByWhiteSpace.SplitText(null);
            result.IsSuccess.Should().BeFalse();
        }
    }
}
