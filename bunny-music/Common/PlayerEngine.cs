using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using bunny_music.Interfaces;
using System.Windows.Threading;

namespace bunny_music.Common
{
    public class PlayerEngine
    {
        private static PlayerEngine instance;
        private DispatcherTimer timer;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public static PlayerEngine Instance
        {
            get { return instance ?? (instance = new PlayerEngine()); }
        }

        public bool Configure(Dispatcher dispatcher)
        {
            return false;
        }

        private void PlayTimerCallback(object sender, EventArgs e)
        {

        }

        public void Play(IMediaFile file)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                //outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@"G:\24H-LyLy-Magazine.mp3");
                
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        public void CleanUp()
        {

        }


    }
}
