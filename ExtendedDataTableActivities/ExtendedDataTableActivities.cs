using ExtendedDataTableActivities.Lib;
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


    public class MaximumInColumn : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<int> ColumnIndex { get; set; }


        [Category("Output")]
        [RequiredArgument]
        public OutArgument<double> MaximumValue { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var inputDataTable = InputDataTable.Get(context);
            var columnIndex = ColumnIndex.Get(context);
            double result = Utils.ColumnActionOnDataTable(inputDataTable, columnIndex, "MAX");
            MaximumValue.Set(context, result);
        }
    }

    public class SumOfColumn : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<int> ColumnIndex { get; set; }


        [Category("Output")]
        [RequiredArgument]
        public OutArgument<double> SumValue { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var inputDataTable = InputDataTable.Get(context);
            var columnIndex = ColumnIndex.Get(context);
            double result = Utils.ColumnActionOnDataTable(inputDataTable, columnIndex, "SUM");
            SumValue.Set(context, result);
        }
    }


    public class MinimumInColumn : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<int> ColumnIndex { get; set; }


        [Category("Output")]
        [RequiredArgument]
        public OutArgument<double> MinimumValue { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var inputDataTable = InputDataTable.Get(context);
            var columnIndex = ColumnIndex.Get(context);
            double result = Utils.ColumnActionOnDataTable(inputDataTable, columnIndex, "MIN");
            MinimumValue.Set(context, result);
        }
    }

    public class AverageInColumn : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> InputDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<int> ColumnIndex { get; set; }


        [Category("Output")]
        [RequiredArgument]
        public OutArgument<double> AverageValue { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var inputDataTable = InputDataTable.Get(context);
            var columnIndex = ColumnIndex.Get(context);
            double result = Utils.ColumnActionOnDataTable(inputDataTable, columnIndex, "AVG");
            AverageValue.Set(context, result);
        }
    }

}
