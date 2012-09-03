using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tanks.Contracts;
using Tanks.LevelDesigner.ViewModel;

namespace Tanks.LevelDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MapEditor.Redraw();
        }

        public MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        private void MapClickedHandler(object sender, MapClickedEventArgs e)
        {
            if (e.MouseButton == MouseButton.Left)
                ViewModel.AddMapItem(e.X, e.Y);
            else if (e.MouseButton == MouseButton.Right)
                ViewModel.RemoveMapItem(e.X, e.Y);
        }
    }
}
