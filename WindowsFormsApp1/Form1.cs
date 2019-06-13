using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphApp
{
    public partial class Form1 : Form
    {
        GraphDrawer Graph;
        List<Vertex> Vertices;
        List<Edge> Edges;

        int[,] AMatrix; //матрица смежности

        int firstSelectedVertex; 
        int secondSelectedVertex;

        public Form1()
        {
            InitializeComponent();
            Vertices = new List<Vertex>();
            Graph = new GraphDrawer(layout.Width, layout.Height);
            Edges = new List<Edge>();
            layout.Image = Graph.GetBitmap();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            addVertex.Enabled = true;
            addEdge.Enabled = true;
            deleteButton.Enabled = true;
            Graph.clearLayout();
            Graph.drawALLGraph(Vertices, Edges);
            layout.Image = Graph.GetBitmap();
            firstSelectedVertex = -1;
        }

        private void addVertex_Click(object sender, EventArgs e)
        {
            addVertex.Enabled = false;
            selectButton.Enabled = true;
            addEdge.Enabled = true;
            deleteButton.Enabled = true;
            Graph.clearLayout();
            Graph.drawALLGraph(Vertices, Edges);
            layout.Image = Graph.GetBitmap();
        }

        private void addEdge_Click(object sender, EventArgs e)
        {
            addEdge.Enabled = false;
            selectButton.Enabled = true;
            addVertex.Enabled = true;
            deleteButton.Enabled = true;
            Graph.clearLayout();
            Graph.drawALLGraph(Vertices, Edges);
            layout.Image = Graph.GetBitmap();
            firstSelectedVertex = -1;
            secondSelectedVertex = -1;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            addVertex.Enabled = true;
            addEdge.Enabled = true;
            Graph.clearLayout();
            Graph.drawALLGraph(Vertices, Edges);
            layout.Image = Graph.GetBitmap();
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            addVertex.Enabled = true;
            addEdge.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Are you sure to delete this graph?";
            const string caption = "Delete";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                Vertices.Clear();
                Edges.Clear();
                Graph.clearLayout();
                layout.Image = Graph.GetBitmap();
            }
        }

        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        private void createAdjAndOut()
        {
            AMatrix = new int[Vertices.Count, Vertices.Count];
            Graph.fillAdjacencyMatrix(Vertices.Count, Edges, AMatrix);
            listBox.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < Vertices.Count; i++)
                sOut += (i + 1) + " ";
            listBox.Items.Add(sOut);
            for (int i = 0; i < Vertices.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < Vertices.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                listBox.Items.Add(sOut);
            }
        }

        private void layout_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if (Math.Pow((Vertices[i].x - e.X), 2) + Math.Pow((Vertices[i].y - e.Y), 2) <= Graph.R * Graph.R)
                    {
                        if (firstSelectedVertex != -1)
                        {
                            firstSelectedVertex = -1;
                            Graph.clearLayout();
                            Graph.drawALLGraph(Vertices, Edges);
                            layout.Image = Graph.GetBitmap();
                        }
                        if (firstSelectedVertex == -1)
                        {
                            Graph.drawSelectedVertex(Vertices[i].x, Vertices[i].y);
                            firstSelectedVertex = i;
                            layout.Image = Graph.GetBitmap();
                            //createAdjAndOut();
                            /* listBoxMatrix.Items.Clear();
                            int degree = 0;
                            for (int j = 0; j < V.Count; j++)
                                degree += AMatrix[firstSelectedVertex, j];
                            listBoxMatrix.Items.Add("Степень вершины №" + (firstSelectedVertex + 1) + " равна " + degree);*/
                            break;
                        }
                    }
                }
            }
            //нажата кнопка "рисовать вершину"
            if (addVertex.Enabled == false)
            {
                Vertices.Add(new Vertex(e.X, e.Y));
                Graph.drawVertex(e.X, e.Y, Vertices.Count.ToString());
                layout.Image = Graph.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
            if (addEdge.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < Vertices.Count; i++)
                    {
                        if (Math.Pow((Vertices[i].x - e.X), 2) + Math.Pow((Vertices[i].y - e.Y), 2) <= Graph.R * Graph.R)
                        {
                            if (firstSelectedVertex == -1)
                            {
                                Graph.drawSelectedVertex(Vertices[i].x, Vertices[i].y);
                                firstSelectedVertex = i;
                                layout.Image = Graph.GetBitmap();
                                break;
                            }
                            if (secondSelectedVertex == -1)
                            {
                                Graph.drawSelectedVertex(Vertices[i].x, Vertices[i].y);
                                secondSelectedVertex = i;
                                Edges.Add(new Edge(firstSelectedVertex, secondSelectedVertex));
                                Graph.drawEdge(Vertices[firstSelectedVertex], Vertices[secondSelectedVertex], Edges[Edges.Count - 1], Edges.Count - 1);
                                firstSelectedVertex = -1;
                                secondSelectedVertex = -1;
                                layout.Image = Graph.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((firstSelectedVertex != -1) &&
                        (Math.Pow((Vertices[firstSelectedVertex].x - e.X), 2) + Math.Pow((Vertices[firstSelectedVertex].y - e.Y), 2) <= Graph.R * Graph.R))
                    {
                        Graph.drawVertex(Vertices[firstSelectedVertex].x, Vertices[firstSelectedVertex].y, (firstSelectedVertex + 1).ToString());
                        firstSelectedVertex = -1;
                        layout.Image = Graph.GetBitmap();
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if (Math.Pow((Vertices[i].x - e.X), 2) + Math.Pow((Vertices[i].y - e.Y), 2) <= Graph.R * Graph.R)
                    {
                        for (int j = 0; j < Edges.Count; j++)
                        {
                            if ((Edges[j].v1 == i) || (Edges[j].v2 == i))
                            {
                                Edges.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (Edges[j].v1 > i) Edges[j].v1--;
                                if (Edges[j].v2 > i) Edges[j].v2--;
                            }
                        }
                        Vertices.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < Edges.Count; i++)
                    {
                        if (Edges[i].v1 == Edges[i].v2) //если это петля
                        {
                            if ((Math.Pow((Vertices[Edges[i].v1].x - Graph.R - e.X), 2) + Math.Pow((Vertices[Edges[i].v1].y - Graph.R - e.Y), 2) <= ((Graph.R + 2) * (Graph.R + 2))) &&
                                (Math.Pow((Vertices[Edges[i].v1].x - Graph.R - e.X), 2) + Math.Pow((Vertices[Edges[i].v1].y - Graph.R - e.Y), 2) >= ((Graph.R - 2) * (Graph.R - 2))))
                            {
                                Edges.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - Vertices[Edges[i].v1].x) * (Vertices[Edges[i].v2].y - Vertices[Edges[i].v1].y) / (Vertices[Edges[i].v2].x - Vertices[Edges[i].v1].x) + Vertices[Edges[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - Vertices[Edges[i].v1].x) * (Vertices[Edges[i].v2].y - Vertices[Edges[i].v1].y) / (Vertices[Edges[i].v2].x - Vertices[Edges[i].v1].x) + Vertices[Edges[i].v1].y) >= (e.Y - 4))
                            {
                                if ((Vertices[Edges[i].v1].x <= Vertices[Edges[i].v2].x && Vertices[Edges[i].v1].x <= e.X && e.X <= Vertices[Edges[i].v2].x) ||
                                    (Vertices[Edges[i].v1].x >= Vertices[Edges[i].v2].x && Vertices[Edges[i].v1].x >= e.X && e.X >= Vertices[Edges[i].v2].x))
                                {
                                    Edges.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    Graph.clearLayout();
                    Graph.drawALLGraph(Vertices, Edges);
                    layout.Image = Graph.GetBitmap();
                }
            }
        }
    }
}
