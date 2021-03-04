using System;
using CableTechModeCommon;
using System.Windows.Forms;

namespace CablesTechModeWindowsFormsApp
{
    public partial class MainForm : Form, IView
    {
        public event Action<int> ShortNameChanged;
        public event Action ViewClosed;

        public ProgramDataRepository ProgramDataRepository { get; set; }

        public MainForm(ProgramDataRepository programDataRepository)
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
            ProgramDataRepository = programDataRepository;
        }

        private void CablesNamesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ShortNameChanged?.Invoke((int)cablesNamesListBox.SelectedValue);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var cableNamesBindingSource = new BindingSource { DataSource = ProgramDataRepository.CableShortNames };
            cablesNamesListBox.DataSource = cableNamesBindingSource;
            cablesNamesListBox.DisplayMember = "ShortName";
            var cableBilletsBindingSource = new BindingSource { DataSource = ProgramDataRepository.InsulatedBillets };
            comboBox1.DataSource = cableBilletsBindingSource;
            cablesNamesListBox.DisplayMember = "Diameter";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewClosed?.Invoke();
        }
    }
}
