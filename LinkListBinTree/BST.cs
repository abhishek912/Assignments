using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListBinTree
{
    class MainClass
    {
        class Node
        {
            public int func;
            public int start;
        }

        public static void main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] ans = ExclusiveTime(n, input);
            foreach(int val in ans)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();

            /*int N = int.Parse(Console.ReadLine());
            int[] data = new int[N];
            for(int i = 0; i < N; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }
            BST b = new BST();
            b.CreateBST(data);
            b.AddDuplicateBST();
            //b.GreatestSumBST();
            b.PreOrderDisplay();*/
            Console.WriteLine("Press any key to Continue . . . ");
            Console.ReadKey();
        }

        static int[] ExclusiveTime(int n, IList<string> logs)
        {

            var stack = new Stack<Node>();
            var ans = new int[n];

            foreach (var log in logs)
            {
                var tokens = log.Split(':');

                int fId = int.Parse(tokens[0]);
                bool start = tokens[1] == "start";
                int time = int.Parse(tokens[2]);

                if (start)
                {
                    if (stack.Any())
                    {
                        ans[stack.Peek().func] += time - stack.Peek().start;
                    }

                    stack.Push(new Node() { func = fId, start = time });
                }
                else
                {
                    var top = stack.Pop();
                    ans[fId] += time - top.start + 1;

                    if (stack.Any())
                    {
                        stack.Peek().start = time + 1;
                    }
                }
            }

            return ans;

        }
    }

    class BST
    {
        Node root;

        public void AddDuplicateBST()
        {
            AddDuplicateBST(this.root);
        }

        private void AddDuplicateBST(Node root)
        {
            if(root == null)
            {
                return;
            }

            AddDuplicateBST(root.Left);

            Node n = new Node(root.Data);
            Node temp = root.Left;
            root.Left = n;
            n.Left = temp;

            AddDuplicateBST(root.Right);
        }

        public void PreOrderDisplay()
        {
            PreOrderDisplay(root);
        }
        private void PreOrderDisplay(Node root)
        {
            if (root == null)
            {
                return;
            }
            string output = "";
            if (root.Left == null)
            {
                output += "END => ";
            }
            else if (root.Left != null)
            {
                output += root.Left.Data + " => ";
            }

            output += root.Data;

            if (root.Right == null)
            {
                output += " <= END";
            }
            else if (root.Right != null)
            {
                output += " <= " + root.Right.Data;
            }
            Console.WriteLine(output);
            PreOrderDisplay(root.Left);
            PreOrderDisplay(root.Right);
        }

        public void GreatestSumBST()
        {
            int sum = 0;
            GreatestSumBST(root, ref sum);
        }

        private void GreatestSumBST(Node root, ref int sum)
        {
            if(root == null)
            {
                return;
            }
            GreatestSumBST(root.Right, ref sum);

            sum += root.Data;
            root.Data = sum - root.Data;

            GreatestSumBST(root.Left, ref sum);
        }

        public void CreateBST(int[] data)
        {
            root = new Node(data[0]);
            for(int i = 1; i < data.Length; i++)
            {
                Node curr = root, parent = null;
                while(curr != null)
                {
                    parent = curr;
                    if (data[i] <= curr.Data)
                    {
                        curr = curr.Left;
                    }
                    else
                    {
                        curr = curr.Right;
                    }
                }
                if(data[i] <= parent.Data)
                {
                    parent.Left = new Node(data[i]);
                }
                else
                {
                    parent.Right = new Node(data[i]);
                }
            }
            //DisplayBST();
        }

        public void DisplayBST()
        {
            //Level order traversal...
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                nodes.Enqueue(null);
                List<int> level = new List<int>();
                while (true)
                {
                    var front = nodes.Dequeue();
                    if (front == null)
                    {
                        break;
                    }
                    level.Add(front.Data);
                    if (front.Left != null)
                    {
                        nodes.Enqueue(front.Left);
                    }
                    if (front.Right != null)
                    {
                        nodes.Enqueue(front.Right);
                    }
                }
                foreach (int val in level)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
