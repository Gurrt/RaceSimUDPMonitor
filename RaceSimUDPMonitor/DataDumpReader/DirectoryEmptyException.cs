namespace Gurrt.RaceSimUDPMonitor.DataDumpReader
{
    public class DirectoryEmptyException : Exception
    {
        public DirectoryEmptyException() : base() 
        {

        }

        public DirectoryEmptyException(string message): base(message)
        {
        }

        public DirectoryEmptyException(string message, Exception inner): base(message, inner)
        {
        }
    }
}