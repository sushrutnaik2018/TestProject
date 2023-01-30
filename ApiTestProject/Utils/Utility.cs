using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    internal class Utility
    {
        /// <summary>
        /// Method to retrive current directory location for project
        /// </summary>
        /// <returns>current directory location</returns>
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
    }
}
