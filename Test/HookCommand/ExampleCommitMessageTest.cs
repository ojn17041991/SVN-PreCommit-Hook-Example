using System.Collections.Generic;
using System.Linq;
using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test.HookCommand.Abstract;

namespace PreCommitHook.Test.HookCommand
{
	public class ExampleCommitMessageTest : BaseHookTest
	{
        // This is an example of how to process the commit text on an SVN commit.
        // In this case, we'll just check that a commit message was provided.

        public ExampleCommitMessageTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                                   base(configHelper, processHelper, repos, txn)
        {
            ErrorCode = Error.CommitMessageEmpty;
        }

        public override Error Execute()
        {
            LogHelper.Info("CommitMessageTest.Execute()");

            // Check if the individual test has been disabled by the config.
            if (!Enabled)
            {
                return Error.Success;
            }

            // Get the log message from svnlook.
            string command = @$"svnlook log ""{Repos}"" -t {Txn}";

            // Get the process response and make sure the process doesn't generate an error.
            IList<string> response = new List<string>();
            if (!ProcessHelper.Process(command, ref response))
            {
                return Error.InternalError;
            }

            // Check if the commit message length is greater than 0.
            return (response.Sum(r => r?.Length ?? 0) > 0) ? Error.Success : ErrorCode;
        }
	}
}
