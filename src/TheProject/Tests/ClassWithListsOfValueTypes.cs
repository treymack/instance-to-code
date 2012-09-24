using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
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
                NullArray = null,
                Array1 = new int[] { 1, 2 },
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }
  
    public class ValueListsClass
    {
        public List<int> Ints { get; set; }
        public List<string> Strings { get; set; }
        public int[] NullArray { get; set; }
        public int[] Array1 { get; set; }
    }
}
