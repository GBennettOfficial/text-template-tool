using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextTemplateTool.Sql.Models;

namespace TextTemplateTool.Sql.Services
{
    public class SqlStoredProcedureFileWriter
    {
        private readonly ClassModel _classModel;
        private readonly StoredProcedureBuilder _spb = new();
        public SqlStoredProcedureFileWriter(Type type, string schema = "dbo")
        {
            string name = type.Name;
            List<PropertyModel> propModels = new();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            for(int i = 0; i < props.Length; i++)
            {
                int? maxLen = null;
                var prop = props[i];
                if (prop.GetCustomAttribute<LengthAttribute>() is not null)
                {
                    maxLen = prop.GetCustomAttribute<LengthAttribute>()!.MaximumLength;
                }
                else if (prop.GetCustomAttribute<MaxLengthAttribute>() is not null)
                {
                    maxLen = prop.GetCustomAttribute<MaxLengthAttribute>()!.Length;
                }

                PropertyModel propModel = new(prop.Name, prop.PropertyType, maxLen);
                propModels.Add(propModel);
            }
            _classModel = new(name, propModels, schema);
        }

        public void WriteFind(string folder)
        {
            if (Directory.Exists(folder) == false)
                throw new Exception($"Directory {folder} does not exist.");

            var stream = File.OpenWrite($"{folder}\\usp_find_{SharedFunctions.ToSnakeCase(_classModel.Name)}.sql");
            using StreamWriter sw = new StreamWriter(stream);
            sw.Write(_spb.GetFind(_classModel, _classModel.Schema!));
        }

    }
}
