using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class NullProperties
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new NullPropertiesTestCase();

            var code = Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }

    public class NullPropertiesTestCase
    {
        public DateTime? NullableDateTime { get; set; }
        public string String1 { get; set; }
        public NullPropertiesTestCase2 TestCase2 { get; set; }
    }
  
    public class NullPropertiesTestCase2
    {
    }
}
