using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Football_Targets
{
    class Program
    {
        public static int MainMenu()
        {
            Console.WriteLine
                        ("                         2018 Football Catching Stats!" + Environment.NewLine +
                    "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" + Environment.NewLine +
                    "                               Type 1 for Week 1 targets" + Environment.NewLine +
                    "                               Type 2 for Week 2 targets" + Environment.NewLine +
                    "                               Type 3 for Week 3 targets" + Environment.NewLine +
                    "                               Type 4 for Week 4 targets" + Environment.NewLine +
                    "                               Type 5 for Week 5 targets" + Environment.NewLine +
                    "                               Type 6 for Week 6 targets" + Environment.NewLine +
                    "                               Type 17 for the Top 3 Target Players" + Environment.NewLine +
                    "                               Type 18 for Total Targets" + Environment.NewLine +
                    "                               Type 19 to add new weekly stats" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "                               Type 99 to exit" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------");
            return int.Parse(Console.ReadLine());


        }

        public static int AddMenu()
        {
            Console.WriteLine("------------------------choose a week------------------------" + Environment.NewLine +
                                "--------8--------" + Environment.NewLine +
                                "--------9--------" + Environment.NewLine +
                                "--------10--------" + Environment.NewLine +
                                "--------11--------" + Environment.NewLine +
                                "--------12--------" + Environment.NewLine +
                                "--------13--------" + Environment.NewLine +
                                "--------14--------" + Environment.NewLine +
                                "--------15--------" + Environment.NewLine +
                                "--------16--------");
            return int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(currentDirectory, "raidersFootballData.json");
            var players = ReadPlayerStats(fileName);
            //fileName = Path.Combine(directory.FullName, "raidersFootballData.json");
            //var players = DeserializePlayers(fileName);





            while (true)
            {
                var test = MainMenu();
                switch (test)
                {
                    case 1:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 1, {player.Position} {player.name} had {player.wk1} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;

                    case 2:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 2, {player.Position} {player.name} had {player.wk2} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;

                    case 3:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 3, {player.Position} {player.name} had {player.wk3} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;


                    case 4:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 4, {player.Position} {player.name} had {player.wk4} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;


                    case 5:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 5, {player.Position} {player.name} had {player.wk5} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;


                    case 6:
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"In week 6, {player.Position} {player.name} had {player.wk6} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;


                    case 17:
                        //Show top 3 targeted players
                        //var topThreeTargets = GetTopThreeTargets(players);

                        var topThreePlayers = GetTopThreeTargets(players);
                        players.Sort();

                        foreach (var player in topThreePlayers)
                        {
                            Console.WriteLine("Name: " + player.name + " Targets:" + player.totalTgts);
                        }
                        fileName = Path.Combine(currentDirectory, "topthree.json");
                        SerializeTopThreeToFile(topThreePlayers, fileName);

                        Console.ReadLine();
                        break;

                    case 18:
                        //When displaying stats, show each player in order of total targets for the season
                        players.Sort();
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"{player.Position} {player.name} had {player.totalTgts} targets");

                            NewStats newStats = new NewStats();
                            newStats.AddStats(players);
                        };
                        Console.ReadLine();
                        break;

                    case 19:
                        //add data for new updated weekly stats 
                        while (true)
                        {
                            var add = AddMenu();
                            switch (add)
                            {
                                case 8:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk8 = Console.ReadLine();

                                        player.wk8 = int.Parse(wk8);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        //players.Add(wk8);

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;


                                case 9:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk9 = Console.ReadLine();

                                        player.wk9 = int.Parse(wk9);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                        break;


                                case 10:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk10 = Console.ReadLine();

                                        player.wk10 = int.Parse(wk10);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;



                                case 11:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk11 = Console.ReadLine();

                                        player.wk11 = int.Parse(wk11);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;



                                case 12:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk12 = Console.ReadLine();

                                        player.wk12 = int.Parse(wk12);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;



                                case 13:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk13 = Console.ReadLine();

                                        player.wk13 = int.Parse(wk13);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;




                                case 14:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk14 = Console.ReadLine();

                                        player.wk14 = int.Parse(wk14);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;




                                case 15:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk15 = Console.ReadLine();

                                        player.wk15 = int.Parse(wk15);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;




                                case 16:
                                    foreach (Player player in players)
                                    {
                                        Console.Write($"How many targets did {player.Position} {player.name} have?");
                                        var wk16 = Console.ReadLine();

                                        player.wk16 = int.Parse(wk16);
                                        fileName = Path.Combine(currentDirectory, "raidersFootballData.json");

                                        Console.WriteLine($"{player.name}'s targets were added!");
                                    }
                                    break;


                                default:
                                    Console.WriteLine("Error message: Your input is not valid");
                                    break;
                            }
                            Console.ReadLine();
                            break;
                        }
                        break;


                    case 99:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Error message: Your input is not valid");
                        break;
                }
                if (test == 99)
                    break;

            }





        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        //Player stats and information weeks 1-6 of data

        public static List<Player> ReadPlayerStats(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var allData = JsonConvert.DeserializeObject<List<Player>>(reader.ReadToEnd());

                return allData;
            };

        }
        //
        //
//
//
//
//
//
        public static List<Player> SerializePlayers (List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
            
           
        }

        //Deserialize data
        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
            return players;
        }


        //generate top three targets
        public static List<Player> GetTopThreeTargets(List<Player> players)
        {
            var topThreeTargets = new List<Player>();
            players.Sort(new StatCompare());
            int counter = 0;
            foreach (var player in players)
            {
                topThreeTargets.Add(player);
                counter++;
                if (counter == 3)
                    break;
            }
            return topThreeTargets;
        }

        //Serialize data
        public static void SerializeTopThreeToFile(List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }
        
    }
}
