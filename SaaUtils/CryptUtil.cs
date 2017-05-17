using System;
using System.Security.Cryptography;
using System.Text;

namespace SaaUtils
{
	/// <summary>
	/// Criptography class
	/// </summary>
	public static class CryptUtil
	{

		/// <summary>
		/// MD5 encrypting
		/// </summary>
		/// <param name="text">Encoding text</param>
		/// <returns>Encipher string</returns>
		public static string EncryptMd5(string text)
		{
			MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
			byte[] enc = provider.ComputeHash(Encoding.ASCII.GetBytes(text));
			string result = string.Empty;
			foreach (byte b in enc)
				result += b.ToString("x2");
			return result;
		}

		#region TripleDES

		/// <summary>
		/// TripleDES encrypting
		/// </summary>
		/// <param name="text">text</param>
		/// <param name="password">password</param>
		/// <returns>Encrypting string</returns>
		public static string Encrypt3Des(string text, string password)
		{
			MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
			byte[] pwdHash = md5Provider.ComputeHash(Encoding.ASCII.GetBytes(password));
			md5Provider.Dispose();

			TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider
			{
				Key = pwdHash,
				Mode = CipherMode.ECB
			};

			byte[] buff = Encoding.ASCII.GetBytes(text);
			string encrypt = Convert.ToBase64String
				(desProvider.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
			desProvider.Dispose();

			return encrypt;
		}

		/// <summary>
		/// TripleDES decrypting
		/// </summary>
		/// <param name="text">text</param>
		/// <param name="password">password</param>
		/// <returns>Decrypting string</returns>
		public static string Decrypt3Des(string text, string password)
		{
			MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
			byte[] pwdHash = md5Provider.ComputeHash(Encoding.ASCII.GetBytes(password));
			md5Provider.Dispose();

			TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider
			{
				Key = pwdHash,
				Mode = CipherMode.ECB
			};

			byte[] buff = Convert.FromBase64String(text);
			string decrypt = Encoding.ASCII.GetString
				(desProvider.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
			desProvider.Dispose();

			return decrypt;
		}

		#endregion TripleDES

	}
}