using log4net;
using System;

namespace PreCommitHook.Helper
{
    public static class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger("FileAppender");

        public static void Error(string error, Exception e)
        {
            log?.Error(error, e);
        }

        public static void Warning(string warning)
        {
            log?.Warn(warning);
        }

        public static void Info(string info)
        {
            log?.Info(info);
        }
    }
}
