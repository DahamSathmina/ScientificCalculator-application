using System;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class Form1 : Form
    {
        private Button button1;
        private Label label1;

        public Form1()
        {
            InitializeComponent();

            // Create a button
            button1 = new Button();
            button1.Text = "Click Me!";
            button1.Location = new System.Drawing.Point(100, 50);
            button1.Click += Button1_Click;

            // Create a label
            label1 = new Label();
            label1.Text = "Hello, World!";
            label1.Location = new System.Drawing.Point(100, 100);
            label1.AutoSize = true;

            // Add controls to form
            this.Controls.Add(button1);
            this.Controls.Add(label1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "You clicked the button!";
        }
    }
}

