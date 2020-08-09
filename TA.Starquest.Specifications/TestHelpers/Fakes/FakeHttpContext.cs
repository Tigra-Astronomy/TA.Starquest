// This file is part of the MS.Gamification project
// 
// File: FakeHttpContext.cs  Created: 2016-05-26@03:51
// Last modified: 2016-08-14@21:48

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    public class FakeHttpContext : HttpContextBase
        {
        readonly HttpCookieCollection _cookies;
        readonly NameValueCollection _formParams;
        readonly Dictionary<object, object> _items;
        readonly string _method;
        readonly NameValueCollection _queryStringParams;
        readonly string _relativeUrl;
        readonly SessionStateItemCollection _sessionItems;
        IPrincipal _principal;
        HttpRequestBase _request;
        HttpResponseBase _response;

        public FakeHttpContext(string relativeUrl, string method)
            : this(relativeUrl, method, null, null, null, null, null) {}

        public FakeHttpContext(string relativeUrl, HttpFileCollectionBase files)
            : this(relativeUrl, HttpVerbs.Post.ToString("G"), null, null, null, null, null)
            {
            var request = new FakeHttpRequest(_relativeUrl, _method, _formParams, _queryStringParams, _cookies);
            request.PostedFiles = files;
            _request = request;
            }

        public FakeHttpContext(string relativeUrl)
            : this(relativeUrl, null, null, null, null, null) {}

        public FakeHttpContext(string relativeUrl, IPrincipal principal, NameValueCollection formParams,
            NameValueCollection queryStringParams, HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems)
            : this(relativeUrl, null, principal, formParams, queryStringParams, cookies, sessionItems) {}

        public FakeHttpContext(string relativeUrl, string method, IPrincipal principal, NameValueCollection formParams,
            NameValueCollection queryStringParams, HttpCookieCollection cookies,
            SessionStateItemCollection sessionItems)
            {
            _relativeUrl = relativeUrl;
            _method = method;
            _principal = principal;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _sessionItems = sessionItems;

            _items = new Dictionary<object, object>();
            }

        public override HttpRequestBase Request
            {
            get
                {
                return _request ??
                       new FakeHttpRequest(_relativeUrl, _method, _formParams, _queryStringParams, _cookies);
                }
            }

        public override HttpResponseBase Response
            {
            get { return _response ?? new FakeHttpResponse(); }
            }

        public override IPrincipal User
            {
            get { return _principal; }
            set { _principal = value; }
            }

        public override HttpSessionStateBase Session
            {
            get { return new FakeHttpSessionState(_sessionItems); }
            }

        public override IDictionary Items
            {
            get { return _items; }
            }


        public override bool SkipAuthorization { get; set; }

        public static FakeHttpContext Root()
            {
            return new FakeHttpContext("~/");
            }

        public void SetRequest(HttpRequestBase request)
            {
            _request = request;
            }

        public void SetResponse(HttpResponseBase response)
            {
            _response = response;
            }

        public override object GetService(Type serviceType)
            {
            return null;
            }
        }
    }