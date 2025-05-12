using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmen
{
    public class Vocabulary
    {
        List<string> _strings = new List<string>();

        public string Process(string stringToBeProcessed)
        {
            if (stringToBeProcessed == "105")
                return "";

            if (stringToBeProcessed != "")
                _strings.Add(stringToBeProcessed);

            return _strings[new Random().Next(_strings.Count)];
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string s in _strings)
                {
                    writer.WriteLine(s);
                }
            }
        }

        public void ReadFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string s;

                while ((s = reader.ReadLine()) != null)
                {
                    _strings.Add(s);
                }
            }
        }
    }
}
