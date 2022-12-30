using PreCommitHook.Enum;
using PreCommitHook.Helper;
using System.Collections.Generic;
using System.Linq;

namespace PreCommitHook.Test.HookCommand.Abstract
{
    public abstract class BaseFileNameTest : BaseHookTest
    {
        public BaseFileNameTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                           base(configHelper, processHelper, repos, txn)
        {
            // Pass through to the base class.
        }

        public string FileText { get; protected set; }

        public override Error Execute()
        {
            LogHelper.Info($"{GetType().Name}.Execute()");

            // Check if the individual test has been disabled by the config.
            if (!Enabled)
            {
                return Error.Success;
            }

            // Run a command to get the names of the files changed in the commit.
            string command = @$"svnlook changed -t {Txn} ""{Repos}""";

            // Get the process response and make sure the process doesn't generate an error.
            IList<string> response = new List<string>();
            if (!ProcessHelper.Process(command, ref response))
            {
                return Error.InternalError;
            }

            // Get file names from the response message.
            IList<string> fileNames = response.Select(r => r.Substring(4)).ToList();
            
            // Check if any of the file names contain the specified text.
            foreach (string fileName in fileNames)
            {
                if (fileName.Contains(FileText))
                {
                    return ErrorCode;
                }
            }

            // No instance of the specified text in the file names so return success.
            return Error.Success;
        }
    }
}
