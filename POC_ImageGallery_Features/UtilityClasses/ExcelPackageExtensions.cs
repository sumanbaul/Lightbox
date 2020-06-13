using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POC_ImageGallery_Features.UtilityClasses
{
    public static class ExcelPackageExtensions
    {
        public static DataTable ToDatatable(this ExcelPackage package)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            DataTable dt = new DataTable();
            foreach (var firstRowcell in worksheet.Cells[10, 1, 1, worksheet.Dimension.End.Column])
            {
                dt.Columns.Add(firstRowcell.Text);
            }
            for (var rownumber = 11; rownumber <= worksheet.Dimension.End.Row; rownumber++)
            {
                var row = worksheet.Cells[rownumber, 1, rownumber, worksheet.Dimension.End.Column];

                var newrow = dt.NewRow();

                foreach (var cell in row)
                {

                    newrow[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(newrow);
            }

            //get datatable without empty rows 
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow currentRow = dt.Rows[i];
                if (String.IsNullOrEmpty(currentRow.ItemArray[0].ToString()))
                {
                    dt.Rows[i].Delete();
                }

            }
            return dt;

        }


    }
}