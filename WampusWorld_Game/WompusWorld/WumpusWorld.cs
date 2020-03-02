using System;
using System.Drawing;
using System.Windows.Forms;


namespace WumpusWorld
{
    public partial class WumpusWorld : Form
    {
        Random rand = new Random();
        public int[] currentPos = new int[2];
        public int[] prevPos = new int[2];
        public Node[,] board = new Node[4, 4];
        public int dir = 3; //Direction 0 = Up; 1 = Down; 2 = Left; 3 = Right
        public bool arrowFired = false;

        Node prevNode;

        public WumpusWorld()
        {
            InitializeComponent();

            createBoard();
            linkNodes(board);
            currentPos[0] = board[3, 0].posY;
            currentPos[1] = board[3, 0].posX;
            board[3, 0].myButton.Image = Image.FromFile("sara.png");
            dir = 3;
            board[3, 0].getStatus(board[3, 0], textBox1, textBox2, textBox3);
            prevNode = board[3, 0];
            richTextBox1.Text += "به بازی خوش آمدید\n";

            string msg = "طلا را پیدا کنید و به درب خروج بروید" + "." +
" همچنین با دکمه کشتن هیولا می توانید هنگامی که در کنار هیولا هستید آن را نابود کنید";
            MessageBox.Show(msg, "راهنمایی", MessageBoxButtons.OK);
        }


        private void wasClicked(Node node)
        {
            //Perform only if the Node clicked is Right, Left, Below or Above the clicked node
            if ((currentPos[0] == node.posY && (currentPos[1] == node.posX + 1 || currentPos[1] == node.posX - 1)) || //Check Right / Left
                (currentPos[1] == node.posX && (currentPos[0] == node.posY + 1 || currentPos[0] == node.posY - 1))) // Check Down / Up
            {
                if (node.checkNode(node, textBox4, richTextBox1))//Check if the player died or won, if so reset the board.
                {
                    tableLayoutPanel1.Visible = false;
                    textBox4.Text += "بازی تمام شد";
                    resetBoard();
                    return;
                }
                node.myButton.Image = prevNode.myButton.Image;
                prevNode.myButton.Image = null;
                prevNode.myButton.BackgroundImage = null;
                prevNode.myButton.BackColor = Color.Black;
                prevNode = node;
                currentPos[0] = node.posY;
                currentPos[1] = node.posX;
                node.myButton.BackColor = Color.White;
                node.getStatus(node, textBox1, textBox2, textBox3);//Gather status from adjacent nodes.     
                richTextBox1.Text += $"موقعیت فعلی : (X={node.posX},Y={node.posY})\n";
            }
            else if ((node.Up != null && node.Up.hasWumpus) || (node.Down != null && node.Down.hasWumpus) || (node.Left != null && node.Left.hasWumpus) || (node.Right != null && node.Right.hasWumpus))
            {
                if (node.Up != null && node.Up.hasWumpus)
                {
                    node.Up.myButton.BackgroundImage = Image.FromFile("deadmonster.png");
                    node.Up.wumpusAlive = false;
                }
                if (node.Down != null && node.Down.hasWumpus)
                {
                    node.Down.myButton.BackgroundImage = Image.FromFile("deadmonster.png");
                    node.Down.wumpusAlive = false;
                }
                if (node.Left != null && node.Left.hasWumpus)
                {
                    node.Left.myButton.BackgroundImage = Image.FromFile("deadmonster.png");
                    node.Left.wumpusAlive = false;
                }
                if (node.Right != null && node.Right.hasWumpus)
                {
                    node.Right.myButton.BackgroundImage = Image.FromFile("deadmonster.png");
                    node.Right.wumpusAlive = false;
                }
                textBox4.Text = "هیولا کشته شد!";
                richTextBox1.Text += "******** آفرین ! هیولا نابود شد! ********\n";
            }
            else
            {
                prevNode.myButton.Select();
            }
        }

