﻿using ExceptionReporting.Extensions;
using NUnit.Framework;

namespace ExceptionReporting.Tests
{
	[TestFixture]
	public class Extensions_Test
	{
		[Test]
		public void can_truncate()
		{
			Assert.That("A message too long".Truncate(9), Is.EqualTo("A message"));
		}
	}
}
