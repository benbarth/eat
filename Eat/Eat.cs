using System;
namespace Eat
{
	public static class Eat
	{
		public static bool IsExceptionThrown(Action it)
		{
			try
			{
				it.Invoke();
			}
			catch
			{
				return true;
			}
			return false;
		}

		public static void Exception(Action it)
		{
			try
			{
				it.Invoke();
			}
			catch
			{
			}
		}

		public static T Exception<T>(Func<T> it, T fallbackValue)
		{
			try
			{
				return it();
			}
			catch
			{
				return fallbackValue;
			}
		}
	}
}
