using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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

        public struct VertexColor
        {
            public int number { get; set; }
            public int color { get; set; }
            public int stepen { get; set; }

            public VertexColor(int number, int color, int stepen)
            {
                this.number = number;
                this.color = color;
                this.stepen = stepen;
            }
        }

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

        #region Click Methods

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

        private void huffman_Click(object sender, EventArgs e)
        {
            countHuffman();
        }

        #endregion

        private void createAdjAndOut()
        {
            AMatrix = new int[Vertices.Count, Vertices.Count];
            Graph.fillAdjacencyMatrix(Vertices.Count, Edges, AMatrix);
            listBox.Items.Clear();
            listBox1.Items.Clear();
            string freqSrt = textBox1.Text;
            List<double> freq = new List<double>();
            string[] sizes = freqSrt.Split(' ', '\t');
            foreach (var i in sizes)
            {
                string str = "";
                if (i.Contains(","))
                {
                    str = i.Replace(',', '.');
                }
                else
                {
                    str = i;
                }

                double m = Convert.ToDouble(str);
                freq.Add(m);
            }

            List<VertexColor> graph = new List<VertexColor>();
            //степени вершин 
            for (int i2 = 0; i2 < Vertices.Count; i2++)
            {
                VertexColor item = new VertexColor(i2, 0, 0);
                for (int j2=0; j2 < Vertices.Count; j2++)
                {
                    if (AMatrix[i2, j2] == 1)
                    {
                        item.stepen++;
                    }
                }
                graph.Add(item);
            }
            graph = graph.OrderBy(z => z.stepen).ToList();

            List<string> wordList = new List<string>();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // список возможных слов для неполного графа (длина до m-2)
            for (int i = 1; i <= (graph.Count -2); i++)
            {
                List<string> local = getStringList(i, new string[] { "0", "1" });
                foreach (var str in local)
                {
                    wordList.Add(str);
                }
            }

            //находим несмежные вершины (нумерация с 0)
            int n1 = graph[0].number;
            int n2 = graph[1].number;

            IEnumerable<string> myEnumerable = wordList;
            IEnumerable<IEnumerable<string>> result =
                GetCombinations<string>(myEnumerable, (graph.Count-1));

            List<List<string>> wRepeatCodeCombinations = new List<List<string>>();
            foreach (var code in result)
            {
                bool hasRepeat = AreAnyDuplicates(code);
                if (!hasRepeat)
                {
                    if (!wRepeatCodeCombinations.Contains(code));
                    wRepeatCodeCombinations.Add(code.ToList());
                }
            }

            List<List<string>> prefixCodes = new List<List<string>>();
            // check prefix
            foreach (var code in wRepeatCodeCombinations)
            {
                bool checkPrefixCode = CheckPrefixCode(code);
                if (checkPrefixCode)
                {
                    // вставляем элемент для n вершины (для исходного графа)
                    string str1 = code[n1];
                    code.Insert(n2, str1);
                    prefixCodes.Add(code);
                }
            }

            List<List<int>> spectrMatrix = new List<List<int>>();
            foreach (var code in prefixCodes)
            {
                List<int> dItem = new List<int>();
                foreach (string str in code)
                {
                    dItem.Add(str.Length);
                }
                spectrMatrix.Add(dItem);
            }

            List<int> indexToRemove = new List<int>();
            for (int i = 0; i < spectrMatrix.Count; i++)
            {
                for (int j = i + 1; j < spectrMatrix.Count; j++)
                {
                    int m = MajorizesOrMatches(spectrMatrix[i], spectrMatrix[j]);
                    if (m == 1)
                    {
                        if (!indexToRemove.Contains(i))
                            indexToRemove.Add(i);
                    }
                    if (m == 2)
                    {
                        if (!indexToRemove.Contains(j))
                            indexToRemove.Add(j);
                    }
                }
            }

            var indexToRemove1 = indexToRemove.OrderByDescending(x => x);

            foreach (var ind1 in indexToRemove1)
            {
                prefixCodes.RemoveAt(ind1);
                spectrMatrix.RemoveAt(ind1);
            }


            int ind = 0;
            double globalCost = 1000000000;
            foreach (var spectr in spectrMatrix)
            {
                double cost = 0;
                for(int i=0;i< spectr.Count;i++)
                {
                    cost += spectr[i] * freq[i];
                }
                if (cost < globalCost)
                {
                    globalCost = cost;
                    ind = spectrMatrix.IndexOf(spectr);
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            mTime.Text = elapsedTime;

            mCost.Text = globalCost.ToString();
            string sp= "";
            var s = spectrMatrix[ind];
            foreach (var m in s)
            {
                sp += m.ToString() + " ";
            }
            mSpectrum.Text = sp;

            foreach (var d in spectrMatrix)
            {
                string str = "";
                foreach (int m in d)
                {
                    str += m + " ";
                }
                listBox.Items.Add(str);
            }

            foreach (var code in prefixCodes)
            {
                string str = "";
                foreach (var c in code)
                {
                    str += c + ", ";
                }
                listBox1.Items.Add(str);
            }
        }

        #region Matrix methods
        //удалить мажорирующие спектры (сделать матрицу оптимальной)
        public int MajorizesOrMatches(List<int> d1, List<int> d2)
        {
            int k= 0;
            int k1 = 0;
            for (int i = 0; i < d1.Count; i++)
            {
                if (d1[i] >= d2[i])
                {
                    k++;
                }
            }
            for (int i = 0; i < d1.Count; i++)
            {
                if (d1[i] <= d2[i])
                {
                    k1++;
                }
            }
            if (k == d1.Count) { return 1; }   // d1 majorizes d2
            if (k1 == d1.Count) { return 2; }   // d2 majorizes d1
            return -1; // nothing
        }

        public bool CheckPrefixCode(List<string> code)
        {
            for(int i=0; i < code.Count; i++)
            {
                for (int j = i+1 ; j < code.Count; j++)
                {
                    // если встретится хотя бы одна непрефиксная пара
                    if (NotPrefixPair(code[i], code[j])) return false;
                }
            }
            return true;
        }

        public bool NotPrefixPair(string one, string two)
        {
            if ((one.StartsWith(two)) || (two.StartsWith(one)))
            {
                return true;
            }
            return false;
        }

        public bool AreAnyDuplicates<T>(IEnumerable<T> list)
        {
            var hashset = new HashSet<T>();
            return list.Any(e => !hashset.Add(e));
        }

        static IEnumerable<IEnumerable<T>>   GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetCombinations(list, length - 1)
                .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public List<string> getStringList(int N, string[] arr)
        {
            List<string> OutArr = new List<string>();

            if (arr == null || arr.Length == 0 || N <= 0) return null;

            for (int i = 0; i < arr.Length; i++)
            {
                getString(OutArr, arr[i].ToString(), N - 1, arr);
            }
            return OutArr;
        }

        private void getString(List<string> OutArr, string strToAppend, int N, string[] arr)
        {
            if(N==0) 
            {
                OutArr.Add(strToAppend);
                return;
            }
    
            for (int i = 0; i<arr.Length; i++)
            {
                getString(OutArr, strToAppend+arr[i].ToString(), N-1, arr);
            }
        }
        #endregion

        public void countHuffman()
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            AMatrix = new int[Vertices.Count, Vertices.Count];
            Graph.fillAdjacencyMatrix(Vertices.Count, Edges, AMatrix);
            string freqSrt = textBox1.Text;
            List<double> freq1 = new List<double>();
            string[] sizes = freqSrt.Split(' ', '\t');
            foreach (var i in sizes)
            {
                string str11 = "";
                if (i.Contains(","))
                {
                    str11 = i.Replace(',', '.');
                }
                else
                {
                    str11 = i;
                }

                double m = Convert.ToDouble(str11);
                freq1.Add(m);
            }

            List<VertexColor> graph = new List<VertexColor>();
            //степени вершин 
            for (int i2 = 0; i2 < Vertices.Count; i2++)
            {
                VertexColor item = new VertexColor(i2, 0, 0);
                for (int j2 = 0; j2 < Vertices.Count; j2++)
                {
                    if (AMatrix[i2, j2] == 1)
                    {
                        item.stepen++;
                    }
                }
                graph.Add(item);
            }

            graph = graph.OrderBy(z => z.stepen).ToList();

            //находим несмежные вершины (нумерация с 0)
            int n1 = graph[0].number; // во внимание не берем при построении преф кода
            int n2 = graph[1].number;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<double> freq = new List<double>();
            foreach (var d in freq1)
            {
                freq.Add(d);
            }

            freq[n2] += freq[n1];
            freq.RemoveAt(n1);

            List<HuffmanNode> nodeList = new List<HuffmanNode>();
            for(int i=1; i< graph.Count; i++)
            {
                nodeList.Add(new HuffmanNode(graph[i].number.ToString(), freq[i-1]));
            }
            nodeList.Sort();

            GetTreeFromList(nodeList);
            SetCodeToTheTree("", nodeList[0]);
            Dictionary<int, string> prefCode = new Dictionary<int, string>();
            PrintfLeafAndCodes(nodeList[0], prefCode);
            var prefCode1 = prefCode.OrderBy(x => x.Key);

            List<string> code = new List<string>();
            foreach (var item in prefCode1)
            {
                code.Add(item.Value);
            }
            code.Insert(n1, code[n2 - 1]);

            List<int> spectr = new List<int>();
            foreach (var item in code)
            {
                spectr.Add(item.Length);
            }

            double cost=0;
            for(int i=0; i< spectr.Count; i++)
            {
                cost += freq1[i] * spectr[i];
            }

            hCost.Text = cost.ToString();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            hTime.Text = elapsedTime;
            string str = "";
            foreach (var d in spectr)
            {
                str += d + " ";
            }
            listBox2.Items.Add(str);

            string str1 = "";
            foreach (var m in code)
            {
                str1 += m + ", ";
            }
            listBox3.Items.Add(str1);
        }

        #region Huffman methods
        //  Creates a Tree according to Nodes(frequency, symbol)
        public void GetTreeFromList(List<HuffmanNode> nodeList)
        {
            while (nodeList.Count > 1)  // 1 because a tree need 2 leaf to make a new parent.
            {
                HuffmanNode node1 = nodeList[0];    // Get the node of the first index of List,
                nodeList.RemoveAt(0);               // and delete it.
                HuffmanNode node2 = nodeList[0];    // Get the node of the first index of List,
                nodeList.RemoveAt(0);               // and delete it.
                nodeList.Add(new HuffmanNode(node1, node2));    // Sending the constructor to make a new Node from this nodes.
                nodeList.Sort();        // and sort it again according to frequency.
            }
        }

        public void SetCodeToTheTree(string code, HuffmanNode Nodes)
        {
            if (Nodes == null)
                return;
            if (Nodes.leftTree == null && Nodes.rightTree == null)
            {
                Nodes.code = code;
                return;
            }
            SetCodeToTheTree(code + "0", Nodes.leftTree);
            SetCodeToTheTree(code + "1", Nodes.rightTree);
        }

        public void PrintfLeafAndCodes(HuffmanNode nodeList, Dictionary<int, string> prefCodes)
        {
            
            if (nodeList == null)
                return ;
            if (nodeList.leftTree == null && nodeList.rightTree == null)
            {
                //Console.WriteLine("Symbol : {0} -  Code : {1}", nodeList.symbol, nodeList.code);
                prefCodes.Add(Convert.ToInt32(nodeList.symbol), nodeList.code);
                return;
            }
            PrintfLeafAndCodes(nodeList.leftTree, prefCodes);
            PrintfLeafAndCodes(nodeList.rightTree, prefCodes);
        }
        #endregion

    }
}
