using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Registros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VRegistros : ContentPage
    {
        public VRegistros()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}