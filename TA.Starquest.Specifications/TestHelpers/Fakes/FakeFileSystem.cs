using System.Collections.Generic;
using MS.Gamification.BusinessLogic.Gamification;
using MS.Gamification.HtmlHelpers;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    class FakeFileSystem : IFileSystemService
        {
        readonly List<string> fakeFiles = new List<string>();

        public FakeFileSystem(params string[] files)
            {
            fakeFiles = new List<string>(files);
            }

        public bool FileExists(string fullyQualifiedFileName)
            {
            return fakeFiles.Contains(fullyQualifiedFileName);
            }

        public override string ToString()
            {
            var result = $"Contains {fakeFiles.Count} files";
            return result;
            }
        }
    }