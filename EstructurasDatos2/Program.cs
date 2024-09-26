using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");

			Stack stack = new Stack();

			stack.Push(4);
			stack.Push(7);
			stack.Push(1);
			stack.Push(9);

			stack.Print();

			stack.Pop();

			stack.Print();

			Console.ReadLine();
		}
	}
}
