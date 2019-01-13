using bunny_music.Common;
using bunny_music.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bunny_music.Views
{
    /// <summary>
    /// Interaction logic for PlaylistsView.xaml
    /// </summary>
    public partial class PlaylistsView : UserControl
    {
        public PlaylistsView()
        {
            InitializeComponent();
            this.AllowDrop = true;

            this.DataContextChanged += (s, ea) => {
                var vm = ea.NewValue as PlaylistsViewModel;
                if (vm != null)
                {
                    // Override this to allow drop functionality.
                    this.PreviewDragOver += (sender, e) => {
                        e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) && FileSearchWorker.Instance.CanStartSearch() ? DragDropEffects.Copy : DragDropEffects.None;
                        e.Handled = true;
                    };

                    this.PreviewDrop += (sender, e) => {
                        if (e.Data.GetDataPresent(DataFormats.FileDrop))
                        {
                            // Get data object
                            var dataObject = e.Data as DataObject;
                            if (dataObject != null && dataObject.ContainsFileDropList())
                            {
                                vm.HandleDropActionAsync(dataObject.GetFileDropList());
                            }
                        }
                    };
                }
            };
        }
    }
}
