﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianEyeMovil.Views.Trasmision
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTrasmision : ContentPage
    {
        public VTrasmision()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}