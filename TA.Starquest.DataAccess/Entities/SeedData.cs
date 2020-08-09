// This file is part of the MS.Gamification project
// 
// File: SeedData.cs  Created: 2016-11-01@19:37
// Last modified: 2017-05-16@20:36

using System;
using System.Collections.Generic;

namespace TA.Starquest.DataAccess.Entities
    {
    public static class SeedData
        {
        internal const string AdministratorUserName = "Administrator";
        internal const string AdministratorDefaultPassword = "password";
        public static List<string> Categories = new List<string>
            {
            "Artificial Satellite",
            "Asterism",
            "Astrometry",
            "Comet",
            "Constellation",
            "Crater",
            "Dark Nebula",
            "Diffuse Nebula",
            "Double Star",
            "Eclipse",
            "Emission Nebula",
            "Galaxy",
            "Globular Cluster",
            "Mare",
            "Meteor",
            "Minor Planet",
            "Open Cluster",
            "Phase",
            "Phenomenon",
            "Planet",
            "Planetary Nebula",
            "Region",
            "Satellite",
            "Sky",
            "Star",
            "Surface Feature",
            "Variable Star"
            };

        internal static void EnsureCategories(this ApplicationDbContext context)
            {
            //ToDo - complete review of data seeding is needed
            //foreach (var seed in Categories)
            //    {
            //    context.Categories.AddOrUpdate(p => p.Name,
            //        new Category {Name = seed});
            //    }
            }

        internal static void EnsureDefaultRolesAndUsers(this ApplicationDbContext context)
            {
            EnsureRoleExists(context, RoleNames.Administrator);
            EnsureRoleExists(context, RoleNames.Moderator);
            EnsureRoleExists(context, RoleNames.EventManager);
            EnsureAdminUserExists(context);
            }

        internal static void EnsureRoleExists(this ApplicationDbContext context, string roleName)
            {
            //ToDo - role management is different in EF Core, this needs to be re-implemented
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);
            //if (!context.Roles.Any(role => role.Name == roleName))
            //    roleManager.Create(new IdentityRole {Name = roleName});
            }

        internal static void EnsureAdminUserExists(this ApplicationDbContext context)
            {
            //ToDo - needs to be re-implemented for EF core
            //if (context.Users.Any(p => p.Roles.Any(r => r.RoleId == RoleNames.Administrator)) ||
            //    context.Users.Any(user => user.UserName == AdministratorUserName)) return;
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            ////ToDo: Hard coded secrets!! These need to come from web.config or similar
            //var adminUser = new ApplicationUser
            //        {UserName = AdministratorUserName, Email = "nobody@nowhere.com", EmailConfirmed = true};
            //userManager.Create(adminUser, AdministratorDefaultPassword);
            //userManager.AddToRole(adminUser.Id, RoleNames.Administrator);
            }

        internal static void CreateBetaMission(ApplicationDbContext context)
            {
            //ToDo - seed data works differently in EF Core - re-implement
            //var phaseCategory = context.Categories.Single(p => p.Name == "Phase");
            //var planetCategory = context.Categories.Single(p => p.Name == "Planet");
            //var openClusterCategory = context.Categories.Single(p => p.Name == "Open Cluster");
            //var galaxyCategory = context.Categories.Single(p => p.Name == "Galaxy");
            //var craterCategory = context.Categories.Single(p => p.Name == "Crater");
            //var globularCategory = context.Categories.Single(p => p.Name == "Globular Cluster");
            //var pnebCategory = context.Categories.Single(p => p.Name == "Planetary Nebula");
            //var doubleCategory = context.Categories.Single(p => p.Name == "Double Star");
            //var skyCategory = context.Categories.Single(p => p.Name == "Sky");
            //var missionTitle = "Alpha Test Mission";
            //context.Missions.AddOrUpdate(p => p.Title,
            //    new Mission
            //        {
            //        Title = missionTitle,
            //        MissionLevels = new List<MissionLevel>
            //            {
            //            #region Level 1
            //            new MissionLevel
            //                {
            //                Name = "Alpha Mission",
            //                AwardTitle = "Legendary Alpha Tester",
            //                Level = 1,
            //                Tracks = new List<MissionTrack>
            //                    {
            //                    new MissionTrack
            //                        {
            //                        Name = "Lunar Track",
            //                        AwardTitle = "Alpha Lunar Observer",
            //                        Badge =
            //                            new Badge {Name = "Alpha Lunar Observer", ImageIdentifier = "alpha-lunar-observer-1"},
            //                        Number = 1,
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "See the waxing crescent moon",
            //                                Points = 1,
            //                                BookSection = "Moon",
            //                                CategoryId = phaseCategory.Id,
            //                                Location = "Moon",
            //                                ValidationImage = "Moon-Waxing-Crescent"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See the full moon",
            //                                Points = 1,
            //                                BookSection = "Moon",
            //                                CategoryId = phaseCategory.Id,
            //                                Location = "Moon",
            //                                ValidationImage = "Moon-Full"
            //                                }
            //                            }
            //                        },
            //                    new MissionTrack
            //                        {
            //                        Name = "Planetary Track",
            //                        AwardTitle = "Alpha Planetologist",
            //                        Number = 2,
            //                        Badge = new Badge {Name = "Alpha Planetologist", ImageIdentifier = "alpha-planetologist-1"},
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "See Jupiter",
            //                                Points = 1,
            //                                BookSection = "Solar System",
            //                                CategoryId = planetCategory.Id,
            //                                Location = "Solar System",
            //                                ValidationImage = "Jupiter"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See Saturn",
            //                                Points = 1,
            //                                BookSection = "Solar System",
            //                                CategoryId = planetCategory.Id,
            //                                Location = "Solar System",
            //                                ValidationImage = "Saturn"
            //                                }
            //                            }
            //                        },
            //                    new MissionTrack
            //                        {
            //                        Name = "Deep Space Track",
            //                        AwardTitle = "Alpha Deep Space Explorer",
            //                        Number = 3,
            //                        Badge =
            //                            new Badge
            //                                {
            //                                Name = "Alpha Deep Space Explorer",
            //                                ImageIdentifier = "alpha-deep-space-explorer-1"
            //                                },
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "See M45, The Pleiades",
            //                                Points = 1,
            //                                BookSection = "Winter",
            //                                CategoryId = openClusterCategory.Id,
            //                                Location = "Taurus",
            //                                ValidationImage = "M45-Pleiades"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See M31, The Andromeda Galaxy",
            //                                Points = 1,
            //                                BookSection = "Autumn",
            //                                CategoryId = galaxyCategory.Id,
            //                                Location = "Andromeda",
            //                                ValidationImage = "M31"
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //            #endregion Level 1

            //            #region Level 2
            //            new MissionLevel
            //                {
            //                Name = "Alpha Mission Level 2",
            //                AwardTitle = "Legendary Alpha Tester II",
            //                Level = 2,
            //                Precondition = LoadPreconditionFromFile("AlphaMission-Level2.xml"),
            //                Tracks = new List<MissionTrack>
            //                    {
            //                    new MissionTrack
            //                        {
            //                        Name = "Lunar Track",
            //                        AwardTitle = "Alpha Lunar Observer II",
            //                        Badge =
            //                            new Badge {Name = "Alpha Lunar Observer II", ImageIdentifier = "alpha-lunar-observer-1"},
            //                        Number = 1,
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "Find the crater Proclus",
            //                                Points = 2,
            //                                BookSection = "Moon",
            //                                CategoryId = craterCategory.Id,
            //                                Location = "The Moon, Mare Crisium",
            //                                ValidationImage = "Moon-Proclus"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "Find the crater Picard",
            //                                Points = 3,
            //                                BookSection = "Moon",
            //                                CategoryId = phaseCategory.Id,
            //                                Location = "The Moon, Mare Crisium",
            //                                ValidationImage = "Moon-Picard"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "Find craters Messier and Messier A",
            //                                Points = 2,
            //                                BookSection = "Moon",
            //                                CategoryId = phaseCategory.Id,
            //                                Location = "The Moon, Mare Fecunditatis",
            //                                ValidationImage = "Moon-Messier"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See the Wrinkle Ridges at Lunar Sunrise or Lunar Sunset",
            //                                Points = 3,
            //                                BookSection = "Moon",
            //                                CategoryId = craterCategory.Id,
            //                                Location = "The Moon, Mare Serenitatis",
            //                                ValidationImage = "Moon-Wrinkle-Ridges"
            //                                }
            //                            }
            //                        },
            //                    new MissionTrack
            //                        {
            //                        Name = "Planetary Track",
            //                        AwardTitle = "Alpha Planetologist II",
            //                        Number = 2,
            //                        Badge = new Badge
            //                                {Name = "Alpha Planetologist II", ImageIdentifier = "alpha-planetologist-1"},
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "See Venus at half phase",
            //                                Points = 1,
            //                                BookSection = "Solar System",
            //                                CategoryId = phaseCategory.Id,
            //                                Location = "Solar System",
            //                                ValidationImage = "Venus-half-phase"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See Mars",
            //                                Points = 1,
            //                                BookSection = "Solar System",
            //                                CategoryId = planetCategory.Id,
            //                                Location = "Solar System",
            //                                ValidationImage = "Mars"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See Jupiter's dark belts",
            //                                Points = 2,
            //                                BookSection = "Solar System",
            //                                CategoryId = planetCategory.Id,
            //                                Location = "Jupiter",
            //                                ValidationImage = "Jupiter"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "Observe Jupiter's moons over several nights and see them change position",
            //                                Points = 2,
            //                                BookSection = "Solar System",
            //                                CategoryId = planetCategory.Id,
            //                                Location = "Jupiter",
            //                                ValidationImage = "Jupiter"
            //                                }
            //                            }
            //                        },
            //                    new MissionTrack
            //                        {
            //                        Name = "Deep Space Track",
            //                        AwardTitle = "Alpha Deep Space Explorer II",
            //                        Number = 3,
            //                        Badge =
            //                            new Badge
            //                                {
            //                                Name = "Alpha Deep Space Explorer II",
            //                                ImageIdentifier = "alpha-deep-space-explorer-1"
            //                                },
            //                        Challenges = new List<Challenge>
            //                            {
            //                            new Challenge
            //                                {
            //                                Name = "See M13, The Great Cluster in Hercules",
            //                                Points = 2,
            //                                BookSection = "Summer",
            //                                CategoryId = globularCategory.Id,
            //                                Location = "Hercules, The Hunter",
            //                                ValidationImage = "M13"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See M57, The Ring Nebula",
            //                                Points = 3,
            //                                BookSection = "Summer",
            //                                CategoryId = pnebCategory.Id,
            //                                Location = "Lyra",
            //                                ValidationImage = "M57"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See Albireo as a double star",
            //                                Points = 2,
            //                                BookSection = "Summer",
            //                                CategoryId = doubleCategory.Id,
            //                                Location = "Cygnus, The Swan",
            //                                ValidationImage = "Albireo-Double"
            //                                },
            //                            new Challenge
            //                                {
            //                                Name = "See The Great Rift",
            //                                Points = 3,
            //                                BookSection = "Summer",
            //                                CategoryId = skyCategory.Id,
            //                                Location = "The Milky Way",
            //                                ValidationImage = "MilkyWay-GreatRift"
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            #endregion Level 2
            //            }
            //        }
            //);
            }

        private static string LoadPreconditionFromFile(string fileNameWithoutPath)
            {
            //ToDo: ASP.Net core uses different settings architecture
            throw new NotImplementedException("Method must be re-implemented for ASP.Net Core");
            //var rulesRoot = MapPath(ConfigurationManager.AppSettings["preconditionsRootPath"]);
            //var fqRuleFile = Path.Combine(rulesRoot, fileNameWithoutPath);
            //using (var reader = new StreamReader(fqRuleFile))
            //    {
            //    return reader.ReadToEnd();
            //    }
            }

        //private static string MapPath(string webRelativePath)
        //    {
        //    if (HttpContext.Current != null)
        //        return HostingEnvironment.MapPath(webRelativePath);
        //    var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
        //    var directoryName = Path.GetDirectoryName(absolutePath);
        //    var path = Path.Combine(directoryName, ".." + webRelativePath.TrimStart('~').Replace('/', '\\'));
        //    return path;
        //    }
        }
    }