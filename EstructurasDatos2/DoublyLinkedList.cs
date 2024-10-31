using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class DoublyLinkedListFactory
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

			do
			{
				Console.WriteLine("What do you want to do in the Doubly Linked List?");
				Console.WriteLine("1. Push");				
				Console.WriteLine("4. Print");
				Console.WriteLine("5. Print from Tail");
				Console.WriteLine("9. Exit");

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));

				if (opt == 1)
				{
					Console.WriteLine("Brand:");
					string brand = Console.ReadLine();

					Console.WriteLine("Model:");
					string model = Console.ReadLine();

					doublyLinkedList.Push(brand, model);
				}
				
				if (opt == 4)
				{
					doublyLinkedList.Print();
				}

				if (opt == 5)
				{
					doublyLinkedList.PrintFromTail();
				}


			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class DoublyLinkedList
	{
		private NodeDL Head; 
		private NodeDL Tail;

		private int count;

		public DoublyLinkedList()
		{
			Head = null; 
			Tail = null;
		}

		public void Push(string _Brand, string _Model)
		{
			NodeDL newNode = new NodeDL(_Brand, _Model);

			if(Head == null)
			{
				Head= newNode;
				Tail= newNode;
			}
            else
            {
				Tail.Next = newNode;
				newNode.Previous = Tail;
				Tail = newNode;
            }

			count++;
        }

		public void Print()
		{
			if (isEmpty())
			{
				Console.WriteLine("Linked List is empty");
				return;
			}

			NodeDL node = Head;

			while (node != null)
			{
				Console.WriteLine(node.Brand + " " + node.Model);
				node = node.Next;
			}
		}

		public void PrintFromTail()
		{
			if (isEmpty())
			{
				Console.WriteLine("Linked List is empty");
				return;
			}

			NodeDL node = Tail;

			while (node != null)
			{
				Console.WriteLine(node.Brand + " " + node.Model);
				node = node.Previous;
			}
		}

		public bool isEmpty()
		{
			return Head == null;
		}
	}
}
