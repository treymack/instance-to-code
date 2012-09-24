using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    public class ClassWithListsOfOtherClasses
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new ClassListClass
            {
                Users = new List<User2>
                {
                    new User2
                    {
                        Name = "tmack",
                        Address = new Address2{
                            AddressLine1 = "line1",
                        },
                        Personality = new Personality2
                        {
                            PersonalityDescriptor = "awesome",
                        },
                    },
                    new User2
                    {
                        Personality = new Personality2
                        {
                            PersonalityDescriptor = "blank",
                        },
                    }
                },
                Addresses = new List<Address2> { },
            };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }

    public class ClassListClass
    {
        public List<User2> Users { get; set; }

        public List<Address2> Addresses { get; set; }
    }
}
