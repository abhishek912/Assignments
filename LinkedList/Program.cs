using System;

namespace LL
{
	public class Test
	{
		public static void Main()
		{
			string[] input = Console.ReadLine().Split(' ');
			int N= int.Parse(input[0]), K = int.Parse(input[1]);
			int[] arr1 = new int[N];

			input = Console.ReadLine().Split(' ');
			for (int i = 0; i < N; i++)
			{
				arr1[i] = int.Parse(input[i]);
			}

			LinkList l1 = new LinkList();
			l1.CreateLinkList(arr1);
			l1.KReverse(K);
			l1.DisplayList();

			Console.ReadKey();
		}

	}

	class LinkList
	{
		Node head, tail;

		public LinkList()
		{
			head = null;
			tail = null;
		}

		public void DisplayList()
        {
			DisplayList(this.head);
        }

		public void KReverse(int k)
        {
			head = KReverse(head, k);
		}

		private Node KReverse(Node node, int k)
		{
			if (node == null)
				return null;

			// smaller problem : argument
			Node temp = node;
			for (int i = 1; i <= k && temp != null; i++)
			{
				temp = temp.Next;
			}

			Node prev = KReverse(temp, k);

			// self work
			Node curr = node;

			while (curr != temp)
			{
				Node ahead = curr.Next;

				curr.Next = prev;

				prev = curr;
				curr = ahead;
			}

			return prev;
		}
		public void FindTriplet(LinkList l2, LinkList l3, int sum)
		{
			FindTriplet(this.head, l2.head, l3.head, sum);
		}

		private void FindTriplet(Node h1, Node h2, Node h3, int sum)
		{
			Node a = h1;
			while (a != null)
			{
             	Node b = h2, c = h3;
				while (b != null && c != null)
				{
					int s = a.Data + b.Data + c.Data;
					if (s == sum)
					{
						Console.WriteLine($"{a.Data} {b.Data} {c.Data}");
						return;
					}

					if (s < sum)
					{
						b = b.Next;
					}
					else
					{
						c = c.Next;
					}
				}
				a = a.Next;
			}
		}

		public void DisplayList(Node head)
		{
			Node temp = head;
			while (temp != null)
			{
				Console.Write(temp.Data + " ");
				temp = temp.Next;
			}
			Console.WriteLine();
		}
		public void CreateLinkList(int[] nodeData)
		{
			foreach (int data in nodeData)
			{
				Node n = new Node(data);
				AddToTail(n);
			}
		}

		private void AddToTail(Node n)
		{
			if (head == null)
			{
				head = n;
				tail = n;
			}
			else
			{
				tail.Next = n;
				tail = tail.Next;
				tail.Next = null;
			}
		}
	}

	class Node
	{
		int data;
		Node next;

		public Node(int data)
		{
			this.data = data;
			next = null;
		}

		public int Data
		{
			set { this.data = value; }
			get { return this.data; }
		}

		public Node Next
		{
			set { this.next = value; }
			get { return this.next; }
		}
	}

}