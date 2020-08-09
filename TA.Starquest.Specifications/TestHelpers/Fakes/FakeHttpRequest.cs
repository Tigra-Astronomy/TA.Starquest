// This file is part of the MS.Gamification project
// 
// File: FakeHttpRequest.cs  Created: 2016-05-26@03:51
// Last modified: 2016-08-14@21:17

using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    public class FakeHttpRequest : HttpRequestBase
        {
        HttpFileCollectionBase postedFiles;

        public FakeHttpRequest(string relativeUrl, string method, NameValueCollection formParams,
            NameValueCollection queryStringParams,
            HttpCookieCollection cookies)
            {
            HttpMethod = method;
            AppRelativeCurrentExecutionFilePath = relativeUrl;
            Form = formParams;
            QueryString = queryStringParams;
            Cookies = cookies;
            ServerVariables = new NameValueCollection();
            }

        public FakeHttpRequest(string relativeUrl, string method, Uri url, Uri urlReferrer, NameValueCollection formParams,
            NameValueCollection queryStringParams,
            HttpCookieCollection cookies)
            : this(relativeUrl, method, formParams, queryStringParams, cookies)
            {
            Url = url;
            UrlReferrer = urlReferrer;
            }

        public FakeHttpRequest(string relativeUrl, Uri url, Uri urlReferrer)
            : this(relativeUrl, HttpVerbs.Get.ToString("g"), url, urlReferrer, null, null, null) {}

        public override NameValueCollection ServerVariables { get; }

        public override NameValueCollection Form { get; }

        public override NameValueCollection QueryString { get; }

        public override HttpCookieCollection Cookies { get; }

        public override string AppRelativeCurrentExecutionFilePath { get; }

        public override Uri Url { get; }

        public override Uri UrlReferrer { get; }

        public override string PathInfo
            {
            get { return string.Empty; }
            }

        public override string ApplicationPath
            {
            get { return ""; }
            }

        public override string HttpMethod { get; }

        public HttpFileCollectionBase PostedFiles
            {
            set { postedFiles = value; }
            }

        public override HttpFileCollectionBase Files => postedFiles;
        }
    }