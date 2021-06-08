using System;
using System.Linq;

namespace TestIssue1
{
	public class TreeNode
	{
		public TreeNode(string[] strs)
		{
			var substrs = strs[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
			FirstName = substrs[^2];
			Lastname = substrs[^1];
			Generation = substrs.Count(x => x == "\t");
			Gender = strs[1].Trim() == "М" ? "Б" : "С";
			BirthDate = int.Parse(strs[2]);
		}
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public int Generation { get; set; }
		public string Gender { get; set; }
		public int BirthDate { get; set; }
	}

	public class Conditions
	{
		public Conditions(string[] conditionsInput)
		{
			var initials = conditionsInput[0].Split();
			if(initials.Length < 2 && conditionsInput.Length < 3 )
			{
				throw new InvalidOperationException();
			}
			Gender = conditionsInput[1].Trim();
			Firstname = initials[0];
			Lastname = initials[1];
			Degree = int.Parse(conditionsInput[2]);
		}
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Degree { get; set; }
		public int Generation { get; set; }
		public string Gender { get; set; }
	}
}