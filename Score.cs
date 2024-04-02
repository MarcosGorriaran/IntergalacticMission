using System.Text.RegularExpressions;

namespace IntergalacticMission
{
    public class Score
    {
        const int MaxScore = 500;
        const string ErrorPlayRegexMissmatch = "The player must only have alphanumeric characters on their name";
        const string RegexPlayer = "^[a-zA-Z]+$";

        private string player;
        private string mission;
        private uint scoring;

        public string Player
        {
            get
            {
                return this.player;
            }
            set
            {
                if(!Regex.IsMatch(value, RegexPlayer))
                {
                    throw new Exception(ErrorPlayRegexMissmatch);
                }
                this.player = value;
            }
        }
        
    }
}
