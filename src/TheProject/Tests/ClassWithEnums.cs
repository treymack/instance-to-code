using System;
using System.Linq;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class ClassWithEnums
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new EnumClass
            {
                Enum1 = Enum1.Value1,
                Enum2 = Enum2.Value2,
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }

    public enum Enum2
    {
        Value1,
        Value2,
    }

    public enum Enum1
    {
        Value1,
    }

    public class EnumClass
    {
        public Enum1 Enum1 { get; set; }
        public Enum2 Enum2 { get; set; }
    }
}
