namespace KochSnowFlake
{
    public partial class FormBase : Form
    {
        Panel drawingPanel;

        public FormBase()
        {
            InitializeComponent();

            drawingPanel = new Panel();
            drawingPanel.Location = new Point(90, 59);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(800, 600);
            drawingPanel.TabIndex = 0;
            drawingPanel.Paint += DrawingPanel_Paint;

            this.Controls.Add(drawingPanel);
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Blue, 1))
            {
                e.Graphics.DrawLine(pen, new Point(50, 50), new Point(75, 65));
            }
        }
    }
}