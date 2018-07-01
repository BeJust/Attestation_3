using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTask2
{
    public partial class MainWindow : Form
    {
       
        Graph graph = new Graph();
        private Graphics g;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".txt";
            saveFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "(*.txt) | *.txt";
            saveFileDialog.Filter = "(*.txt) | *.txt";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Multiselect = false;
            inputNodeName_txt.Text = "аа";

            groupBox_gb.Controls.Add(addNode_rb);
            groupBox_gb.Controls.Add(deleteNode_rb);
            groupBox_gb.Controls.Add(addEdge_rb);
            groupBox_gb.Controls.Add(deleteEdge_rb);
            groupBox_gb.Controls.Add(moveNode_rb);
        }

        private void saveToFile_btn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            graph.SaveGraph(saveFileDialog.FileName);
        }

        private void loadFromFile_btn_Click(object sender, EventArgs e)
        {
            g = pictureBox_pb.CreateGraphics();
            g.Clear(Color.AliceBlue);
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            graph = graph.LoadGraph(openFileDialog.FileName);
            graph.Draw(g);
        }
        private string GrowNodeName(string startName)
        {
            string str = String.Empty;
            char c = startName[0];
            char e = startName[1];

            if (e == 'я' && c == 'я')
            {
                str = "aa";
            }
            else
            {
                if (e == 'я')
                {
                    c++;
                    e = 'а';
                    str = c.ToString() + e;
                }
                else
                {
                    e++;
                    str = c.ToString() + e;
                }
            }

            return str;
        }
        private void pictureBox_pb_MouseClick(object sender, MouseEventArgs e)
        {
            g = pictureBox_pb.CreateGraphics();
            g.Clear(Color.AliceBlue);
            if (addNode_rb.Checked)
            {
                if (inputNodeName_txt.Text != "")
                {
                    int k = graph.GetNodesListCount();
                    graph.AddNode(e.X, e.Y, inputNodeName_txt.Text);
                    if (k != graph.GetNodesListCount())
                    {
                        inputNodeName_txt.Text = GrowNodeName(inputNodeName_txt.Text);

                    }
                    graph.Draw(g);
                }
            }

            if (deleteNode_rb.Checked)
            {
                graph.DeleteNode(e.X, e.Y);
                graph.Draw(g);
            }

            if (moveNode_rb.Checked)
            {
                graph.MoveNode(e.X, e.Y);
                graph.Draw(g);
            }

            if (addEdge_rb.Checked)
            {
                
                graph.AddEdge(e.X, e.Y);
                graph.Draw(g);
            }

            if (deleteEdge_rb.Checked)
            {
                graph.DeleteEdge(e.X, e.Y);
                graph.Draw(g);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox_pb.CreateGraphics();
            g.Clear(Color.AliceBlue);
            int mincost = graph.AltSolve();
            deletedEdges_lbl.Text = mincost.ToString();
            string[] resultArr = new string[graph.Best_Cut.Count];
            for (int i = 0; i < graph.Best_Cut.Count; i++)
            {
                resultArr[i] = graph.Best_Cut[i].Name;
            }
            string result = string.Join(" ", resultArr);
            separatedNodes_lbl.Text = result;
            graph.Draw(g);
        }
    }
}
