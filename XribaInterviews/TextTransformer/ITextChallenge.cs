namespace XribaInterviews
{
    public interface ITextChallenge
    {
        /// <summary>
        /// Check if the text is palindrome (i.e. "anna" or "Step on no pets")
        /// </summary>
        /// <param name="text">text to check</param>
        /// <returns>true if text is palindrome, false otherwise</returns>
        bool IsPalindrome(string? text);

        /// <summary>
        /// Remove all spaces from the text
        /// </summary>
        /// <param name="text">text to elaborate</param>
        /// <returns>text without spaces</returns>
        string RemoveSpaces(string? text);

        /// <summary>
        /// Reverse the text
        /// </summary>
        /// <param name="text">text to reverse</param>
        /// <returns>text reversed</returns>
        string Reverse(string? text);

        /// <summary>
        /// Offuscate the email replacing letters with asterix (i.e. mytest12345@yahoo.com in my*******45@ya*****om 
        /// In the end write the test
        /// </summary>
        /// <param name="email">email to offuscate</param>
        /// <returns>email offuscated</returns>
        string MaskEmail(string? email);

        /// <summary>
        /// Check if the expression has balanced curly brackets
        /// </summary>
        /// <param name="expression">expression to check</param>
        /// <returns>true if the expression have balanced curly brackets, false otherwise</returns>
        bool AreBalancedCurlyBrackets(string? expression);
    }
}
