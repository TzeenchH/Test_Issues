using System;

namespace TestIssue1
{
	class Program
	{
		static void Main(string[] args)
		{
			var preparer = new FilePreparer();
			var searcher = new Searcher();
			Console.WriteLine("Введите путь к файлу источнику");
			var path = Console.ReadLine();
			var file = preparer.ReadFile(path);
			var key = new ConsoleKeyInfo();
			while (key.Key != ConsoleKey.Escape)
			{
				Console.WriteLine("Введите критерии поиска в формате 'Имя Фамилия, Пол, Степень родства'");
				var conditions = new Conditions(Console.ReadLine().Split(','));
				var result = searcher.Search(file, conditions);
				foreach (var res in result)
				{
					Console.WriteLine($"{res.FirstName} {res.Lastname}");
				}
				Console.WriteLine("Для завершения программы нажмите Esc, для продолжения любую другую");
				key = Console.ReadKey();
			}
		}
	}
}