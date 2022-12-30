using PreCommitHook.Enum;
using PreCommitHook.Helper;
using PreCommitHook.Test;
using PreCommitHook.Test.HookCommand;
using System;

namespace PreCommitHook
{
    class Program
    {
        static ConfigHelper ConfigHelper { get; set; }
        static ProcessHelper ProcessHelper { get; set; }
        static TestRunner TestRunner { get; set; }
        static string Repos { get; set; }
        static string Txn { get; set; }

        static int Main(string[] args)
        {
            LogHelper.Info($"Main({args})");

            // Run the setup, and exit immediately if there were any errors.
            if (!Setup(args))
            {
                return (int)Error.InternalError;
            }

            // Start running through the tests.
            int errorCode = (int)RunTests();

            // Process, log and return the result.
            LogHelper.Info($"Exiting with error code {errorCode}");
            return errorCode;
        }

        static bool Setup(string[] args)
        {
            LogHelper.Info($"Setup({args})");

            try
            {
                ConfigHelper = new ConfigHelper();
                ProcessHelper = new ProcessHelper();
                TestRunner = new TestRunner();

                Repos = args[0];
                Txn = args[1];
            }
            catch (Exception e)
            {
                LogHelper.Error($"Setup({args})", e);
                return false;
            }

            return true;
        }

        static Error RunTests()
        {
            LogHelper.Info("RunTests()");

            // Variables required for testing.
            bool testsEnabled = ConfigHelper.GetTestsEnabled();

            // Variables required for handling test responses.
            Error errorCode = Error.Success;
            string response = string.Empty;

            // Make sure tests are enabled before continuing.
            if (!testsEnabled)
            {
                return Error.Success;
            }

            // Start running the main tests:
            // 1) Make sure we have a commit message.
            if (!TestRunner.RunTest(
                new ExampleCommitMessageTest(ConfigHelper, ProcessHelper, Repos, Txn),
                ref errorCode,
                ref response))
            {
                Console.WriteLine(response);
                return errorCode;
            }

            // 2) Make sure none of the committed file names contain "ExampleFileName".
            if (!TestRunner.RunTest(
                new ExampleFileNameTest(ConfigHelper, ProcessHelper, Repos, Txn),
                ref errorCode,
                ref response))
            {
                Console.WriteLine(response);
                return errorCode;
            }

            // 3) Make sure none of the committed code contains "Example Text".
            if (!TestRunner.RunTest(
                new ExampleFileTextTest(ConfigHelper, ProcessHelper, Repos, Txn),
                ref errorCode,
                ref response))
            {
                Console.WriteLine(response);
                return errorCode;
            }

            // ... Add more tests here ...

            // No errors have been found, so return success.
            return Error.Success;
        }
    }
}
