using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Football_Targets
{
    class Program
    {

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "raidersFootballData.json");
            var fileContents = ReadPlayerStats(fileName);
            fileName = Path.Combine(directory.FullName, "raidersFootballData.json");
            var players = DeserializePlayers(fileName);




           
            Console.WriteLine
                        ("                         2018 Football Catching Stats!" + Environment.NewLine +
                    "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" + Environment.NewLine +
                    "                               Type 1 for Week 1 targets" + Environment.NewLine +
                    "                               Type 2 for Week 2 targets" + Environment.NewLine +
                    "                               Type 3 for Week 3 targets" + Environment.NewLine +
                    "                               Type 4 for Week 4 targets" + Environment.NewLine +
                    "                               Type 5 for Week 5 targets" + Environment.NewLine +
                    "                               Type 6 for Week 6 targets" + Environment.NewLine +
                    "                               Type TOP for the Top 3 Target Players" + Environment.NewLine +
                    "                               Type T for Total Targets" + Environment.NewLine +
                    "                               Type ADD to add new weekly stats" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "                               Type E to exit" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    "-------------------------------------------------------------------------------------------------------");
            string UserInput = Console.ReadLine().ToUpper();
           

                try
                {
                    UserInput = "1";
                    players.Sort();
                        foreach(Player player in players)
                    {
                        Console.WriteLine($"In week 1, {player.Position} {player.name} had {player.wk1} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();

                    UserInput = "2";
                    players.Sort();
                        foreach (Player player in players)
                    {
                        Console.WriteLine($"In week 2, {player.Position} {player.name} had {player.wk2} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break; 
                    };
                    Console.ReadLine();


                    UserInput = "3";
                    players.Sort();
                        foreach (Player player in players)
                    {
                        Console.WriteLine($"In week 3, {player.Position} {player.name} had {player.wk3} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();


                    UserInput = "4";
                    players.Sort();
                        foreach (Player player in players)
                    {
                        Console.WriteLine($"In week 4, {player.Position} {player.name} had {player.wk4} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();


                    UserInput = "5";
                    players.Sort();
                        foreach (Player player in players)
                    {
                        Console.WriteLine($"In week 5, {player.Position} {player.name} had {player.wk5} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();


                    UserInput = "6";
                    players.Sort();
                        foreach (Player player in players)
                    {
                        Console.WriteLine($"In week 6, {player.Position} {player.name} had {player.wk6} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();


                    UserInput = "TOP";
                    //Show top 3 targeted players
                    var topThreeTargets = GetTopThreeTargets(players);
                    
                    Console.ReadLine();

                    UserInput = "T";
                    /* 
                    When displaying stats, show each player in order of total targets for the season
                    */
                    players.Sort();
                    foreach (Player player in players)
                    {
                        Console.WriteLine($"{player.Position} {player.name} had {player.totalTgts} targets");

                        NewStats newStats = new NewStats();
                        newStats.AddStats(players);
                    break;
                    };
                    Console.ReadLine();

                    UserInput = "ADD";
                    Console.ReadLine();
                /* prompt the user to add target data 
                 
                                {
                    Console.WriteLine("------------------------choose a week------------------------" + Environment.NewLine +
                        "--------Week 8--------" + Environment.NewLine +
                        "--------Week 9--------" + Environment.NewLine +
                        "--------Week 10--------" + Environment.NewLine +
                        "--------Week 11--------" + Environment.NewLine +
                        "--------Week 12--------" + Environment.NewLine +
                        "--------Week 13--------" + Environment.NewLine +
                        "--------Week 14--------" + Environment.NewLine +
                        "--------Week 15--------" + Environment.NewLine +
                        "--------Week 16--------");
                    /*
                    Console.ReadLine();
                    string UserInput = Console.ReadLine().ToUpper();

                    try
                    {
                        UserInput = "WEEK 8";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk8  = Console.ReadLine();
                        
                        raidersFootballData.Add(wk8);

                        Console.WriteLine($"{player.name}'s targets were added!");


                        UserInput = "WEEK 9";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk9 = Console.ReadLine();

                        raidersFootballData.Add(wk9);

                        Console.WriteLine($"{player.name}'s targets were added!");



                        UserInput = "WEEK 10";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk10 = Console.ReadLine();

                        raidersFootballData.Add(wk10);

                        Console.WriteLine($"{player.name}'s targets were added!");



                        UserInput = "WEEK 11";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk11 = Console.ReadLine();

                        raidersFootballData.Add(wk11);
                        
                        Console.WriteLine($"{player.name}'s targets were added!");
                        


                        UserInput = "WEEK 12";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk12 = Console.ReadLine();

                        raidersFootballData.Add(wk12);

                        Console.WriteLine($"{player.name}'s targets were added!");



                        UserInput = "WEEK 13";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk13 = Console.ReadLine();

                        raidersFootballData.Add(wk13);

                        Console.WriteLine($"{player.name}'s targets were added!");




                        UserInput = "WEEK 14";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk14 = Console.ReadLine();

                        raidersFootballData.Add(wk14);

                        Console.WriteLine($"{player.name}'s targets were added!");




                        UserInput = "WEEK 15";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk15 = Console.ReadLine();

                        raidersFootballData.Add(wk15);

                        Console.WriteLine($"{player.name}'s targets were added!");




                        UserInput = "WEEK 16";
                        Console.Write("How many targets did {player.Position} {player.name} have?");
                        var wk16 = Console.ReadLine();

                        raidersFootballData.Add(wk16);

                        Console.WriteLine($"{player.name}'s targets were added!");


                        UserInput = "E";
                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error message: Your input is not valid, please choose a week or type E to exit" + Environment.NewLine +
                        "------------------------choose a week------------------------" + Environment.NewLine +
                        "--------Week 8--------" + Environment.NewLine +
                        "--------Week 9--------" + Environment.NewLine +
                        "--------Week 10--------" + Environment.NewLine +
                        "--------Week 11--------" + Environment.NewLine +
                        "--------Week 12--------" + Environment.NewLine +
                        "--------Week 13--------" + Environment.NewLine +
                        "--------Week 14--------" + Environment.NewLine +
                        "--------Week 15--------" + Environment.NewLine +
                        "--------Week 16--------");
                    }

                }

                //add data for new updated weekly stats 

                UserInput = "E";
                    //exit
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);

                }

                catch (Exception)
                {
                    Console.WriteLine("Error message: Your input is not valid, please type S for stats, E to exit");
                }*/

               

                //add data for new updated weekly stats 

                }

                catch (Exception)
                {
                    Console.WriteLine("Error message: Your input is not valid, please type S for stats, E to exit");
                }


            //Show top 3 targeted players
            var topThreePlayers = GetTopThreeTargets(players);
            players.Sort();

            foreach (var player in topThreePlayers)
            {
                Console.WriteLine("Name: " + player.name + " Targets:" + player.totalTgts);
            }
            fileName = Path.Combine(directory.FullName, "topthree.json");
            SerializeStatsToFile(topThreePlayers, fileName);
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
                foreach(var player in players)
                {
                    topThreeTargets.Add(player);
                    counter++;
                    if (counter == 3)
                        break;
                }
                return topThreeTargets;
            }

            //Serialize data
            public static void SerializeStatsToFile(List<Player> players, string fileName)
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
