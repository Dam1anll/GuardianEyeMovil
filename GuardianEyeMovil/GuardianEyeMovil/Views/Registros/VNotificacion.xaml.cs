using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.Models;
using GuardianEyeMovil.ViewModels.Registros;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Registros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VNotificacion : ContentPage
    {
        public VNotificacion(MNotificacion mNotificacion)
        {
            InitializeComponent();
            BindingContext = new VMNotificacion(Navigation, mNotificacion);
        }
    }
}