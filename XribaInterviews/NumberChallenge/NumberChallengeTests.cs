namespace XribaInterviews
{
    public class NumberChallengeTests
    {
        [Theory]
        [InlineData(12345, new short[] { 1, 2, 3, 4, 5 })]
        [InlineData(12, new short[] { 1, 2 })]
        [InlineData(0, new short[] { 0 })]
        public void GetDigits_Test(uint number, IEnumerable<short> expectedResult)
        {
            INumberChallenge th = GetInstance();
            var result = th.GetDigits(number);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new short[] { 1, 2, 3, 4, 5 }, 12345)]
        [InlineData(new short[] { 1, 2 }, 12)]
        [InlineData(new short[] { 0 }, 0)]
        public void GetNumber_Test(IEnumerable<short> digits, uint expectedResult)
        {
            INumberChallenge th = GetInstance();
            var result = th.GetNumber(digits);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(19, true)]
        [InlineData(89, true)]
        [InlineData(389, true)]
        [InlineData(1789, true)]
        [InlineData(2357, true)]
        [InlineData(6, false)]
        [InlineData(18, false)]
        [InlineData(390, false)]
        [InlineData(2000, false)]
        public void IsPrime_Test(ulong number, bool expectedResult)
        {
            INumberChallenge th = GetInstance();
            var result = th.IsPrime(number);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(19, false)]
        [InlineData(89, false)]
        [InlineData(389, false)]
        [InlineData(1789, false)]
        [InlineData(6, false)]
        [InlineData(18, false)]
        [InlineData(390, false)]
        [InlineData(2000, false)]
        [InlineData(2357, true)]
        public void IsPrimeDigitPrime_Test(ulong number, bool expectedResult)
        {
            INumberChallenge th = GetInstance();
            var result = th.IsPrimeDigitPrime(number);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(15432, true)]
        [InlineData(199, false)]
        [InlineData(4545, false)]
        [InlineData(8, true)]
        [InlineData(0, true)]
        [InlineData(1234567890, true)]
        public void IsPandigitalNumber_Test(ulong number, bool expectedResult)
        {
            INumberChallenge th = GetInstance();
            var result = th.IsPandigitalNumber(number);
            Assert.Equal(expectedResult, result);
        }

        private INumberChallenge GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}