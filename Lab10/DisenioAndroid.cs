using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName")]
    public class DisenioAndroid : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DisenioAndroid);
            // Create your application here
            var btnValidate = FindViewById<Button>(Resource.Id.btnValidacion);
            var lblCorreo = FindViewById<EditText>(Resource.Id.txtCorreo);
            var lblPassword = FindViewById<EditText>(Resource.Id.txtClave);
           

            btnValidate.Click += (object sender, System.EventArgs e) =>
            {
                Validate(lblCorreo.Text.Trim(), lblPassword.Text.Trim());
            };


        }




        private async void Validate(String Correo, string Clave)
        {
          
            SALLab10.ServiceClient ServiceClient = new
                SALLab10.ServiceClient();

            string myDevice = Android.Provider
                 .Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab10.ResultInfo Result = await
            ServiceClient.ValidateAsync(Correo, Clave, myDevice);
            // string mensaje = ($"{Result.Status} \n{Result.Fullname}\n {Result.Token}");


            var txtNombre = FindViewById<TextView>(Resource.Id.textNomUsu);
            var txtStatus = FindViewById<TextView>(Resource.Id.textStatus);
            var txtCodigo = FindViewById<TextView>(Resource.Id.textCodigo);
            var configReg = FindViewById<TextView>(Resource.Id.configReg);

            txtNombre.Text = ($"{Result.Fullname}");
            txtStatus.Text = ($"{Result.Status}");
            txtCodigo.Text = ($"{Result.Token}");
            configReg.Text = Resources.Configuration.Locale.ToString() + " " + Resources.Configuration.Locale.DisplayName;



        }
    }
}