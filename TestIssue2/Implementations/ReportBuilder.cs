using System;
using System.Text;
using System.Threading;

using TestIssue2.Interfaces;

namespace TestIssue2.Implementations
{
	public class ReportBuilder : IReportBuilder
	{
		public byte[] Build(CancellationToken token)
		{
			int timeToBuild = new Random().Next(5, 45);
			int throwError = new Random().Next(0, 5);

			if (throwError == 0)
			{
				throw new Exception("ReportFailed");
			}

			for(int i = 0; i<timeToBuild; i++)
			{
				token.ThrowIfCancellationRequested();
				Thread.Sleep(1000);
			}

			return Encoding.UTF8.GetBytes($"Report ready at [{timeToBuild}] s.");
		}
	}
}