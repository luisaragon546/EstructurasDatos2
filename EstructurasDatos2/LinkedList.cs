using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class LinkedListFactory
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			LinkedList linkedList = new LinkedList();

			do
			{
				Console.WriteLine("What do you want to do in the Linked List?");
				Console.WriteLine("1. Add");
				Console.WriteLine("2. Add Position");
				Console.WriteLine("3. Remove");
				Console.WriteLine("4. Print");
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

					Console.WriteLine("Last Name:");
					string lastName = Console.ReadLine();

					linkedList.Add(name, lastName);
				}

				if (opt == 2)
				{
					Console.WriteLine("Name:");
					string name = Console.ReadLine();

					Console.WriteLine("Last Name:");
					string lastName = Console.ReadLine();

					Console.WriteLine("Name in list:");
					string nameInList = Console.ReadLine();

					linkedList.AddPosition(name, lastName, nameInList);
				}

				if (opt == 3)
				{
					
				}

				if (opt == 4)
				{
					linkedList.Print();
				}


			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class LinkedList
	{
		private NodeP Head;
		private int count = 0;

		public LinkedList()
		{
			Head = null;
		}

		public void Add(string _Name, string _LastName)
		{
			NodeP newNodeP = new NodeP(_Name, _LastName);

			if(Head == null) 
			{ 
				Head = newNodeP;
			}
            else
            {
				NodeP node = Head;
				while (node.Next != null)
				{
					node = node.Next;
				}
				node.Next = newNodeP;
            }
			count++;
        }

		public void AddPosition(string _Name, string _LastName, string _NameInList)
		{
			NodeP newNodeP = new NodeP(_Name, _LastName);

			NodeP pivot = Head;

			while (pivot != null)
			{
				if (pivot.Name == _NameInList)
				{
					newNodeP.Next = pivot.Next;
					pivot.Next = newNodeP;
					return;
				}

				pivot = pivot.Next;
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

			NodeP node = Head;

			while (node != null)
			{
				Console.WriteLine(node.Name + " " + node.LastName);
				node = node.Next;
			}
		}

		public bool isEmpty()
		{
			return Head == null;
		}
	}
}
