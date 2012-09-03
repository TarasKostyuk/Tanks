using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Tanks.Contracts;
using Tanks.LevelDesigner.Model;

namespace Tanks.LevelDesigner.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private KeyValuePair<MapItemType, string> _selectedMapItemType;
        private ICommand _saveCommand;
        private ICommand _openCommand;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Map = new Map();
        }
    
        public static Dictionary<MapItemType, string> MapItemTypes
        {
            get
            {
                return new Dictionary<MapItemType, string>
                           {
                               {MapItemType.Brick, "images/Brick.png"},
                               {MapItemType.Concrete, "images/Concrete.png"},
                               {MapItemType.Head, "images/Head.png"},
                               {MapItemType.Wood, "images/Tree.png"},
                               {MapItemType.Water, "images/Water.png"}
                           };
            }
        }

        public KeyValuePair<MapItemType, string> SelectedMapItem
        {
            get { return _selectedMapItemType; }
            set
            {
                _selectedMapItemType = value;
                RaisePropertyChanged(() => SelectedMapItem);
            }
        }

        public Map Map { get; private set; }

        public void AddMapItem(int posX, int posY)
        {
            if(SelectedMapItem.Key == MapItemType.Empty)
            {
                return;
            }

            RemoveMapItem(posX, posY, Map.MapItemSize[SelectedMapItem.Key]);

            Map.MapItems.Add(new MapItem
                                 {
                                     X = posX,
                                     Y = posY,
                                     ItemType = SelectedMapItem.Key
                                 });
            RaisePropertyChanged(() => Map);
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(SaveCommandExecute)); }
        }

        private void SaveCommandExecute()
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "XML files|*.xml"
            };
            if (saveFile.ShowDialog() == true)
            {
                bool minimize = MessageBox.Show("Minimize output file?", string.Empty, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                DataContractSerializer serializer = new DataContractSerializer(typeof(Map));
                var settings = new XmlWriterSettings { Indent = !minimize };

                using (var w = XmlWriter.Create(saveFile.FileName, settings))
                    serializer.WriteObject(w, Map);
            }
        }

        public ICommand OpenCommand
        {
            get { return _openCommand ?? (_openCommand = new RelayCommand(OpenCommandExecute)); }
        }

        private void OpenCommandExecute()
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "XML files|*.xml"
            };
            if (openFile.ShowDialog() == true)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Map));

                using(Stream s = File.OpenRead(openFile.FileName))
                {
                    Map = (Map) serializer.ReadObject(s);
                }

                RaisePropertyChanged(() => Map);
            }
        }

        public void RemoveMapItem(int x, int y, int size = 1)
        {
            Rectangle r = new Rectangle
                              {
                                  X = x,
                                  Y = y,
                                  Size = size
                              };
            Map.MapItems.RemoveAll(item => new Rectangle {X = item.X, Y = item.Y, Size = Map.MapItemSize[item.ItemType]}.Intersect(r));
            RaisePropertyChanged(() => Map);
        }
    }
}