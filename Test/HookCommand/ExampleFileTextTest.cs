using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test.HookCommand.Abstract;

namespace PreCommitHook.Test.HookCommand
{
    public class ExampleFileTextTest : BaseFileTextTest
    {
        // This is an example of how to process the file contents of an SVN commit.
        // In this case, we'll just check if the code in all committed files does not contain some arbitrary text.
        // This could be used to block commits that contain deprecated functions or bad code practises.

        public ExampleFileTextTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                              base(configHelper, processHelper, repos, txn)
        {
            ErrorCode = Error.ExampleFileTextUsage;
            Text = "Example Text";
        }
    }
}
