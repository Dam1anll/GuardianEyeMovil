using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels.Trasmision;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Trasmision
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTrasmisionCamara : ContentPage
    {
        public VTrasmisionCamara()
        {
            InitializeComponent();
            BindingContext = new VMTrasmisionCamara(Navigation);
        }
    }
}