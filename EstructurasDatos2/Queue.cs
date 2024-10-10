using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class QueueFactory
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			Queue queue = new Queue();

			do
			{
				Console.WriteLine("What do you want to do in the Queue?");
				Console.WriteLine("1. Enqueue");
				Console.WriteLine("2. Dequeue");
				Console.WriteLine("3. Print");
				Console.WriteLine("9. Exit");

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));

				if (opt == 1)
				{
					Console.WriteLine("Name:");
					string name = Console.ReadLine();

					Console.WriteLine("Price:");
					decimal price = Convert.ToDecimal(Console.ReadLine());

					queue.Enqueue(name, price);
				}

				if (opt == 2)
				{
					NodeQueue node = queue.Dequeue();

					if (node != null)
					{
						Console.WriteLine(node.Name + " was removed");
					}					
				}


			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class Queue
	{
		private NodeQueue first;
		private NodeQueue last;
		private int count = 0;

		public Queue()
		{
			this.first = null;
			this.last = null;
		}

		public void Enqueue(string _Name, decimal _Price)
		{
			NodeQueue node = new NodeQueue(_Name, _Price);

			if (last != null)
			{
				last.Next = node;
			}

			last = node;

			if (first == null)
			{
				first = node;
			}
			count++;
		}

		public NodeQueue Dequeue()
		{
			if (isEmpty())
			{
				Console.WriteLine("Queue is empty");
				return null;
			}

			NodeQueue node = first;

			first = first.Next;

			if (first == null)
			{
				last = null;
			}

			count--;

			return node;
		}

		public bool isEmpty()
		{
			return first == null;
		}
	}
}
