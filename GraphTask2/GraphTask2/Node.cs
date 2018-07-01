using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask2
{
    public class Node
    {
        public string Name;
        public List<Edge> Edges;
        public bool isVisited;
        public bool isDrawn;
        public int x0, y0;
        public int numNode;
    }
}
