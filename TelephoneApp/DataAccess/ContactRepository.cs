using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneApp.Entitiy;

namespace TelephoneApp.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        private string _connectionString = "Data Source=phonebook.db;Version=3;";

        public ContactRepository()
        {

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                string tableCmd = @"CREATE TABLE IF NOT EXISTS Contacts (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Isim TEXT,
                                        Soyisim TEXT,
                                        Numara TEXT,
                                        Cinsiyet TEXT,
                                        Mail TEXT
                                    );";
                SQLiteCommand cmd = new SQLiteCommand(tableCmd, con);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Contacts", con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contacts.Add(new Contact
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Isim = reader["Isim"].ToString(),
                            Soyisim = reader["Soyisim"].ToString(),
                            Numara = reader["Numara"].ToString(),
                            Cinsiyet = reader["Cinsiyet"].ToString(),
                            Mail = reader["Mail"].ToString()
                        });
                    }
                }
            }

            return contacts;
        }

        public void Insert(Contact contact)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("INSERT INTO Contacts (Isim, Soyisim, Numara, Cinsiyet, Mail) VALUES (@Isim, @Soyisim, @Numara, @Cinsiyet, @Mail)", con);
                cmd.Parameters.AddWithValue("@Isim", contact.Isim);
                cmd.Parameters.AddWithValue("@Soyisim", contact.Soyisim);
                cmd.Parameters.AddWithValue("@Numara", contact.Numara);
                cmd.Parameters.AddWithValue("@Cinsiyet", contact.Cinsiyet);
                cmd.Parameters.AddWithValue("@Mail", contact.Mail);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Contact contact)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("UPDATE Contacts SET Isim=@Isim, Soyisim=@Soyisim, Numara=@Numara, Cinsiyet=@Cinsiyet, Mail=@Mail WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Isim", contact.Isim);
                cmd.Parameters.AddWithValue("@Soyisim", contact.Soyisim);
                cmd.Parameters.AddWithValue("@Numara", contact.Numara);
                cmd.Parameters.AddWithValue("@Cinsiyet", contact.Cinsiyet);
                cmd.Parameters.AddWithValue("@Mail", contact.Mail);
                cmd.Parameters.AddWithValue("@Id", contact.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("DELETE FROM Contacts WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
