namespace DataImport.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException(string fileName) : base($"The provided file {fileName} is in invalid format.")
        {
            
        }
    }
}