        private void createBoard()
        {
            bool wumpusPlaced = false;
            bool goldPlaced = false;
            Node node0 = new Node(button0, 3, 0);
            board[3, 0] = node0;
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
            foreach (Node node in board)
            {
                //Exit door
                if (node.myButton.Text == "Exit")
                {
                    node.isExit = true;
                    continue;
                }

                if (node.posX == 0 && node.posY == 3) //Ensure start node has no pit or wumpus.
                {
                    currentPos[0] = board[3, 0].posY;
                    currentPos[1] = board[3, 0].posX;
                    node.myButton.BackColor = Color.White;
                }
                else
                {
                    if (rand.Next(5) == 0 && wumpusPlaced == false && node.hasPit == false && node.hasWumpus == false)
                    {
                        node.hasWumpus = true;
                        node.wumpusAlive = true;
                        wumpusPlaced = true;
                        node.myButton.BackgroundImage = Image.FromFile("monster.png");
                    }
                    else if (rand.Next(5) == 0 && goldPlaced == false && node.hasPit == false && node.hasWumpus == false)
                    {
                        node.hasGold = true;
                        goldPlaced = true;
                        node.myButton.BackgroundImage = Image.FromFile("gold.png");
                    }
                    else if (rand.Next(5) == 0 && node.hasGold == false && node.hasWumpus == false)
                    {
                        node.hasPit = true;
                        node.myButton.BackgroundImage = Image.FromFile("blackhole.png");
                    }
                }

            }
            if (wumpusPlaced == false) //Ensure wumpus is placed on the board
            {
                foreach (Node node in board)
                {
                    if (node.hasPit == false && node.hasGold == false)
                    {
                        node.hasWumpus = true;
                        node.wumpusAlive = true;
                        wumpusPlaced = true;
                        break;
                    }
                }
            }
            if (goldPlaced == false) //Ensure gold is placed on the board
            {
                foreach (Node node in board)
                {
                    if (node.hasPit == false && node.hasWumpus == false)
                    {
                        node.hasGold = true;
                        goldPlaced = true;
                        break;
                    }
                }
            }
        }

        private void resetBoard()
        {
            bool wumpusPlaced = false;
            bool goldPlaced = false;
            dir = 3;
            button0.Select();
            arrowFired = false;
            //Clear the board of previous objects.
            foreach (Node node in board)
            {
                node.hasPit = false;
                node.hasWumpus = false;
                node.wumpusAlive = false;
                node.hasGold = false;
                node.myButton.BackColor = Color.Black;
                node.myButton.BackgroundImage = null;
                node.myButton.Image = null;
                node.visited = false;
                node.isSafe = false;
            }

            //Reset Wumpus and place traps.
            foreach (Node node in board)
            {
                if (node.posX == 0 && node.posY == 3) //Ensure start node has no pit or wumpus.
                {
                    currentPos[0] = board[3, 0].posY;
                    currentPos[1] = board[3, 0].posX;
                    node.myButton.BackColor = Color.White;
                    node.myButton.Image = Image.FromFile("sara.png");
                    prevNode = node; //Reassign prevNode to origin
                }
                else
                {

                    if (rand.Next(5) == 0 && goldPlaced == false && node.hasPit == false && node.hasWumpus == false)
                    {
                        node.hasGold = true;
                        goldPlaced = true;
                    }
                    else if (rand.Next(5) == 0 && wumpusPlaced == false && node.hasPit == false && node.hasWumpus == false && node.hasGold == false)
                    {
                        node.hasWumpus = true;
                        node.wumpusAlive = true;
                        wumpusPlaced = true;
                    }
                    else if (rand.Next(5) == 0 && node.hasGold == false && node.hasWumpus == false)
                    {
                        node.hasPit = true;
                    }
                }

            }
            if (wumpusPlaced == false) //Ensure wumpus is placed on the board
            {
                foreach (Node node in board)
                {
                    if (node.hasPit == false && node.hasGold == false)
                    {
                        node.hasWumpus = true;
                        node.wumpusAlive = true;
                        wumpusPlaced = true;
                        break;
                    }
                }
            }
            if (goldPlaced == false) //Ensure gold is placed on the board
            {
                foreach (Node node in board)
                {
                    if (node.hasPit == false && node.hasWumpus == false)
                    {
                        node.hasGold = true;
                        goldPlaced = true;
                        break;
                    }
                }
            }

            textBox4.Visible = true;
            board[3, 0].getStatus(board[3, 0], textBox1, textBox2, textBox3); //Grab new status from start.
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

        //Handle Button Clicks, All buttons send their corresponding board node to wasClicked();
        private void button0_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[3, 0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[3, 1]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[3, 2]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[3, 3]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[2, 0]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[2, 1]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[2, 2]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[2, 3]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[1, 0]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[1, 1]);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[1, 2]);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[1, 3]);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[0, 0]);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[0, 1]);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[0, 2]);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[0, 3]);
        }

        private void btnKillMonster_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            wasClicked(board[currentPos[0], currentPos[1]]);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("بازی جدید را شروع می کنید ؟", "بازی جدید", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                richTextBox1.Clear();
                richTextBox1.Text += "به بازی خوش آمدید\n";
                tableLayoutPanel1.Visible = true;
                resetBoard();
                Node.isGoldFound = false;
                textBox4.Clear();
                createBoard();
                linkNodes(board);
                currentPos[0] = board[3, 0].posY;
                currentPos[1] = board[3, 0].posX;
                board[3, 0].myButton.Image = Image.FromFile("sara.png");
                dir = 3;
                board[3, 0].getStatus(board[3, 0], textBox1, textBox2, textBox3);
                prevNode = board[3, 0];
            }
        }
    }
}
