namespace IntergalacticMission;

public class Driver
{
    public static void Main()
    {

        const string AskPlayerName = "Please provide me with the name of the player {0}: ";
        const string AskMissionCode = "Please provide me with the code of his mission: ";
        const string AskScore = "Please provide me with the score of the mission [0-500]: ";
        const string ShowScore = "Player {0} scores: ";
        const string ShowScoreStats = "   Mission: {0}\n      Score: {1}";
        const string FormatError = "The score must be a number";
        const int amountPlayers = 2;

        Score[] scores = new Score[amountPlayers];
        List<List<Score>> scoreList = new List<List<Score>>();
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
                    scores[i].Scoring = Convert.ToInt32(Console.ReadLine());
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
        scoreList = Score.GenerateUniqueRanking(new List<Score>(scores));

        foreach(List<Score> scoreSmallList in scoreList)
        {
            Console.WriteLine(ShowScore,scoreSmallList.First().Player);
            foreach(Score score in scoreSmallList)
            {
                Console.WriteLine(ShowScoreStats,score.Mission, score.Scoring);
            }
        }
    }
}
