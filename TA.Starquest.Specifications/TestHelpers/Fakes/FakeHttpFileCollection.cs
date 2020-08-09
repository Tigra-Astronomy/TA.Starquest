// This file is part of the MS.Gamification project
// 
// File: FakeHttpFileCollection.cs  Created: 2016-08-14@21:13
// Last modified: 2016-08-14@21:33

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    public class FakeHttpFileCollection : HttpFileCollectionBase
        {
        readonly Dictionary<string, HttpPostedFileBase> postedFiles;

        public FakeHttpFileCollection(HttpPostedFileBase file)
            {
            postedFiles = new Dictionary<string, HttpPostedFileBase> {[file.FileName] = file};
            }

        public override string[] AllKeys => postedFiles.Keys.ToArray();

        public override HttpPostedFileBase this[string name] => postedFiles[name];
        }
    }