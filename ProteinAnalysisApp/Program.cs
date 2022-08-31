// See https://aka.ms/new-console-template for more information


using System.Data;
using ExcelDataReader;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Reading Protein Details");


        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        FileStream stream = File.Open(@"/Users/AnthonyWeidner/Desktop/SampleExcelFile.xlsx", FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();

        while (excelReader.Read())
        {
            int i = 0;
            Boolean exceptionHasOccurred = false;
            while (!exceptionHasOccurred)
            {

                try
                {
                    var nextChunk = excelReader.GetString(i);
                    Console.WriteLine(nextChunk);
                    ++i;
                }
                catch
                {
                    exceptionHasOccurred = true;
                }
            }
              
           
        };

        
    }

}