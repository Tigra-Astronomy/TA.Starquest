// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: SendgridEmailSender.cs  Last modified: 2020-09-05@16:59 by Tim Long

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TA.Starquest.Web.Services.Email
    {
    public class AuthMessageSenderOptions
        {
        public string SendgridUserName { get; set; }

        public string SendgridApiKey { get; set; }
        }

    class SendgridEmailSender : IEmailSender
        {
        public SendgridEmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
            {
            Options = optionsAccessor.Value;
            }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
            {
            //ToDo - delete the API key from here
            var SendgridApiKey = "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";
            return Execute(/*Options.*/SendgridApiKey, subject, message, email);
            }

        public Task Execute(string apiKey, string subject, string message, string email)
            {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
                {
                From = new EmailAddress("Starquest@tigra-astronomy.com", Options.SendgridUserName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
                };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
            }
        }
    }