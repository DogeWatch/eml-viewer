using System.Windows;
using System.Windows.Controls;

namespace EmlViewer.Wpf
{
    public static class WebBrowserUtility
    {
        #region Public Fields

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(WebBrowserUtility), new FrameworkPropertyMetadata(OnHtmlChanged));

        #endregion

        #region Public Methods

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser d)
        {
            return (string)d.GetValue(HtmlProperty);
        }

        public static void SetHtml(WebBrowser d, string value)
        {
            d.SetValue(HtmlProperty, value);
        }

        #endregion

        #region Private Methods

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string ?? "&nbsp;");
            }
        }

        #endregion
    }
}