using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool.Sql.Models
{
    internal record SalesRecord(int Id, string ProductName, int Quantity, decimal Price, DateTime SaleDate, string? Overseer)
    {
        

    }
}
