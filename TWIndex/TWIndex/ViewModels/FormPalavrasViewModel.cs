﻿using MVVMCoffee.ViewModels;
using System.Collections.Generic;
using TWIndex.Models;
using Xamarin.Forms;

namespace TWIndex.ViewModels
{
    public class FormPalavrasViewModel : BaseViewModel
    {
        public Command ValidarCommand { get; private set; }
        public int QuantidadePalavras { get; set; }

        private string _palavra1;

        private string _palavra2;

        private string _palavra3;

        private string _palavra4;

        private string _palavra5;

       
        public string Palavra1
        {
            get { return _palavra1; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _palavra1, value);
                    ValidarCommand.ChangeCanExecute();
                }
               
            }
        }

        public string Palavra2
        {
            get { return _palavra2; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _palavra2, value);
                    ValidarCommand.ChangeCanExecute();
                }
            }
        }

        public string Palavra3
        {
            get { return _palavra3; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _palavra3, value);
                    ValidarCommand.ChangeCanExecute();
                }
            }
        }

        public string Palavra4
        {
            get { return _palavra4; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _palavra4, value);
                    ValidarCommand.ChangeCanExecute();
                }
            }
        }

        public string Palavra5
        {
            get { return _palavra5; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _palavra5, value);
                    ValidarCommand.ChangeCanExecute();
                }
            }
        }

       
        public FormPalavrasViewModel(int quantidadePalavras)
        {
            QuantidadePalavras = quantidadePalavras;

            MessagingCenter.Send(this, "QuantidadePalavras", quantidadePalavras);

            
        
            var listaAuxiliar = new List<string>();
            var listaPalavras = new List<string>();

            ValidarCommand = new Command(
                execute: () =>
            {


                listaAuxiliar.Add(_palavra1);
                listaAuxiliar.Add(_palavra2);
                listaAuxiliar.Add(_palavra3);
                listaAuxiliar.Add(_palavra4);
                listaAuxiliar.Add(_palavra5);
              

                for (int i = 0; i < quantidadePalavras; i++)
                {
                    if (!string.IsNullOrEmpty(listaAuxiliar[i]))
                    {
                        listaPalavras.Add(listaAuxiliar[i]);
                    }
                }

                ExecutePushAsyncResultadosCommand(listaPalavras);


            },

            canExecute: () =>
            {
                int caseSwitch = quantidadePalavras;

                bool validador = false;

                switch (caseSwitch)
                {
                    case 1:
                        validador = !string.IsNullOrEmpty(_palavra1);
                        break;
                    case 2:
                          validador = !string.IsNullOrEmpty(_palavra1) && !string.IsNullOrEmpty(_palavra2);
                        break;
                    case 3:
                          validador = !string.IsNullOrEmpty(_palavra1) && !string.IsNullOrEmpty(_palavra2) && !string.IsNullOrEmpty(_palavra3);
                        break;
                    case 4:
                       validador = !string.IsNullOrEmpty(_palavra1) && !string.IsNullOrEmpty(_palavra2) && !string.IsNullOrEmpty(_palavra3) && !string.IsNullOrEmpty(_palavra4);
                        break;
                    case 5:
                        validador = !string.IsNullOrEmpty(_palavra1) && !string.IsNullOrEmpty(_palavra2) && !string.IsNullOrEmpty(_palavra3) && !string.IsNullOrEmpty(_palavra4) && !string.IsNullOrEmpty(_palavra5);
                        break;
                  
                         
                }
                return validador;
            });

        }


        private async void ExecutePushAsyncResultadosCommand(List<string> palavras)
        {

            await Navigation.PushAsync<ResultadoViewModel>(false, palavras);

        }


    }
}
