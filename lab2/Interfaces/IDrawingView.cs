using System.Drawing;
using System.Windows.Forms;

namespace lab2.Interfaces
{
    public interface IDrawingView
    {
        PictureBox PictureBox { get; }
        ComboBox FiguresComboBox { get; }
        ComboBox LinesComboBox { get; }
        CheckBox FillCheckBox { get; }
        Button ColorButton { get; }
        Button FillButton { get; }
        TrackBar ThicknessTrackBar { get; }
        Button UndoButton { get; }
        Button RedoButton { get; }
        Button ClearButton { get; }
        Label ThicknessLabel { get; }
        ColorDialog ColorDialog { get; }
        ColorDialog FillColorDialog { get; }
    }
}