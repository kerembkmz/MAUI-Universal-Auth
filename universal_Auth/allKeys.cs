using System;
namespace password_Manager
{
	public class allKeys
	{
		//DB username and password
		private static string DBUsername = "your mySql username(usually root)";
		private static string DBPassword = "your mySql password";

		//Hashing keys
		private static string salt = "salt value of your choice";
        private static string blackPepper = "pepper value of your choice";
        private static int workForceLevel = 11; //Can change, higher number means 
        										//more protection but it will take more time.


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

