using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	public class StackFactory
	{
		public void Start()
		{
			Stack stack = new Stack();
			Stack reverseStack = new Stack();
			StackP stackP = new StackP();
			int opt;
			string vopt = string.Empty;

			do
			{
				Console.WriteLine("What do you want to do in the Stack?");
				Console.WriteLine("1. Push");
				Console.WriteLine("2. Find");
				Console.WriteLine("3. Print");
				Console.WriteLine("4. Pop");
				Console.WriteLine("5. Push Person");
				Console.WriteLine("6. Pop Person");
				Console.WriteLine("7. Reverse");
				Console.WriteLine("9. Exit");

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));				

				if (opt == 1)
				{
					Console.WriteLine("How many nodes are required?");
					int count = Convert.ToInt16(Console.ReadLine());

					for (int i = 0; i < count; i++)
					{
						Console.WriteLine("Node " + i);
						stack.Push(Convert.ToInt16(Console.ReadLine()));
					}
				}
				if (opt == 2)
				{
					Console.WriteLine("What value are you looking for?");
					stack.Find(Convert.ToInt16(Console.ReadLine()));
				}
				if (opt == 3)
				{
					stack.Print();
				}
				if (opt == 4)
				{
					stack.Pop();
				}
				if (opt == 5)
				{
					Console.WriteLine("Name: ");
					string name = Console.ReadLine();
					Console.WriteLine("Last Name: ");
					string lastName = Console.ReadLine();

					stackP.Push(name, lastName);

					stackP.Print();
				}
				if (opt == 6)
				{
					stackP.Pop();
				}
				if (opt == 7)
				{
					if (stack.IsEmpty())
					{
						Console.WriteLine("Stack is empty");
						return;
					}
					
					Node node = stack.Peek;

					do
					{
						Node removedNode = stack.Pop();
						reverseStack.Push(removedNode.Value);

						node = node.Next;
					}
					while (node != null);

					Console.WriteLine("Reversed Stack");
					reverseStack.Print();
				}

			} while (opt != 9);

			Console.ReadLine();
		}
	}
	internal class Stack
	{
		public Node Peek;
		public int Count;		

		public Stack()
		{
			Peek = null;
		}

		public void Push(int Value)
		{
			Node newNode = new Node(Value);

			newNode.Next = Peek;
			Peek = newNode;
			Count++;
		}

		public void Find(int Value)
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			Node node = Peek;

			do
			{
				if (node.Value == Value)
				{
					Console.WriteLine("Value is in the stack");
					return;
				}

				node = node.Next;
			}
			while (node != null);

			Console.WriteLine("Value is not in the stack");
		}

		public Node Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return null;
			}

			Node node = Peek;
			Peek = Peek.Next;

			Count--;

			Console.WriteLine(node.Value + " was removed");

			return node;
		}

		public void Print()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			Console.WriteLine("These are the elements in the stack:");
			Node node = Peek;
			Console.WriteLine(node.Value);

			while (node.Next != null)
			{
				node = node.Next;
				Console.WriteLine(node.Value);
			}
		}

		public bool IsEmpty()
		{
			return Peek == null;
		}
	}

	internal class StackP
	{
		public NodeP Peek;
		public int Count;

		public StackP()
		{
			Peek = null;
		}

		public void Push(string _Name, string _LastName)
		{
			NodeP newNode = new NodeP(_Name, _LastName);

			newNode.Next = Peek;
			Peek = newNode;
			Count++;
		}

		public void Find(string _Name, string _LastName)
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			NodeP node = Peek;

			do
			{
				if (node.Name == _Name && node.LastName == _LastName)
				{
					Console.WriteLine("Value is in the stack");
					return;
				}

				node = node.Next;
			}
			while (node != null);

			Console.WriteLine("Value is not in the stack");
		}

		public void Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			NodeP node = Peek;
			Peek = Peek.Next;

			Count--;

			Console.WriteLine(node.Name + " " + node.LastName + " was removed");
		}

		public void Print()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			Console.WriteLine("These are the elements in the stack:");
			NodeP node = Peek;
			Console.WriteLine(node.Name + " " + node.LastName);

			while (node.Next != null)
			{
				node = node.Next;
				Console.WriteLine(node.Name + " " + node.LastName);
			}
		}

		public bool IsEmpty()
		{
			return Peek == null;
		}
	}
}
