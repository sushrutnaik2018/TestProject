using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Test Data source setup for Posts tests
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PostsFileInputSource<T> : JsonFileInputParamsBase<T>
    {
        protected override string FileName => "Posts";  
        protected override string DataFilesSubFolder => "Data";

    }
}
