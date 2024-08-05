using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FFmpegView.Bass;
using FFmpegView.NAudio;

namespace FFmpegView.AvaloniaDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Width = 800;
            Height = 600;

            //var audioStreamDecoder = new BassAudioStreamDecoder();
            //audioStreamDecoder.Headers = new Dictionary<string, string> { { "User-Agent", "ffmpeg_demo" } };
            var ffView = new FFmpegView();
            this.Content = ffView;
            //ffView.SetAudioHandler(audioStreamDecoder);
            //ffView.Play("C:\\Users\\Sekoree\\Videos\\Marine Dreamin' (WIP).mp4");
            var channel = ManagedBass.Bass.CreateStream("G:\\IMAS_Content\\MKVs\\THE IDOLM@STER MOVIE\\THE IDOLM@STER MOVIE.flac");
            ffView.Play("G:\\IMAS_Content\\MKVs\\THE IDOLM@STER MOVIE\\THE IDOLM@STER MOVIE.mkv");
            ManagedBass.Bass.ChannelSetPosition(channel, ManagedBass.Bass.ChannelSeconds2Bytes(channel, 6600));

            ffView.SeekTo(6600);
            ManagedBass.Bass.ChannelPlay(channel);
        }
    }
}