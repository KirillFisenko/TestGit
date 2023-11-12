using System;
using System.Collections;

namespace CSharpEssentials
{
	class Animal
	{
		public string Name { get; set; }
	}

	class Cat : Animal
	{
		public Cat(string name)
		{
			Name = name;
		}
	}

	class Dog : Animal
	{
		public Dog(string name)
		{
			Name = name;
		}
	}
	class Program
	{
		static void Main()
		{
			List<Animal> animals = new List<Animal>
			{
				new Cat("Tom"),
				new Dog("Spike"),
				new Cat("Jerry"),
				new Dog("Max"),
			};
			var result = animals.Where(animal => animal is Cat).Select(cat => cat.Name).Cast<string>();
			Console.WriteLine(string.Join(" ", result));
		}
	}
}