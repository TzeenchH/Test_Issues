using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TestIssue2.Interfaces;

namespace TestIssue2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private IReportBuilder _reportBuilder { get; set; }

		private IReporter _reporter { get; set; }

		private static int reportId = 0;
		private static CancellationTokenSource cancellationTokenSource { get; set; }
		private CancellationToken token { get; set; }

		public ReportController(IReportBuilder reportBuilder, IReporter reporter)
		{
			_reportBuilder = reportBuilder;
			_reporter = reporter;
		}

		
		[HttpGet("/build")]
		public ActionResult<int> Build()
		{
			cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
			token = cancellationTokenSource.Token;
			reportId++;
			
			var build = Task<byte[]>.Run(() => _reportBuilder.Build(token), token);

			var createSuccessReport = build.ContinueWith
				(
					(Task t) => _reporter.ReportSuccess(build.Result, reportId),
					TaskContinuationOptions.OnlyOnRanToCompletion
				);

			var createErrorReport = build.ContinueWith
				(
					(Task t) => _reporter.ReportError(reportId),
					TaskContinuationOptions.OnlyOnFaulted
				);
			var createTimeoutReport = build.ContinueWith
				(
					(Task t) => _reporter.ReportError(reportId),
					TaskContinuationOptions.OnlyOnCanceled
				);
			return reportId;
		}

		[HttpPost("/stop")]
		public void Stop(int Id)
		{
			cancellationTokenSource.Cancel();
			_reporter.ReportTimeout(Id);
		}
	}
}