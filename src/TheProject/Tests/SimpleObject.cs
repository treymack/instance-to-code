using System;
using System.Linq;
using ApprovalTests;
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
                Date1 = new DateTime(2012, 1, 2, 3, 4, 50),
                NullDate2 = null,
                NullableDate3 = new DateTime(2012, 2, 3, 4, 5, 50),
                Decimal1 = 1.23m,
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }

    public class SimpleObjectTestCase
    {
        public int Int1 { get; set; }
        public string String1 { get; set; }
        public double Double1 { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime? NullDate2 { get; set; }
        public DateTime? NullableDate3 { get; set; }
        public decimal Decimal1 { get; set; }
    }
}
