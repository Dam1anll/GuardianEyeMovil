using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VRegistro : ContentPage
    {
        public VRegistro()
        {
            InitializeComponent();
            BindingContext = new VMRegistro(Navigation);
        }
    }
}