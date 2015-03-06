using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace MathParser
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FillHelpInformation();
        }

        private void FillHelpInformation()
        {
            gridHelp.Rows.Add("Add", "Adds Two Numbers", "3+5 , e+3.5");
            gridHelp.Rows.Add("Substract", "Substracts Two Numbers", "PI-E, 3+6");
            gridHelp.Rows.Add("MultiPlay", "MultiPlays Two Numbers", "1*0");
            gridHelp.Rows.Add("Divide", "Divids Two Numbers", "PI/4");
            gridHelp.Rows.Add("Log10", "Calculates The Base 10 Logarithm of a given number", "Log(10), Log(PI)");
            gridHelp.Rows.Add("Ln", "Calculates The Base e Logarithm of a given number", "Ln(e), Ln(1)");
            gridHelp.Rows.Add("Sqrt", "Calculates The Squar Root of a given number", "sqrt(25), sqrt(9)");
            gridHelp.Rows.Add("Power", "Raises a number to the provided exponent", "3Power5, 10^3, 25^5");
            gridHelp.Rows.Add("Sin", "Calculates The Sin Of a given angle", "Sin(30), Sin(PI)");
            gridHelp.Rows.Add("Cos", "Calculates The Cos Of a given angle", "Cos(30), Cos(PI)");
            gridHelp.Rows.Add("Sinh", "Calculates The Sinh Of a given angle", "Sinh(30), Sinh(PI)");
            gridHelp.Rows.Add("Cosh", "Calculates The Cosh Of a given angle", "Cosh(30), Cosh(PI)");
            gridHelp.Rows.Add("Tan", "Calculates The Tan Of a given angle", "Tan(30), Tan(PI)");
            gridHelp.Rows.Add("ATan", "Calculates The Angle Whose Tan is Provided", "ATan(0), ATan(1)");
            gridHelp.Rows.Add("ASin", "Calculates The Angle Whose Sin Is Provided", "ASin(0.5), ASin(0)");
            gridHelp.Rows.Add("ACos", "Calculates The Angle Whose Cos Is Provided", "ACos(0.5), ACos(0)");
            gridHelp.Rows.Add("Abs", "Returns The Absolute Value Of The provided Number", "Abs(3) = Abs(-3) = 3");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this,
                "Math Parser Application V1\n" +
                "Made By Feras Dawod", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string infixInput = txtInputExpression.Text;
            if (string.IsNullOrWhiteSpace(infixInput))
            {
                MetroMessageBox.Show(this, "Input Expression Can't be empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtInputExpression.Clear();
                txtInputExpression.Focus();
            }
            else
            {
                DoParsing(infixInput);
            }
        }

        private async void DoParsing(string input)
        {
            pnlLoading.Visible = true;
            ClearInformation();
            ToggleControls(false);

            lblCurrentTask.Text = "Parsing And Building The Tree";

            // create the tree and try to parse the input string
            MathTree tree = new MathTree();
            Task<bool> buildTask = Task.Run<bool>(() =>
                {
                    return tree.BuildFromInfix(input);
                });
            await buildTask;

            if (buildTask.Result)
            {
                lblCurrentTask.Text = "Populating Information";

                string optimized, postfix, tokens;
                optimized = postfix = tokens = string.Empty;

                double answer = 0.0D;

                await Task.Run(() =>
                    {
                        optimized = tree.OptimizedExpression;

                        foreach (string token in tree.ExtractedTokens)
                        {
                            tokens += token + " ";
                        }

                        foreach (string token in tree.PostfixTokens)
                        {
                            postfix += token + " ";
                        }

                        answer = tree.Evaluate();
                    });

                txtOptimized.Text = optimized;
                txtExtractedTokens.Text = tokens;
                txtPostfix.Text = postfix;
                txtAnswer.Text = answer.ToString();

                lblCurrentTask.Text = "Rendering Tree Image";
                Image treeImage = new Bitmap(15, 15);

                await Task.Run(() =>
                    {
                        treeImage = MathTreeRenderer.RenderTree(tree);
                    });

                pctrTree.Image = treeImage;

            }
            else
            {
                MetroMessageBox.Show(this,
                    "Failed To parse the expression\nError Information : " + tree.LastError,
                    "Error While Parsing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pnlLoading.Visible = false;
            ToggleControls(true);
        }

        private void ToggleControls(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = enabled;
            }
        }

        private void ClearInformation()
        {
            txtAnswer.Clear();
            txtExtractedTokens.Clear();
            txtOptimized.Clear();
            txtPostfix.Clear();

            pctrTree.Image = null;

            this.Invalidate();
        }

    }
}
