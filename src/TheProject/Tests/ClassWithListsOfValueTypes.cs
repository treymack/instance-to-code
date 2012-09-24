using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class ClassWithListsOfValueTypes
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new ValueListsClass
            {
                Ints = new List<int> { 1, 2, 3 },
                Strings = new List<string> { "one", "two", "three" },
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }
  
    public class ValueListsClass
    {
        public List<int> Ints { get; set; }
        public List<string> Strings { get; set; }
    }
}
