using System;

namespace Ref.WebApi.Starter.Web.Models
{
    public readonly struct CurrentTimeStamp 
    {
        public CurrentTimeStamp(DateTime timeStamp)
        {
            TimeStamp = timeStamp;
        }

        public DateTime TimeStamp { get; }
    }
}