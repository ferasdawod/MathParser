using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathParser
{
    public partial class Form1 : Form
    {
        MathTree tree;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = MathHelper.UsingRadians;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string infix = textBox1.Text;

            var l = MathHelper.OptimizeExpression(infix);
            lblOptimized.Text = l;

            lblMathTokens.Text = "";
            var aa = MathHelper.ExtractMathTokens(infix);
            foreach (var p in aa)
                lblMathTokens.Text += p + " _ ";

            lblPostfix.Text = "";
            var s = MathHelper.ConvertToPostfix(infix);
            foreach (var a in s)
                lblPostfix.Text += a + " _ ";

            tree = new MathTree();

            if (tree.BuildFromInfix(infix))
            {
                lblResult.Text = tree.Evaluate().ToString();

                pictureBox1.Image = MathTreeRenderer.RenderTree(tree);
                this.Invalidate();
            }
            else
            {
                MessageBox.Show(tree.LastError);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MathHelper.UsingRadians = checkBox1.Checked;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Array operations = Enum.GetValues(typeof(MathOperation));
            StringBuilder str = new StringBuilder();
            foreach (object op in operations)
            {
                str.Append(op.ToString() + ", ");
            }

            MessageBox.Show("Available Operations : \n" + str.ToString(), "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
