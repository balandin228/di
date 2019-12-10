﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TagCloud
{
    public class WordsHandler : IWordsHandler
    {
        public Dictionary<string, int> Conversion(Dictionary<string, int> wordsAndCount)
        {
            var boringWords = File.ReadAllLines($"{GetCurrentDirectoryPath()}\\BoringWords.txt")
                .Select(s => s.ToLower())
                .ToHashSet();

            return wordsAndCount
                .Select(p => new KeyValuePair<string, int>(p.Key.ToLower(), p.Value))
                .Where(p => !boringWords.Contains(p.Key))
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public Dictionary<string, int> GetWordsAndCount(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файла не существует");
            if (path == null)
                throw new ArgumentNullException("Путь к файлу не введен");
            return File.ReadAllLines(path, Encoding.UTF8)
                .Where(s => s != string.Empty)
                .GroupBy(word => word)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        private string GetCurrentDirectoryPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }
    }
}