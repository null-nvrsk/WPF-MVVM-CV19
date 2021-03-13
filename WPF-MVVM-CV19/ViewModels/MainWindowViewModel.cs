using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Controls;
using System.Xaml;
using WPF_MVVM_CV19.ViewModels.Base;

namespace WPF_MVVM_CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Window title

        private string _Title = "Анализ статистики CV19";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status : string статус программы

        private string _Status = "Готов!";

        public string Status { 
            get => _Status; 
            set => Set(ref _Status, value);
        }

        #endregion


    }
}
