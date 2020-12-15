using System;
using Ref.WebApi.Starter.Web.Models.Business;

namespace Ref.WebApi.Starter.Web.Services.RequestContext
{
    internal class CurrentTimeStampResolver
    {
        public CurrentTimeStamp Resolve()
        {
            return new (DateTime.Now);
        }    
    }
}