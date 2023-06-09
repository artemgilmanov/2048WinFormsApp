namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private const int gridSize = 4;
        private const int spaceBetweenLabels = 10;
        private Label[,] labelsGrid;
        private static Random random = new Random();
        private int score = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitField();
            GenerateNumber();
            ShowScore();
        }
        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }
        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(gridSize * gridSize);
                var indexRow = randomNumberLabel / gridSize;
                var indexColumn = randomNumberLabel % gridSize;
                if (labelsGrid[indexRow, indexColumn].Text == string.Empty)
                {
                    //would be nice to generate 2 or 4
                    labelsGrid[indexRow, indexColumn].Text = "2";
                    break;
                }
            }
        }
        private void InitField()
        {
            labelsGrid = new Label[gridSize, gridSize];
            for (int a = 0; a < gridSize; a++)
            {
                for (int b = 0; b < gridSize; b++)
                {
                    var newLabel = GenerateNewLabel(a, b);
                    Controls.Add(newLabel);
                    labelsGrid[a, b] = newLabel;
                }
            }
        }
        private Label GenerateNewLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = Color.Gainsboro;
            label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label.Size = new Size(100, 100);
            label.TextAlign = ContentAlignment.MiddleCenter;

            var x = spaceBetweenLabels + indexColumn * (label.Size.Width+spaceBetweenLabels);
            var y = spaceBetweenLabels + indexRow * (label.Size.Height+spaceBetweenLabels);
            label.Location = new Point(x, y);

            return label;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) 
            {
                for (int a = 0; a < gridSize; a++)
                {
                    for (int b = gridSize - 1; b >=0 ; b--)
                    {
                        if (labelsGrid[a,b].Text != string.Empty)
                        {
                            for (int c = b-1; c >= 0; c--)
                            {
                                if (labelsGrid[a,c].Text != string.Empty )
                                {
                                    if (labelsGrid[a, b].Text == labelsGrid[a, c].Text)
                                    {
                                        var number = int.Parse(labelsGrid[a,b].Text);
                                        score += number * 2;
                                        labelsGrid[a, b].Text = (number * 2).ToString();
                                        labelsGrid[a, c].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int a = 0; a < gridSize; a++)
                {
                    for (int b = gridSize - 1; b >= 0; b--)
                    {
                        if (labelsGrid[a, b].Text == string.Empty)
                        {
                            for (int c = b - 1; c >= 0; c--)
                            {
                                if (labelsGrid[a, c].Text != string.Empty)
                                {
                                    labelsGrid[a, b].Text = labelsGrid[a, c].Text;
                                    labelsGrid[a, c].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
                //MessageBox.Show("Pressed RIGHT button.");
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int a = 0; a < gridSize; a++)
                {
                    for (int b = 0; b < gridSize; b++)
                    {
                        if (labelsGrid[a, b].Text != string.Empty)
                        {
                            for (int c = b + 1; c < gridSize; c++)
                            {
                                if (labelsGrid[a, c].Text != string.Empty)
                                {
                                    if (labelsGrid[a, b].Text == labelsGrid[a, c].Text)
                                    {
                                        var number = int.Parse(labelsGrid[a, b].Text);
                                        score += number * 2;
                                        labelsGrid[a, b].Text = (number * 2).ToString();
                                        labelsGrid[a, c].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int a = 0; a < gridSize; a++)
                {
                    for (int b = 0; b < gridSize; b++)
                    {
                        if (labelsGrid[a, b].Text == string.Empty)
                        {
                            for (int c = b + 1; c < gridSize; c++)
                            {
                                if (labelsGrid[a, c].Text != string.Empty)
                                {
                                    labelsGrid[a, b].Text = labelsGrid[a, c].Text;
                                    labelsGrid[a, c].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
                //MessageBox.Show("Pressed LEFT button.");
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int b = 0; b < gridSize; b++)
                {
                    for (int a = 0; a < gridSize; a++)
                    {
                        if (labelsGrid[a, b].Text != string.Empty)
                        {
                            for (int c = a + 1; c < gridSize; c++)
                            {
                                if (labelsGrid[c, b].Text != string.Empty)
                                {
                                    if (labelsGrid[a, b].Text == labelsGrid[c, b].Text)
                                    {
                                        var number = int.Parse(labelsGrid[a, b].Text);
                                        score += number * 2;
                                        labelsGrid[a, b].Text = (number * 2).ToString();
                                        labelsGrid[c, b].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int b = 0; b < gridSize; b++)
                {
                    for (int a = 0; a < gridSize; a++)
                    {
                        if (labelsGrid[a, b].Text == string.Empty)
                        {
                            for (int c = a + 1; c < gridSize; c++)
                            {
                                if (labelsGrid[c, b].Text != string.Empty)
                                {
                                    labelsGrid[a, b].Text = labelsGrid[c, b].Text;
                                    labelsGrid[c, b].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    } 
                }
                //MessageBox.Show("Pressed UP button.");
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int b = 0; b < gridSize; b++)
                {
                    for (int a = gridSize-1; a >= 0; a--)
                    {
                        if (labelsGrid[a, b].Text != string.Empty)
                        {
                            for (int c = a - 1; c >= 0; c--)
                            {
                                if (labelsGrid[c, b].Text != string.Empty)
                                {
                                    if (labelsGrid[a, b].Text == labelsGrid[c, b].Text)
                                    {
                                        var number = int.Parse(labelsGrid[a, b].Text);
                                        score += number * 2;
                                        labelsGrid[a, b].Text = (number * 2).ToString();
                                        labelsGrid[c, b].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int b = 0; b < gridSize; b++)
                {
                    for (int a = gridSize - 1; a >= 0; a--)
                    {
                        if (labelsGrid[a, b].Text == string.Empty)
                        {
                            for (int c = a - 1; c >= 0; c--)
                            {
                                if (labelsGrid[c, b].Text != string.Empty)
                                {
                                    labelsGrid[a, b].Text = labelsGrid[c, b].Text;
                                    labelsGrid[c, b].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
                //MessageBox.Show("Pressed DOWN button.");
            }

            GenerateNumber();
            ShowScore();
        }
        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}