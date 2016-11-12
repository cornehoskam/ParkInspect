﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;

namespace ParkInspectGroupC.Encryption
{
	public class PassEncrypt
	{
		// <summary>
		// GetPasswordHash
		// </summary>
		// <returns>
		// Return the hash value from the password and identical guid. 
		// </returns>
		// <param name="passString">
		// passString; the original password from a textbox 
		// </param>
		// <param name="guid">
		// guid; a identical string generate form each account. Retreived from the database.
		// </param>
		public static string GetPasswordHash(string passString, string guid)
		{
			string hashedPassword;
			string stringToHash = passString += guid;

			hashedPassword = GenerateHashValue(stringToHash);

			// Dit is even om Corné zijn Github skills te testen.

			return hashedPassword;
		}

		public static string GetPasswordHash(string passString)
		{
			string hashedPassword;

			hashedPassword = GenerateHashValue(passString);

			return hashedPassword;
		}

		// <summary>
		// Generates a random guid string.
		// </summary>
		public static string GenerateGuid()
		{
			Guid userGuid = System.Guid.NewGuid();
			return userGuid.ToString();
		}

		private static string GenerateHashValue(string value)
		{
			var sha1 = System.Security.Cryptography.SHA1.Create();
			var inputBytes = Encoding.ASCII.GetBytes(value);
			var hash = sha1.ComputeHash(inputBytes);

			var sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}

			return sb.ToString();
		}

		// <summary>
		// Retreives a secure password.
		// </summary>
		public static string ConvertToUnsecureString(SecureString securePassword)
		{
			if (securePassword == null)
			{
				return string.Empty;
			}

			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}

	}
}
