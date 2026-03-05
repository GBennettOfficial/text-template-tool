using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool.Sql.Models
{
    internal record PropertyModel(string Name, Type Type, int? MaxLength = null)
    {
        public string SqlType => SharedFunctions.ToSqlType(Type, MaxLength);
        public string SqlNull => Nullable.GetUnderlyingType(Type) != null ? "NULL" : "NOT NULL";
    }
}
