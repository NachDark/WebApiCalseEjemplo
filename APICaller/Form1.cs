namespace APICaller
{
    public partial class Form1 : Form
    {
        ConfigReader Config { get; set; }
        public Form1()
        {
            InitializeComponent();
            Config = new ConfigReader();
            label1.Text = Config.test;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new LecturaXML().LecturaXML_Nodes(Config.fichero);
            new LecturaXML().LecturaXML_Deserialize(Config.fichero);
            new LecturaXML().LecturaXML_Deserialize(Config.ficheropizza, true);
            new LecturaXML().LecturaXML_Nodes(Config.ficheropizza);
        }
    }
}