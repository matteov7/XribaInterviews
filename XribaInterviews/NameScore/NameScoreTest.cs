namespace XribaInterviews.NameScore
{
    public class NameScoreTest
    {
        [Theory]
        [InlineData("0022_names.txt", 871198282)]
        [InlineData("0022_names_2.txt", 222987815872)]
        public async Task GetTotalScore_Test(string filename, ulong expectedResult)
        {
            INameScore nameScore = GetInstance();
            using var s = File.OpenRead($"./NameScore/{filename}");
            var result = await nameScore.GetTotalScoreAsync(s);
            Assert.Equal(expectedResult, (ulong)result);
        }

        private INameScore GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
