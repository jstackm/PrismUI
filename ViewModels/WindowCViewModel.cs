using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class WindowCViewModel : BindableBase, IDialogAware
    {
        public WindowCViewModel()
        {
            ReturnParameterToMainWindow = new DelegateCommand(ReturnParameterToMainWindowExe);
        }
        // プロパティの定型（デフォルト記述）
        private string _title = "Window C";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }      
        
        // Window で入力するテキストボックスのプロパティ
        private string _windowCText = string.Empty;
        public string WindowCText
        {
            get { return _windowCText; }
            set { SetProperty(ref _windowCText, value); }
        }



        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true; 
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        // MainView にパラメータを返すメソッド
        public DelegateCommand ReturnParameterToMainWindow { get; }
        private void ReturnParameterToMainWindowExe()
        {
            // メソッド実行時に Window を閉じる処理
            // DialogParameter 型のパラメータを返す
            var p = new DialogParameters();
            p.Add(nameof(WindowCText), WindowCText);

            // RequestCloseアクションをInvokeする
            // Null かもしれないので ? をつけておくこと
            // buttonResult をつけて返す必要があり，dialogResult.Result で読める
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }
    }
}
