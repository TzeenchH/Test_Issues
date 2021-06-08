using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestIssue1
{
	public class FilePreparer
	{
		public List<TreeNode> ReadFile(string path)
		{
			var preparedFile = new List<TreeNode>();
			try
			{
				var fileToRead = File.ReadLines(path).ToArray();
				preparedFile = PrepareFile(fileToRead).ValidateBirthDates();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Произошла ошибка при чтении файла");
			}
			return preparedFile;
		}

		/// <summary>
		/// Трансформирует коллекцию вычитанных строк в коллекцию экземпляров TreeNode
		/// </summary>
		/// <param name="strings">коллекция вычитанных из файла строк </param>
		/// <returns> коллекция экземпляров TreeNode</returns>
		private List<TreeNode> PrepareFile(IEnumerable<string> strings)
		{
			var prepared = new List<TreeNode>();
			foreach (var str in strings)
			{
				prepared.Add(new TreeNode(str.Split('|')));
			}
			return prepared;
		}
	}

	public class Searcher
	{
		/// <summary>
		/// Производит По коллекции основываясь на заданных условиях 
		/// </summary>
		/// <param name="resource"> коллекция в которой будет производиться поиск</param>
		/// <param name="conditions"> условия поиска</param>
		/// <returns> коллекцию экземпляров TreeNode, удовлетвор</returns>
		public IEnumerable<TreeNode> Search(IEnumerable<TreeNode> resource, Conditions conditions)
		{
			try
			{
				conditions.Generation = resource.First(x => x.FirstName == conditions.Firstname && x.Lastname == conditions.Lastname).Generation;
			}
			catch( Exception ex)
			{
				Console.WriteLine("Человек не найден");
			}
			conditions.ReverseLastname();
			var result = resource.Where(x => SearchConditions(x, conditions)).ToArray();
			return result;
		}

		private bool SearchConditions(TreeNode node, Conditions conditions)
		{
			if (node.Gender == conditions.Gender)
			{
				if(node.Generation == conditions.Generation && conditions.Degree == 2)
				{
					if (node.Lastname == conditions.Lastname)
						return true;
				}
				else if ( node.Generation == conditions.Generation && conditions.Degree == 3)
				{
					if (node.Lastname !=conditions.Lastname)
						return true;
				}
			}
			return false;
		}
	}
}