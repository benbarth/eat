using NUnit.Framework;
using System;

namespace Eat.Tests
{
	[TestFixture]
	public class TestEat
	{
		[Test]
		public void IsExceptionThrown_Should_ReturnFalse_When_NoExceptionIsThrown()
		{
			var isException = Eat.IsExceptionThrown(() => { Console.WriteLine("Doing something that doesn't throw an exception."); });
			Assert.IsFalse(isException);
		}

		[Test]
		public void IsExceptionThrown_Should_ReturnTrue_When_ExceptionIsThrown()
		{
			var isException = Eat.IsExceptionThrown(() => { throw new Exception("test"); });
			Assert.IsTrue(isException);
		}

		[Test]
		public void Exception_Should_Continue_When_ExceptionIsThrown()
		{
			Eat.Exception(() => { throw new Exception("test"); });
			Assert.Pass();
		}

		[Test]
		public void Exception_Should_ReturnValue_When_NoExceptionIsThrown()
		{
			var result = Eat.Exception(() => { return "test"; }, "defaultValue");
			Assert.AreEqual("test", result);
		}

		[Test]
		public void Exception_Should_ReturnDefaultValueString_When_ExceptionIsThrown()
		{
			var result = Eat.Exception(() => { throw new Exception("test"); }, "defaultValue");
			Assert.AreEqual("defaultValue", result);
		}

		[Test]
		public void Exception_Should_ReturnDefaultValueNull_When_ExceptionIsThrown()
		{
			var result = Eat.Exception<string>(() => { throw new Exception("test"); }, null);
			Assert.IsNull(result);
		}
	}
}
