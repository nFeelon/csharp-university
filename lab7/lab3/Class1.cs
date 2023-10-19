using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

public class String
{
	public Production prodk;
	public Developer devk;
	private string value;
	public String()
	{
		value = "";
	}
	public String(string value)
	{
		this.value = value;
	}

	public String(string value, string pName, int pID, string dName, int dID, string dDepart)
	{
		prodk = new Production(pName, pID);
		devk = new Developer(dName, dID, dDepart);
	}
	public string Value
	{
		get { return value; }
		set { this.value = value; }
	}
	

	public int Length()
	{
		return value.Length;
	}

	public static bool operator ==(String a, String b)
	{
        string[] words1 = a.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] words2 = b.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        double avgLength1 = words1.Sum(w => w.Length);
        double avgLength2 = words2.Sum(w => w.Length);
        return avgLength1 == avgLength2;
    }

    public static bool operator !=(String a, String b)
    {
        string[] words1 = a.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] words2 = b.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        double avgLength1 = words1.Sum(w => w.Length);
        double avgLength2 = words2.Sum(w => w.Length);
        return avgLength1 != avgLength2;
    }

    public static bool operator <(String a, String b)
    {
		string[] words1 = a.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] words2 = b.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
		double avgLength1 = words1.Sum(w => w.Length);
		double avgLength2 = words2.Sum(w => w.Length);
		return avgLength1 < avgLength2;
    }

    public static bool operator >(String a, String b)
    {
        string[] words1 = a.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] words2 = b.value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        double avgLength1 = words1.Sum(w => w.Length);
        double avgLength2 = words2.Sum(w => w.Length);
        return avgLength1 > avgLength2;
    }

    public static String operator +(String a, int b)
    {
		return new String(a.Value + b.ToString());
    }

    public static String operator -(String a)
    {
        if (a.Length() > 0)
		{
			return new String(a.Value.Remove(a.Length() - 1));
		}
		else
		{
			return new String();
		}
    }

	public static String operator *(String a, char b)
	{
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i< a.Length(); i++)
		{
			sb.Append(b);
		}
		return new String(sb.ToString());
	}

	public class Production
	{
		private string orgName;
		private int id;

		public Production ()
		{
			orgName = "None";
			id = 0;
		}

		public Production (string orgName, int id)
		{
			this.orgName = orgName;
			this.id = id;
		}

		public string Name
		{
			get { return orgName; }
			set { orgName = value; }
		}

		public int Id
		{
			get { return id; }
			set {  id = value; }
		}

        public void ShowInfo()
        {
            Console.WriteLine($"Production: Name = {orgName}, ID = {id};");
        }
    }

	public class Developer
	{
		private string Name;
		private int id;
		private string department;

		public Developer()
		{
			Name = "None";
			id = 0;
			department = "None";
		}

		public Developer(string name, int id, string depart)
		{
			Name = name;
			this.id = id;
			department = depart;
		}

		public string NameV
		{
			get { return Name; }
			set { Name = value; }
		}

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public string Department
		{
			get { return department; }
			set { department = value; }
		}

		public void ShowInfo()
		{
            Console.WriteLine($"Developer: Name = {Name}, ID = {id}, Department = {department};");
        }
	}

	public void ShowInfo()
	{
		prodk.ShowInfo();
		devk.ShowInfo();
    }
}

static class StaticOperations
{
	public static String Sum(this String a, String b)
	{
		return new String(a.Value + b.Value);
	}

	public static int Diff(this String a)
	{
        string[] words = a.Value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
		if(words.Length > 0)
		{
			int max = words.Max(w => w.Length);
			int min = words.Min(w => w.Length);
			return max - min;
		}
		else
		{
			return 0;
		}
    }

	public static int Count(this String a)
	{
		string[] words = a.Value.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
		int count = 0;
        foreach (var item in words)
        {
			count++;
        }
        return count;
	}
	public static bool HasControlChars(this String a)
	{
		return a.Value.Any(c => (c >= 0 && c <= 31) || (c >= 127 && c <= 159));
	}

	public static String RemovePunct(this String a)
	{
		StringBuilder sb = new StringBuilder();
		foreach(char c in a.Value)
		{
			if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
			{
				sb.Append(c);
			}
		}
		return new String(sb.ToString());
	}
}
