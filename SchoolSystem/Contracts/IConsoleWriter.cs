namespace SchoolSystem.IO
{
    public interface IConsoleWriter
    {
        void WriteLine(string messageToWrite);
        void Write(string messageToWrite);
    }
}