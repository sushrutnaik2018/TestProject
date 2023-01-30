using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Base class for Json Test data sources
    /// </summary>
    /// <typeparam name="TTestCaseParams"></typeparam>
    public class JsonFileInputParamsBase<TTestCaseParams> : IEnumerable
    {
        protected virtual string DataFilesSubFolder => "TestDataFiles";

        protected virtual string FileName => "TestInputs";

        /// <summary>
        /// Get test data file location
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string GetFilePath()
        {
            string directoryName = Path.Combine(Utility.GetProjectRootDirectory(), DataFilesSubFolder);

            if (directoryName == null)
                throw new Exception("Couldn't get assembly directory");

            return Path.Combine(directoryName, $"{FileName}.json");
        }

        /// <summary>
        /// Load Json test data file
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var testFixtureParams = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(GetFilePath()));
            var genericItems = testFixtureParams[$"{typeof(TTestCaseParams).Name}"].ToObject<IEnumerable<TTestCaseParams>>();

            foreach (var item in genericItems)
            {
                yield return new object[] { item };
            }
        }
    }
}
