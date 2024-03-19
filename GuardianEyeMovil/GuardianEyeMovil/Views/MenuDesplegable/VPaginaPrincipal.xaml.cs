using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardianEyeMovil.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.MenuDesplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    #pragma warning disable CS0618 // El tipo o el miembro están obsoletos
    public partial class VPaginaPrincipal : MasterDetailPage
    #pragma warning restore CS0618 // El tipo o el miembro están obsoletos
    {
        public VPaginaPrincipal()
        {
            InitializeComponent();
            this.Master = new VMenuDesplegable();
            this.Detail = new NavigationPage(new VHome());
            App.MasterDet = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}