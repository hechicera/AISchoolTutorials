using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using myMLNET.Common.Models;
using myMLNET.Common.Utils;

namespace myMLNET
{
    class LinearRegression
    {
        private static readonly string TrainDataPath = Path.Combine(Environment.CurrentDirectory,"data", "chocolate-data.txt");
        
        static void Main(string[] args)
        {
            /* Add ML Context */
            MLContext mlContext = new MLContext();
            
            /* Create TextLoader */
            // Define a reader: specify the data columns, types, and where to find them in the text file
            var reader = mlContext.Data.CreateTextLoader(
                columns: new TextLoader.Column[]
                {
                    new TextLoader.Column("CocoaPercent", DataKind.Single, 1),
                    new TextLoader.Column("Label", DataKind.Single, 4)
                },
                // First line of the file is a header, not a data row
                hasHeader: true
            );

            /* Print out data */
            // Create a preview and print out like a CSV
            var trainingData = reader.Load(TrainDataPath);
            var preview = trainingData.Preview(10);
            Console.WriteLine($"******************************************");
            Console.WriteLine($"Loaded training data: {preview.ToString()}");
            Console.WriteLine($"******************************************");
            foreach (var columnInfo in preview.ColumnView)
            {
                Console.Write($"{columnInfo.Column.Name},");
            }
            Console.WriteLine();
            foreach (var rowInfo in preview.RowView)
            {
                foreach(var row in rowInfo.Values) {
                    Console.Write($"{row.Value},");
                }
                Console.WriteLine();
            }
            /* Create pipeline */

            /* Train the model */

            /* Get the prediction */

            /* Generate graph */

            Console.ReadKey();
        }

        public class ChocolateInput
        {
            public float CocoaPercent { get; set; }

            public float Weight { get; set; }
        }

        public class ChocolateOutput
        {
            [ColumnName("Score")]
            public float CustomerHappiness { get; set; }
        }
    }
}
