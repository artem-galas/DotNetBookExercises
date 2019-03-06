using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using Newtonsoft.Json;

namespace FXExample
{
    class Program
    {
        static string[] callsing = new string[]
        { "Husker", "Starbuck", "Apllo", "Boomer", "Bulldog", "Athena", "Helo" };

        static List<Person> people = new List<Person>
            {
                new Person(30000M) {
                    FirstName = "Alice", LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14)
                },
                new Person(40000M) {
                    FirstName = "Bob", LastName = "Jones",
                    DateOfBirth = new DateTime(1969, 11, 23),
                    Children = new HashSet<Person>
                    {
                        new Person(0M) {
                            FirstName = "Sally", LastName = "Rose",
                            DateOfBirth = new DateTime(1990, 7, 12)
                        }
                    }
                },
            };

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // OutputFileSystemInfo();
            // WorkingDisk();
            // WorkingDirs();
            // WorkingFiles();
            // WorkWithText();
            // SerializeXML();
            JsonParse();
        }

        static void JsonParse()
        {
            var jsonPath = Combine(CurrentDirectory, "people.json");
            StreamWriter sw = File.CreateText(jsonPath);
            var jss = new JsonSerializer();
            jss.Serialize(sw, people);
            sw.Close();

            Console.WriteLine();
            Console.WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to: {jsonPath}");
        }

        static void OutputFileSystemInfo()
        {
            Console.WriteLine($"Path.PathSeporator: {PathSeparator}");
            Console.WriteLine($"Path.DirectorySeparatorChar: {DirectorySeparatorChar}");
            Console.WriteLine($"Directory.GetCurrentDirectory(): {GetCurrentDirectory()}");
            Console.WriteLine($"Environment.CurrentDirectory: {CurrentDirectory}");
            Console.WriteLine($"Environment.SystemDirectory: {SystemDirectory}");
            Console.WriteLine($"Path.GetTempPath(): {GetTempPath()}");
            Console.WriteLine($"GetFolderPath(SpecialFolder):");
            Console.WriteLine($" System: {GetFolderPath(SpecialFolder.System)}");
            Console.WriteLine($" ApplicationData: {GetFolderPath(SpecialFolder.ApplicationData)}");
            Console.WriteLine($" MyDocuments: {GetFolderPath(SpecialFolder.MyDocuments)}");
            Console.WriteLine($" Personal: {GetFolderPath(SpecialFolder.Personal)}");
        }

        static void WorkingDisk()
        {
            Console.WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
            Console.WriteLine($"| {"Name",-30} | {"Type",-10} | {"Format",-7} | {"Size",18} | {"Free space",18} |");
            Console.WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"| {drive.Name,-30} | {drive.DriveType,-10} | {drive.DriveFormat,-7} | {drive.TotalSize,18:N0} | {drive.AvailableFreeSpace,18:N0} |");
                }
                else
                {
                    Console.WriteLine($"| {drive.Name,-30} | {drive.DriveType,-10} |");
                }

                Console.WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
            }
        }

        static void WorkingDirs()
        {
            string userFolder = GetFolderPath(SpecialFolder.Personal);
            var customFolder = new string[]
            { userFolder, "work", "DotNetTutorB", "Chapter09", "New Folder" };
            string dir = Combine(customFolder);

            Console.WriteLine($"Working width: {dir}");

            Console.WriteLine($"Does it Exist? {Exists(dir)}");

            Console.WriteLine("Create catalog");
            CreateDirectory(dir);

            Console.WriteLine($"Does it Exist? {Exists(dir)}");

            Console.WriteLine("Confirm that directory exist and press ENTER: ");
            Console.ReadLine();

            Console.WriteLine("Delete it...");
            Delete(dir, recursive: true);

            Console.WriteLine($"Does it Exist? {Exists(dir)}");
        }

        static void WorkingFiles()
        {
            string userFolder = GetFolderPath(SpecialFolder.Personal);
            var customFolder = new string[]
            { userFolder, "work", "DotNetTutorB", "Chapter09", "OutputFiles" };

            string dir = Combine(customFolder);
            CreateDirectory(dir);

            string textFile = Combine(dir, "Dommu.txt");
            string backupFile = Combine(dir, "Dommy.bak");

            Console.WriteLine($"Working with: {textFile}");

            StreamWriter textWritter = File.CreateText(textFile);
            textWritter.WriteLine("Hello, C#!");
            textWritter.Close();

            Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

            Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            Console.WriteLine("Confirm that file exist, and press ENTER:");
            Console.ReadLine();

            File.Delete(textFile);
            Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

            Console.WriteLine($"Reading contents of {backupFile}");
            StreamReader textReader = File.OpenText(backupFile);
            Console.WriteLine(textReader.ReadToEnd());
            textReader.Close();
        }

        static void SerializeXML()
        {

            string path = Combine(CurrentDirectory, "people.xml");
            FileStream fs = File.Create(path);
            var xs = new XmlSerializer(typeof(List<Person>));
            xs.Serialize(fs, people);

            fs.Close();
            Console.WriteLine($"{new FileInfo(path).Length} bytes of XML to {path}");
            Console.WriteLine();

            Console.WriteLine(File.ReadAllText(path));

            FileStream xmlLoad = File.Open(path, FileMode.Open);
            var loadedPople = (List<Person>)xs.Deserialize(xmlLoad);

            foreach (var item in loadedPople)
            {
                Console.WriteLine($"{item.LastName} has {item.Children.Count} children");
            }
        }
    
        static void WorkWithText()
        {
            string textFile = Combine(CurrentDirectory, "strams.txt");
            StreamWriter text = File.CreateText(textFile);

            foreach (string item in callsing)
            {
                text.WriteLine(item);
            }
            text.Close();

            Console.WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
            Console.WriteLine(File.ReadAllText(textFile));
        }
    }

}
