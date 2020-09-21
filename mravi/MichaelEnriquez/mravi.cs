using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mravi
{
    struct Node
    {
        public int parent;
        public int percent;
        public int needed;
        public bool super;
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());

            // n-1 lines
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            for (int i = 0; i < n - 1; i++)
            {
                int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

                Node node = new Node();
                node.parent = input[0];
                node.percent = input[2];
                node.super = input[3] == 1;

                nodes.Add(input[1], node);
            }

            //ultimo
            int[] Ki = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < Ki.Length; i++)
            {
                if (Ki[i] == -1) continue;

                Node node = nodes[i + 1];
                node.needed = Ki[i];
                nodes[i + 1] = node;
            }

            //alg

            double max = 0;
            for (int i = 0; i < nodes.Count; i++)
            {
                Node node = nodes[nodes.Keys.ToArray()[i]];
                double contestant = node.needed;
                while (true)
                {
                    if (node.super) contestant = Math.Sqrt(contestant);
                    contestant *= 100 / (double)node.percent;

                    if (node.parent == 1) break;

                    node = nodes[node.parent];
                }
                if (contestant > max) max = contestant;
            }

            Console.WriteLine(max);
            Console.Read();
        }
    }
}