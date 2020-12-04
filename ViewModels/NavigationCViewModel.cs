using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class NavigationCViewModel : BindableBase
    {
        // Navigation 画面遷移を使う場合は，IReagionManager 必須
        // 子画面から子画面，子画面から孫画面のときも有効
        private IRegionManager _regionManager;
        public NavigationCViewModel(IRegionManager regionManager)
        {
            MoveToViewB = new DelegateCommand(MoveToViewBExe);
            _regionManager = regionManager;
        }

        // テキストボックスのデータバインド
        private string _viewCText = string.Empty;
        public string ViewCText
        {
            get { return _viewCText; }
            set { SetProperty(ref _viewCText, value); }
        }

        // ViewB にパラメータを渡しつつ画面遷移する
        public DelegateCommand MoveToViewB { get; }
        private void MoveToViewBExe()
        {
            // パラメータの型は NavigatioParameters
            var p = new NavigationParameters();

            // string/object の Key/Value で Add する．受取先のプロパティ名を Key としておくと便利
            p.Add(nameof(NavigationBViewModel.ViewBText), ViewCText);

            // Key は string だが，Value は何でもよい
            p.Add("testKey1", "View C から受け取った値");
            p.Add("testKey2", 333.333f);
            p.Add("testKey3", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            // RequestNavigate の第三引数として NavigationParameters を渡す
            _regionManager.RequestNavigate("ContentRegion", nameof(NavigationB), p);
        }
    }
}
