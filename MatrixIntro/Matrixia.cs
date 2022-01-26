namespace MatrixIntro
{
    public partial class Matrixia : Form
    {
        const int MAX_LABEL = 64;

        const int POINT_X = 12;
        const int POINT_Y = 9;

        const int TEXT_SPACE = 19;

        const int TEXT_RANGE_MAX = 50;
        const int TEXT_RANGE_MIN = 7;

        const int SPACE_RANGE_MAX = 20;
        const int SPACE_RANGE_MIN = 5;

        private Size TEXT_SIZE = new Size(13, 432);

        private enum MODE
        {
            TEXT,
            SPACE,
            WAIT
        }

        List<MODE> _mode = new List<MODE>();

        List<Label> label = new List<Label>();
        List<int> textRange = new List<int>();
        List<int> textCount = new List<int>();
        List<int> spaceRange = new List<int>();
        List<int> spaceCount = new List<int>();
        List<int> waitCount = new List<int>();



        public Matrixia()
        {
            InitializeComponent();
            CreateLabel();
        }
        private void TextUpdate(int i, Random random)
        {
            switch (_mode[i])
            {
                case MODE.TEXT:

                    label[i].Text = label[i].Text.Insert(0, random.Next(0, 10).ToString());
                    textCount[i]++;
                    if (textCount[i] > textRange[i])
                    {
                        textRange[i] = random.Next(TEXT_RANGE_MIN, TEXT_RANGE_MAX);
                        textCount[i] = 0;
                        _mode[i] = MODE.SPACE;
                    }

                    break;

                case MODE.SPACE:

                    label[i].Text = label[i].Text.Insert(0, "@");
                    spaceCount[i]++;

                    if (spaceCount[i] > spaceRange[i])
                    {
                        spaceRange[i] = random.Next(SPACE_RANGE_MIN, SPACE_RANGE_MAX);
                        spaceCount[i] = 0;
                        _mode[i] = MODE.TEXT;
                    }

                    break;

                case MODE.WAIT:

                    waitCount[i]--;
                    if (waitCount[i] <= 0) _mode[i] = MODE.TEXT;

                    break;

                default:
                    break;
            }
        }
        private void CreateLabel()
        {

            for (int i = 0; i < MAX_LABEL; i++)
            {
                label.Add(new Label());
                label[i].Location = new Point(POINT_X * (i) + TEXT_SPACE, POINT_Y);
                label[i].Size = TEXT_SIZE;
                label[i].Text = "";
                label[i].AutoSize = false;
                label[i].TextAlign = ContentAlignment.TopCenter;
                label[i].ForeColor = Color.Lime;
                this.Controls.Add(label[i]);

                Random random = new Random();

                textRange.Add(random.Next(TEXT_RANGE_MIN, TEXT_RANGE_MAX));
                textCount.Add(0);

                spaceRange.Add(random.Next(SPACE_RANGE_MIN, SPACE_RANGE_MAX));
                spaceCount.Add(0);

                waitCount.Add(random.Next(0, 20));

                _mode.Add(MODE.WAIT);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            for (int i = 0; i < MAX_LABEL; i++)
            {
                Random random = new Random();
                TextUpdate(i, random);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}