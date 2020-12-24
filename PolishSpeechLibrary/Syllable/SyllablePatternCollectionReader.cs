using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
using System;
using System.Data;
using System.IO;

namespace PolishSpeechLibrary.IO
{
    public class SyllablePatternCollectionReader
    {
        public SyllablePatternCollection ReadJson(string jsonContent)
        {
            return JsonConvert.DeserializeObject<SyllablePatternCollection>(jsonContent);
        }

        public SyllablePatternCollection ReadJsonFile(string jsonFilePath)
        {
            return ReadJson(File.ReadAllText(jsonFilePath));
        }

        public SyllablePatternCollection ReadDataSet(DataSet DataSet)
        {
            SyllablePatternCollection syllablePatterns = new SyllablePatternCollection();

            foreach (DataRow row in DataSet.Tables["SyllablePattern"].Rows)
            {
                var pattern = new SyllablePattern();
                ReadDataRow(row, pattern);
                syllablePatterns.Add(pattern);
            }

            return syllablePatterns;
        }

        public SyllablePatternCollection ReadDataSetXmlFile(string xmlFilePath)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFilePath);

            return ReadDataSet(dataSet);
        }

        public void ReadDataRow(DataRow Row, SyllablePattern pattern)
        {
            //ID = Convert.ToInt32(Row.ItemArray[0]);
            pattern.Pattern = Convert.ToString(Row.ItemArray[1]);
            pattern.StandardPattern = Convert.ToString(Row.ItemArray[2]);
            pattern.IsFactory = Convert.ToBoolean(Row.ItemArray[3]);
        }
    }
}