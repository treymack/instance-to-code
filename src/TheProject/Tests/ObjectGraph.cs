using System;
using System.Linq;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class ObjectGraph
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new User2
            {
                Name = "Trey",
                Address = new Address2
                {
                    AddressLine1 = "123 My Street",
                },
                Personality = new Personality2
                {
                    PersonalityDescriptor = "Intense",
                },
                ByteArray = new byte[] { 1, 2, 3 },
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }
  
    public class User2
    {
        public string Name { get; set; }
        public Address2 Address { get; set; }
        public Personality2 Personality { get; set; }
        public byte[] ByteArray { get; set; }
    }

    public class Address2
    {
        public string AddressLine1 { get; set; }
    }

    public class Personality2
    {
        public string PersonalityDescriptor { get; set; }
    }
}
