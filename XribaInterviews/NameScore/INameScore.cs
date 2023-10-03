namespace XribaInterviews.NameScore
{
    public interface INameScore
    {
        /// <summary>
        /// Read a sequence of first names and calculate the total score of all names. 
        /// </summary>
        /// <param name="dataStream">stream to read names sequence (sequence of names comma separated)</param>
        /// <returns>the total score calculated by this logic: https://projecteuler.net/problem=22</returns>
        Task<int> GetTotalScoreAsync(Stream dataStream);
    }
}
