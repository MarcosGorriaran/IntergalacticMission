using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace IntergalacticMission
{
    public class Score : IComparable<Score>
    {
        
        const string ErrorPlayRegexMissmatch = "The player must only have alphanumeric characters on their name";
        const string ErrorMissionRegexMissmatch = "The mission code must start with a greek word followed by a 3 numeric code and splited by a - sign";
        const string ErrorScoringOutOfBounds = "The value must be between 0 and 500. Both included";
        const string RegexPlayer = "^[a-zA-Z]+$";
        const string RegexMission = "^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mi|Ni|Ksi|Omicron|Pi|Ro|Sigma|Tau|Ipsilon|Fi|Khi|Psi|Omega|Digamma|Heta|Qoppa|Sho|Stigma|San|Sampi)-[0-9]{3}$";
        const string DefPlayerName = "";
        const string DefMission = "Alpha-001";
        const int DefScore = 0;
        const int MaxScore = 500;
        const int MinScore = 0;

        private string player;
        private string mission;
        private int scoring;

        public Score(string playerName, string missionCode, int score) 
        {
            this.player = playerName;
            this.mission = missionCode; 
            this.scoring = score;
        }

        public Score():this(DefPlayerName,DefMission,DefScore)
        {

        }

        public string Player
        {
            get
            {
                return this.player;
            }
            set
            {
                if (!Regex.IsMatch(value, RegexPlayer))
                {
                    throw new Exception(ErrorPlayRegexMissmatch);
                }
                this.player = value;
            }
        }
        public string Mission
        {
            get
            {
                return this.mission;
            }
            set
            {
                if (!Regex.IsMatch(value, RegexMission))
                {
                    throw new Exception(ErrorMissionRegexMissmatch);
                }
                this.mission = value;
            }
        }
        public int Scoring
        {
            get
            {
                return this.scoring;
            }
            set
            {
                if(value > MaxScore || value <MinScore)
                {
                    throw new Exception(ErrorScoringOutOfBounds);
                }
                this.scoring = value;
            }
        }
        
        public static List<List<Score>> GenerateUniqueRanking(List<Score> scores)
        {
            List<List<Score>> filteredScoreList = new List<List<Score>>();
            var filteredScores = (from score in scores
                                 group score by score.Player into newGroup
                                 orderby newGroup.Key
                                 select newGroup);
            
            foreach (var scoreVals in filteredScores)
            {
                List<Score> scoreList = scoreVals.ToList();
                List<Score> nonRepeatedScore = new List<Score>();
                while(scoreList.Count > 0)
                {
                    nonRepeatedScore.Add(scoreList.First());
                    scoreList.RemoveAll(score => score.scoring==scoreList.First().scoring && score.Mission==scoreList.First().Mission);
                }
                nonRepeatedScore.Sort();
                filteredScoreList.Add(nonRepeatedScore);
            }
            return filteredScoreList;
        }
        public int CompareTo(Score other)
        {
            if(other.Scoring < this.Scoring)
            {
                return -1;
            }else if(other.Scoring > this.Scoring) { return 1; }
            return 0;
        }
    }
}
