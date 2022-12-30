using System.Collections.Generic;
using System.Diagnostics;

namespace PreCommitHook.Helper
{
	public class ProcessHelper
	{
		public bool Process(string args, ref IList<string> response)
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = $"/c {args}",
					UseShellExecute = false,
					RedirectStandardOutput = true,
                    RedirectStandardError = true,
					CreateNoWindow = false
				}
			};
			process.Start();
            
            while (!process.StandardError.EndOfStream)
            {
                response.Add(process.StandardError.ReadLine());
            }
            if (response.Count > 0)
            {
                return false;
            }
			while (!process.StandardOutput.EndOfStream)
			{
                response.Add(process.StandardOutput.ReadLine());
			}
            return true;
		}
	}
}
