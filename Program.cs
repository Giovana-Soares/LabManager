﻿using LabManager.Database;
using LabManager.Models;
using LabManager.Repositories;
using Microsoft.Data.Sqlite;



var databaseConfig = new DatabaseConfig();
var DatabaseSetup= new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

// Roteamento
var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processador);
        }
    }

    if(modelAction == "New")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); 

        Console.WriteLine("New computer");
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processador = args[4];

        var computer = new Computer(id,ram,processador);
        computerRepository.Save(computer);
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        
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