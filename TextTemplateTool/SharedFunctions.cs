using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool
{
    internal class SharedFunctions
    {
        public static string ToSnakeCase(string pascal)
        {
            if (string.IsNullOrEmpty(pascal))
                return pascal;

            var sb = new StringBuilder();

            for (int i = 0; i < pascal.Length; i++)
            {
                char c = pascal[i];

                if (char.IsUpper(c))
                {
                    // Add underscore if not the first character
                    // and previous char is not uppercase (handles acronyms)
                    if (i > 0 && !char.IsUpper(pascal[i - 1]))
                        sb.Append('_');

                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();

        }
        public static string ToSqlType(Type type, int? varcharSize)
        {
            bool isNullable = Nullable.GetUnderlyingType(type) != null;
            string strIsNullable = isNullable ? " NULL" : "";
            type = Nullable.GetUnderlyingType(type) ?? type;

            if (type == typeof(string))
                return $"VARCHAR({varcharSize?.ToString() ?? "255"})" + strIsNullable;

            else if (type == typeof(int))
                return "INT" + strIsNullable;

            else if (type == typeof(long))
                return "BIGINT" + strIsNullable;

            else if (type == typeof(bool))
                return "BIT" + strIsNullable;

            else if (type == typeof(decimal))
                return "DECIMAL(18,2)" + strIsNullable;

            else if (type == typeof(double))
                return "FLOAT" + strIsNullable;

            else if (type == typeof(float))
                return "REAL" + strIsNullable;

            else if (type == typeof(DateTime))
                return "DATETIME" + strIsNullable;

            else if (type == typeof(Guid))
                return "UNIQUEIDENTIFIER" + strIsNullable;

            else if (type == typeof(byte[]))
                return "VARBINARY(MAX)" + strIsNullable;

            else if (type == typeof(short))
                return "SMALLINT" + strIsNullable;

            else if (type == typeof(byte))
                return "TINYINT" + strIsNullable;

            else if (type == typeof(TimeSpan))
                return "TIME" + strIsNullable;

            return "VARCHAR(255)";
        }
    }
}
