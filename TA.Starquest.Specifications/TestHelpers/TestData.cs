// This file is part of the MS.Gamification project
// 
// File: TestData.cs  Created: 2016-07-20@21:56
// Last modified: 2016-07-20@23:33

using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    static class TestData
        {
        internal static string FromEmbeddedResource(string resourceName)
            {
            var asm = Assembly.GetExecutingAssembly();
            var asmName = asm.GetName().Name;
            var resourceRoot = $"{asmName}.TestData";
            var resource = $"{resourceRoot}.{resourceName}";
            using (var stream = asm.GetManifestResourceStream(resource))
                {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
                }
            }

        internal static void CreateStandardMissionData(DataContextBuilder data)
            {
            data.WithEntity(new Category {Id = 10, Name = "Phase"}).WithEntity(new Category {Id = 20, Name = "Planet"}).WithEntity(new Category {Id = 30, Name = "Open Cluster"}).WithEntity(new Category {Id = 40, Name = "Galaxy"}).WithMissionLevel().WithId(1).Level(1).WithTrack(1).WithId(1).WithChallenge("See the New Moon").WithId(100).InCategory(10).BuildChallenge().WithChallenge("See the Full Moon").WithId(101).InCategory(10).BuildChallenge().BuildTrack().WithTrack(2).WithId(2).WithChallenge("See Jupiter").WithId(200).InCategory(20).BuildChallenge().WithChallenge("See Saturn").WithId(201).InCategory(20).BuildChallenge().BuildTrack().WithTrack(3).WithId(3).WithChallenge("See the Pleiades").WithId(300).InCategory(30).BuildChallenge().WithChallenge("See Andromeda").WithId(400).InCategory(40).BuildChallenge().BuildTrack().BuildMission();
            }
        }
    }