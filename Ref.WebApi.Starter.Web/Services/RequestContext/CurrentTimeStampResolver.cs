using System;
using Ref.WebApi.Starter.Contracts.RequestContext;

namespace Ref.WebApi.Starter.Web.Services.RequestContext
{
    internal class CurrentTimeStampResolver : ICurrentTimeStampResolver
    {
        public CurrentTimeStamp Resolve()
        {
            return new (DateTime.Now);
        }    
    }
}