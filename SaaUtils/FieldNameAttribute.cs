using System;

namespace SaaUtils
{
	
	/// <summary>
	/// Field name attribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class FieldNameAttribute : Attribute
	{
		/// <summary>
		/// Default value
		/// </summary>
		public static FieldNameAttribute Default { get; } = new FieldNameAttribute(default(string));

		/// <summary>
		/// Field name value
		/// </summary>
		public string Value { get; }

		/// <summary>
		/// Field name constructor
		/// </summary>
		/// <param name="name"></param>
		public FieldNameAttribute(string name)
		{
			Value = name;
		}
	}

}