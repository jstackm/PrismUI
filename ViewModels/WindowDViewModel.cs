using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class WindowDViewModel : BindableBase, IDialogAware
    {
        private IDialogService _dialogService;
        public WindowDViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            DisplayWindowB = new DelegateCommand(DisplayWindowBExe);
            DisplayWindowC = new DelegateCommand(DisplayWindowCExe);
        }
        // プロパティの定型（デフォルト記述）
        private string _title = "Window C";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _windowDText = string.Empty;
        public string WindowDText
        {
            get { return _windowDText; }
            set { SetProperty(ref _windowDText, value); }
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

        // Pop-Up の孫ウィンドウを表示する
        public DelegateCommand DisplayWindowB { get; }
        public DelegateCommand DisplayWindowC { get; }
        // パラメータを渡しつつ Window B を表示
        private void DisplayWindowBExe()
        {
            var p = new DialogParameters();
            p.Add(nameof(WindowBViewModel.WindowBText), "Window D からパラメータを受け取る");
            p.Add("testKey1", WindowDText);
            p.Add("testKey2", 444.444f);
            p.Add("testKey3", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            _dialogService.ShowDialog(nameof(WindowB), p, null);
        }
        // パラメータをもらえる形で Window C を表示
        private void DisplayWindowCExe()
        {
            _dialogService.ShowDialog(nameof(WindowC), null, CloseWindowC);
        }
        private void CloseWindowC(IDialogResult dialogResult)
        {
            WindowDText = dialogResult.Parameters.GetValue<string>(nameof(WindowCViewModel.WindowCText));
        }


    }
}
