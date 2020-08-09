// This file is part of the MS.Gamification project
// 
// File: UnitTestImageStore.cs  Created: 2016-05-26@03:51
// Last modified: 2016-08-19@02:30

using System.Collections.Generic;
using System.IO;
using MS.Gamification.BusinessLogic.Gamification;

namespace MS.Gamification.Tests.TestHelpers
    {
    class UnitTestImageStore : Dictionary<string, string>, IImageStore
        {
        readonly string rootPath;

        public UnitTestImageStore(string rootPath)
            {
            this.rootPath = rootPath;
            this["NoImage"] = "NoImage.png";
            }

        public new string this[string key]
            {
            get { return base[key]; }
            set { base[key] = Path.Combine(rootPath, value); }
            }

        public string ImageIdentifier { get; set; }

        public Stream ImageStream { get; set; }

        public bool SaveCalled { get; set; }

        public string FindImage(string identifier)
            {
            if (ContainsKey(identifier))
                return this[identifier];
            return this["NoImage"];
            }

        public string MimeType(string identifier)
            {
            var image = FindImage(identifier);
            return $"image/{Path.GetExtension(image).TrimStart('.')}";
            }

        public void Save(Stream imageStream, string identifier)
            {
            ImageStream = imageStream;
            ImageIdentifier = identifier;
            SaveCalled = true;
            }

        public IEnumerable<string> EnumerateImages()
            {
            yield break;
            }
        }
    }