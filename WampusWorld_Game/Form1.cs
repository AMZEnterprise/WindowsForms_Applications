using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WompusWorld
{
    public partial class WumpusWorld : Form
    {

        public int[] currentPos = new int[2];
        public Node[,] board= new Node[4,4];

        public WumpusWorld()
        {
            InitializeComponent();
            createBoard();
            linkNodes(board);
            currentPos[0] = board[3,0].posX;
            currentPos[1] = board[3,0].posY;
            wasClicked(3, 0);
        }

        private void createBoard()
        {
            Node node0 = new Node(button0, 3, 0);
            board[3,0] = node0;
            Node node1 = new Node(button1, 3, 1);
            board[3, 1] = node1;
            Node node2 = new Node(button2, 3, 2);
            board[3, 2] = node2;
            Node node3 = new Node(button3, 3, 3);
            board[3, 3] = node3;
            Node node4 = new Node(button4, 2, 0);
            board[2, 0] = node4;
            Node node5 = new Node(button5, 2, 1);
            board[2, 1] = node5;
            Node node6 = new Node(button6, 2, 2);
            board[2, 2] = node6;
            Node node7 = new Node(button7, 2, 3);
            board[2, 3] = node7;
            Node node8 = new Node(button8, 1, 0);
            board[1, 0] = node8;
            Node node9 = new Node(button9, 1, 1);
            board[1, 1] = node9;
            Node node10 = new Node(button10, 1, 2);
            board[1, 2] = node10;
            Node node11 = new Node(button11, 1, 3);
            board[1, 3] = node11;
            Node node12 = new Node(button12, 0, 0);
            board[0, 0] = node12;
            Node node13 = new Node(button13, 0, 1);
            board[0, 1] = node13;
            Node node14 = new Node(button14, 0, 2);
            board[0, 2] = node14;
            Node node15 = new Node(button15, 0, 3);
            board[0, 3] = node15;
        }

        public void wasClicked(int posY, int posX)
        {
            currentPos[0] = posY;
            currentPos[1] = posX;
            board[posY, posX].myButton.BackColor = Color.Green;
            board[posY, posX].wasClicked = true;
            

            foreach (Node node in board)
            {

                //Check Adjacent Nodes 
                if (node.wasClicked == false && node.posX == posX && (node.posY == posY + 1 || node.posY == posY - 1))
                {
                    node.myButton.BackColor = Color.Black;
                }
                if (node.wasClicked == false && node.posY == posY && (node.posX == posX + 1 || node.posX == posX - 1))
                {
                    node.myButton.BackColor = Color.Black;
                }
            }
      

        }




        //Link Adjacent Nodes Together
        public void linkNodes(Node[,] board)
        {
            foreach (Node node in board)
            {
                foreach (Node linkNode in board)
                {
                    if (node.posX == linkNode.posX && node.posY - 1 == linkNode.posY)
                    {
                        node.Up = linkNode;
                    }
                    else if (node.posX == linkNode.posX && node.posY + 1 == linkNode.posY)
                    {
                        node.Down = linkNode;
                    }
                    else if (node.posY == linkNode.posY && node.posX - 1 == linkNode.posX)
                    {
                        node.Left = linkNode;
                    }
                    else if (node.posY == linkNode.posY && node.posX + 1 == linkNode.posX)
                    {
                        node.Right = linkNode;
                    }
                }               
            }
        }

        //Handle Button Clicks, All buttons send their Y and X coordinates to wasClicked();
        private void button0_Click(object sender, EventArgs e)
        {
            wasClicked(board[3,0].posY, board[3,0].posX);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wasClicked(board[3,1].posY, board[3,1].posX);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wasClicked(board[3,2].posY, board[3,2].posX);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wasClicked(board[3,3].posY, board[3,3].posX);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wasClicked(board[2,0].posY, board[2,0].posX);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wasClicked(board[2,1].posY, board[2,1].posX);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            wasClicked(board[2,2].posY, board[2,2].posX);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            wasClicked(board[2,3].posY, board[2,3].posX);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            wasClicked(board[1,0].posY, board[1,0].posX);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            wasClicked(board[1,1].posY, board[1,1].posX);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wasClicked(board[1,2].posY, board[1,2].posX);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            wasClicked(board[1,3].posY, board[1,3].posX);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            wasClicked(board[0,0].posY, board[0,0].posX);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            wasClicked(board[0,1].posY, board[0,1].posX);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            wasClicked(board[0,2].posY, board[0,2].posX);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            wasClicked(board[0,3].posY, board[0,3].posX);
        }

        

    }
}
