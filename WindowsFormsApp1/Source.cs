using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GraphApp
{
    class Vertex
    {
        public int x, y;

        public Vertex(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    class Edge
    {
        public int v1, v2;

        public Edge(int _v1, int _v2)
        {
            v1 = _v1;
            v2 = _v2;
        }
    }

    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public string symbol;   // For the character of char value. Public because Process class use it.
        public double frequency;          // Number of the count on file, string, text.
        public string code;            // Getting from a tree for making a huffman tree.
        public HuffmanNode parentNode; // Parent Node of current Node.
        public HuffmanNode leftTree;   // Left Node of current Node.
        public HuffmanNode rightTree;  // Right Node of current Node.
        public bool isLeaf;            // Shows it is a leaf.


        public HuffmanNode(string value, double freq)    // Creating a Node with given value(character).
        {
            symbol = value;     // Setting the symbol.
            frequency = freq;      // This is creation of Node, so now its count is 1.

            rightTree = leftTree = parentNode = null;       // Does not have a left or right tree and a parent.

            code = "";          // It will be Assigned on the making Tree. Now it is empty.
            isLeaf = true;      // Because all Node we create first does not have a parent Node.
        }


        public HuffmanNode(HuffmanNode node1, HuffmanNode node2) // Join the 2 Node to make Node.
        {
            // Firsly we are adding this 2 Nodes' variables. Except the new Node's left and right tree.
            code = "";
            isLeaf = false;
            parentNode = null;

            // Now the new Node need leaf. They are node1 and node2. if node1's frequency is bigger than or equal to node2's frequency. It is right tree. Otherwise left tree. The controllers are below:
            if (node1.frequency >= node2.frequency)
            {
                rightTree = node1;
                leftTree = node2;
                rightTree.parentNode = leftTree.parentNode = this;     // "this" means the new Node!
                symbol = node1.symbol + node2.symbol;
                frequency = node1.frequency + node2.frequency;
            }
            else if (node1.frequency < node2.frequency)
            {
                rightTree = node2;
                leftTree = node1;
                leftTree.parentNode = rightTree.parentNode = this;     // "this" means the new Node!
                symbol = node2.symbol + node1.symbol;
                frequency = node2.frequency + node1.frequency;
            }
        }


        public int CompareTo(HuffmanNode otherNode) // We just override the CompareTo method. Because when we compare two Node, it must be according to frequencies of the Nodes.
        {
            return this.frequency.CompareTo(otherNode.frequency);
        }


        public void frequencyIncrease()             // When facing a same value on the Node list, it is increasing the frequency of the Node.
        {
            frequency++;
        }
    }

    class GraphDrawer
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkRedPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 15; //vertex radius
         
        public GraphDrawer(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearLayout();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Blue);
            redPen.Width = 2;
            darkRedPen = new Pen(Color.DarkRed);
            darkRedPen.Width = 2;
            fo = new Font("Arial", 13);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearLayout()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            if (E.v1 == E.v2)
            {
                gr.DrawArc(darkRedPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else
            {
                gr.DrawLine(darkRedPen, V1.x, V1.y, V2.x, V2.y);
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //draw edges
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkRedPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
                else
                {
                    gr.DrawLine(darkRedPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
            }
            //draw vertices
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }


        //заполняет матрицу смежности
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = 1;
                matrix[E[i].v2, E[i].v1] = 1;
            }
        }
    }
}
