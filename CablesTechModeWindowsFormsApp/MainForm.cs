using System;
using CableTechModeCommon;
using System.Windows.Forms;
using System.Linq;

namespace CablesTechModeWindowsFormsApp
{
    public partial class MainForm : Form, IView
    {
        public event Action<int> ShortNameChanged;
        public ProgramDataRepository ProgramDataRepository { get; set; }

        public MainForm(ProgramDataRepository programDataRepository)
        {
            InitializeComponent();
            ProgramDataRepository = programDataRepository;
        }

        private void CablesNamesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ShortNameChanged?.Invoke((int)cablesNamesListBox.SelectedValue);
        }

        public void SetProgramData()
        {
            cablesNamesListBox.DataSource = ProgramDataRepository.CableShortNames;
            cablesNamesListBox.DisplayMember = "ShortName";
            cablesNamesListBox.ValueMember = "Id";
            cablesNamesListBox.SelectedValueChanged += CablesNamesListBox_SelectedValueChanged;

            wireSquareListBox.DataSource = ProgramDataRepository.InsulatedBillets.Select(b => b.Conductor);
            wireSquareListBox.DisplayMember = "AreaInSqrMm";
            wireSquareListBox.ValueMember = "Id";
        }
    }
}
