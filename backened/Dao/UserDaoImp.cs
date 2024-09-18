using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;
using DotnetTask.Model;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DotnetTask.DAO
{
    public class UserDaoImp : IUserDaoImp
    {
        NpgsqlConnection _conn;

        public UserDaoImp(NpgsqlConnection conn)
        {
            _conn = conn;

        }

        public async Task<User> AddUser(User u, string host)
        {
            User insertedUser = null;
            string insertQuery = $@"INSERT INTO userdata (
                name, 
                date_of_birth, 
                residential_address, 
                permanent_address, 
                phone_number, 
                email_address, 
                marital_status, 
                gender, 
                occupation, 
                aadhar_card_number, 
                pan_number, 
                image
            ) 
            VALUES
            (
                '{u.Name}', 
                '{u.DateOfBirth}', 
                '{u.ResidentialAddress}', 
                '{u.PermanentAddress}', 
                '{u.PhoneNumber}', 
                '{u.EmailAddress}', 
                '{u.MaritalStatus}', 
                '{u.Gender}', 
                '{u.Occupation}', 
                '{u.AadharCardNumber}', 
                '{u.PanNumber}', 
                '{u.Image}'
            ) returning *";

            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _conn);
                    insertCommand.CommandType = CommandType.Text;

                    using (var reader = await insertCommand.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            insertedUser = new User
                            {
                                Name = reader["name"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["date_of_birth"].ToString()),
                                ResidentialAddress = reader["residential_address"].ToString(),
                                PermanentAddress = reader["permanent_address"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString(),
                                EmailAddress = reader["email_address"].ToString(),
                                MaritalStatus = reader["marital_status"].ToString(),
                                Gender = reader["gender"].ToString(),
                                Occupation = reader["occupation"].ToString(),
                                AadharCardNumber = reader["aadhar_card_number"].ToString(),
                                PanNumber = reader["pan_number"].ToString(),
                                Image = host + reader["image"].ToString()
                            };
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Exception in Insertion: " + ex.Message);
            }

            return insertedUser;
        }


        public async Task<int> DeleteUserById(int id)
        {
            string deleteQuery = "DELETE FROM userdata WHERE id = @id";
            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, _conn);
                    deleteCommand.CommandType = CommandType.Text;
                    deleteCommand.Parameters.AddWithValue("@id", id);

                    int rowDeleted = await deleteCommand.ExecuteNonQueryAsync();
                    return rowDeleted;
                }
            }

            catch (NpgsqlException e)
            {
                Console.WriteLine("---------Exception--------------" + e.Message);
            }
            return 0;
        }

        public async Task<List<User>> GetUsers(string host)
        {
            string query = "Select * from userdata";
            List<User> users = new List<User>();
            User user = null;

            try
            {
                using (_conn)
                {
                    await _conn.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _conn);
                    NpgsqlDataReader npgsqlDataReader = await command.ExecuteReaderAsync();

                    if (npgsqlDataReader.HasRows)
                    {

                        while (npgsqlDataReader.Read())
                        {
                            user = new User();
                            user.Id = npgsqlDataReader.GetInt32(0);
                            user.Name = npgsqlDataReader.GetString(1);
                            user.DateOfBirth = npgsqlDataReader.GetDateTime(npgsqlDataReader.GetOrdinal("date_of_birth"));
                            user.ResidentialAddress = npgsqlDataReader.GetString(3);
                            user.PermanentAddress = npgsqlDataReader.GetString(4);
                            user.PhoneNumber = npgsqlDataReader.GetString(5);
                            user.EmailAddress = npgsqlDataReader.GetString(6);
                            user.MaritalStatus = npgsqlDataReader.GetString(7);
                            user.Gender = npgsqlDataReader.GetString(8);
                            user.Occupation = npgsqlDataReader.GetString(9);
                            user.AadharCardNumber = npgsqlDataReader.GetString(10);
                            user.PanNumber = npgsqlDataReader.GetString(11);
                            user.Image = host + npgsqlDataReader.GetString(12);
                            users.Add(user);

                        }
                    }
                    npgsqlDataReader?.Close();
                    return users;

                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("------Exception------" + ex.Message);
            }

            return users;
        }

        public async Task<int> UpdateUserPhoneNumberById(int id, string phoneNumber)
        {
            string updateQuery = "update userdata set phone_number = @phoneNumber where id = @id;";
            int rowUpdated = 0;
            try
            {
                using (_conn)
                {
                    NpgsqlCommand command = new NpgsqlCommand(updateQuery, _conn);
                    await _conn.OpenAsync();
                    command.CommandType = CommandType.Text;
                    NpgsqlParameter numberParameter = new NpgsqlParameter()
                    {
                        ParameterName = "@phoneNumber",
                        NpgsqlDbType = NpgsqlDbType.Text,
                        Direction = ParameterDirection.Input,
                        Value = phoneNumber
                    };
                    NpgsqlParameter idParameter = new NpgsqlParameter()
                    {
                        ParameterName = "@id",
                        NpgsqlDbType = NpgsqlDbType.Integer,
                        Direction = ParameterDirection.Input,
                        Value = id

                    };


                    command.Parameters.Add(numberParameter);
                    command.Parameters.Add(idParameter);

                    rowUpdated = await command.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("---------Exception--------------" + e.Message);
            }


            return rowUpdated;

        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            // Ensure the Images folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Extract the original file name (without extension)
            var originalFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);

            // Create a unique file name by appending the timestamp
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var fileName = $"{originalFileName}_{timestamp}{Path.GetExtension(imageFile.FileName)}";
            // Combine the folder path and file name
            var filePath = Path.Combine(folderPath, fileName);

            // Save the image file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Return the relative image path to save in the database
            return $"Image/{fileName}";
        }


    }
}
