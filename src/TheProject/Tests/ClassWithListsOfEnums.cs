using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class ClassWithListsOfEnums
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new EnumListClass
            {
                EnumList1 = new List<Enum1>
                {
                    { Enum1.Value1 },
                    { Enum1.Value1 },
                },
                EnumList2 = new List<Enum2>
                {
                    { Enum2.Value2 },
                    { Enum2.Value1 },
                },
                EmptyList = new List<Enum1> { },
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }
  
    public class EnumListClass
    {
        public List<Enum1> EnumList1 { get; set; }
        public List<Enum2> EnumList2 { get; set; }
        public List<Enum1> EmptyList { get; set; }
    }
}
