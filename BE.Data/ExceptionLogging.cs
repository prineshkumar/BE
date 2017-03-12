using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Data
{
    public class ExceptionLogging
    {
        /// <summary>
        /// This method is used to log exception to database.
        /// This is the first choice of exception logging.
        /// </summary>
        public static void LogExceptiontoDB(Exception excep)
        {
            try
            {
            }
            catch
            {
                LogExceptiontoLogFile(excep);
            }
        }

        /// <summary>
        /// This method is used to log exception to log file
        /// This method has to be used when connection/logging to DB is failing
        /// </summary>
        public static void LogExceptiontoLogFile(Exception excep)
        {
            try
            {
            }
            catch
            {
                LogExceptiontoEventViewer(excep);
            }
        }

        /// <summary>
        /// This method is used to log exception to Event Viewer
        /// This method is least preferred and should be used when logging to DB and log files fails.
        /// </summary>
        public static void LogExceptiontoEventViewer(Exception excep)
        {

        }
    }
}
