using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDataTableActivities.Lib
{
    class Utils
    {
        public static double ColumnActionOnDataTable(DataTable dataTable, int columnIndex, string operation)
        {
            int totalColumns = dataTable.Columns.Count;
            double result = 0;

            if (totalColumns > columnIndex)
            {
                switch (operation)
                {
                    case "SUM":
                        return dataTable.AsEnumerable().Sum(x => HandlerFunction(x, columnIndex));
                    case "MAX":
                        return dataTable.AsEnumerable().Max(x => HandlerFunction(x, columnIndex));
                    case "MIN":
                        return dataTable.AsEnumerable().Min(x => HandlerFunction(x, columnIndex));
                    case "AVG":
                        return dataTable.AsEnumerable().Average(x => HandlerFunction(x, columnIndex));
                }

            }
            else
            {
                throw new Exception("Column Index Not Found");
            }

            return result;
        }

         private static double HandlerFunction(DataRow x, int columnIndex)
        {
            double value;
            try
            {
                value = Convert.ToDouble(x[columnIndex].ToString());
            }
            catch (Exception)
            {
                value = 0;
            }
            return value;
        }
    }
}
