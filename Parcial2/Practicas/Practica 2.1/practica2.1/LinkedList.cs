using System;

namespace practica2._1 {
    class LinkedList {
        private Node head;
        private Node current; // Will have the lastest node
        public int Count;

        public LinkedList () {
            head = new Node ();
            current = head;
        }

        public void AddAtLast (int data) {
            Node newNode = new Node ();
            newNode.Value = data;
            current.Next = newNode;
            current = newNode;
            Count++;
        }

        public void AddAtStart (int data) {
            Node newNode = new Node () { Value = data };
            newNode.Next = head.Next; //new node will have reference of head's next reference
            head.Next = newNode; //and now head will refer to new node
            Count++;
        }

        public Node RemoveFromStart () {
            if (Count > 0) {
                Node temp = head.Next;
                head.Next = head.Next.Next;
                Count--;
                return temp;
            } else {
                Console.WriteLine ("No element exist in this linked list.");
                return null;
            }
        }

        public void PrintAllNodes () {
            //Traverse from head
            Console.Write ("Head ->");
            Node curr = head;
            while (curr.Next != null) {
                curr = curr.Next;
                Console.Write (curr.Value);
                Console.Write ("->");
            }
            Console.Write ("NULL");
        }
    }
}