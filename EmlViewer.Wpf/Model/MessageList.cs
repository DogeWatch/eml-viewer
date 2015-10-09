using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using MimeKit;

namespace EmlViewer.Wpf.Model
{
    public class MessageList : ObservableCollection<Message>, IDisposable
    {
        #region Private Fields

        readonly FileSystemWatcher _watcher;
        readonly string _watchPath;

        #endregion

        #region Public Properties

        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set
            {
                _selectedMessage = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedMessage)));
            }
        }

        #endregion



        #region Private Fields

        Message _selectedMessage;

        #endregion

        #region Public Constructors

        public MessageList(string watchPath) : base()
        {
            _watchPath = watchPath;

            Update();

            _watcher = new FileSystemWatcher(_watchPath, "*.eml");
            _watcher.Created += (a, b) =>
            {
                AddFile(b.FullPath, true);
            };

            _watcher.EnableRaisingEvents = true;
        }

        #endregion

        #region Private Methods

        public void Dispose()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }

        void AddFile(string path, bool wait = false)
        {
            if (wait)
            {
                Thread.Sleep(500);
            }

            var msg = MimeMessage.Load(path);

            App.Current.Dispatcher.Invoke(() =>
            {
                Add(new Message
                {
                    Id = msg.MessageId,
                    Sender = msg.From.First().ToString(),
                    Sent = msg.Date.ToLocalTime(),
                    Subject = msg.Subject,
                    Html = msg.HtmlBody
                });
            });
        }

        void Update()
        {
            using (BlockReentrancy())
            {
                Directory
                    .GetFiles(_watchPath)
                    .Where(ent => ent.EndsWith(".eml"))
                    .ForEach(ent => AddFile(ent));
            }
        }

        #endregion
    }
}