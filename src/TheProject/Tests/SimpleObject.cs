using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class SimpleObject
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new SimpleObjectTestCase
            {
                Int1 = 1,
                Double1 = 2.3,
                String1 = "slim shady",
            };

            var code = Instance.ToCode(instance);

            ApprovalTests.Approvals.Verify(code);
        }
    }

    public class SimpleObjectTestCase
    {
        public int Int1 { get; set; }
        public string String1 { get; set; }
        public double Double1 { get; set; }
    }
}
