using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xaml;
using WPF_MVVM_CV19.Infrastructure.Commands;
using WPF_MVVM_CV19.Models;
using WPF_MVVM_CV19.Models.Decanat;
using WPF_MVVM_CV19.ViewModels.Base;

namespace WPF_MVVM_CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        //---------------------------------------------------------------------------------

        public ObservableCollection<Group> Groups { get; }

        #region SelectedPageIndex : int - Номер выбранно вкладки

        private int _SelectedPageIndex;

        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        #endregion

        #region TestDataPoints : IEnumerable<DataPoint>

        /// <summary>Тестовый набор данных для визуализации графиков </summary>
        private IEnumerable<DataPoint> _testDataPoints;

        /// <summary>Тестовый набор данных для визуализации графиков </summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _testDataPoints;
            set => Set(ref _testDataPoints, value);
        }


        #endregion


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

        //---------------------------------------------------------------------------------

        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region ChangeTabIndexCommand
        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        #endregion

        //---------------------------------------------------------------------------------

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;

            int studentIndex = 1;
            var students = Enumerable.Range(1, 30).Select(i => new Student
            {
                Name = $"Имя {studentIndex}", 
                Surname = $"Фамилия {studentIndex}", 
                Patronymic = $"Отчество {studentIndex++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);


        }

        //---------------------------------------------------------------------------------
    }
}
