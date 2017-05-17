using System.Collections.Generic;
using System.Linq;

namespace SaaUtils
{

	/// <summary>
	/// Generic extensions
	/// </summary>
	public static class GenericUtil
	{

		/// <summary>
		/// Is Enumerable empty?
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsEmpty<T>(this IEnumerable<T> input)
		{
			return false == input.Any();
		}

		/// <summary>
		/// Determine is List not contains value
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool NotContains<T>(this List<T> input, T value)
		{
			return false == input.Contains(value);
		}

		/// <summary>
		/// Determine is HashSet not contains value
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool NotContains<T>(this HashSet<T> input, T value)
		{
			return false == input.Contains(value);
		}

		/// <summary>
		/// Add values to HashSet
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input"></param>
		/// <param name="items"></param>
		public static void AddRange<T>(this HashSet<T> input, IEnumerable<T> items)
		{
			foreach (T item in items)
				input.Add(item);
		}

		/// <summary>
		/// Determine is Dictionary not contains key
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="input"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool NotContainsKey<TKey, TValue>(this Dictionary<TKey, TValue> input, TKey key)
		{
			return false == input.ContainsKey(key);
		}

		/// <summary>
		/// Determine is Dictionary not contains key
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="input"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool NotContainsKey<TKey, TValue>(this SortedDictionary<TKey, TValue> input, TKey key)
		{
			return false == input.ContainsKey(key);
		}

	}
}
