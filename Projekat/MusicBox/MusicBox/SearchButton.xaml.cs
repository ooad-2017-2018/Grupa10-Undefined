using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.ComponentModel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MusicBox
{
    public partial class SearchButton : UserControl
    {
        public static readonly DependencyProperty SearchTextProperty=
  DependencyProperty.Register("SearchText", typeof(string), typeof(SearchButton), new PropertyMetadata(null));

        public static DependencyProperty CommandOneProperty = DependencyProperty.Register("CommandOne", typeof(ICommand), typeof(SearchButton), new PropertyMetadata(null));
        
        public SearchButton()
        {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set
            {
                SetValue(SearchTextProperty, value);
            }
        }

        public ICommand CommandOne
        {
            get
            {
                return (ICommand)GetValue(CommandOneProperty);
            }
            set
            {
                SetValue(CommandOneProperty, value);
            }
        }       
    }
}
