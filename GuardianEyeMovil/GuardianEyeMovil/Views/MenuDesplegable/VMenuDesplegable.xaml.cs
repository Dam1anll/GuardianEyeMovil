using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.MenuDesplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VMenuDesplegable : ContentPage
    {
        public VMenuDesplegable()
        {
            InitializeComponent();
            BindingContext = new VMMenuDesplegable(Navigation);
        }
    }
}