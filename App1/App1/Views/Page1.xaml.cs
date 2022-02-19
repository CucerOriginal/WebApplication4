using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private ViewModel1 ViewModel1 = new ViewModel1();
        public Page1()
        {
            InitializeComponent();
            BindingContext = ViewModel1;
        }
    }
}