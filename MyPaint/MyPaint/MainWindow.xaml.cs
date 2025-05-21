using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        public InformationForDraw informationForDraw;
        public ShowTools showTools;
        public Undo_Redo undoRedo;
        public SelectedTool selectedTool;
        public SelectItemMethods selectItemMethods;
        public DefaultTools defaultTools;

        public List<ShapeAllKinds> ShapesOnCanvas = new List<ShapeAllKinds>();

        public MainWindow()
        {
            InitializeComponent();

            informationForDraw = new InformationForDraw();

            InformationForDraw.CanvasForDrawing = canvasForDrawing;
            InformationForDraw.PopupThicknesses = popupThicknesses;
            InformationForDraw.UniColors = uniColors;
            InformationForDraw.UniShapes = uniShapes;
            InformationForDraw.ShapesOnCanvas = ShapesOnCanvas;

            defaultTools = new DefaultTools();

            selectedTool = new SelectedTool();

            selectItemMethods = new SelectItemMethods()
            {
                informationForDraw = informationForDraw,
                selectedTool = selectedTool,
                defaultTools = defaultTools
            };

            undoRedo = new Undo_Redo()
            {
                informationForDraw = this.informationForDraw
            };

            showTools = new ShowTools()
            {
                informationForDraw = this.informationForDraw,
                selectItemMethods = selectItemMethods,
                selectedTool = selectedTool,
                defaultTools = defaultTools
            };

            showTools.AddColorsToTools();
            showTools.AddThicknessesToTools();
            showTools.AddShapesToTools();

            canvasForDrawing.MouseDown += CanvasForDrawing_OnMouseDown;
            canvasForDrawing.MouseMove += CanvasForDrawing_OnMouseMove;
            canvasForDrawing.MouseUp += CanvasForDrawing_OnMouseUp;

            menuOpenFile.Click += MenuOpenFile_OpenFile;
            menuSaveFile.Click += MenuSaveFile_SaveFile;
            menuAddPlugin.Click += MenuAddPlugin_AddPlugin; 
        }

        public void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            InformationForDraw.IsPressed = true;
            InformationForDraw.ShiftWasPressed = false;
            informationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            informationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        public void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InformationForDraw.IsPressed)
            {
                if (sender is Canvas canvas)
                {
                    informationForDraw.xExit = e.GetPosition(canvas).X;
                    informationForDraw.yExit = e.GetPosition(canvas).Y;

                    if (!InformationForDraw.isDrawed)
                    {
                        InformationForDraw.isDrawed = true;
                        var shape = (ShapeAllKinds)Activator.CreateInstance(InformationForDraw.CurrShapeType);
                        shape.Draw(informationForDraw);
                        ShapesOnCanvas.Add(shape);
                        InformationForDraw.CanvasForDrawing.Children.Add(ShapesOnCanvas[^1].FigurePtr);
                    }

                    ShapesOnCanvas[^1].UpdateData(informationForDraw);
                }
            }
        }

        public void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.isDrawed = false;
            InformationForDraw.IsPressed = false;
            informationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            informationForDraw.yExit = e.GetPosition(sender as Canvas).Y;

            InformationForDraw.ShiftWasPressed = false;

            undoRedo.ShapeUndoStack.Clear();
            (sender as Canvas).ReleaseMouseCapture();
        }

        private void MenuOpenFile_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _ = new OpenFileDialog()
            {
                Filter = "graph edit files (*.json)|*.json"
            };

            if (_.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(_.FileName)) return;

                InformationForDraw.CanvasForDrawing?.Children?.Clear();
                string shapesInJson = File.ReadAllText(_.FileName);

                List<ShapeAllKinds> temp;
                try
                {
                    temp = JsonConvert.DeserializeObject<List<ShapeAllKinds>>(shapesInJson,
                        new JsonSerializerSettings()
                        {
                            TypeNameHandling = TypeNameHandling.All
                        });
                }
                catch (JsonException exception)
                {
                    MessageBox.Show($"Ошибка открытия файла: неверный формат файла\n{exception.Message}",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool hasUnsupportedShapes = false;
                StringBuilder unsupportedShapes = new StringBuilder();

                foreach (var shape in temp)
                {
                    if (shape == null)
                    {
                        hasUnsupportedShapes = true;
                        unsupportedShapes.AppendLine("Неизвестная фигура (null)");
                        continue;
                    }

                    Type shapeType = shape.GetType();
                    if (!showTools.defaultTools.ShapesTools.Contains(shapeType))
                    {
                        hasUnsupportedShapes = true;
                        unsupportedShapes.AppendLine(shapeType.Name);
                    }
                }

                if (hasUnsupportedShapes)
                {
                    MessageBox.Show($"Файл содержит следующие неподдерживаемые фигуры:\n{unsupportedShapes}\n" +
                                  "Эти фигуры не будут отображены.",
                                  "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);

                    temp = temp.Where(shape => shape != null &&
                           showTools.defaultTools.ShapesTools.Contains(shape.GetType())).ToList();
                }

                ShapesOnCanvas.Clear();
                ShapesOnCanvas = temp;
                InformationForDraw.ShapesOnCanvas = ShapesOnCanvas;

                Console.WriteLine(JsonConvert.SerializeObject(ShapesOnCanvas, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }));

                foreach (var elem in ShapesOnCanvas)
                    elem.Draw(InformationForDraw.CanvasForDrawing);
            }
        }

        private void MenuSaveFile_SaveFile(object sender, RoutedEventArgs e)
        {
            var _ = new SaveFileDialog()
            {
                Title = "Сохранить как",
                FileName = "",
                DefaultExt = ".json",
                Filter = "Graph editor (*.json)|*.json"
            };

            if (_.ShowDialog() == true)
            {
                string shapesJson = JsonConvert.SerializeObject(ShapesOnCanvas, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                Console.WriteLine(shapesJson);
                File.WriteAllText(_.FileName, shapesJson);
            }
        }

        private void MenuAddPlugin_AddPlugin(object sender, RoutedEventArgs e)
        {
            var _ = new OpenFileDialog()
            {
                Filter = "graph edit plugins (*.dll)|*.dll"
            };

            if (_.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(_.FileName)) return;

                try
                {
                    Assembly plugin = Assembly.LoadFrom(_.FileName);

                    foreach (var type in plugin.GetTypes())
                    {
                        if (typeof(ShapeAllKinds).IsAssignableFrom(type) && !type.IsAbstract)
                        {
                            if (showTools.defaultTools.ShapesTools.Contains(type))
                            {
                                MessageBox.Show("Этот плагин уже добавлен в программу", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            showTools.defaultTools.ShapesTools.Add(type);
                            showTools.AddOneShapeToTools(showTools.defaultTools.ShapesTools.Count - 1);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Ошибка загрузки плагина: {exception.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}