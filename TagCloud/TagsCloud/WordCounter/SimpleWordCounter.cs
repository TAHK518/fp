﻿using System.Collections.Generic;
using System.Linq;
using TagsCloud.ErrorHandling;

namespace TagsCloud.WordCounter
{
    public class SimpleWordCounter
    {
        public Result<Dictionary<string, int>> GetWordsStatistics(IEnumerable<string> words)
        {
            return Result.Of(() =>
                words.GroupBy(word => word).ToDictionary(group => group.Key, group => group.Count()));
        }
    }
}