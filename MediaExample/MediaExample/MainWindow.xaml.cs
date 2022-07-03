using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MediaExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string SourceMedia { get; set; }

        public MainWindow()
        {
            SourceMedia = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
            InitializeComponent();

            PlayCommand = new RelayCommand(PlayCommandInvoke);
            ListVideos = new ObservableCollection<ItemSong>
            {
                new ItemSong
                {
                    Image = @"Images/1.jpg",
                    LinkSong = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                },
                new ItemSong
                {
                    Image = @"Images/2.jpg",
                    LinkSong = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
                },
                new ItemSong
                {
                    Image = @"Images/3.jpg",
                    LinkSong = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4"
                }
            };
        }

        public ObservableCollection<ItemSong> ListVideos { get; set; }

        public ICommand PlayCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void PlayCommandInvoke(object sender)
        {
            //var wd = new Window();
            //wd.Title = "This is play commnad call";
            //var result = wd.ShowDialog();
        }
    }
}