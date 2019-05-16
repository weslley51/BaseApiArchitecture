using System;
using System.Security.Cryptography;
using System.Text;

namespace BaseApiArchitecture.Utils
{
	public static class Criptography
    {
		public static string GetSalt()
		{
			var Number = new byte[32];
			var Generator = RandomNumberGenerator.Create();
			Generator.GetBytes(Number);
			return Convert.ToBase64String(Number);
		}

		public static string GetHash(string Value, string Salt = null)
		{
			var SHA = SHA256.Create();
			var ValueBytes = Encoding.UTF8.GetBytes((Salt ?? GetSalt()) + Value);
			var Hash = SHA.ComputeHash(ValueBytes);
			return Convert.ToBase64String(Hash);
		}
	}
}
