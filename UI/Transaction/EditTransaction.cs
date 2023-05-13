namespace UI.Transaction
{
    public partial class EditTransaction : Form
    {
        public EditTransaction()
        {
            InitializeComponent();
        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
        }
    }
}
