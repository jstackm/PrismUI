using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    // ViewModel でパラメータを受け取る場合は，INavigationAware を継承する
    public class NavigationBViewModel : BindableBase, INavigationAware
    {
        // メイン画面から渡されたパラメータを格納するフィールド
        private NavigationContext _parameters;

        public NavigationBViewModel()
        {
            ViewParameter1 = new DelegateCommand(ViewParameter1Exe);
            ViewParameter2 = new DelegateCommand(ViewParameter2Exe);
            ViewParameter3 = new DelegateCommand(ViewParameter3Exe);
        }

        // Viewのコントロールとバインドするプロパティ
        private string _viewBText = string.Empty;
        public string ViewBText
        {
            get { return _viewBText; }
            set { SetProperty(ref _viewBText, value); }
        }


        // メイン画面から遷移してきたときの処理
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // navibationContext に NavigationParamter型の値が渡される
            // value は object 型なので，GetValue<> で型指定して取り出す
            // ひとまず．TextBlock の Content とバインドされている ViewBText プロパティを
            // key として格納されている文字列を TextBlock に表示してみる
            ViewBText = navigationContext.Parameters.GetValue<string>(nameof(ViewBText));

            // 受け取ったパラメータをフィールドに代入して他のメソッドで使えるようにする
            _parameters = navigationContext;
        }

        // インスタンスを使いまわすかどうか
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        // この View から離れる時の処理
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }


        // ボタンによるメソッドの実行
        public DelegateCommand ViewParameter1 { get; }
        public DelegateCommand ViewParameter2 { get; }
        public DelegateCommand ViewParameter3 { get; }
        private void ViewParameter1Exe()
        {
            ViewBText = _parameters.Parameters.GetValue<string>("testKey1");
        }
        private void ViewParameter2Exe()
        {
            ViewBText = _parameters.Parameters.GetValue<string>("testKey2");
        }
        private void ViewParameter3Exe()
        {
            ViewBText = _parameters.Parameters.GetValue<DateTime>("testKey3").ToString();
        }

    }
}
