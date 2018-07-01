using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTask2
{
    class Graph
    {
        private Node NodeToMove;
        private List<Node> NodesList = new List<Node>();
        private List<Edge> EdgesList = new List<Edge>(); 
        private int[,] g; //матрица смежности
        private int best_cost = Int32.MaxValue;
        private List<Node> best_cut = new List<Node>();

        public int Best_Cost
        {
            get { return best_cost; }
        }
       
        public List<Node> Best_Cut
        {
            get { return best_cut; }
        }
        public int GetNodesListCount()
        {
            return NodesList.Count;
        }

        public int GetEdgesListCount()
        {
            return EdgesList.Count;
        }

        public void AddNode(int x, int y, string name)
        {
            if (FindByXY(x, y) == null)
            {
                Node node = new Node();
                node.x0 = x;
                node.y0 = y;
                node.Name = name;
                node.Edges = new List<Edge>();
                NodesList.Add(node);
            }
        }
        private Edge EdgeGraphAdd;
        public void AddEdge(int x, int y)
        {
            if (EdgeGraphAdd == null)
            {
                EdgeGraphAdd = new Edge();
                EdgeGraphAdd.LeftNode = FindByXY(x, y);
                if (EdgeGraphAdd.LeftNode != null)
                {
                    FindByXY(x, y).Edges.Add(EdgeGraphAdd);
                }
                return;
            }
            else
            {
                EdgeGraphAdd.RightNode = FindByXY(x, y);
                if (EdgeGraphAdd.RightNode != null)
                {
                    FindByXY(x, y).Edges.Add(EdgeGraphAdd);
                    EdgeGraphAdd.Weight = 1;
                    EdgesList.Add(EdgeGraphAdd);
                    EdgeGraphAdd = null;
                }
            }
        }
        public void MoveNode(int x, int y)
        {
            if (NodeToMove == null)
            {
                NodeToMove = FindByXY(x, y);
                return;
            }
            else
            {
                NodeToMove.x0 = x;
                NodeToMove.y0 = y;
                NodeToMove = null;
            }
        }
        public void DeleteEdge(int x, int y) //может быть треугольник
        {
            double dist1, dist2, rebro;
            for (int i = 0; i < EdgesList.Count; i++)
            {
                if (EdgesList[i] != null)
                {
                    dist1 = Math.Sqrt(Math.Pow(x - EdgesList[i].LeftNode.x0, 2) +
                                      Math.Pow(y - EdgesList[i].LeftNode.y0, 2));
                    dist2 = Math.Sqrt(Math.Pow(x - EdgesList[i].RightNode.x0, 2) +
                                      Math.Pow(y - EdgesList[i].RightNode.y0, 2));
                    rebro = Math.Sqrt(Math.Pow(EdgesList[i].LeftNode.x0 - EdgesList[i].RightNode.x0, 2) +
                                      Math.Pow(EdgesList[i].LeftNode.y0 - EdgesList[i].RightNode.y0, 2));
                    if (Math.Abs(dist1 + dist2 - rebro) < 0.1)
                    {
                        for (int k = 0; k < EdgesList[i].LeftNode.Edges.Count; k++)
                        {
                            if (EdgesList[i] == EdgesList[i].LeftNode.Edges[k])
                            {
                                EdgesList[i].LeftNode.Edges[k] = null;
                                EdgesList[i].LeftNode.Edges.RemoveAt(k);
                                k--;
                            }
                        }
                        for (int u = 0; u < EdgesList[i].RightNode.Edges.Count; u++)
                        {
                            if (EdgesList[i] == EdgesList[i].RightNode.Edges[u])
                            {
                                EdgesList[i].RightNode.Edges[u] = null;
                                EdgesList[i].RightNode.Edges.RemoveAt(u);
                                u--;
                            }
                        }

                        EdgesList[i] = null;
                        EdgesList.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Node x in NodesList)
            {
                if (x != null)
                {
                    x.isDrawn = false;
                }
            }
            foreach (Node x in NodesList)
            {
                if (x != null)
                {
                    Draw(g, x); // передаем один из узлов
                }
            }
        }

        private void Draw(Graphics g, Node p)
        {
            if (p.isDrawn) return;
            if (p.Edges != null)
            {
                foreach (Edge e in p.Edges)
                {
                    if (e != null)
                    {
                        if (p == e.RightNode)
                        {
                            if (e.LeftNode != null)
                            {
                                if (!e.LeftNode.isDrawn)
                                    DrawEdge(g, p, e.LeftNode, e.Weight); // отдельный метод для рисования ребра (так лучше)
                            }
                        }

                        if (p == e.LeftNode)
                        {
                            if (e.RightNode != null)
                            {
                                if (!e.RightNode.isDrawn)
                                    DrawEdge(g, p, e.RightNode, e.Weight);
                            }
                        }
                    }
                }
            }

            DrawNode(g, p);
            p.isDrawn = true;
        }

        private void DrawEdge(Graphics g, Node p, Node n, int weight)
        {
            g.DrawLine(UtilsForDrawing.PenLine, p.x0, p.y0, n.x0, n.y0);
        }

        private void DrawNode(Graphics g, Node p)
        {
            if (p == NodeToMove)
            {
                g.FillEllipse(UtilsForDrawing.BrushBackHighLight, p.x0 - 20, p.y0 - 20, 40, 40);
                g.DrawEllipse(UtilsForDrawing.CrimsonPenNode, p.x0 - 20, p.y0 - 20, 40, 40);
            }
            else
            {
                g.FillEllipse(UtilsForDrawing.BrushBackground, p.x0 - 20, p.y0 - 20, 40, 40);
                g.DrawEllipse(UtilsForDrawing.PenNode, p.x0 - 20, p.y0 - 20, 40, 40);
            }

            g.DrawString(p.Name, UtilsForDrawing.FontNode, UtilsForDrawing.BrushNodeData, p.x0 - 12, p.y0 - 12);
        }

        private Node FindByXY(int x, int y) // нахождение вершины по координатам через мышку
        {
            foreach (Node p in NodesList)
            {
                if (p != null)
                {
                    if ((p.x0 - x) * (p.x0 - x) + (p.y0 - y) * (p.y0 - y) < 40 * 40) //r - радиус нода
                        return p;
                }
            }
            return null;
        }

        public void DeleteNode(int x, int y)
        {
            if (FindByXY(x, y) != null)
            {
                for (int q = 0; q < NodesList.Count; q++)
                {
                    for (int j = 0; j < NodesList[q].Edges.Count; j++)
                    {
                        if (NodesList[q].Edges[j].RightNode == FindByXY(x, y) || NodesList[q].Edges[j].LeftNode == FindByXY(x, y))
                        {
                            NodesList[q].Edges[j] = null;
                            NodesList[q].Edges.RemoveAt(j);
                            j--;
                        }
                    }
                }

                if (FindByXY(x, y).Edges != null)
                {
                    for (int i = 0; i < FindByXY(x, y).Edges.Count; i++)
                    {
                        FindByXY(x, y).Edges[i] = null;
                        FindByXY(x, y).Edges.RemoveAt(i);
                        i--;
                    }
                }

                for (int k = 0; k < NodesList.Count; k++)
                {
                    if (NodesList[k] == FindByXY(x, y))
                    {
                        NodesList[k] = null;
                        NodesList.RemoveAt(k);
                        k--;
                        break;
                    }
                }
            }

            for (int q = 0; q < NodesList.Count; q++)
            {
                for (int j = 0; j < NodesList[q].Edges.Count; j++)
                {
                    if (NodesList[q].Edges[j].RightNode == null || NodesList[q].Edges[j].LeftNode == null)
                    {
                        NodesList[q].Edges[j] = null;
                        NodesList[q].Edges.RemoveAt(j);
                        j--;
                    }
                }
            }

            for (int n = 0; n < EdgesList.Count; n++)
            {
                if (EdgesList[n].RightNode == null || EdgesList[n].LeftNode == null)
                {
                    EdgesList[n] = null;
                    EdgesList.RemoveAt(n);
                    n--;
                }
            }

        }

        public void SaveGraph(string saveFileName)
        {
            StreamWriter writer = new StreamWriter(saveFileName, true, Encoding.Default);
            for (int i = 0; i < NodesList.Count; i++)
            {
                writer.WriteLine(NodesList[i].Name);
                writer.WriteLine(NodesList[i].x0);
                writer.WriteLine(NodesList[i].y0);
                writer.WriteLine(NodesList[i].numNode);
            }
            writer.WriteLine("NodesReady");
            for (int i = 0; i < EdgesList.Count; i++)
            {
                writer.WriteLine(EdgesList[i].Weight);
                writer.WriteLine(EdgesList[i].RightNode.x0);
                writer.WriteLine(EdgesList[i].RightNode.y0);
                writer.WriteLine(EdgesList[i].LeftNode.x0);
                writer.WriteLine(EdgesList[i].LeftNode.y0);
                writer.WriteLine(EdgesList[i].VisitsCounter);
            }
            writer.WriteLine("EdgesReady");
            writer.Close();
        }

        public Graph LoadGraph(string loadFileName)
        {
            Graph graphRGraph = new Graph();
            StreamReader reader = new StreamReader(loadFileName, Encoding.Default);
            string line = String.Empty;
            while ((line = reader.ReadLine()) != "NodesReady")
            {
                Node node = new Node();
                node.Edges = new List<Edge>();
                node.Name = line;
                node.x0 = Convert.ToInt32(reader.ReadLine());
                node.y0 = Convert.ToInt32(reader.ReadLine());
                node.numNode = Convert.ToInt32(reader.ReadLine());
                graphRGraph.NodesList.Add(node);
            }

            while ((line = reader.ReadLine()) != "EdgesReady")
            {
                Edge edge = new Edge();
                edge.Weight = Convert.ToInt32(line);
                int xTemp = Convert.ToInt32(reader.ReadLine());
                int yTemp = Convert.ToInt32(reader.ReadLine());
                Node tmp = new Node();
                tmp = graphRGraph.FindByXY(xTemp, yTemp);
                edge.RightNode = tmp;
                tmp.Edges.Add(edge);

                xTemp = Convert.ToInt32(reader.ReadLine());
                yTemp = Convert.ToInt32(reader.ReadLine());
                tmp = graphRGraph.FindByXY(xTemp, yTemp);
                edge.LeftNode = tmp;
                edge.VisitsCounter = Convert.ToInt32(reader.ReadLine());
                tmp.Edges.Add(edge);

                graphRGraph.EdgesList.Add(edge);
            }
            reader.Close();
            return graphRGraph;
        }
       
        public int[,] CreateAdjMatrix()
        {
            int[,] adj = new int[NodesList.Count, NodesList.Count];
            for (int k = 0; k < NodesList.Count; k++)
            {
                for (int l = 0; l < NodesList.Count; l++)
                {
                    adj[k, l] = 0;
                }
            }
            for (int i = 0; i < NodesList.Count; i++)
            {
                Node n1 = NodesList[i];

                for (int j = 0; j < NodesList.Count; j++)
                {
                    if (i == j)
                    {
                        adj[i, i] = 0;
                        continue;
                    }
                    Node n2 = NodesList[j];

                    var arc = n1.Edges.FirstOrDefault(a => a.RightNode == n2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weight;
                        adj[j, i] = arc.Weight;
                    }
                }
            }
            return adj;
        }

        private void DeleteSeparationEdges()
        {
            for (int k = 0; k < EdgesList.Count; k++)
            {
                if (best_cut.Contains(EdgesList[k].LeftNode) && !best_cut.Contains(EdgesList[k].RightNode) ||
                    best_cut.Contains(EdgesList[k].RightNode) && !best_cut.Contains(EdgesList[k].LeftNode))
                {

                    DeleteEdge((EdgesList[k].LeftNode.x0 + EdgesList[k].RightNode.x0) / 2, (EdgesList[k].LeftNode.y0 + EdgesList[k].RightNode.y0) / 2);
                    k = -1;
                }
            }
        }
        public int AltSolve()
        {
            best_cut.Clear();
            best_cost = Int32.MaxValue;
            List<int> tmp = new List<int>();
            int n = NodesList.Count;
            g = CreateAdjMatrix();
            List<List<int>> v = new List<List<int>>(NodesList.Count);

            for (int i = 0; i < NodesList.Count; ++i)
            {
                v.Add( new List<int>());
                v[i].Add(i);
            }
            int[] w = new int[NodesList.Count];
            bool[] exist = new bool[NodesList.Count];
            bool[] in_a = new bool[NodesList.Count];
            for (int i = 0; i < exist.Length; i++)
            {
                exist[i] = true;
            }
            
            for (int ph = 0; ph < n - 1; ++ph)
            {
                for (int i = 0; i < in_a.Length; i++)
                {
                    in_a[i] = false;
                }
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = 0;
                }
                int prev = 0;
                for (int it = 0; it < n - ph; ++it)
                {
                    int sel = -1;
                    for (int i = 0; i < n; ++i)
                        if (exist[i] && !in_a[i] && (sel == -1 || w[i] > w[sel]))
                            sel = i;
                    if (it == n - ph - 1)
                    {
                        if (w[sel] < best_cost)
                        {
                            best_cost = w[sel];
                             tmp = v[sel];
                            
                           
                        }
                        v[prev].InsertRange(v[prev].Count,v[sel]);
                        
                        for (int i = 0; i < n; ++i)
                            g[prev,i] = g[i,prev] += g[sel,i];
                        exist[sel] = false;
                    }
                    else
                    {
                        in_a[sel] = true;
                        for (int i = 0; i < n; ++i)
                            w[i] += g[sel,i];
                        prev = sel;
                    }
                }
            }
            for (int i = 0; i < tmp.Count; i++)
            {
                best_cut.Add(NodesList[tmp[i]]);
            }
            DeleteSeparationEdges();
            return best_cost;
        }
        
    }
}
