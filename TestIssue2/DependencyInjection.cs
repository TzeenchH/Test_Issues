using Microsoft.Extensions.DependencyInjection;

using TestIssue2.Interfaces;
using TestIssue2.Implementations;

namespace TestIssue2
{
	/// <summary>
	/// Класс предоставляющий уникальные для приложения методы внедрения зависимостей.
	/// </summary>
	public static class DependencyInjection
	{
		/// <summary>
		/// Метод обспечивающий внедрение логики.
		/// </summary>
		/// <param name="services"> Коллекция сервисов. </param>
		/// <returns>Дополненная коллекция сервисов. </returns>
		public static IServiceCollection AddLogicConfiguration(this IServiceCollection services)
		{
			services.AddSingleton<IReporter, Reporter>();
			services.AddTransient<IReportBuilder, ReportBuilder>();
			return services;
		}
	}
}