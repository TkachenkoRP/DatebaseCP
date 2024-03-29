﻿using System.Windows;
using DatebaseCP.Command;
using DatebaseCP.Models;
using DatebaseCP.ViewModel.Base;

namespace DatebaseCP.ViewModel
{
    class ListTitleEditWindowViewModel : BaseViewModel
    {
        private string _title;
        private TeacherTitle _teacherTitle;
        private string _name;

        public ListTitleEditWindowViewModel(TeacherTitle teacherTitle)
        {
            _title = "Добавление звания";
            _teacherTitle = teacherTitle;
            _name = teacherTitle.Name;
            if (_name != null)
            {
                Title = "Редактирование должности";
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        #region Command

        #region SaveCommand

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new RelayCommand(obj =>
                {
                    _teacherTitle.Name = Name;

                    Window window = obj as Window;
                    window.DialogResult = true;
                    window.Close();
                }, obj => !string.IsNullOrEmpty(Name));
            }
        }

        #endregion

        #endregion
    }
}
