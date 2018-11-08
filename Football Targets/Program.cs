using System;
using System.Collections.Generic;
using System.IO;
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
            fileName = Path.Combine(directory.FullName, "players.json");
            var players = DeserializePlayers(fileName);

            //Show top 3 targeted players
            var topThreePlayers = GetTopThreeTargets(players);

            players.Sort();
            foreach(Player player in players)
            {
                Console.WriteLine($"{player.name} had {player.totalTgts} targets");

                NewStats newStats = new NewStats();
                newStats.AddStats(players);

                
            }

            Console.WriteLine
                ("                         2018 Football Catching Stats!" + Environment.NewLine +
                "                           Type S for stats" + Environment.NewLine +
                "                               Type Week 1 for Week 1 targets" + Environment.NewLine +
                "                               Type Week 2 for Week 2 targets" + Environment.NewLine +
                "                               Type Week 3 for Week 3 targets" + Environment.NewLine +
                "                               Type Week 4 for Week 4 targets" + Environment.NewLine +
                "                               Type Week 5 for Week 5 targets" + Environment.NewLine +
                "                               Type Week 6 for Week 6 targets" + Environment.NewLine +
                "                           Type 3 for the Top 3 Target Players" + Environment.NewLine +
                "                           Type ADD to add new weekly stats" + Environment.NewLine +
                "                            Type E to exit" + Environment.NewLine +


                "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                "-------------------------------------------------------------------------------------------------------");
            string UserInput = Console.ReadLine().ToUpper();
            try
            {
                UserInput = "S";
                Console.WriteLine("STATS");
                Console.WriteLine("Here are the receiving stats of the 2018 Oakland Raiders players from weeks 1 - 6");
                Console.ReadLine();

                /*          When displaying stats, show each player in order of total targets for the season
                 *          players.Sort();
                foreach (Player player in players)
                {
                    Console.WriteLine($"{player.name} had {player.totalTgts} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);


                }
                */

                UserInput = "WEEK 1";
                players.Sort();
                    foreach(Player player in players)
                {
                    Console.WriteLine($"In week 1, {player.name} had {player.wk1} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();

                UserInput = "WEEK 2";
                players.Sort();
                    foreach (Player player in players)
                {
                    Console.WriteLine($"In week 2, {player.name} had {player.wk2} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();


                UserInput = "WEEK 3";
                players.Sort();
                    foreach (Player player in players)
                {
                    Console.WriteLine($"In week 3, {player.name} had {player.wk3} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();


                UserInput = "WEEK 4";
                players.Sort();
                    foreach (Player player in players)
                {
                    Console.WriteLine($"In week 4, {player.name} had {player.wk4} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();


                UserInput = "WEEK 5";
                players.Sort();
                    foreach (Player player in players)
                {
                    Console.WriteLine($"In week 5, {player.name} had {player.wk5} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();


                UserInput = "WEEK 6";
                players.Sort();
                    foreach (Player player in players)
                {
                    Console.WriteLine($"In week 6, {player.name} had {player.wk6} targets");

                    NewStats newStats = new NewStats();
                    newStats.AddStats(players);
                };
                Console.ReadLine();


                UserInput = "3";
                //Show top 3 targeted players
                var topThreeTargets = GetTopThreeTargets(players);
                Console.ReadLine();

                UserInput = "ADD";
                Console.ReadLine();
                //add data for new updated weekly stats 

                UserInput = "E";
                //exit
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);

            }

            catch (Exception)
            {
                Console.WriteLine("Error message: Your input is not valid, please type S for stats, E to exit");
            }

           // Console.WriteLine("Here are the receiving stats of the 2018 Oakland Raiders players from weeks 1 - 6");
           // Console.ReadLine();




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

            
            
           
            
            
            
            
            /*
            Console.WriteLine
                ("                         2018 Football Catching Stats!" + Environment.NewLine +
                "                           Type S for stats, E to exit" + Environment.NewLine +
                "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                "-------------------------------------------------------------------------------------------------------");
            string UserInput = Console.ReadLine().ToUpper();
                try
                    {
                        UserInput = "S";
                        Console.WriteLine("STATS");


                        UserInput = "E";
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);

                    }

                catch (Exception)
                    {
                        Console.WriteLine("Error message: Your input is not valid, please type S for stats, E to exit");
                    }

            Console.WriteLine("Here are the receiving stats of the 2018 Oakland Raiders players from weeks 1 - 6");
            Console.ReadLine();
            */
        }
    }
