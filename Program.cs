namespace IntergalacticMission;

public class Driver
{
    public static void Main()
    {
        const string AskPlayerName = "Please provide me with the name of the player {0}: ";
        const string AskMissionCode = "Please provide me with the code of his mission: ";
        const string AskScore = "Please provide me with the score of the mission [0-500]: ";
        const string FormatError = "The score must be a number";
        const int amountPlayers = 10;

        Score[] scores = new Score[amountPlayers];

        for(int i = 0; i < amountPlayers; i++)
        {
            bool error;
            scores[i] = new Score();
            do
            {
                error = false;
                try
                {
                    Console.Write(AskPlayerName, i + 1);
                    scores[i].Player = Console.ReadLine()??"";
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            }while (error);
            
            do
            {
                error = false;
                try
                {
                    Console.Write(AskMissionCode);
                    scores[i].Mission = Console.ReadLine() ?? "";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            } while (error);
            do
            {
                error = false;
                try
                {
                    Console.Write(AskScore);
                    scores[i].Scoring = int.Parse(Console.ReadLine() ?? "");
                }
                catch (FormatException)
                {
                    Console.WriteLine(FormatError);
                    error = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            } while (error);
        }
    }
}
