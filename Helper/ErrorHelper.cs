using System.Collections.Generic;
using PreCommitHook.Enum;

namespace PreCommitHook.Helper
{
    public class ErrorHelper
	{
        private readonly IDictionary<Error, string> errorLookup = new Dictionary<Error, string>
        {
            {
                Error.Success,
                string.Empty
            },
            {
                Error.InternalError,
                "An internal error occurred."
            },
            {
                Error.CommitMessageEmpty,
                "A commit message is required."
            },
            {
                Error.ExampleFileNameUsage,
                @"The file ""ExampleFileName"" cannot be committed."
            },
            {
                Error.ExampleFileTextUsage,
                @"The code changes cannot include ""Example Text""."
            }
        };

        public string GetErrorMessage(Error errorCode)
        {
            return errorLookup?[errorCode] ?? errorLookup?[Error.InternalError];
        }
	}
}
