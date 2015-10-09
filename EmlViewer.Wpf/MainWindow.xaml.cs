using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using EmlViewer.Wpf.Model;

namespace EmlViewer.Wpf
{
    public partial class MainWindow : Window
    {
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();

            lvMessages.ItemsSource = Messages;

            var view = CollectionViewSource.GetDefaultView(lvMessages.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Sent", ListSortDirection.Descending));
        }

        #endregion

        #region Protected Properties

        protected MessageList Messages { get; } = new MessageList(Environment.GetCommandLineArgs().Skip(1).First());

        #endregion
    }
}