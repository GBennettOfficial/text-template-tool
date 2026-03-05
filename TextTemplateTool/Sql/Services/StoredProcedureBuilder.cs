using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTemplateTool.Sql.Models;

namespace TextTemplateTool.Sql.Services
{
    internal class StoredProcedureBuilder
    {
        public string GetFind(ClassModel classModel, string schema = "dbo")
        {
            string idSql = SharedFunctions.ToSqlType(classModel.Properties.First(x => x.Name == "Id").Type, null);

            StringBuilder sb = new();
            sb.AppendLine($"CREATE PROCEDURE [{schema}].[usp_find_{SharedFunctions.ToSnakeCase(classModel.Name)}]");
            sb.AppendLine($"    @Id {idSql}");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    SELECT (");
            for(int i = 0; i < classModel.Properties.Count; i++)
            {
                var prop = classModel.Properties[i];
                sb.Append("        " + prop.Name);
                if (i < classModel.Properties.Count - 1)
                    sb.Append(", ");
                sb.AppendLine();
            }
            sb.AppendLine("    )");
            sb.AppendLine($"    FROM [{classModel.Schema}].[{classModel.Name}]");
            sb.AppendLine("    WHERE Id = @Id;");
            sb.AppendLine("END;");
            sb.AppendLine("RETURN 0;");

            return sb.ToString();

        }
    }
}
