namespace Los.Core
{
    internal interface ISearchable
    {
        /// <summary>
        ///     Return a score between 0 and 1
        /// </summary>
        /// <param name="key">should not contain space</param>
        /// <returns>between 0 and 1</returns>
        double CalcSearchScore(string key);

        double CalcSearchScore(string[] keys);
    }
}