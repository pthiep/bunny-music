﻿using System;
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
using bunny_music.Common;
using bunny_music.ViewModels;
using MahApps.Metro.Controls;

namespace bunny_music
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            var vm = new MainWindowViewModel(this.Dispatcher);
            this.DataContext = vm;
            InitializeComponent();
            //this.Closed += (sender, e) => PlayerEngine.Instance.CleanUp();
        }
    }
}
