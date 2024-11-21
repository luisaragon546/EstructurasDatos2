using System;
using System.Collections.Generic;

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
                        Console.WriteLine($"{node.Name} with price {node.Price} was removed");
                    }
                }

                if (opt == 3)
                {
                    queue.Print();
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

        public void Enqueue(string name, decimal price)
        {
            NodeQueue node = new NodeQueue(name, price);

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
            Console.WriteLine($"{name} with price {price} was added to the queue.");
        }

        public NodeQueue Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
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

        public bool IsEmpty()
        {
            return first == null;
        }

        // Método para imprimir todos los elementos de la cola
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            NodeQueue current = first;
            Console.WriteLine("Queue contents:");

            while (current != null)
            {
                Console.WriteLine($"Name: {current.Name}, Price: {current.Price}");
                current = current.Next;
            }
        }
    }

    internal class NodeQueue
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public NodeQueue Next { get; set; }

        public NodeQueue(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Next = null;
        }
    }

    // Main class to run the application
    class Program
    {
        static void Main(string[] args)
        {
            QueueFactory queueFactory = new QueueFactory();
            queueFactory.Start();
        }
    }
}
