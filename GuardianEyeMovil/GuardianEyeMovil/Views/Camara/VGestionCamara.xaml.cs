using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels.Camara;
using GuardianEyeMovil.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Camara
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VGestionCamara : ContentPage
    {
        public VGestionCamara(MCamara mCamara)
        {
            InitializeComponent();
            BindingContext = new VMGestionCamara(Navigation, mCamara);
        }
    }
}