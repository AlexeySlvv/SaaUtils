using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace SaaUtils
{

	[SuppressUnmanagedCodeSecurity]
	internal static class SafeNativeMethods
	{
		[DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
		public static extern int StrCmpLogicalW(string s1, string s2);
	}

	// http://stackoverflow.com/questions/248603/natural-sort-order-in-c-sharp

	/// <summary>
	/// Natural string comparation: s1, s2, ..., s10
	/// </summary>
	public sealed class NaturalStringComparer : IComparer<string>
	{
		private static readonly Lazy<NaturalStringComparer> _instance 
			= new Lazy<NaturalStringComparer>(() => new NaturalStringComparer());

		/// <summary>
		/// Single instance
		/// </summary>
		public static NaturalStringComparer Instance => _instance.Value;

		/// <summary>
		/// Compare method
		/// </summary>
		/// <param name="s1"></param>
		/// <param name="s2"></param>
		/// <returns></returns>
		public int Compare(string s1, string s2)
		{
			return SafeNativeMethods.StrCmpLogicalW(s1, s2);
		}
	}

}
