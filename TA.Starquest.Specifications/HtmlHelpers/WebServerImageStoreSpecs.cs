// This file is part of the MS.Gamification project
// 
// File: WebServerImageStoreSpecs.cs  Created: 2016-07-15@22:54
// Last modified: 2016-07-15@23:16

using Machine.Specifications;
using MS.Gamification.BusinessLogic.Gamification;
using MS.Gamification.HtmlHelpers;
using MS.Gamification.Tests.TestHelpers;
using MS.Gamification.Tests.TestHelpers.Fakes;

namespace MS.Gamification.Tests.HtmlHelpers
    {
    [Subject(typeof(WebServerImageStore))]
    public class when_requesting_an_image_file_with_an_extension_and_a_file_with_a_different_extension_exists
        {
        const string root = @"c:\wwwroot";

        Establish context = () =>
            {
            IFileSystemService fileSystem = new FakeFileSystem($@"{root}\file.png");
            var fakeHttpServerUtility = new FakeHttpServerUtility(root);
            store = new WebServerImageStore(fakeHttpServerUtility, fileSystem, "fakeSetting");
            };

        It should_return_the_placeholder_file =
            () => store.FindImage("file.gif").ShouldEqual($@"{root}\NoImage.png");

        static WebServerImageStore store;
        }

    [Subject(typeof(WebServerImageStore))]
    public class when_requesting_an_image_file_and_no_matching_files_exist
        {
        const string root = @"c:\wwwroot";

        Establish context = () =>
            {
            IFileSystemService fileSystem = new FakeFileSystem($@"{root}\otherfile.png");
            var fakeHttpServerUtility = new FakeHttpServerUtility(root);
            store = new WebServerImageStore(fakeHttpServerUtility, fileSystem, "fakeSetting");
            };

        It should_return_the_placeholder_file =
            () => store.FindImage("file").ShouldEqual($@"{root}\NoImage.png");

        static WebServerImageStore store;
        }

    [Subject(typeof(WebServerImageStore), "extension matching")]
    public class when_requesting_an_image_file_without_an_extension_and_a_file_with_matching_name_exists
        {
        const string root = @"c:\wwwroot";

        Establish context = () =>
            {
            IFileSystemService fileSystem = new FakeFileSystem($@"{root}\file.png", $@"{root}\file.gif", $@"{root}\file.jpg");
            var fakeHttpServerUtility = new FakeHttpServerUtility(@"c:\wwwroot");
            store = new WebServerImageStore(fakeHttpServerUtility, fileSystem);
            };
        It should_return_the_full_path_of_the_matching_file =
            () => store.FindImage("file").ShouldEqual($@"{root}\file.png");

        static WebServerImageStore store;
        }
    }
