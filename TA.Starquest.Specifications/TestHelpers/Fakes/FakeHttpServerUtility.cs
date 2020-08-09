using System.Web;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    class FakeHttpServerUtility : HttpServerUtilityBase
        {
        readonly string wwwroot;

        public FakeHttpServerUtility(string wwwroot = @"c:\fake\directory\doesnt\exist")
            {
            this.wwwroot = wwwroot;
            }

        public override string MapPath(string path) => wwwroot;
        }
    }