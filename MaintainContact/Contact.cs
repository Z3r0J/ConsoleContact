using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MaintainContact
{

    public class Contact
    {
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
    public class Methodos
    {
        SqlConnection connection = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-PM985H2\\JEANCREYES",
                InitialCatalog = "Contact",
                UserID = "sa",
                Password="new",
                IntegratedSecurity = true
            }.ConnectionString
    );
        
        public List<Contact> ListarContacto(string buscar)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCONTACT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            reader = cmd.ExecuteReader();
            List<Contact> Listar = new List<Contact>();
            if (reader.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("ID | Nombre | Apellido | Telefono | Ciudad");
                while (reader.Read())
                {

                    Console.Write("*********************************************************************");
                    Console.WriteLine(" ");
                    Console.WriteLine("|{0} | {1} | {2} | {3} | {4}|", reader[0],reader[1],reader[2],reader[3],reader[4]);
                }
            }
            connection.Close();
            reader.Close();
            return Listar;
        }
        public void AgregarContacto(Contact contact)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTCONTACT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();

            cmd.Parameters.AddWithValue("@NAME", contact.Name);
            cmd.Parameters.AddWithValue("@LASTNAME", contact.LastName);
            cmd.Parameters.AddWithValue("@PHONENUMBER", contact.PhoneNumber);
            cmd.Parameters.AddWithValue("@CITY", contact.City);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void EditarContacto(Contact contact, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITCONTACT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@IDCONTACT", id);
            cmd.Parameters.AddWithValue("@NAME", contact.Name);
            cmd.Parameters.AddWithValue("@LASTNAME", contact.LastName);
            cmd.Parameters.AddWithValue("@PHONENUMBER", contact.PhoneNumber);
            cmd.Parameters.AddWithValue("@CITY", contact.City);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Contacto Editado Correctamente");
            connection.Close();
            
        }

        public void EliminarContacto(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETCONTACT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@IDCONTACT", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void SaludarContacto(Contact contact, int id)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SP_SALUDAR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@IDCONTACT", id);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                contact.Name = reader.GetString(1);
                contact.LastName = reader.GetString(2);
                contact.PhoneNumber = reader.GetString(3);
                contact.City = reader.GetString(4);
            }
            connection.Close();
        }

    }
}
