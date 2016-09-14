using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Eric Pickard
//Group 2-1
//9/14/16

namespace ConsoleAssignment
{
    class Program
    {
        //Parent class for Team
        public class Team
        {
            public string name;
            public int wins;
            public int loss;
        }
        
        //Child class SoccerTeam that inherits Team class
        public class SoccerTeam:Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;
            public List<Game> lGames; 

            //SoccerTeam constructor
            public SoccerTeam(String sName, int iPoints)
            {
                this.name = sName;
                this.points = iPoints;
            }
        }

        //Game class
        public class Game
        {
            public int goalsFor;
            public int goalsAgainst;
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {
            int iNumTeams = 0;
            List<SoccerTeam> lTeams = new List<SoccerTeam>();
            bool bError = false;

            //error catching
            do
            {
                //reset bError
                bError = false;

                //find out how many teams
                Console.Write("How many teams? ");

                //see if input is an integer
                try
                {
                    //assign input to iNumTeams
                    iNumTeams = Convert.ToInt32(Console.ReadLine());

                    //see if number is neg integer or zero
                    if (iNumTeams < 1)
                    {
                        throw new Exception();
                    }
                }
                //catch for Exception
                catch (Exception e)
                {
                    bError = true;
                    Console.WriteLine("\nPlease enter a positive integer\n", e);
                }
            } while (bError == true);



            Console.WriteLine();

            //enter team names and points
            for (int iCount = 0; iCount < iNumTeams; iCount++)
            {
                String sTeamName;
                int iPoints = 0;

                //ask for team name
                Console.Write("Enter Team " + (iCount + 1) + "'s name: ");
                sTeamName = Console.ReadLine();

                //capitalize the first letter of team name
                sTeamName = UppercaseFirst(sTeamName);

                //error catching
                do
                {
                    //reset bError
                    bError = false;

                    //ask for team points
                    Console.Write("Enter " + sTeamName + "'s points: ");

                    //error catching
                    try
                    {
                        //assign input to iPoints
                        iPoints = Convert.ToInt32(Console.ReadLine());

                        //
                        if (iPoints < 0)
                        {
                            throw new Exception();
                        }
                    }

                    //catch for Exception
                    catch (Exception e)
                    {
                        bError = true;
                        Console.WriteLine("\nPlease enter a positive integer\n", e);
                    }
                } while (bError == true);


                //create new object and add to list
                SoccerTeam oSoccerTeam = new SoccerTeam(sTeamName, iPoints);
                lTeams.Add(oSoccerTeam);

                Console.WriteLine();
            }

            //sort the teams by points
            List<SoccerTeam> sortedTeams = lTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

            //display results header and seperator
            Console.WriteLine("Here is the sorted list: ");
            Console.WriteLine();
            Console.Write(Convert.ToString("Position").PadRight(25, ' '));
            Console.Write(Convert.ToString("Name").PadRight(25, ' ') + "Points\n");
            Console.Write(Convert.ToString("--------").PadRight(25, ' '));
            Console.Write(Convert.ToString("----").PadRight(25, ' ') + "------\n");

            //display results using foreach loop
            foreach (SoccerTeam soccerTeam in sortedTeams)
            {
                Console.Write(Convert.ToString(sortedTeams.IndexOf(soccerTeam) +1).PadRight(25, ' '));
                Console.Write(Convert.ToString(soccerTeam.name).PadRight(25, ' ') + soccerTeam.points + "\n");
            }

            Console.Read();
        }
    }
}
