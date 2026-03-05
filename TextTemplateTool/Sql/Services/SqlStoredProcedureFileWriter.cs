using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTemplateTool.Sql.Services
{
    public class SqlStoredProcedureFileWriter
    {
        private readonly Type _type;
        private readonly StoredProcedureBuilder _spb = new();
        public SqlStoredProcedureFileWriter(Type type)
        {
            _type = type;
        }

        public void WriteFind(string folder, string schema, string name = "")
        {

        }

    }
}
