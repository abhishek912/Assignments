using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class BinaryTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
    Node root;
    public void CreateTreeWithLevelOrder(string[] input)
    {
        //string[] input = Console.ReadLine().Split(' ');

        Queue<Node> q = new Queue<Node>();
        int r = int.Parse(input[0]);
        this.root = new Node(r);
        q.Enqueue(this.root);

        for (int i = 1; i < input.Length - 1;)
        {
            Node front = q.Dequeue();
            int left = int.Parse(input[i]);
            int right = int.Parse(input[i + 1]);
            if (left != -1)
            {
                Node n = new Node(left);
                front.left = n;
                q.Enqueue(n);
            }

            if (right != -1)
            {
                Node n = new Node(right);
                front.right = n;
                q.Enqueue(n);
            }
            i += 2;
        }
    }
    /*public void createBT(string[] str)
    {
        Queue<Node> q = new Queue<Node>();
        int val = Convert.ToInt32(str[0]);
        root = new Node(val);
        q.Enqueue(root);
        int count = 1;
        while (q.Count != 0)
        {
            Node pn = q.Dequeue();

            int ld = Convert.ToInt32(str[count++]);
            if (ld != -1)
            {
                Node ln = new Node(ld);
                pn.left = ln;
                q.Enqueue(ln);
            }
            int rd = Convert.ToInt32(str[count++]);
            if (rd != -1)
            {
                Node rn = new Node(rd);
                pn.right = rn;
                q.Enqueue(rn);
            }
        }

    }*/

    int ans = 0;
    int Help(Node root)
    {

        if (root == null)
            return 0;

        int l = Help(root.left);
        int r = Help(root.right);

        ans += Math.Abs(l + r + root.data - 1);
        return l + r + root.data - 1;
    }

    public int DistributeChoclatesCall()
    {
        return DistributeChoclates(this.root);
    }
    int DistributeChoclates(Node root)
    {
        Help(root);
        return ans;
    }

}



public class Test
{
    public static void Main(string[] args)
    {
        BinaryTree bt = new BinaryTree();
        string[] str = Console.ReadLine().Split(' ');
        bt.CreateTreeWithLevelOrder(str);
        Console.WriteLine(bt.DistributeChoclatesCall());
    }
}
