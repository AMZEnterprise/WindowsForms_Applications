using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WumpusWorld
{
    public class Node : Form
    {

        public Button myButton;
        public Node Up;
        public Node Down;
        public Node Left;
        public Node Right;
        public int value = 0; //Used by the logic bot.
        public int posX, posY;
        public bool visited = false;
        public bool isSafe = false;
        public double pitProb = 0.0;
        public bool hasBreeze = false;
        public bool hasStench = false;
        public bool hasGlitter = false;

        public bool hasPit, hasWumpus, hasGold, closePit, closeGold, closeWumpus, wumpusAlive, isExit;

        public static bool isGoldFound = false;
        public Node(Button button, int PosY, int PosX)
        {
            myButton = button;            
            posX = PosX;
            posY = PosY;
            hasGold = false;
            hasWumpus = false;
            hasPit = false;
        }

        public void getStatus(Node node, TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {

            if ((node.Up != null && node.Up.hasGold) || (node.Down != null && node.Down.hasGold) || (node.Left != null && node.Left.hasGold) || (node.Right != null && node.Right.hasGold))
            {
                node.myButton.BackColor = Color.Yellow;
                closeGold = true;
                textBox1.BackColor = Color.Yellow;
                textBox1.Text = "درخشش";
            }
            else
            {
                textBox1.Text = "";
                textBox1.BackColor = Color.White;
                closeGold = false;
            }
            if ((node.Up != null && node.Up.hasPit) || (node.Down != null && node.Down.hasPit) || (node.Left != null && node.Left.hasPit) || (node.Right != null && node.Right.hasPit))
            {
                node.myButton.BackColor = Color.Blue;
                closePit = true;
                textBox2.BackColor = Color.Blue;
                textBox2.Text = "جاذبه";
            }
            else
            {
                textBox2.Text = "";
                textBox2.BackColor = Color.White;
                closePit = false;
            }
            if ((node.Up != null && node.Up.hasWumpus) || (node.Down != null && node.Down.hasWumpus) || (node.Left != null && node.Left.hasWumpus) || (node.Right != null && node.Right.hasWumpus))
            {
                node.myButton.BackColor = Color.Green;
                closeWumpus = true;
                textBox3.BackColor = Color.Green;
                textBox3.Text = "بوی تعفن";
            }
            else
            {
                textBox3.Text = "";
                textBox3.BackColor = Color.White;
                closeWumpus = false;
            }
            if (closePit && closeGold)
            {
                node.myButton.BackgroundImage = Image.FromFile("YellowAndBlue.png");
                textBox1.Text = "درخشش";
                textBox1.BackColor = Color.Yellow;
                textBox2.Text = "جاذبه";
                textBox2.BackColor = Color.Blue;
            }
            if (closeWumpus && closeGold)
            {
                node.myButton.BackgroundImage = Image.FromFile("YellowAndGreen.png");
                textBox1.Text = "درخشش";
                textBox1.BackColor = Color.Yellow;
                textBox3.Text = "بوی تعفن";
                textBox3.BackColor = Color.Green;
            }
            if (closeWumpus && closePit)
            {
                node.myButton.BackgroundImage = Image.FromFile("BlueAndGreen.png");
                textBox2.Text = "جاذبه";
                textBox2.BackColor = Color.Blue;
                textBox3.Text = "بوی تعفن";
                textBox3.BackColor = Color.Green;
            }
            if (closeGold && closePit && closeWumpus)
            {
                node.myButton.BackgroundImage = Image.FromFile("AllColors.png");
                textBox1.Text = "درخشش";
                textBox1.BackColor = Color.Yellow;
                textBox2.Text = "جاذبه";
                textBox2.BackColor = Color.Blue;
                textBox3.Text = "بوی تعفن";
                textBox3.BackColor = Color.Green;
            }
            if (node.wumpusAlive == false && node.hasWumpus == true)
            {
                node.myButton.BackgroundImage = Image.FromFile("deadmonster.png");
            }
        }

        public bool checkNode(Node node, TextBox textBox4,RichTextBox richText1)
        {
            if (node.hasPit || (node.hasWumpus && node.wumpusAlive))
            {
                textBox4.Text = "شما بازی را باختید!";
                richText1.Text += "******** بازی را باختید ********\n";
                node.myButton.Image = null;
                return true;
            }
            else if (node.hasGold)
            {
                textBox4.Text = "شما طلا را پیدا کردید!";
                richText1.Text += "******** طلا را پیدا کردید ، اکنون به درب خروج بروید ********\n";
                isGoldFound = true;
                return false;
            }
            else if (node.isExit)
            {
                if (isGoldFound == true)
                {
                    textBox4.Text = "شما بازی را برنده شدید";
                    richText1.Text += "******** تبریک ! بازی را برنده شدید ********\n";
                    node.myButton.Image = null;
                    return true;
                }
                else
                {
                    textBox4.Text = "ابتدا طلا را پیدا کنید و سپس به درب خروج وارد شوید";
                    richText1.Text += "******** ابتدا طلا را پیدا کنید ********\n";
                    node.myButton.Image = null;
                    return false;
                }
            }
            else return false;
        }
    }
}
