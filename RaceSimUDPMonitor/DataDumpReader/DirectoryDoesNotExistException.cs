namespace Gurrt.RaceSimUDPMonitor.DataDumpReader
{
    public class DirectoryDoesNotExistException : Exception
    {
        public DirectoryDoesNotExistException() : base() 
        {

        }

        public DirectoryDoesNotExistException(string message): base(message)
        {
        }

        public DirectoryDoesNotExistException(string message, Exception inner): base(message, inner)
        {
        }
    }
}