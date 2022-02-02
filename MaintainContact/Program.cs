using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;

namespace MaintainContact
{
    class Program
    {
        public static int x;

        public static void Menu()
        {
            var chars = new[]
   {
    '\u2666'+ " ",
};

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("¿Que accion quieres realizar?: ");
            Console.WriteLine(chars[0] + "[1] - Listar");
            Console.WriteLine(chars[0] + "[2] - Agregar");
            Console.WriteLine(chars[0] + "[3] - Editar");
            Console.WriteLine(chars[0] + "[4] - Eliminar");
            Console.WriteLine(chars[0] + "[5] - Saludar Contacto");
            Console.WriteLine(chars[0] + "[6] - Limpiar");
            Console.WriteLine(chars[0] + "[7] - Salir");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("CONTACT-SYSTEM> ");
            x = Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Methodos methodos = new Methodos();
            int y;
            Console.WriteLine("[1] - Sacar Contactos");
            Console.WriteLine("[2] - CONTACT-SYSTEM");
            Console.Write("> ");
            y = Convert.ToInt32(Console.ReadLine());
            if (y==1)
            {
                var file = new FileInfo(@"C:\Users\admin\source\repos\MaintainContact\MaintainContact\bin\Debug\net5.0\Datos\Ejemplo.xlsx");
                using (ExcelPackage excel = new ExcelPackage(file))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet sheet = excel.Workbook.Worksheets["Hoja1"];
                    SqlConnection connection = new SqlConnection(
            new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-PM985H2\\JEANCREYES",
                InitialCatalog = "Contact",
                UserID = "sa",
                Password = "new",
                IntegratedSecurity = true
            }.ConnectionString
            );
            connection.Open();
                    var command = new SqlCommand("SELECT * FROM Contact", connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    int count = dataTable.Rows.Count;
                    sheet.Cells.LoadFromDataTable(dataTable,true);
                    FileInfo fileInfo = new FileInfo(@"C:\Users\admin\source\repos\MaintainContact\MaintainContact\bin\Debug\net5.0\Datos\Contact.xlsx");
                    excel.SaveAs(fileInfo);
                }
            }
            if (y==2)
            {
                Contacto();
            }
            Console.ReadKey();
        }
        public static void Contacto()
        {
            Methodos meth = new Methodos();
            Contact contact = new Contact();
                m:

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("CONTACT-SYSTEM>                                                                             ");
                Console.WriteLine("CONTACT-SYSTEM>   _|_|_|    _|_|    _|      _|  _|_|_|_|_|    _|_|      _|_|_|  _|_|_|_|_|  ");
                Console.WriteLine("CONTACT-SYSTEM> _|        _|    _|  _|_|    _|      _|      _|    _|  _|            _|      ");
                Console.WriteLine("CONTACT-SYSTEM> _|        _|    _|  _|  _|  _|      _|      _|_|_|_|  _|            _|      ");
                Console.WriteLine("CONTACT-SYSTEM> _|        _|    _|  _|    _|_|      _|      _|    _|  _|            _|      ");
                Console.WriteLine("CONTACT-SYSTEM>   _|_|_|    _|_|    _|      _|      _|      _|    _|    _|_|_|      _|      ");
                Console.WriteLine("CONTACT-SYSTEM>                                                                             ");
                Console.Write("\n");

                Menu();
              
                if (x==1)
                {
                    meth.ListarContacto("");
                    Console.WriteLine("\n");
                Console.Write("> ");
                Console.ReadKey();
                Console.Clear();
                goto m;
                }
                if (x == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta Nombre: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.Name = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta Apellido: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.LastName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta Telefono: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.PhoneNumber = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta Ciudad: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.City = Console.ReadLine();

                    meth.AgregarContacto(contact);
                Console.Write("> ");
                Console.ReadKey();
                Console.Clear();
                goto m;
            }
                if (x==3)
                {
                    int id;
                    meth.ListarContacto("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el ID del usuario a editar: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el nuevo nombre del contacto: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.Name = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el nuevo apellido del contacto: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.LastName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el nuevo telefono del contacto: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.PhoneNumber = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta la nueva ciudad del contacto: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    contact.City = Console.ReadLine();

                    meth.EditarContacto(contact, id);
                    meth.ListarContacto("");
                    Console.WriteLine("\n");
                Console.ReadKey();
                Console.Clear();
                goto m;
            }
                if (x==4)
                {
                    meth.ListarContacto("");
                    int id;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el ID del usuario a borrar: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    id = Convert.ToInt32(Console.ReadLine());
                    meth.EliminarContacto(id);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Contacto eliminado correctamente ");
                    meth.ListarContacto("");
                    Console.WriteLine("\n");
                Console.ReadKey();
                Console.Clear();
                goto m;
            }

                if (x == 5)
                {
                    int id;
                    meth.ListarContacto("");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inserta el ID del usuario a Saludar: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("CONTACT-SYSTEM> ");
                    id = Convert.ToInt32(Console.ReadLine());
                    meth.SaludarContacto(contact, id);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("CONTACT-SYSTEM> ");
                    Console.WriteLine("Hola al contacto " + contact.Name  + " " + contact.LastName + " su numero telefonico es" + " " + contact.PhoneNumber + " y es residente en" + " " +contact.City);
                Console.ReadKey();
                Console.Clear();
                goto m;

            }
                if (x==6)
                {
                    Console.Clear();
                Console.ReadKey();
                goto m;
            }
                if (x== 7){
                Environment.Exit(0);
                }
        }
    }
}
