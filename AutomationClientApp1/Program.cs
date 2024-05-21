// See https://aka.ms/new-console-template for more information

using AutomationClientApp1;
using System.IO;
using System.Reflection;

string programPath = Assembly.GetExecutingAssembly().Location;
string relativePath = @"..\..\..\..\WpfApp1\bin\Debug\net6.0-windows\WpfApp1.exe";
string appPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(programPath), relativePath));

Launcher.Launch(appPath, "WpfApp1");

string gridItem1 = Launcher.GetGridItem("UserGrid", 0, 0);
Console.WriteLine(gridItem1 != null ? $"Grid[\"UserGrid\"](0, 0) = {gridItem1}" : "Grid[\"UserGrid\"](0, 0) is null");
string tableItem1 = Launcher.GetTableItem("UserGrid", 0, 0);
Console.WriteLine(tableItem1 != null ? $"Table[\"UserGrid\"](0, 0) = {tableItem1}" : "Table[\"UserGrid\"](0, 0) is null");

string gridItem2 = Launcher.GetGridItem("UserDataGrid", 0, 0);
Console.WriteLine(gridItem2 != null ? $"UserDataGrid(0, 0) = {gridItem2}" : "UserDataGrid(0, 0) is null");
string tableItem2 = Launcher.GetTableItem("UserDataGrid", 0, 0);
Console.WriteLine(tableItem2 != null ? $"Table[\"UserDataGrid\"](0, 0) = {tableItem2}" : "Table[\"UserDataGrid\"](0, 0) is null");

Launcher.UnloadApp();
