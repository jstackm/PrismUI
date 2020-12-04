using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    // Pop Up で表示する画面の ViewModel は，IDialogAware を継承する
    public class WindowAViewModel : BindableBase, IDialogAware
    {
        public WindowAViewModel()
        {
            
        }

        // プロパティの定型（デフォルト記述）
        private string _title = "Window A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        // 画面が閉じれるかどうか
        public bool CanCloseDialog()
        {
            return true;
        }

        // 画面が閉じられた時の処理
        public void OnDialogClosed()
        {
        }

        // 画面が表示されたときの処理
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }


    }
}
