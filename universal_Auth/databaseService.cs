using System;
using MySql.Data.MySqlClient;
using WarNov.CryptAndHash;

namespace password_Manager
{
    public class databaseService
    {
        private readonly string connectionString;
        private readonly MySqlConnection cnn;

        public databaseService()
        {
            connectionString = "Server=127.0.0.1;Database=AUTH_template;Uid=" + allKeys.getDBUsername() + ";Pwd=" + allKeys.getDBPassword();
            cnn = new MySqlConnection(connectionString);
        }

        
        

        public bool RegisterUser(string name, string surname, string email, string username, string password, int age)
        {
            // Generate Salt and RedPepper using WarBCrypt.SecurePwd
            var securedPwdInfo = WarBCrypt.SecurePwd(password, allKeys.getBlackPepper(), allKeys.getWorkForceLevel());
            string hashedPassword = securedPwdInfo.SecuredPwd;
            string salt = securedPwdInfo.Salt;
            string redPepper = securedPwdInfo.RedPepper;
            bool registerSuccess = false;

            string insertUserQuery = "INSERT INTO users (name, surname, email, username, password, age, salt, redPepper) VALUES (@name, @surname, @email, @username, @hashedPassword, @age, @salt, @redPepper)";

            try
            {
                cnn.Open(); // Open the existing connection

                using MySqlCommand cmd = new MySqlCommand(insertUserQuery, cnn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@redPepper", redPepper);
                //salt and redPepper added to the database for correct userValidation.

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Successfully added user");
                    registerSuccess = true;
                    return registerSuccess;
                }
                else
                {
                    Console.WriteLine("Failed to add user");
                    registerSuccess = false;
                    return registerSuccess;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                registerSuccess = false;
                return registerSuccess;

            }
            finally
            {
                cnn.Close(); // Always close the connection after use to release resources
            }
        }





        public bool CheckValidationUser(string username, string password)
        {
            string hashedPasswordFromDB = GetHashedPassFromDB(username);
            string saltFromDB = GetSaltFromDB(username);
            string redPepperFromDB = GetRedPepperFromDB(username);

            if (!string.IsNullOrEmpty(hashedPasswordFromDB)) // If the user exists in the DB.
            {
                var securedPwdInfo = new SecuredPwdInfo
                {
                    RedPepper = redPepperFromDB,
                    Salt = saltFromDB,
                    SecuredPwd = hashedPasswordFromDB
                };

                // Verify if the user-entered password matches the hashed password from the database
                var verificationResult = WarBCrypt.Verify(password, securedPwdInfo, allKeys.getBlackPepper());

                if (verificationResult)
                {
                    return true;
                }
            }

            return false;
        }
        public string GetSaltFromDB(string username)
        {
            string getSaltQuery = "SELECT salt FROM Map_Weather.users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(getSaltQuery, cnn);
            cmd.Parameters.AddWithValue("@username", username);
            string saltFromDB = "";

            try
            {
                cnn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        saltFromDB = reader["salt"].ToString();
                    }
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return saltFromDB;
        }

        public string GetRedPepperFromDB(string username)
        {
            string getRedPepperQuery = "SELECT redPepper FROM Map_Weather.users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(getRedPepperQuery, cnn);
            cmd.Parameters.AddWithValue("@username", username);
            string redPepperFromDB = "";

            try
            {
                cnn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        redPepperFromDB = reader["redPepper"].ToString();
                    }
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return redPepperFromDB;
        }

        public string GetHashedPassFromDB(string username)
        {
            string getPassQuery = "SELECT passw FROM Map_Weather.users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(getPassQuery, cnn);
            cmd.Parameters.AddWithValue("@username", username);
            String hashedPassOfGivenUser = "";

            try
            {
                cnn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashedPassOfGivenUser = reader["passw"].ToString();
                    }
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return hashedPassOfGivenUser;
        }

    }
}


