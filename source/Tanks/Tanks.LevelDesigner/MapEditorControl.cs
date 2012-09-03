using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tanks.Contracts;
using Tanks.LevelDesigner.ViewModel;
using Rect = System.Windows.Shapes.Rectangle;

namespace Tanks.LevelDesigner
{
    public class MapEditorControl : Canvas
    {
        private double _cellHeight;
        double _cellWidth;
        
        public MapEditorControl()
        {
            SizeChanged += GameScreenControlSizeChanged;
            MouseDown += GameScreenControlMouseDown;
            MouseMove += MapEditorControlMouseMove;
        }

        void MapEditorControlMouseMove(object sender, MouseEventArgs e)
        {
            MouseButton? button = null;
            if (e.LeftButton == MouseButtonState.Pressed)
                button = MouseButton.Left;
            else if (e.RightButton == MouseButtonState.Pressed)
                button = MouseButton.Right;
            if (button != null)
                SendMouseNotification(e.GetPosition(this), button.Value);
        }

        private void SendMouseNotification(Point position, MouseButton button)
        {
            double x = position.X/_cellHeight;
            double y = position.Y/_cellHeight;

            if(x<0 || y<0)
            {
                return;
            }

            OnMapClicked(new MapClickedEventArgs
                             {
                                 X = (int) Math.Ceiling(x),
                                 Y = (int) Math.Ceiling(y),
                                 MouseButton = button
                             });
        }

        public Map Map
        {
            get { return (Map)GetValue(MapProperty); }
            set { SetValue(MapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapProperty =
            DependencyProperty.Register("Map", typeof(Map), typeof(MapEditorControl), new UIPropertyMetadata(null));
        
        public event EventHandler<MapClickedEventArgs> MapClicked;

        private void OnMapClicked(MapClickedEventArgs e)
        {
            EventHandler<MapClickedEventArgs> handler = MapClicked;
            if (handler != null) handler(this, e);
        }

        void GameScreenControlMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(this);
            SendMouseNotification(position, e.ChangedButton);
        }

        void GameScreenControlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _cellHeight = RenderSize.Height / 14;
            _cellWidth = RenderSize.Width / 13;
            Draw(e.NewSize);
        }

        public void Redraw()
        {
            Draw(RenderSize);
        }

        private void Draw(Size size)
        {
            Children.Clear();
            CreateGrid(size);
            CreateMap(size);
        }

        private void CreateMap(Size size)
        {
            int x = 0;
            foreach (var mapItem in Map.MapItems)
            {
                Image image = new Image
                                  {
                                      Source = new BitmapImage(new Uri(MainViewModel.MapItemTypes[mapItem.ItemType], UriKind.Relative)),
                                      Width = _cellWidth * Map.MapItemSize[mapItem.ItemType],
                                      Height = _cellHeight * Map.MapItemSize[mapItem.ItemType]
                                  };
                Canvas.SetLeft(image, _cellWidth * (mapItem.X - 1));
                Canvas.SetTop(image, _cellHeight * (mapItem.Y - 1));

                Children.Add(image);

                x += 10;
            }   
        }

        private void CreateGrid(Size size)
        {
            Children.Add(new Rect
                             {
                                 Fill = Brushes.White,
                                 Width = 10000,
                                 Height = 10000
                             });

            for (int i = 0; i <= 12; i++)
            {
                Line line = new Line
                                {
                                    Stroke = new SolidColorBrush(Colors.LightGray),
                                    StrokeThickness = 1,
                                    X1 = _cellWidth*i,
                                    X2 = _cellWidth*i,
                                    Y1 = 0,
                                    Y2 = size.Height
                                };

                Children.Add(line);
            }


            for (int i = 0; i <= 13; i++)
            {
                Line line = new Line
                                {
                                    Stroke = new SolidColorBrush(Colors.Gray),
                                    StrokeThickness = 1,
                                    X1 = 0,
                                    X2 = RenderSize.Width,
                                    Y1 = _cellHeight*i,
                                    Y2 = _cellHeight*i
                                };

                Children.Add(line);
            }
        }
    }
}