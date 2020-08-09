using System;

namespace TA.Starquest.Web.Models
    {
    public class ErrorViewModel
        {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }
