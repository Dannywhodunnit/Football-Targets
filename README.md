# Football-Targets
2018 player stats

--This is the C# Objects project of Daniel Thompson from the Wednesday evening class--
In brief: This console app allows the user to view and add stats to the players of
the 2018 Oakland Raiders players. Specifically targets for the receiving players, 
up to week six, allowing the user to add later statistics to the file.


------In Detail------

In this console application the user is able to access football stats of 
players on this years Oakland Raiders team. Currently offering the option 
to view the number of times each player was targeted (thrown to), for the
first six weeks. It was stopped there because week seven was a bye week with
no game to be played. The user can search for each of the 6 first weeks and
view how many times each player was thrown to, as well as see a list of the
players in order of most targets up to that point in the season, and even 
isolate a list of the top three most targeted players. Finally the user
will be able to add future data to the file, for weeks 8 through 16.

Later I would like to add more functionality to the application for a better idea
of the players performances through the season. Eventually the user will be able to
view and add to the number of touchdowns and catches each player had. In addition,
math logic could be added to update total targets, average targets, and catch 
percentages with user input. 

Finding a dataset, I used data from https://www.lineups.com/nfl/nfl-targets and
picked out the data specific to the Oakland Raiders players. Originally in CSV format,
I converted it to json to integrate it to my project. The "Player" class acts as a 
model for my "raidersFootBallData" file. In the Player class, it gets and sets mostly
intergers (due to most of the data being numerical statistics), but also uses string for
the player name and enum for player position since the players will be listed as one of
three potential positions on the team. Double is currently in place for the catch percentage
and average targets but will see more use later when more functionality is added.
