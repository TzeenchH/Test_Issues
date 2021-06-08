using System.IO;
using System.Text;
using TestIssue2.Interfaces;

namespace TestIssue2.Implementations
{
	public class Reporter : IReporter
	{
		
		public void ReportError(int Id)
		{
			var fl = File.OpenWrite($".\\Error_[{Id}].txt");
			fl.Write(Encoding.UTF8.GetBytes("Report error"));
			fl.Dispose();
		}

		public void ReportSuccess(byte[] Data, int Id)
		{
			var fl = File.OpenWrite($".\\Success_[{Id}].txt");
			fl.Write(Data);
			fl.Dispose();
		}

		public void ReportTimeout(int Id)
		{
			var fl = File.OpenWrite($".\\Timeout_[{Id}].txt");
			fl.Write(Encoding.UTF8.GetBytes("Report error"));
			fl.Dispose();
		}
	}
}