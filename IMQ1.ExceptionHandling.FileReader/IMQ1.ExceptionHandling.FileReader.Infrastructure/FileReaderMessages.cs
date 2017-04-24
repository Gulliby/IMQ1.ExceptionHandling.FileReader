namespace IMQ1.ExceptionHandling.FileReader.Infrastructure
{
    internal static class FileReaderMessages
    {
        internal static string FileReaderFileIsNotExistMessage { get; set; } = "File is not exist!";

        internal static string FileReaderSystemExcetion { get; set; } = "FileReader is busy!";

        internal static string FileReaderUserExcetion { get; set; } = "FileReader can't be used with this sort of parameters!";
    }
}
