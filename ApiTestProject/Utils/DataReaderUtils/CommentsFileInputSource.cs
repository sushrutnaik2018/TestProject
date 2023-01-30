using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Test Data source setup for Comments tests
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommentsFileInputSource<T> : JsonFileInputParamsBase<T>
    {
        protected override string FileName => "Comments";
        protected override string DataFilesSubFolder => "Data";

    }
}
