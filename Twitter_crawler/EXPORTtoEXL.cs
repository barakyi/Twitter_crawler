using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApplication3
{
    class EXPORTtoEXL
    {


              public EXPORTtoEXL(System.Data.DataTable table,string S)
              {
                     
                  
                  WriteToCsvFile(table, S);


              }

              private void WriteToCsvFile(System.Data.DataTable table, string filePath)
{
 	 StringBuilder fileContent = new StringBuilder();

     foreach (var col in table.Columns)
     {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);



            foreach (DataRow dr in table.Rows)
            {

                foreach (var column in dr.ItemArray) {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());

        
}





       
        
    }


}
