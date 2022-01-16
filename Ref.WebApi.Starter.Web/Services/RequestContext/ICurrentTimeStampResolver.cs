using Ref.WebApi.Starter.Web.Models.Business;

namespace Ref.WebApi.Starter.Web.Services.RequestContext;

internal interface ICurrentTimeStampResolver
{
	CurrentTimeStamp Resolve();
}