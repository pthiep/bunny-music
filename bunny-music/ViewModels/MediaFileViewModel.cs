using bunny_music.Base;
using bunny_music.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunny_music.ViewModels
{
    public class MediaFileViewModel : ViewModelBaseNotifyPropertyChanged, IMediaFile
    {
        private string fullFileName;
        private string fileName;
        private string title;

        public MediaFileViewModel(string fileName)
        {
            this.FullFileName = fileName;
            this.FileName = Path.GetFileName(fileName);
        }

        public static IMediaFile GetMediaFileViewModel(string fileName)
        {
            try
            {
                using (TagLib.File file = TagLib.File.Create(fileName))
                {
                    var mf = new MediaFileViewModel(fileName);

                    //mf.Grouping = file.Tag.Grouping;
                    mf.Title = file.Tag.Title;
                    //mf.TitleSort = file.Tag.TitleSort;
                    //mf.AlbumArtists = file.Tag.AlbumArtists;
                    //mf.AlbumArtistsSort = file.Tag.AlbumArtistsSort;
                    //mf.Performers = file.Tag.Performers;
                    //mf.PerformersSort = file.Tag.PerformersSort;
                    //mf.Composers = file.Tag.Composers;
                    //mf.ComposersSort = file.Tag.ComposersSort;
                    //mf.Conductor = file.Tag.Conductor;
                    //mf.Album = file.Tag.Album;
                    //mf.AlbumSort = file.Tag.AlbumSort;
                    //mf.Comment = file.Tag.Comment;
                    //mf.Copyright = file.Tag.Copyright;
                    //mf.Genres = file.Tag.Genres;
                    //mf.BPM = file.Tag.BeatsPerMinute;
                    //mf.Year = file.Tag.Year;
                    //mf.Track = file.Tag.Track;
                    //mf.TrackCount = file.Tag.TrackCount;
                    //mf.Disc = file.Tag.Disc;
                    //mf.DiscCount = file.Tag.DiscCount;

                    //mf.FirstAlbumArtist = file.Tag.FirstAlbumArtist;
                    //mf.FirstAlbumArtistSort = file.Tag.FirstAlbumArtistSort;
                    //mf.FirstComposer = file.Tag.FirstComposer;
                    //mf.FirstComposerSort = file.Tag.FirstComposerSort;
                    //mf.FirstGenre = file.Tag.FirstGenre;
                    //mf.FirstPerformer = file.Tag.FirstPerformer;
                    //mf.FirstPerformerSort = file.Tag.FirstPerformerSort;

                    //    if (file.Properties.MediaTypes != TagLib.MediaTypes.None)
                    //    {
                    //        mf.Duration = file.Properties.Duration;
                    //    }

                    return mf;
                }
            }
            catch (Exception e)
            {
                var em = e.Message;
                Console.WriteLine("Fail to parse file: {0}, {1}", fileName, e.ToString());
                return null;
            }
        }

        public string FullFileName
        {
            get { return this.fullFileName; }
            set
            {
                if (Equals(value, this.fullFileName))
                {
                    return;
                }
                this.fullFileName = value;
                this.OnPropertyChanged(() => this.FullFileName);
            }
        }

        public string FileName
        {
            get { return this.fileName; }
            set
            {
                if (Equals(value, this.fileName))
                {
                    return;
                }
                this.fileName = value;
                this.OnPropertyChanged(() => this.FileName);
            }
        }

        protected string Title
        {
            get { return this.title; }
            set
            {
                if (Equals(value, this.title))
                {
                    return;
                }
                this.title = value;
                this.OnPropertyChanged(() => this.Title);
            }
        }
    }
}
