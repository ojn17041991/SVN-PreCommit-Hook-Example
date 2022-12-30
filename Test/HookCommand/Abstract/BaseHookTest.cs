using PreCommitHook.Enum;
using PreCommitHook.Helper;

namespace PreCommitHook.Test.HookCommand.Abstract
{
	public abstract class BaseHookTest
	{
        public BaseHookTest(ConfigHelper configHelper, ProcessHelper processHelper, string repos, string txn)
        {
            ConfigHelper = configHelper;
            ProcessHelper = processHelper;

            Enabled = ConfigHelper.GetTestEnabled(GetType().Name);
			Repos = repos;
			Txn = txn;
        }

		protected ProcessHelper ProcessHelper { get; }
		protected ConfigHelper ConfigHelper { get; }

		public bool Enabled { get; }
		public Error ErrorCode { get; protected set; } = Error.InternalError; // This should be overriden by the inheriting class.
		public string Repos { get; }
		public string Txn { get; }

		public abstract Error Execute();
	}
}
