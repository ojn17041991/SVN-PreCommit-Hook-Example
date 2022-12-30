using PreCommitHook.Enum;
using PreCommitHook.Helper;
using System.Collections.Generic;
using System.Linq;

namespace PreCommitHook.Test.HookCommand.Abstract
{
    public abstract class BaseFileTextTest : BaseHookTest
    {
        public BaseFileTextTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                           base(configHelper, processHelper, repos, txn)
        {
            // Pass through to the base class.
        }

        public string Text { get; protected set; }

        public override Error Execute()
        {
            LogHelper.Info($"{GetType().Name}.Execute()");

            // Check if the individual test has been disabled by the config.
            if (!Enabled)
            {
                return Error.Success;
            }

            // Run a command to get the names of the files changed in the commit.
            string files_command = @$"svnlook changed -t {Txn} ""{Repos}""";

            // Get the process response and make sure the process doesn't generate an error.
            IList<string> files_response = new List<string>();
            if (!ProcessHelper.Process(files_command, ref files_response))
            {
                return Error.InternalError;
            }

            // Get file names from the response message.
            IList<string> fileNames = files_response.Select(r => r.Substring(4)).ToList();

            // Check the code contents of each of the files.
            foreach (string fileName in fileNames)
            {
                // Run a command to get the code from each file in the commit.
                string code_command = @$"svnlook cat -t {Txn} ""{Repos}"" ""{fileName}""";

                // Get the process response and make sure the process doesn't generate an error.
                IList<string> code_response = new List<string>();
                if (!ProcessHelper.Process(code_command, ref code_response))
                {
                    return Error.InternalError;
                }

                // Check line-by-line to see if the code contains the specified text.
                foreach (string line in code_response)
                {
                    if (line.Contains(Text))
                    {
                        return ErrorCode;
                    }
                }
            }

            // No instance of the specified text in the code so return success.
            return Error.Success;
        }
    }
}
