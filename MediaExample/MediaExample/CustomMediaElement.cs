using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediaExample
{
    [TemplatePart(Name = "PART_Media", Type = typeof(MediaElement))]
    [TemplatePart(Name = "PART_Play", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Pause", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Stop", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Next", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Prev", Type = typeof(Button))]
    public class CustomMediaElement : Control
    {
        public static DependencyProperty PlayCommandProperty;

        public static DependencyProperty NextCommandProperty;

        public static DependencyProperty PrevCommandProperty;

        public static DependencyProperty StopCommandProperty;

        public static DependencyProperty PauseCommandProperty;

        public static DependencyProperty SourceProperty;

        static CustomMediaElement()
        {
            PlayCommandProperty = DependencyProperty.Register("PlayCommand",
                typeof(ICommand),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));

            NextCommandProperty = DependencyProperty.Register("NextCommand",
                typeof(ICommand),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));

            PrevCommandProperty = DependencyProperty.Register("PrevCommand",
                typeof(ICommand),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));

            StopCommandProperty = DependencyProperty.Register("StopCommand",
                typeof(ICommand),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));

            PauseCommandProperty = DependencyProperty.Register("PauseCommand",
                typeof(ICommand),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));
            SourceProperty = DependencyProperty.Register("Source",
                typeof(string),
                typeof(CustomMediaElement),
                new PropertyMetadata((d, e) =>
                {
                }));
        }

        public ICommand PlayCommand
        {
            get { return (ICommand)GetValue(PlayCommandProperty); }
            set { SetValue(PlayCommandProperty, value); }
        }

        public ICommand NextCommand
        {
            get { return (ICommand)GetValue(NextCommandProperty); }
            set { SetValue(NextCommandProperty, value); }
        }

        public ICommand PrevCommand
        {
            get { return (ICommand)GetValue(PrevCommandProperty); }
            set { SetValue(PrevCommandProperty, value); }
        }

        public ICommand StopCommand
        {
            get { return (ICommand)GetValue(StopCommandProperty); }
            set { SetValue(StopCommandProperty, value); }
        }

        public ICommand PauseCommand
        {
            get { return (ICommand)GetValue(PauseCommandProperty); }
            set { SetValue(PauseCommandProperty, value); }
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(PauseCommandProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var playList = GetTemplateChild("PART_PlayList") as ListView;

            var mediaElement = GetTemplateChild("PART_Media") as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.LoadedBehavior = MediaState.Manual;
            }

            // hook event from template
            var playBtn = GetTemplateChild("PART_Play") as Button;
            if (playBtn != null)
            {
                playBtn.Click += (sender, e) =>
                {
                    mediaElement?.Play();
                    if (PlayCommand != null && NextCommand.CanExecute(sender))
                    {
                        PlayCommand.Execute(new { sender, e });
                    }
                };
            }

            var nextBtn = GetTemplateChild("PART_Next") as Button;
            if (nextBtn != null)
            {
                nextBtn.Click += (sender, e) =>
                {
                    if (NextCommand != null && NextCommand.CanExecute(sender))
                    {
                        NextCommand.Execute(new { sender, e });
                    }
                    mediaElement?.Play();
                };
            }

            var prevBtn = GetTemplateChild("PART_Prev") as Button;
            if (prevBtn != null)
            {
                prevBtn.Click += (sender, e) =>
                {
                    if (PrevCommand != null && NextCommand.CanExecute(sender))
                    {
                        PrevCommand.Execute(new { sender, e });
                    }
                    mediaElement?.Play();
                };
            }

            var pauseBtn = GetTemplateChild("PART_Pause") as Button;
            if (pauseBtn != null)
            {
                pauseBtn.Click += (sender, e) =>
                {
                    mediaElement?.Pause();
                    if (PauseCommand != null && NextCommand.CanExecute(sender))
                    {
                        PauseCommand.Execute(new { sender, e });
                    }
                };
            }

            var stopBtn = GetTemplateChild("PART_Stop") as Button;
            if (stopBtn != null)
            {
                stopBtn.Click += (sender, e) =>
                {
                    mediaElement?.Stop();
                    if (PauseCommand != null && NextCommand.CanExecute(sender))
                    {
                        PauseCommand.Execute(new { sender, e });
                    }
                };
            }
        }
    }
}