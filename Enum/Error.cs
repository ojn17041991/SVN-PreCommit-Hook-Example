namespace PreCommitHook.Enum
{
    public enum Error
    {
        // Success: Allow the commit.
        Success = 0,

        // Error: Block the commit and inform the user.
        InternalError = 100,
        CommitMessageEmpty = 101,

        // Error: A specific keyword was found in the commit.
        ExampleFileNameUsage = 200,
        ExampleFileTextUsage = 201
    };
}
