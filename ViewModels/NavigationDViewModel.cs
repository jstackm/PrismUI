using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class NavigationDViewModel : BindableBase
    {
        // メイン画面を操作する場合は，コンストラクタで mainWindowのインスタンスを受けておく．
        // Prismが自動で渡してくれる
        private MainWindowViewModel _mainWindowViewModel;
        public NavigationDViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            ReturnParametersToMainView = new DelegateCommand(ReturnParametersToMainViewExe);
        }

        // テキストボックスのデータバインド
        private string _viewDText = string.Empty;
        public string ViewDText
        {
            get { return _viewDText; }
            set { SetProperty(ref _viewDText, value); }
        }

        // メイン画面にパラメータを返すメソッド
        public DelegateCommand ReturnParametersToMainView { get; }
        private void ReturnParametersToMainViewExe()
        {
            // コンストラクタで（自動で）MainWindow のインスタンスを受けているので，直接代入できる

            _mainWindowViewModel.NavigationDText = ViewDText;
        }


    }
}
