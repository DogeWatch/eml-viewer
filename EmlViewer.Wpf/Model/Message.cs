using System;
using System.ComponentModel;

namespace EmlViewer.Wpf.Model
{
    public class Message : INotifyPropertyChanged
    {
        #region Private Fields

        string _html;
        string _sender;
        DateTimeOffset _sent;
        string _subject;

        #endregion

        #region Public Properties

        public string Html
        {
            get { return _html; }
            set { _html = value; OnPropertyChanged(nameof(Html)); }
        }

        public string Id { get; set; }

        public string Sender
        {
            get { return _sender; }
            set { _sender = value; OnPropertyChanged(nameof(Sender)); }
        }

        public DateTimeOffset Sent
        {
            get { return _sent; }
            set { _sent = value; OnPropertyChanged(nameof(Sent)); }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; OnPropertyChanged(nameof(Subject)); }
        }

        #endregion

        #region Private Methods

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}