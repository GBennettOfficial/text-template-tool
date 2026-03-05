using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool.Sql.Models
{
    internal record PropertyModel(string Name, Type Type, IReadOnlyList<string> AttributeData)
    {
        public string SqlType => SharedFunctions.ToSqlType(Type);
        public string SqlNull => Nullable.GetUnderlyingType(Type) != null ? "NULL" : "NOT NULL";
    }
}
