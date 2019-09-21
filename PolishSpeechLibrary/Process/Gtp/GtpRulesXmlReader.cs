using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PolishSpeechLibrary.Process.Gtp
{
    public class GtpRulesXmlReader
    {
        DataSet dataSetGtpDatabase;
        DataTable dataTableGtpRule;
        DataColumn dataColumnGrapheme;
        DataColumn dataColumnPrecedingContext;
        DataColumn dataColumnFollowingContext;
        DataColumn dataColumnPhoneme;

        public GtpRulesXmlReader()
        {
            Initialize();
        }

        private void Initialize()
        {
            dataSetGtpDatabase = new DataSet();
            dataTableGtpRule = new DataTable();
            dataColumnGrapheme = new DataColumn();
            dataColumnPrecedingContext = new DataColumn();
            dataColumnFollowingContext = new DataColumn();
            dataColumnPhoneme = new DataColumn();
            ((System.ComponentModel.ISupportInitialize)(dataSetGtpDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataTableGtpRule)).BeginInit();
            
            // 
            // dataSetGtpDatabase
            // 
            dataSetGtpDatabase.DataSetName = "GtpDatabase";
            dataSetGtpDatabase.Tables.AddRange(new DataTable[] { dataTableGtpRule });
            
            // 
            // dataTableGtpRule
            // 
            dataTableGtpRule.Columns.AddRange(new DataColumn[] {
                dataColumnGrapheme,
                dataColumnPrecedingContext,
                dataColumnFollowingContext,
                dataColumnPhoneme
            });
            dataTableGtpRule.Constraints.AddRange(new Constraint[] {
            new UniqueConstraint("Constraint1", new string[] {
                        "FollowingContext",
                        "Grapheme",
                        "PrecedingContext"}, true)});
            dataTableGtpRule.PrimaryKey = new DataColumn[] {
                dataColumnFollowingContext,
                dataColumnGrapheme,
                dataColumnPrecedingContext
            };
            dataTableGtpRule.TableName = "GtpRule";

            // 
            // dataColumnGrapheme
            // 
            dataColumnGrapheme.AllowDBNull = false;
            dataColumnGrapheme.ColumnMapping = MappingType.Attribute;
            dataColumnGrapheme.ColumnName = "Grapheme";
            dataColumnGrapheme.MaxLength = 10;

            // 
            // dataColumnPrecedingContext
            // 
            dataColumnPrecedingContext.AllowDBNull = false;
            dataColumnPrecedingContext.ColumnMapping = MappingType.Attribute;
            dataColumnPrecedingContext.ColumnName = "PrecedingContext";
            dataColumnPrecedingContext.MaxLength = 50;

            // 
            // dataColumnFollowingContext
            // 
            dataColumnFollowingContext.AllowDBNull = false;
            dataColumnFollowingContext.ColumnMapping = MappingType.Attribute;
            dataColumnFollowingContext.ColumnName = "FollowingContext";
            dataColumnFollowingContext.MaxLength = 50;

            // 
            // dataColumnPhoneme
            // 
            dataColumnPhoneme.AllowDBNull = false;
            dataColumnPhoneme.ColumnMapping = MappingType.Attribute;
            dataColumnPhoneme.ColumnName = "Phoneme";
            dataColumnPhoneme.MaxLength = 10;
            ((System.ComponentModel.ISupportInitialize)(dataSetGtpDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataTableGtpRule)).EndInit();
        }

        public IList<GtpRule>LoadGtpRules(string xmlFilePath)
        {
            var gtpRules = new List<GtpRule>();

            dataSetGtpDatabase.Clear();
            dataSetGtpDatabase.ReadXml(xmlFilePath);

            foreach (DataRow row in dataTableGtpRule.Rows)
            {
                GtpRule rule = new GtpRule
                {
                    Grapheme = row[dataColumnGrapheme].ToString(),
                    PrecedingContext = row[dataColumnPrecedingContext].ToString(),
                    FollowingContext = row[dataColumnFollowingContext].ToString(),
                    Phoneme = row[dataColumnPhoneme].ToString()
                };
                gtpRules.Add(rule);
            }

            return gtpRules;
        }
    }
}
