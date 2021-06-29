using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListBinTree
{
    class Program
    {
        static void main(string[] args)
        {
            BinaryTree b = new BinaryTree();
            b.CreateTreeWithLevelOrder();
            b.RightView();
            //b.DisplayLeafNodes();
            /*string[] input1 = Console.ReadLine().Split(' ');
            //string[] input2 = Console.ReadLine().Split(' ');
            //int k = int.Parse(Console.ReadLine());

            BinaryTree tree1 = new BinaryTree();
            //BinaryTree tree2 = new BinaryTree();
            tree1.CreateBinaryTree(input1);
            //tree2.CreateBinaryTree(input2);
            //b.RootToLeafPathWithSumK(k);

            //bool result = tree1.CheckStructureIdentical(tree2);
            //Console.WriteLine(result);

            //tree1.NodeWithNoSibling();

            //tree1.RemoveLeaves();
            //tree1.PreOrderDisplay();

            //int sum = tree1.GetSumOfNodes();
            //Console.WriteLine(sum);

            bool balance = tree1.CheckBalance();
            if (balance) Console.WriteLine("true");
            else Console.WriteLine("false");
            //tree1.DisplayBinaryTree();*/

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadLine();
        }
    }

    class Node
    {
        int data;
        Node left, right;

        public int Data
        {
            set { this.data = value; }
            get { return data; }
        }
        public Node Left
        {
            set { left = value; }
            get { return left; }
        }
        public Node Right
        {
            set { right = value; }
            get { return right; }
        }

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    class BinaryTree
    {
        private Node root;

        public void DisplayLeafNodes()
        {
            DisplayLeafNodes(root);
        }

        private void DisplayLeafNodes(Node root)
        {
            if(root == null)
            {
                return;
            }
            if(root.Left == null && root.Right == null)
            {
                Console.Write(root.Data + " ");
                return;
            }

            DisplayLeafNodes(root.Left);
            DisplayLeafNodes(root.Right);
        }

        public void RightView()
        {
            RightView(this.root);
        }

        private void RightView(Node root)
        {
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
                if(level.Count > 0)
                {
                    Console.Write(level[0] + " ");
                }
            }
            Console.WriteLine();
        }

        public void CreateTreeWithLevelOrder()
        {
            /*List<string[]> l = new List<string[]>();

            int inp = 0;
            while(true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (inp !=0 && input.Length == 1) 
                    break;
                l.Add(input);
                inp++;
            }*/
            string[] input = Console.ReadLine().Split(' ');

            Queue<Node> q = new Queue<Node>();
            //int r = int.Parse(Console.ReadLine());
            int r = int.Parse(input[0]);
            this.root = new Node(r);
            q.Enqueue(this.root);

            for(int i=1; i<input.Length-1;)
            {
                //string[] input = l[i];
                Node front = q.Dequeue();
                int left = int.Parse(input[i]);
                int right = int.Parse(input[i+1]);
                if (left != -1)
                {
                    Node n = new Node(left);
                    front.Left = n;
                    q.Enqueue(n);
                }

                if (right != -1)
                {
                    Node n = new Node(right);
                    front.Right = n;
                    q.Enqueue(n);
                }
                i += 2;
            }

            //DisplayBinaryTree();
        }

        public int GetSumOfNodes()
        {
            return GetSumOfNodes(this.root);
        }

        public void PreOrderDisplay()
        {
            PreOrderDisplay(this.root);
        }

        public bool CheckBalance()
        {
            int height = 0;
            return CheckBalance(this.root, ref height); ;
        }

        public void RemoveLeaves()
        {
            if (root.Left == null && root.Right == null)
                root = null;
            else
                RemoveLeaves(this.root, null);
        }

        private bool CheckBalance(Node root, ref int height)
        {
            int lh = 0, rh = 0;
            if (root == null)
            {
                height = 0;
                return true;
            }

            bool lb = CheckBalance(root.Left, ref lh);
            bool rb = CheckBalance(root.Right, ref rh);
            height = (lh > rh ? lh : rh) + 1;

            int bf = lh - rh;

            if(bf >=-1 && bf <= 1 && lb && rb)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetSumOfNodes(Node root)
        {
            if (root == null)
                return 0;

            if (root.Left == null && root.Right == null)
                return root.Data;

            int ls = GetSumOfNodes(root.Left);
            int rs = GetSumOfNodes(root.Right);
            
            return ls + rs + root.Data;
        }

        private void PreOrderDisplay(Node root)
        {
            if(root == null)
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
                output += " <= "+root.Right.Data;
            }
            Console.WriteLine(output);
            PreOrderDisplay(root.Left);
            PreOrderDisplay(root.Right);
        }

        private void RemoveLeaves(Node root, Node parent)
        {
            if (root == null) 
                return;

            if(root.Left == null && root.Right == null)
            {
                if(root == parent.Left)
                {
                    parent.Left = null;
                }
                else if(root == parent.Right)
                {
                    parent.Right = null;
                }
            }

            RemoveLeaves(root.Left, root);
            RemoveLeaves(root.Right, root);
        }

        public void RootToLeafPathWithSumK(int k)
        {
            RootToLeafPathWithSumK(this.root, k, "");
        }

        public bool CheckStructureIdentical(BinaryTree otherTree)
        {
            return CheckStructureIdentical(this.root, otherTree.root);
        }

        public void NodeWithNoSibling()
        {
            NodesWithNoSibling(this.root);
            Console.WriteLine();
        }

        private void NodesWithNoSibling(Node root)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return;
            }

            if (root.Left != null && root.Right == null)
            {
                Console.Write(root.Left.Data+" ");
            }

            if (root.Left == null && root.Right != null)
            {
                Console.Write(root.Right.Data + " ");
            }

            if(root.Left != null)
                NodesWithNoSibling(root.Left);
            if(root.Right != null)
                NodesWithNoSibling(root.Right);
        }

        private bool CheckStructureIdentical(Node root1, Node root2)
        {
            if (root1 == null && root2 == null)
                return true;
            
            if (root1 == null || root2 == null)
                return false;

            return CheckStructureIdentical(root1.Left, root2.Left) && 
                   CheckStructureIdentical(root1.Right, root2.Right);
        }

        private void RootToLeafPathWithSumK(Node root, int K, string path)
        {
            if(root == null)
            {
                return ;
            }

            if(K < 0)
            {
                return;
            }

            if(K == root.Data && root.Left == null && root.Right == null)
            {
                Console.WriteLine(path.Substring(1)+" "+root.Data);
                return ;
            }

            RootToLeafPathWithSumK(root.Left, K - root.Data, path + " " + root.Data);
            RootToLeafPathWithSumK(root.Right, K - root.Data, path + " " + root.Data);
        }

        public void DisplayBinaryTree()
        {
            //Level order traversal...
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);
            while(nodes.Count > 0)
            {
                nodes.Enqueue(null);
                List<int> level = new List<int>();
                while(true)
                {
                    var front = nodes.Dequeue();
                    if(front == null)
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
                foreach(int val in level)
                {
                    Console.Write(val+" ");
                }
                Console.WriteLine();
            }
        }
        public void CreateBinaryTree(string[] input)
        {
            Stack<KeyValuePair<Node, bool>> nodeAddress = new Stack<KeyValuePair<Node, bool>>();

            root = new Node(int.Parse(input[0]));
            nodeAddress.Push(new KeyValuePair<Node, bool>(root, false));

            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] == "true")
                {
                    if(nodeAddress.Peek().Value == false)
                    {
                        Node temp = new Node(int.Parse(input[i + 1]));
                        var top = nodeAddress.Pop();
                        top.Key.Left = temp;
                        nodeAddress.Push(new KeyValuePair<Node, bool>(top.Key, true));
                        nodeAddress.Push(new KeyValuePair<Node, bool>(temp, false));
                        i++;
                    }
                    else
                    {
                        Node temp = new Node(int.Parse(input[i + 1]));
                        var top = nodeAddress.Pop();
                        top.Key.Right = temp;
                        nodeAddress.Push(new KeyValuePair<Node, bool>(temp, false));
                        i++;
                    }
                }
                else
                {
                    if (nodeAddress.Peek().Value == false)
                    {
                        var top = nodeAddress.Pop();
                        nodeAddress.Push(new KeyValuePair<Node, bool>(top.Key, true));
                    }
                    else
                    {
                        nodeAddress.Pop();
                    }
                }
            }
        }
    }
}


//1 true 2 false true 4 true 7 false false false true 3 true 5 false true 6 false false false

