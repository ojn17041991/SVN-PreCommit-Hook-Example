using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test.HookCommand.Abstract;

namespace PreCommitHook.Test
{
    public class TestRunner
    {
        ErrorHelper errorHelper = new ErrorHelper();

        public bool RunTest(BaseHookTest test, ref Error errorCode, ref string response)
        {
            // Execute the test and get the error code.
            errorCode = test.Execute();

            // If an error was found, then terminate here with the appropriate error code and message.
            if (errorCode > Error.Success)
            {
                response = $@"@echo {errorHelper.GetErrorMessage(errorCode)} >&2";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
