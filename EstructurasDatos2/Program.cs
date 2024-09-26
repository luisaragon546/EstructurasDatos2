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
			Console.WriteLine("Menu");
			int opt = 0;

			do
			{
				Console.WriteLine("What do you want to do?");
				Console.WriteLine("1. Stack");
				Console.WriteLine("9. Exit"); ;
				opt = Convert.ToInt16(Console.ReadLine());

				if (opt == 1)
				{
					StackFactory stackFactory = new StackFactory();
					stackFactory.Start();
				}


			} while(opt != 9);
		}
	}
}
