using System.Data.SQLite;

namespace Practices;

public class ContactRepository
{
    private readonly string _connectionString;

    public ContactRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateTable()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Contacts (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            PhoneNumber TEXT NOT NULL)";
            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddContact(string name, string phoneNumber)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO Contacts (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteContact(int id)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            string deleteQuery = "DELETE FROM Contacts WHERE Id = @Id";
            using (var command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void SearchContacts(string name)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM Contacts WHERE Name LIKE @Name";
            using (var command = new SQLiteCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", "%" + name + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                    }
                }
            }
        }
    }
}