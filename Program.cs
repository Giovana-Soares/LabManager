
using Microsoft.Data.Sqlite;

var connection = new SqliteConnection("Data Source=database.db");
connection.Open();
var command = connection.CreateCommand();
command.CommandText = @"
CREATE TABLE IF NOT EXISTS Computers(
    id int not null primary key, 
    ram varchar(100) not null,
    processador varchar(100) not null
);
    CREATE TABLE IF NOT EXISTS Lab(
    id int not null primary key,
    num varchar(100) not null,  
    name varchar(100) not null,
    bloco varchar(100) not null
);
";
command.ExecuteNonQuery();

connection.Close();

// Roteamento
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        connection = new SqliteConnection("Data Source=database.db");
        connection.Open();  
        command = connection.CreateCommand();
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
        Console.WriteLine("New computer");
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processador = args[4];

        connection = new SqliteConnection("Data Source=database.db");
        connection.Open();  
        command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processador);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processador", processador);

        command.ExecuteNonQuery();
       // Console.WriteLine("{0},{1},{2}", id, ram, processador);
        connection.Close();
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        connection = new SqliteConnection("Data Source=database.db");
        connection.Open();  
        command = connection.CreateCommand();
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
        connection = new SqliteConnection("Data Source=database1.db");
        connection.Open(); 

        Console.WriteLine("New lab");
        int id = Convert.ToInt32(args[2]);
        string num = args[3];
        string nome = args[4];
        string bloco = args[5];

         
        command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Labs VALUES($id, $num,  $nome, $bloco);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$num", num);
        command.Parameters.AddWithValue("$nome", nome);
        command.Parameters.AddWithValue("$bloco", bloco);

        command.ExecuteNonQuery();
        connection.Close();
    }
}