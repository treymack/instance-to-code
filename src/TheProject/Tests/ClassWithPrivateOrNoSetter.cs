using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace TheProject.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ClassWithPrivateOrNoSetter
    {
        [Test]
        public void CanScriptToCode()
        {
            var instance = new GetterClass
                               {
                                   IntProp = 1,
                               };

            var code = ITC.Instance.ToCode(instance);

            Approvals.Verify(code);
        }
    }

    public class GetterClass
    {
        public GetterClass()
        {
            PrivateSetterIntProp = 6;
        }
        public int IntProp { get; set; }
        public int NoSetterIntProp { get { return 4; } }
        public int PrivateSetterIntProp { get; private set; }
    }
}