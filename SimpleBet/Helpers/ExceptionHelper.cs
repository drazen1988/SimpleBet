using NLog;

namespace SimpleBet.Helpers
{
    public static class ExceptionHelper
    {
        public static string LogAndDisplayErrorMessage(Exception exception, string addtionalInfo = "")
        {
            Logger logger = LogManager.GetLogger("errorLogger");
            logger.Error(exception, addtionalInfo);

            string messsage = string.Empty;

            if (exception.InnerException == null)
            {
                messsage = exception.Message;
            }
            else
            {
                messsage = exception.Message + " Inner exception: " + exception.InnerException.Message;
            }

            return messsage;
        }
    }
}
