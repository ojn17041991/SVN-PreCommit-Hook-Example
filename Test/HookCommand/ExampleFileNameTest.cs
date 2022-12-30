using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test.HookCommand.Abstract;

namespace PreCommitHook.Test.HookCommand
{
    public class ExampleFileNameTest : BaseFileNameTest
    {
        public ExampleFileNameTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn) :
                              base(configHelper, processHelper, repos, txn)
        {
            ErrorCode = Error.ExampleFileNameUsage;
            FileText = "ExampleFileName";
        }
    }
}
