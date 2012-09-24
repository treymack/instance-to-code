using System;
using System.Linq;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class NestedClass
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new NestedClassTestCase();

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }

        public class NestedClassTestCase
        {
        }
    }
}
