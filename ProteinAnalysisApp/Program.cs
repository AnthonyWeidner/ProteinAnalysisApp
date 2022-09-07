// See https://aka.ms/new-console-template for more information


using System.Data;
using ExcelDataReader;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Reading Protein Details");


        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        FileStream stream = File.Open(@"/Users/AnthonyWeidner/Downloads/SpNlibr_QizhiSwab-7ToF5iul22_quan.xlsx", FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();

        while (excelReader.Read())
        {
            int i = 0;
            Boolean exceptionHasOccurred = false;

            // Each while loop reads the first i+1 columns for each line in the Excel file
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
                if (i == 2)
                {
                    exceptionHasOccurred = true;
                }
            }
              
           
        };

        
    }

}