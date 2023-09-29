namespace XribaInterviews
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
        public void IsPalindrome_Test(string? text, bool expectedResult)
        {
            ITextChallenge th = GetInstance();
            var result = th.IsPalindrome(text);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(" ", "")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("Oggi è una bella giornata", "Oggièunabellagiornata")]
        public void RemoveSpaces_Test(string? text, string? expectedResult)
        {
            ITextChallenge th = GetInstance();
            var result = th.RemoveSpaces(text);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(" ", " ")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("Oggi è una bella giornata", "atanroig alleb anu è iggO")]
        public void Reverse_Test(string? text, string? expectedResult)
        {
            ITextChallenge th = GetInstance();
            var result = th.Reverse(text);
            Assert.Equal(expectedResult, result);
        }

        private ITextChallenge GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}