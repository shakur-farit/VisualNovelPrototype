using System.Text.RegularExpressions;

namespace Code.Progress.Provider
{
	public static class EnumExtensions
	{
		public static string ToReadableString(this System.Enum value)
		{
			var input = value.ToString();
			return Regex.Replace(input, "(\\B[A-Z])", " $1");
		}
	}
}