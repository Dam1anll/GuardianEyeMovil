﻿using GuardianEyeMovil.Views;
using GuardianEyeMovil.Views.MenuDesplegable;
using GuardianEyeMovil.Views.RecuperarContraseña;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuardianEyeMovil.ViewModels
{
    public class VMInicioSesion : BaseViewModel
    {
        #region VARIABLES
        private string _correo;
        private string _contra;
        #endregion
        #region CONTRUCTOR
        public VMInicioSesion(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Correo
        {
            get { return _correo; }
            set { SetValue(ref _correo, value); }
        }
        public string Contra
        {
            get { return _contra; }
            set { SetValue(ref _contra, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new VRegistro());
        }
        public async Task IrSolicitud()
        {
            await Navigation.PushAsync(new VIngresarCorreo());
        }

        public async Task IrAHome()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            var paginaPrincipal = new NavigationPage(new VPaginaPrincipal());
            NavigationPage.SetHasBackButton(paginaPrincipal, false);
            Application.Current.MainPage = paginaPrincipal;
        }

        #endregion
        #region COMANDOS
        public ICommand IrARegistroCommand => new Command(async () => await IrARegistro());
        public ICommand IrAHomeCommand => new Command(async () => await IrAHome());
        public ICommand IrSolicitudCommand => new Command(async () => await IrSolicitud());

        #endregion
    }
}
