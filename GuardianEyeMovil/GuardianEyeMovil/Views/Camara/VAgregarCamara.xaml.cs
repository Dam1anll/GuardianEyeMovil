using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels.Camara;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Camara
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VAgregarCamara : ContentPage
    {
        public VAgregarCamara()
        {
            InitializeComponent();
            BindingContext = new VMAgregarCamara(Navigation);
        }
    }
}