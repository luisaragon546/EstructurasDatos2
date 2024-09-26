using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
			int opt;

			do
			{
				Console.WriteLine("What do you want to do in the Stack?");
				Console.WriteLine("1. Push");
				Console.WriteLine("2. Find");
				Console.WriteLine("3. Print");
				Console.WriteLine("9. Exit"); ;
				opt = Convert.ToInt16(Console.ReadLine());

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

		public void Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return;
			}

			Node node = Peek;
			Peek = Peek.Next;

			Count--;

			Console.WriteLine(node.Value + " was removed");
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

			while(node.Next != null)
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
}
