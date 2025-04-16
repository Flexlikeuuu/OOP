using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using lab2.Enums;
using lab2.Interfaces;
using lab2.Models;
using lab2.Models.Shapes;

namespace lab2.Presenters
{
    public class DrawingPresenter
    {
        private readonly IDrawingView _view;
        private readonly DrawingModel _model;
        private IShape _currentShape;
        private bool _isDrawing;
        private Point _startPoint;

        public DrawingPresenter(IDrawingView view)
        {
            _view = view;
            _model = new DrawingModel();

            SubscribeEvents();
            InitializeView();
        }

        private void SubscribeEvents()
        {
            _view.PictureBox.MouseDown += PictureBox_MouseDown;
            _view.PictureBox.MouseMove += PictureBox_MouseMove;
            _view.PictureBox.MouseUp += PictureBox_MouseUp;
            _view.PictureBox.Paint += PictureBox_Paint;

            _view.ColorButton.Click += ColorButton_Click;
            _view.FillButton.Click += FillButton_Click;
            _view.UndoButton.Click += UndoButton_Click;
            _view.RedoButton.Click += RedoButton_Click;
            _view.ClearButton.Click += ClearButton_Click;
            _view.ThicknessTrackBar.Scroll += ThicknessTrackBar_Scroll;
            _view.LinesComboBox.SelectedIndexChanged += LinesComboBox_SelectedIndexChanged;
        }

        private void InitializeView()
        {
            _view.ThicknessTrackBar.Value = (int)_model.StrokeWidth;
            _view.ThicknessLabel.Text = $"Толщина: {_model.StrokeWidth} px";
            _view.ColorButton.BackColor = _model.StrokeColor;
            _view.FillButton.BackColor = _model.FillColor;
        }

        private void LinesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _model.LineStyle = GetCurrentLineStyle();
        }

        private DashStyle GetCurrentLineStyle()
        {
            if (_view.LinesComboBox.SelectedItem == null)
                return DashStyle.Solid;

            switch (_view.LinesComboBox.SelectedItem.ToString())
            {
                case "Пунктирная": return DashStyle.Dash;
                case "Точечная": return DashStyle.Dot;
                case "Штрих-пунктир": return DashStyle.DashDot;
                default: return DashStyle.Solid;
            }
        }

        private void ThicknessTrackBar_Scroll(object sender, EventArgs e)
        {
            _model.StrokeWidth = _view.ThicknessTrackBar.Value;
            _view.ThicknessLabel.Text = $"Толщина: {_model.StrokeWidth} px";
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _isDrawing = true;
            _startPoint = e.Location;
            _currentShape = CreateShape();
            _currentShape.StartPoint = e.Location;
            _currentShape.EndPoint = e.Location;
            _currentShape.LineStyle = _model.LineStyle;
        }

        private IShape CreateShape()
        {
            switch (_view.FiguresComboBox.SelectedItem?.ToString())
            {
                case "Прямоугольник": return new RectangleShape();
                case "Эллипс": return new EllipseShape();
                case "Многоугольник": return new PolygonShape();
                case "Ломаная": return new PolylineShape();
                default: return new LineShape();
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDrawing || _currentShape == null) return;

            if (_currentShape is PolylineShape polyline)
            {
                polyline.Points.Add(e.Location);
            }
            else if (_currentShape is PolygonShape polygon)
            {
                polygon.Points.Add(e.Location);
            }
            else
            {
                _currentShape.EndPoint = e.Location;
            }

            _view.PictureBox.Invalidate();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDrawing || _currentShape == null) return;

            _isDrawing = false;

            if (_currentShape is PolygonShape polygon && polygon.Points.Count > 2)
            {
                polygon.Points.Add(polygon.Points[0]);
            }

            _model.AddShape(_currentShape);
            _currentShape = null;
            _view.PictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            _model.DrawAll(e.Graphics);

            if (_isDrawing && _currentShape != null)
            {
                _currentShape.StrokeColor = _model.StrokeColor;
                _currentShape.FillColor = _model.FillColor; 
                _currentShape.StrokeWidth = _model.StrokeWidth;
                _currentShape.LineStyle = _model.LineStyle;

                _currentShape.Draw(e.Graphics);
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (_view.ColorDialog.ShowDialog() == DialogResult.OK)
            {
                _model.StrokeColor = _view.ColorDialog.Color;
                _view.ColorButton.BackColor = _view.ColorDialog.Color;
            }
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            if (_view.FillColorDialog.ShowDialog() == DialogResult.OK)
            {
                _model.FillColor = _view.FillColorDialog.Color;
                _view.FillButton.BackColor = _view.FillColorDialog.Color;
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            _model.Undo();
            _view.PictureBox.Invalidate();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            _model.Redo();
            _view.PictureBox.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _model.Clear();
            _view.PictureBox.Invalidate();
        }
    }
}