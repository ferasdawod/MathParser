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
            try
            {
                string infix = textBox1.Text;
                infix = MathHelper.OptimizeExpression(infix);
                var l = MathHelper.ExtractMathTokens(infix);
                lblOptimized.Text = "";
                foreach (var s in l)
                    lblOptimized.Text += s + " _ ";

                lblPostfix.Text = "";
                foreach (string s in MathHelper.ConvertToPostfix(infix))
                    lblPostfix.Text += s + " _ ";

                tree = new MathTree();
                if (tree.BuildFromPostfix(MathHelper.ConvertToPostfix(infix)))
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
            catch (Exception ex)
            {
                MessageBox.Show("Error while parsing the expression\nError Message : " + ex.Message +
                    "\nStack Trace : \n" + ex.StackTrace);
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
