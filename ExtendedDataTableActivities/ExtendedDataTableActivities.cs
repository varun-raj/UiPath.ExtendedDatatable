using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDataTableActivities
{
    public class GetColumnValuesAsArray : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ColumnName { get; set; }

        [Category("Output")]
        [RequiredArgument]
        public OutArgument<string[]> ResultArray { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var inputDataTable = InputDataTable.Get(context);
            var columnName = ColumnName.Get(context);
            var result = inputDataTable.AsEnumerable().Select(r => r.Field<string>(columnName)).ToArray();
            ResultArray.Set(context, result);
        }
    }

    public class GetColumnHeaders: CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }


        [Category("Output")]
        [RequiredArgument]
        public OutArgument<string[]> ResultArray { get; set; }

        protected override void Execute(CodeActivityContext context)
        {   
            var inputDataTable = InputDataTable.Get(context);
            int totalColumns = inputDataTable.Columns.Count;
            string[] result = new string[totalColumns];
            for (int i = 0; i < totalColumns; i++)
            {
                result[i] = inputDataTable.Columns[i].ColumnName.ToString();
            }
            ResultArray.Set(context, result.ToArray());
        }
    }


}
