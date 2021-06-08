namespace TestIssue2.Interfaces
{
	/// <summary>
	/// Предоставляет методы для генерации файла отчёта в зависимости от результата.
	/// </summary>
	public interface IReporter
	{
		/// <summary>
		/// Метод для генерации файла с успешным отчётом.
		/// </summary>
		/// <param name="Data">Данные для записи.</param>
		/// <param name="Id">ID отчёта.</param>
		public void ReportSuccess(byte[] Data, int Id);

		/// <summary>
		/// Метод для генерации файла с данными об ошибке построения отчёта.
		/// </summary>
		/// <param name="Id">ID отчёта.</param>
		public void ReportError(int Id);

		/// <summary>
		/// Метод для генерации файла с данными об отчёте, превысившем время построения.
		/// </summary>
		/// <param name="Id">ID отчёта.</param>
		public void ReportTimeout(int Id);
	}
}
