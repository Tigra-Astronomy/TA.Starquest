using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting.Internal;

namespace TA.Starquest.Web.Hosting
{
internal static class HostingExtensions
    {
    public static string MapToFileSystem(this HostingEnvironment environment, string webRelativePath)
        {
        //ToDo: re-implement - make sure it works for Linux!
        throw new NotImplementedException("Needs to be re-implemented for ASP.Net Core");
        }
    }
}
