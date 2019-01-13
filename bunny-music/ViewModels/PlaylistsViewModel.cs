using bunny_music.Base;
using bunny_music.Common;
using bunny_music.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;

namespace bunny_music.ViewModels
{
    public class PlaylistsViewModel : ViewModelBaseNotifyPropertyChanged
    {
        private IEnumerable firstSimplePlaylistFiles;
        private IMediaFile selectedPlayListFile;

        public PlaylistsViewModel(Dispatcher dispatcher)
        {
        }

        public async void HandleDropActionAsync(StringCollection fileOrDirDropList)
        {
            if (FileSearchWorker.Instance.CanStartSearch())
            {
                var files = await FileSearchWorker.Instance.StartSearchAsync(fileOrDirDropList);
                this.FirstSimplePlaylistFiles = CollectionViewSource.GetDefaultView(new ObservableCollection<IMediaFile>(files));
            }
        }

        public IEnumerable FirstSimplePlaylistFiles
        {
            get { return this.firstSimplePlaylistFiles; }
            set
            {
                if (Equals(value, this.firstSimplePlaylistFiles))
                {
                    return;
                }
                this.firstSimplePlaylistFiles = value;
                this.OnPropertyChanged(() => this.FirstSimplePlaylistFiles);
            }
        }

        public IMediaFile SelectedPlayListFile
        {
            get { return this.selectedPlayListFile; }
            set
            {
                if (Equals(value, this.selectedPlayListFile))
                {
                    return;
                }
                this.selectedPlayListFile = value;
                this.OnPropertyChanged(() => this.SelectedPlayListFile);
            }
        }
    }
}
