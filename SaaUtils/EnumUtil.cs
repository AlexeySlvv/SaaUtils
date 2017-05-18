using System;
using System.Reflection;

namespace SaaUtils
{
	/// <summary>
	/// Enum extensions
	/// </summary>
	public static class EnumUtil
	{

		/// <summary>
		/// Last error message
		/// </summary>
		public static string LastError { get; private set; } = default(string);

		/// <summary>
		/// Returns attribute value
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <returns></returns>
		private static T GetAttribute<T>(this Enum e)where T : Attribute
		{
			try
			{
				Type t = typeof(T), et = e.GetType();
				FieldInfo fi = et.GetField(Enum.GetName(et, e));
				if (fi != null && Attribute.IsDefined(fi, t))
					return Attribute.GetCustomAttribute(fi, t) as T;
			}
			catch (Exception ex)
			{
				LastError = $"Error extracting attribute {nameof(T)}: {ex.Message}";
			}

			return null;
		}

		/// <summary>
		/// Returns field name value
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string FieldName(this Enum e)
		{
			FieldNameAttribute a = e.GetAttribute<FieldNameAttribute>();
			return a?.Value ?? string.Empty;
		}

	}

}
