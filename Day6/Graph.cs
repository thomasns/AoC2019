using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{
    class Graph
    {
        public Node head { get; set; }


        public Graph()
        {
            head = null;
        }


        public bool tryAdd(string parentName, string childName)
        {
            if(head == null)
            {
                if(parentName == "COM")
                {
                    head = new Node("COM",null);
                    head.addChild(childName);

                    return true;
                }
                return false;
            }
             else
            {
                return head.tryAdd(parentName, childName);
            }

        }

        public int countOrbits()
        {
            int sum = 0;
            foreach(Node child in head.children)
            {
                sum += child.countOrbits(0);
            }

            return sum;

        }
        
        public int findStepsToSanta()
        {
            Node you = head.findYou();
            head.ImMyOwnGrandPa();
            return you.stepsToSanta(new List<Node>());



        }       


    }

    class Node
    {
        public String name { get; set; }
        public List<Node> children { get; set; }
        public Node Parent { get; set; }

        public Node()
        {
            this.name = "COM";
            this.children = new List<Node>();
        }

        public Node(String name, Node parent)
        {
            this.name = name;
            this.children = new List<Node>();
            this.Parent = parent;
        }

        public void addChild(string childName)
        {
            this.children.Add(new Node(childName,this));
        }
        public bool tryAdd(string parentName, string childName)
        {

            foreach(Node child in children)
            {
                if (child.name == parentName)
                {
                    child.addChild(childName);
                    return true;
                }
                else
                    if (child.tryAdd(parentName, childName))
                        return true;



            }

            return false;

            

        }

        public int countOrbits(int orbitsAbove)
        {
            int sum = orbitsAbove + 1;
            foreach(Node child in children)
            {
                sum += child.countOrbits(orbitsAbove + 1);
            }

            return sum;
                       

        }

        public int stepsToSanta(List<Node> visited) 
        {
            //okay we're gonna try dfs starting from you 

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(this);
            visited.Add(this);
            int steps = 0;
            while(true)
            {
                List<Node> layer = q.ToList<Node>();
                q.Clear();
                foreach(Node parent in layer)
                {
                    foreach (Node child in parent.children)
                    {
                        if (child.name == "SAN")
                            return steps;
                        if (visited.Contains(child) == false)
                        {
                            q.Enqueue(child);
                            visited.Add(child);
                        }
                    }

                }
                steps++;
            }



        }

        public Node findYou()
        {
            if (this.name == "YOU")
                return this;

            foreach(Node child in children)
            {
                Node you = child.findYou();
                if (you != null)
                    return you;
            }
            return null;
        }

        public void ImMyOwnGrandPa()
        {

            foreach (Node child in children)
                child.ImMyOwnGrandPa();
            if(Parent != null)
                this.children.Add(this.Parent);

        }


    }
}
