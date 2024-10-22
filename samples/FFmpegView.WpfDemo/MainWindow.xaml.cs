﻿using FFmpegView.NAudio;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FFmpegView.WpfDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var audioStreamDecoder= new NAudioStreamDecoder();
            audioStreamDecoder.Headers = new Dictionary<string, string> { { "User-Agent", "ffmpeg_demo" } };
            playerView.SetAudioHandler(audioStreamDecoder);
            playerVView.SetAudioHandler(new NAudioStreamDecoder());
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is TabItem item)
            {
                switch (item.Header.ToString())
                {
                    case "FFmpegView":
                        playerVView.Pause();
                        playerView.Play("http://vfx.mtime.cn/Video/2019/03/18/mp4/190318231014076505.mp4");
                        break;
                    case "FFmpegVisualView":
                        playerView.Pause();
                        playerVView.Play("http://vfx.mtime.cn/Video/2019/03/18/mp4/190318231014076505.mp4");
                        break;
                }
            }
        }
    }
}