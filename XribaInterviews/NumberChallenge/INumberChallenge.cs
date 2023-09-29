namespace XribaInterviews
{
    public interface INumberChallenge
    {
        /// <summary>
        /// Get digits from number
        /// </summary>
        /// <param name="number">the number</param>
        /// <returns>sequence of digits</returns>
        IEnumerable<short> GetDigits(uint number);

        /// <summary>
        /// Get number from digits
        /// </summary>
        /// <param name="digits">sequence of digits</param>
        /// <returns>the number</returns>
        uint GetNumber(IEnumerable<short> digits);

        /// <summary>
        /// Check if the number is a prime number (number whose only factors are 1 and itself)
        /// </summary>
        /// <param name="number">number to check</param>
        /// <returns>true if the number is prime, 0 otherwise</returns>
        bool IsPrime(ulong number);

        /// <summary>
        /// Check if the number is a prime number that has only the prime digits (2, 3, 5, or 7)
        /// </summary>
        /// <param name="number">number to check</param>
        /// <returns>true if the number is prime, 0 otherwise</returns>
        bool IsPrimeDigitPrime(ulong number);

        /// <summary>
        /// Check if a number is a pandigital number (an integer that has among its significant digits each digit used in the base at least once)
        /// </summary>
        /// <param name="number">the number to test</param>
        /// <returns>true if the number is pandigital, false otherwise</returns>
        bool IsPandigitalNumber(ulong number);
    }
}
