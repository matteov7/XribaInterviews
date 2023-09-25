namespace XribaInterviews.AlgTest
{
    public class TextTransformerTests
    {
        [Theory]
        [InlineData("Anna", true)]
        [InlineData("anna", true)]
        [InlineData("Ecco delle belle docce", true)]
        [InlineData("Ciao", false)]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("  ", true)]
        [InlineData("   ", true)]
        public void IsPalindrome_Tests(string? word, bool expectedResult)
        {
            ITextTransformer th = GetInstance(word);
            bool palindrome = th.IsPalindrome();
            Assert.Equal(expectedResult, palindrome);
        }        

        [Theory]
        [InlineData(" ", "")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("Oggi è una bella giornata", "Oggièunabellagiornata")]
        public void RemoveSpaces_Tests(string? word, string? expectedResult)
        {
            ITextTransformer th = GetInstance(word);
            th.RemoveSpaces();
            Assert.Equal(expectedResult, th.Text);
        }

        [Theory]
        [InlineData(" ", " ")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("Oggi è una bella giornata", "atanroig alleb anu è iggO")]
        public void Reverse_Tests(string? word, string? expectedResult)
        {
            ITextTransformer th = GetInstance(word);
            th.Reverse();
            Assert.Equal(expectedResult, th.Text);
        }

        private ITextTransformer GetInstance(string? word)
        {
            return new XribaInterviews.AlgTest.TextTransformer(word);
        }
    }
}