using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test.HookCommand.Abstract;

namespace PreCommitHook.Test.HookCommand
{
    public class ExampleFileNameTest : BaseFileNameTest
    {
        // This is an example of how to process the file names of an SVN commit.
        // In this case, we'll just check if the file name contains some arbitrary text.
        // This could be used to block commits to certain files or file types.

        public ExampleFileNameTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                              base(configHelper, processHelper, repos, txn)
        {
            ErrorCode = Error.ExampleFileNameUsage;
            FileText = "ExampleFileName";
        }
    }
}
