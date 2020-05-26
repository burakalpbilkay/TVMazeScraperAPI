namespace TVMazeScrapperAPI.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception that is used when an object was not found that should be found.
    /// </summary>
    public class NotFoundException : Exception
    {        
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
