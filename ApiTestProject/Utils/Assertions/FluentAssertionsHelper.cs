using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Fluent Assertion helper methods
    /// </summary>
    public class FluentAssertionsHelper
    {
        /// <summary>
        /// Compare actual and expected model
        /// </summary>
        /// <param name="actualModel"></param>
        /// <param name="expectedModel"></param>
        public static void AssertJsonModel(Object actualModel, Object expectedModel)
        {
            JToken expected= JToken.FromObject(expectedModel);
            JToken actual= JToken.FromObject(actualModel);
            actual.Should().BeEquivalentTo(expected);
        }

        /// <summary>
        /// Conpare actual and expected strings
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public static void AssertStrings(string actual, string expected)
        {
            actual.Should().Be(expected);
        }

        /// <summary>
        /// Compare actual and expected numbers
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public static void AssertNumbers(int actual, int expected)
        {
            actual.Should().Be(expected);
        }
    }
}
