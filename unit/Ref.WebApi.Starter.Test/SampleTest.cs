using System;
using FluentAssertions;
using NUnit.Framework;
using Ref.WebApi.Starter.Web.Services.RequestContext;

namespace Ref.WebApi.Starter.Test;

[Obsolete("Only as example")]
public class SampleTest
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void Test1()
	{
		CurrentTimeStampResolver res = new CurrentTimeStampResolver();
		res.Resolve().Should().NotBeNull();
	}
}