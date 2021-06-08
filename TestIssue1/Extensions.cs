using System;
using System.Linq;
using System.Collections.Generic;

namespace TestIssue1
{
	public static class Extensions
	{
	/// <summary>
	/// Для поиска по  одному поколению отчеству производится замена его окончания на соответствующее искомому полу у текущей записи
	/// </summary>
		public static string ReverseLastname(this Conditions cond)
		{
			if (cond.Gender == "Б")
			{
				return cond.Lastname = cond.Lastname.Replace("вна", "вич");
			}
			return cond.Lastname = cond.Lastname.Replace("вич", "вна");
		}
	}

	public static class VlidationExtensions
	{
	/// <summary>
	/// Метод проверяющий правильность соотношения дат рождения родителей и детей. 
	/// Поскольку оговорено, что нет повторяющихся имён, то родителем считается первый найденный человек из предыдущего поколения
	/// </summary>
	/// <param name="source"> Валидироемый список</param>
	/// <returns> Возвращает список, из кторого исключены невалидные записи</returns>
	
		public static List<TreeNode> ValidateBirthDates(this IEnumerable<TreeNode> source)
		{
			var filteredNodes = new List<TreeNode>(source);
			foreach (var node in source)
			{
				var parent = source.FirstOrDefault( x => node.Lastname.Contains(x.FirstName) && node.Generation == x.Generation-1 );
				if (null != parent && node.BirthDate < parent.BirthDate)
				{
					Console.WriteLine($"Дата рождения родителя не может быть позже даты рождения ребёнка, запись о {node.FirstName} {node.Lastname} будет не будет добавлена");
					filteredNodes.Remove(node);
				}
			}
			return filteredNodes;
		}
	}
}