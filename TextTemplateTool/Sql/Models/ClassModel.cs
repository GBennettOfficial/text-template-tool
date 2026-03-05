using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool.Sql.Models
{
    internal record ClassModel(string Name, List<PropertyModel> Properties, string? Schema = "dbo")
    {
        
    }
}
