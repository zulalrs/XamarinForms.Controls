﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinForms.Controls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new KayitForm(); // Uygulama ilk açıldığında gözükecek sayfa yani uygulamanın başlama sayfası
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
