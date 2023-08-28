namespace DesignPatterns.Singleton.Monostate
{
	public class CEO
	{
		private static string name;
		private static int age;

		public string Name
		{
			get => name;
			set => name = value;
		}

		public int Age
		{
			get => age;
			set => age = value;
		}

		public override string ToString()
		{
			return $"{{{nameof(Name)}={Name}, {nameof(Age)}={Age.ToString()}}}";
		}
	}

	public static class Monostate
	{
		public static void Test()
		{
			var ceo = new CEO();
			ceo.Name = "Adam smith";
			ceo.Age = 55;

			var ceo2 = new CEO();
			System.Console.WriteLine(ceo2);  // {Name=Adam smith, Age=55}
			// CEO�� �ʵ尡 static ����� ��ü������ �ϰ� �Ǹ� ���� ������ static �����
			// ���Եȴ�.
		}
	}
}