using System.Threading;

namespace TestIssue2.Interfaces
{
	/// <summary>
	/// Предоставляет метод построения отчёта.
	/// </summary>
	public interface IReportBuilder
	{
		/// <summary>
		/// Строит отчёт (имитирует процесс). Поскольку данная операция должна быть отменяемой, то в неё так же передаётся токен отмены.
		/// </summary>
		/// <returns> Байтовый массив данных отчёта в кодировке UTF-8. </returns>
		public byte[] Build(CancellationToken token);
	}
}