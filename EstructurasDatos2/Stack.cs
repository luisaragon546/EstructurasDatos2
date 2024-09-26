using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
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
