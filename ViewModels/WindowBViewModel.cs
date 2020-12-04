using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class WindowBViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters _parameters;

        public WindowBViewModel()
        {
            WindowBParameter1 = new DelegateCommand(WindowBParameter1Exe);
            WindowBParameter2 = new DelegateCommand(WindowBParameter2Exe);
            WindowBParameter3 = new DelegateCommand(WindowBParameter3Exe);
        }
        // プロパティの定型（デフォルト記述）
        private string _title = "Window B";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // Window に表示するテキストのプロパティ
        private string _windowBText = string.Empty;
        public string WindowBText
        {
            get { return _windowBText; }
            set { SetProperty(ref _windowBText, value); }
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
            // navibationContext に NavigationParamter型の値が渡される
            // value は object 型なので，GetValue<> で型指定して取り出す
            // ひとまず．TextBlock の Content とバインドされている ViewBText プロパティを
            // key として格納されている文字列を TextBlock に表示してみる
            WindowBText = parameters.GetValue<string>(nameof(WindowBText));

            // 受け取ったパラメータをフィールドに代入して他のメソッドで使えるようにする
            _parameters = parameters;
        }

        // ボタンによるメソッドの実行
        public DelegateCommand WindowBParameter1 { get; }
        public DelegateCommand WindowBParameter2 { get; }
        public DelegateCommand WindowBParameter3 { get; }
        private void WindowBParameter1Exe()
        {
            WindowBText = _parameters.GetValue<string>("testKey1");
        }
        private void WindowBParameter2Exe()
        {
            WindowBText = _parameters.GetValue<string>("testKey2");
        }
        private void WindowBParameter3Exe()
        {
            WindowBText = _parameters.GetValue<DateTime>("testKey3").ToString();
        }


    }
}
