using CV_Maker.IRepository;
using CV_Maker.Repository.Models;
using Microsoft.Data.SqlClient;

namespace CV_Maker.Repository
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly string _connectionString;

        public PersonalDetailsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(PersonalDetail personalDetails)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO PersonalDetails (FirstName, LastName, Email, Phone, Address, City, State, Country, PostalCode, Education, WorkExperience) " +
                    "VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @City, @State, @Country, @PostalCode, @Education, @WorkExperience); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT)",
                    connection);
                command.Parameters.AddWithValue("@FirstName", personalDetails.FirstName);
                command.Parameters.AddWithValue("@LastName", personalDetails.LastName);
                command.Parameters.AddWithValue("@Email", personalDetails.Email);
                command.Parameters.AddWithValue("@Phone", personalDetails.Phone);
                command.Parameters.AddWithValue("@Address", personalDetails.Address);
                command.Parameters.AddWithValue("@City", personalDetails.City);
                command.Parameters.AddWithValue("@State", personalDetails.State);
                command.Parameters.AddWithValue("@Country", personalDetails.Country);
                command.Parameters.AddWithValue("@PostalCode", personalDetails.PostalCode);
                command.Parameters.AddWithValue("@Education", personalDetails.Education);
                command.Parameters.AddWithValue("@WorkExperience", personalDetails.WorkExperience);

                int id = (int)command.ExecuteScalar();
                personalDetails.Id = id;
            }
        }
        public PersonalDetail GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM PersonalDetails WHERE Id = @Id",
                    connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PersonalDetail
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                            PostalCode = reader.GetString(reader.GetOrdinal("PostalCode")),
                            Education = reader.GetString(reader.GetOrdinal("Education")),
                            WorkExperience = reader.GetString(reader.GetOrdinal("WorkExperience")),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
