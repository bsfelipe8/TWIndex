﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWIndex.Models;
using TWIndex.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TWIndex.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicialDetail : ContentPage
    {
        public InicialDetail()
        {
            InitializeComponent();
            this.BindingContext = new InicialDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Trabalho>(this, "TrabalhoSelecionado",
            (msg) =>
            {
                Navigation.PushAsync(new InfoTrabalho());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Trabalho>(this, "TrabalhoSelecionado");
        }
    }
}