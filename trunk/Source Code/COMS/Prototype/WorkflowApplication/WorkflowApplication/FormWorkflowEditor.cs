using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkflowApplication
{
    public partial class FormWorkflowEditor : Form
    {
        public FormWorkflowEditor()
        {
            InitializeComponent();
        }

        private Pen penBlack = new Pen(Color.Black);

        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawingBlock dbk = new DrawingBlock(g, 0, 0, "Printing");
            dbk.drawBlock();

            DrawingBlock dbk2 = new DrawingBlock(g, 120, 120, "Engraving");
            dbk2.drawBlock();
        }
    }
}
