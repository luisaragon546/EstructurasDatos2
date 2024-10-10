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

				if (opt == 3)
				{
					queue.Print();
				}

				if (opt == 4)
				{
					Console.WriteLine("What are you looking for?");
					string name = Console.ReadLine();
					queue.Find(name);
				}


			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class Queue
	{
		private NodeQueue First;
		private NodeQueue Last;
		private int count = 0;

		public Queue()
		{
			this.First = null;
			this.Last = null;
		}

		public void Enqueue(string _Name, decimal _Price)
		{
			NodeQueue node = new NodeQueue(_Name, _Price);

			if (Last != null)
			{
				Last.Next = node;
			}

			Last = node;

			if (First == null)
			{
				First = node;
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

			NodeQueue node = First;

			First = First.Next;

			if (First == null)
			{
				Last = null;
			}

			count--;

			return node;
		}

		public bool isEmpty()
		{
			return First == null;
		}

		public void Print()
		{
			if (isEmpty())
			{			
				Console.WriteLine("Queue is empty");
				return;
			}

			NodeQueue nodeQueue = First;

			while (nodeQueue != null)
			{
				Console.WriteLine(nodeQueue.Name + " " + nodeQueue.Price);
				nodeQueue = nodeQueue.Next;
			}
		}

		public void Find(string _Name)
		{
			if (isEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			NodeQueue node = First;

			do
			{
				if (node.Name == _Name)
				{
					Console.WriteLine("Product is in the queue");
					return;
				}

				node = node.Next;
			}
			while (node != null);

			Console.WriteLine("Product is not in the queue");
		}
	}
}
