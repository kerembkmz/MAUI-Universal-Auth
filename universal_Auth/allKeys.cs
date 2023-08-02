using System;
namespace password_Manager
{
	public class allKeys
	{
		//DB username and password
		private static string DBUsername = "root";
		private static string DBPassword = "Kerem/kerem10";

		//Hashing keys
		private static string salt = "hf9820msadg92";
        private static string blackPepper = "f1nd1ngn3m0";
        private static int workForceLevel = 11;


		//Methods to retrieve the attributes from different files.
		public static string getDBUsername() {
			return DBUsername;
		}

		public static string getDBPassword() {
			return DBPassword;
		}

		public static string getSalt() {
			return salt;
		}

		public static string getBlackPepper() {
			return blackPepper;
		}

		public static int getWorkForceLevel() {
			return workForceLevel;
		}

	}
}

