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
                "                           Type S for stats, 3 for the Top 3 Targeted Players, E to exit" + Environment.NewLine +
                "-------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                "-------------------------------------------------------------------------------------------------------");
            string UserInput = Console.ReadLine().ToUpper();
            try
            {
                UserInput = "S";
                Console.WriteLine("STATS");

                UserInput = "3";
                //Show top 3 targeted players
                var topThreeTargets = GetTopThreeTargets(players);

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
            var playerStats = new List<Player>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while((line = reader.ReadLine()) != null)
                {
                    var playerStat = new Player();
                    string[] values = line.Split(',');

                    playerStat.name = values[0];

                    Position Position;
                    if (Enum.TryParse(values[1], out Position))
                    {
                        playerStat.Position = Position;
                    }
                    int parseInt;
                    if (int.TryParse(values[2], out parseInt))
                    {
                        playerStat.wk1 = parseInt;
                    }
                    if (int.TryParse(values[3], out parseInt))
                    {
                        playerStat.wk2 = parseInt;
                    }
                    if (int.TryParse(values[4], out parseInt))
                    {
                        playerStat.wk3 = parseInt;
                    }
                    if (int.TryParse(values[5], out parseInt))
                    {
                        playerStat.wk4 = parseInt;
                    }
                    if (int.TryParse(values[6], out parseInt))
                    {
                        playerStat.wk5 = parseInt;
                    }
                    if (int.TryParse(values[7], out parseInt))
                    {
                        playerStat.wk6 = parseInt;
                    }
                    if (int.TryParse(values[8], out parseInt))
                    {
                        playerStat.totalTgts = parseInt;
                    }
                    if (int.TryParse(values[9], out parseInt))
                    {
                        playerStat.ctch = parseInt;
                    }
                    if (int.TryParse(values[10], out parseInt))
                    {
                        playerStat.touchDown = parseInt;
                    }

                    double averageTargets;
                    if (double.TryParse(values[11], out averageTargets))
                    {
                        playerStat.avgTgts = averageTargets;
                    }

                    double catchPercent;
                    if (double.TryParse(values[12], out catchPercent))
                    {
                        playerStat.catchPrcnt = catchPercent;
                    }

                    playerStats.Add(playerStat);
                }

            }
            return playerStats;
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
