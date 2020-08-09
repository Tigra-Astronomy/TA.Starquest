// This file is part of the MS.Gamification project
// 
// File: ControllerContextBuilder.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-13@00:00

using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Machine.Specifications;
using MS.Gamification.App_Start;
using MS.Gamification.BusinessLogic.Gamification;
using MS.Gamification.DataAccess;
using MS.Gamification.Tests.TestHelpers.Fakes;
using Ninject;

namespace MS.Gamification.Tests.TestHelpers
    {
    /// <summary>
    ///     Builds an instance of an MVC <see cref="Controller" />, initialized with fke data suitable for unit testing.
    /// </summary>
    /// <typeparam name="TController">The type of the controller to be constructed.</typeparam>
    class ControllerContextBuilder<TController> where TController : ControllerBase
        {
        readonly FakeHttpContext blobby = new FakeHttpContext("/", "GET");
        readonly DataContextBuilder fakeDataBuilder = new DataContextBuilder();
        readonly TempDataDictionary tempdata = new TempDataDictionary();
        Uri baseUri = new Uri("http://localhost:9876");
        HttpPostedFileBase postedFile;
        HttpVerbs requestMethod = HttpVerbs.Get;
        string requestPath = "/";
        string requestUserId = string.Empty;
        string requestUsername = string.Empty;
        string[] requestUserRoles;

        public IGameEngineService RulesService { get; internal set; }

        public IMapper Mapper { get; internal set; }

        public IImageStore ImageStore { get; set; } = new UnitTestImageStore(@"C:\UnitTestStore");

        public IUnitOfWork UnitOfWork { get; internal set; }

        public ControllerContextBuilder<TController> WithRoute(string relativeUrl, HttpVerbs method = HttpVerbs.Get)
            {
            requestPath = relativeUrl;
            requestMethod = method;
            return this;
            }

        /// <summary>
        ///     Builds a controller of the required type using any data previously supplied (or defaults).
        /// </summary>
        /// <returns>An initialized controller of type <typeparamref name="TController" />.</returns>
        /// <exception cref="SpecificationException">Thrown if the controller cannot be built.</exception>
        public TController Build()
            {
            UnitOfWork = fakeDataBuilder.Build();
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<ViewModelMappingProfile>(); });
            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
            var notifier = new FakeNotificationService();
            RulesService = new GameRulesService(UnitOfWork, Mapper, notifier);
            HttpContextBase httpContext;
            if (postedFile == null)
                {
                httpContext = new FakeHttpContext(requestPath, requestMethod.ToString("G"));
                }
            else
                {
                var filesCollection = new FakeHttpFileCollection(postedFile);
                httpContext = new FakeHttpContext(requestPath, filesCollection);
                }
            var fakeIdentity = new FakeIdentity(requestUsername);
            var fakePrincipal = new FakePrincipal(fakeIdentity, requestUserRoles);
            httpContext.User = fakePrincipal;
            var context = new ControllerContext {HttpContext = httpContext};
            /*
             * Use Ninject to create the controller, as we don't know in advance what
             * type of controller or how many constructor parameters it has.
             */
            var kernel = BuildNinjectKernel(fakeIdentity, requestUserId, RulesService);
            var controller = kernel.Get<TController>();
            if (controller == null)
                throw new SpecificationException(
                    $"ControllerContextBuilder: Unable to create controller instance of type {nameof(TController)}");

            controller.ControllerContext = context;
            controller.TempData = tempdata;
            return controller;
            }

        public ControllerContextBuilder<TController> WithRequestingUser(string id, string username, params string[] roles)
            {
            requestUsername = username;
            requestUserRoles = roles;
            requestUserId = id;
            return this;
            }

        public ControllerContextBuilder<TController> WithTempData(string key, object value)
            {
            tempdata.Add(key, value);
            return this;
            }

        IKernel BuildNinjectKernel(IIdentity identity, string userId, IGameEngineService rulesService)
            {
            var requestUserId = userId;
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUnitOfWork>().ToMethod(u => UnitOfWork);
            kernel.Bind<ICurrentUser>().ToMethod(u => new FakeCurrentUser(identity, requestUserId));
            kernel.Bind<TController>().ToSelf().InTransientScope();
            kernel.Bind<IGameEngineService>().ToMethod(u => rulesService).InTransientScope();
            kernel.Bind<IGameNotificationService>().To<FakeNotificationService>().InTransientScope();
            kernel.Bind<IImageStore>().ToMethod(u => ImageStore).InTransientScope().Named("BadgeImageStore");
            kernel.Bind<IImageStore>().ToMethod(u => ImageStore).InTransientScope().Named("ValidationImageStore");
            kernel.Bind<IImageStore>().ToMethod(u => ImageStore).InTransientScope().Named("StaticImageStore");
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<ViewModelMappingProfile>());
            kernel.Bind<IMapper>().ToMethod(m => mapperConfig.CreateMapper()).InTransientScope();
            return kernel;
            }

        public ControllerContextBuilder<TController> WithPostedFile(HttpPostedFileBase postedFile)
            {
            this.postedFile = postedFile;
            return this;
            }

        public ControllerContextBuilder<TController> WithImageStore(IImageStore store)
            {
            ImageStore = store;
            return this;
            }

        public ControllerContextBuilder<TController> WithData(Action<DataContextBuilder> dataBuilder)
            {
            dataBuilder(fakeDataBuilder);
            return this;
            }
        }
    }