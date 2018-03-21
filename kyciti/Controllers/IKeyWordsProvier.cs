namespace kyciti.Controllers
{
    public interface IKeyWordsProvier
    {
        KeyWord[] GetKeyWords();
    }

    public class KeyWordsProvier : IKeyWordsProvier
    {
        public KeyWord[] GetKeyWords()
        {
            return new[]
            {
                new KeyWord
                {
                    Category = "money laundering",
                    Word = "money laundering"
                },
                new KeyWord
                {
                    Category = "money laundering",
                    Word = "concealing"
                },
                new KeyWord
                {
                    Category = "money laundering",
                    Word = "concealment"
                },
                new KeyWord
                {
                    Category = "fraud",
                    Word = "fraud"
                },
                new KeyWord
                {
                    Category = "fraud",
                    Word = "dupery"
                },
                new KeyWord
                {
                    Category = "fraud",
                    Word = "fraudulence"
                },
                new KeyWord
                {
                    Category = "corruption",
                    Word = "corruption"
                },
                new KeyWord
                {
                    Category = "corruption",
                    Word = "corruptness"
                },
                new KeyWord
                {
                    Category = "terror",
                    Word = "terror"
                },
                new KeyWord
                {
                    Category = "terror",
                    Word = "terrorism"
                }
            };
        }
    }
}