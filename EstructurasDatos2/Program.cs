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
			string vopt = string.Empty;

			do
			{
				Console.WriteLine("What do you want to do?");
				Console.WriteLine("1. Stack");
				Console.WriteLine("2. Queue");
				Console.WriteLine("9. Exit"); ;			

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));

				if (opt == 1)
				{
					StackFactory stackFactory = new StackFactory();
					stackFactory.Start();
				}
				if (opt == 2)
				{
					QueueFactory queueFactory = new QueueFactory();
					queueFactory.Start();
				}

			} while(opt != 9);
		}
	}
}
