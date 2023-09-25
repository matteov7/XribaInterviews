namespace XribaInterviews.AlgTest
{
    /// <summary>
    /// Utility that helps transform a string
    /// </summary>
    public interface ITextTransformer
    {
        /// <summary>
        /// The transformed string
        /// </summary>
        string? Text { get; }

        /// <summary>
        /// Check if the string is palindrome
        /// </summary>
        /// <returns>true if palindrome, false otherwise</returns>
        bool IsPalindrome();

        /// <summary>
        /// Transforms the string removing spaces (if any)
        /// </summary>
        void RemoveSpaces();

        /// <summary>
        /// Transforms the string by reversing it
        /// </summary>
        void Reverse();
    }
}