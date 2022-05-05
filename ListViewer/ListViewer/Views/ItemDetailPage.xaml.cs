using ListViewer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ListViewer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}