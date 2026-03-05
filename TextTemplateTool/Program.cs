// See https://aka.ms/new-console-template for more information
using TextTemplateTool.Sql.Models;
using TextTemplateTool.Sql.Services;

Console.WriteLine("Hello, World!");

SqlStoredProcedureFileWriter builder = new(typeof(SalesRecord), "dbo");

builder.WriteFind("");