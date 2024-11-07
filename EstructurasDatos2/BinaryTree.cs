using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatos2
{
	internal class StartBinaryTree
	{
		public void Start()
		{
			int opt;
			string vopt = string.Empty;
			BinaryTree binaryTree = new BinaryTree();

			do
			{
				Console.WriteLine("What do you want to do in the Binary Tree?");
				Console.WriteLine("1. Add");
				Console.WriteLine("2. Search");
				Console.WriteLine("4. Print");
				Console.WriteLine("9. Exit");

				do
				{
					Console.WriteLine("Please choose an option with a number");
					vopt = Console.ReadLine();
				} while (!int.TryParse(vopt, out opt));

				if (opt == 1)
				{
					Console.WriteLine("Value:");
					int num = Convert.ToInt16(Console.ReadLine());

					binaryTree.Add(num);
				}

				if (opt == 2)
				{
					Console.WriteLine("What value are you looking for:");
					int num = Convert.ToInt16(Console.ReadLine());

					TreeNode nodeFound = binaryTree.Search(num);
					if (nodeFound != null)
					{
						Console.WriteLine(nodeFound.Value + " was found.");
					}
					else
					{
						Console.WriteLine(num + " was NOT found.");
					}

				}

				if (opt == 4)
				{
					binaryTree.DrawBinaryTree(binaryTree.root);
					Console.WriteLine("******************************************");
					binaryTree.DrawBinaryTree2(binaryTree.root);
				}

			} while (opt != 9);

			Console.ReadLine();
		}
	}

	internal class BinaryTree
	{
		public TreeNode root;

		public BinaryTree()
		{
			root = null;
		}

		public void Add(int value)
		{
			TreeNode newNode = new TreeNode(value);

			if (root == null)
			{
				root = newNode;
			}
			else
			{
				AddRecursive(root, newNode);
			}
		}

		public TreeNode Search(int value)
		{
			return SearchRecursive(root, value);
		}

		public TreeNode SearchRecursive(TreeNode parent, int value)
		{
			if (parent == null || parent.Value == value)
			{
				return parent;
			}

			if (value < parent.Value)
			{
				return SearchRecursive(parent.Left, value);
			}
			else
			{
				return SearchRecursive(parent.Right, value);
			}
		}

		public void AddRecursive(TreeNode parentNode, TreeNode childNode)
		{
			if (childNode.Value < parentNode.Value)
			{
				if (parentNode.Left == null)
				{
					parentNode.Left = childNode;
				}
				else
				{
					AddRecursive(parentNode.Left, childNode);
				}
			}
			else
			{
				if (parentNode.Right == null)
				{
					parentNode.Right = childNode;
				}
				else
				{
					AddRecursive(parentNode.Right, childNode);
				}
			}
		}

		public void DrawBinaryTree(TreeNode node, int space = 0, int level = 0, int maxLevel = 5)
		{
			if (node == null || level == maxLevel)
				return;

			space += 10;

			DrawBinaryTree(node.Right, space, level + 1, maxLevel);

			Console.WriteLine();
			for (int i = 10; i < space; i++)
				Console.Write(" ");
			Console.WriteLine(node.Value);

			DrawBinaryTree(node.Left, space, level + 1, maxLevel);
		}

		public void DrawBinaryTree2(TreeNode node, string indent = "", bool last = true)
		{
			if (node == null) return;

			Console.Write(indent);
			if (last)
			{
				Console.Write("└─");
				indent += "  ";
			}
			else
			{
				Console.Write("├─");
				indent += "| ";
			}

			Console.WriteLine(node.Value);

			DrawBinaryTree2(node.Left, indent, false);
			DrawBinaryTree2(node.Right, indent, true);
		}
	}
}
