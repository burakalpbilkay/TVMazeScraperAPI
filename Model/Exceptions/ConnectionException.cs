namespace TVMazeScrapperAPI.Models.Exceptions
{
    using System;

    /// <summary>
    /// Exception used when problems occur when communicating with an external application.
    /// </summary>
    public class ConnectionException : Exception
    {        
        public ConnectionException(string message)
            : base(message)
        {
        }
    }
}
