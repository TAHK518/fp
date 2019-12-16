﻿using CommandLine;
using TagsCloud.SupportedTypes;

namespace TagCloudCLI
{
    class Options
    {
        [Value(0, Required = true, HelpText = "Input files with words.")]
        public string InputFiles { get; set; }

        [Value(1, Required = true, HelpText = "Result file.")]
        public string savePath { get; set; }

        [Option('w', "width", Default = 1920, HelpText = "Width result image.")]
        public int width { get; set; }

        [Option('h', "height", Default = 1080, HelpText = "Height result image.")]
        public int height { get; set; }

        [Option('b', "backgroundColor", Default = "White", HelpText = "Background color.")]
        public string backgroundColor { get; set; }

        [Option('f', "font", Default = "Comic Sans MS", HelpText = "Font name.")]
        public string fontName { get; set; }

        [Option('s', "spliter", Default = TextSpliter.WhiteSpace, HelpText = "Split by line or white space. (Line || WhiteSpace)")]
        public TextSpliter splitType { get; set; }

        [Option('a', "boringWords", Default = "", HelpText = "Path to file with boring words. Words must be separated by line.")]
        public string boringWordsPath { get; set; }

        [Option('i', "ignoredPartsOfSpeech", Default = "ADVPRO,APRO,CONJ,INTJ,PR,PART,SPRO", HelpText = "Parts of speech to be excluded. " +
            "Possible parts: A, ADV, ADVPRO, ANUM, APRO, COM, CONJ, INTJ, NUM, PART, PR, S, SPRO, V.")]
        public string ignoredPartsOfSpeech { get; set; }

        [Option('g', "GenerationAlgorithm", Default = GenerationsAlghoritm.CircularCloud, HelpText = "Which alghorithm will be used to generate the cloud. " +
            "(CircularCloud || MiddleCloud)")]
        public GenerationsAlghoritm GenerationAlghoritm { get; set; }

        [Option('c', "ColorScheme", Default = ColorSchemes.RandomColor, HelpText = "Color scheme of result cloud." +
            "(RandomColor || RedGreenBlueScheme)")]
        public ColorSchemes ColorScheme { get; set; }
    }
}
