using lab2.Interfaces;
using lab2.Presenters;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form, IDrawingView
    {
        private DrawingPresenter _presenter;

        public Form1()
        {
            InitializeComponent();

            comboBoxFigures.Items.AddRange(new object[]
            {
        "Линия",
        "Прямоугольник",
        "Эллипс",
        "Многоугольник",
        "Ломаная"
            });

            comboBoxFigures.SelectedIndex = 0;
            comboBoxLines.SelectedIndex = 0;

            comboBoxFigures.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLines.DropDownStyle = ComboBoxStyle.DropDownList;

            _presenter = new DrawingPresenter(this);

            trackBarThickness.Scroll += TrackBarThickness_Scroll;
            UpdateThicknessLabel();
        }

        private void TrackBarThickness_Scroll(object sender, EventArgs e)
        {
            UpdateThicknessLabel();
        }

        private void UpdateThicknessLabel()
        {
            lblThickness.Text = $"Толщина: {trackBarThickness.Value} px";
        }

        public PictureBox PictureBox => pictureBoxDrawing;
        public ComboBox FiguresComboBox => comboBoxFigures;
        public ComboBox LinesComboBox => comboBoxLines;
        public Button ColorButton => buttonColor;
        public Button FillButton => buttonFilling;
        public TrackBar ThicknessTrackBar => trackBarThickness;
        public Button UndoButton => buttonBack;
        public Button RedoButton => buttonForward;
        public Button ClearButton => buttonClear;
        public Label ThicknessLabel => lblThickness;
        public ColorDialog ColorDialog => colorDialog1;
        public ColorDialog FillColorDialog => colorDialog2;
        public Button SaveButton => buttonSave; 
        public Button LoadButton => buttonLoad; 
    }
}