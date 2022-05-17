using LabManager.Database;
using Microsoft.Data.Sqlite;


var databaseConfig = new DatabaseConfig();
var DatabaseSetup= new DatabaseSetup(databaseConfig);

// Roteamento
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); 
         
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers;";

        var reader = command.ExecuteReader();
        Console.WriteLine("Computer List");
        while(reader.Read())
        {
            Console.WriteLine("{0}, {1}, {2} ", reader.GetInt32(0), reader.GetString(1), reader.GetString(2)) ;
        }

        reader.Close();
        connection.Close();
    }

    if(modelAction == "New")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); 

        Console.WriteLine("New computer");
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processador = args[4];
        
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processador);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processador", processador);
        command.ExecuteNonQuery();
        
        connection.Close();
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();  
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab;";

        var reader = command.ExecuteReader();
        Console.WriteLine("Lab List");
        while(reader.Read())
        {
            Console.WriteLine("{0}, {1}, {2} {3}", reader.GetInt32(0), reader.GetString(1),  reader.GetString(2), reader.GetString(3)) ;
        }

        reader.Close();
        connection.Close();
    }

    if(modelAction == "New")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        Console.WriteLine("New lab");
        int id = Convert.ToInt32(args[2]);
        string num = args[3];
        string nome = args[4];
        string bloco = args[5];
         
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Lab VALUES($id, $num,  $nome, $bloco);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$num", num);
        command.Parameters.AddWithValue("$nome", nome);
        command.Parameters.AddWithValue("$bloco", bloco);

        command.ExecuteNonQuery();
        connection.Close();
    }
}