using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismUI.Views;
using System;

namespace PrismUI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // test for git 
        // Navigation 画面遷移を使う場合は，IReagionManager 必須
        private IRegionManager _regionManager;
        // Pop Up 画面表示を使う場合，IDialogService 必須
        private IDialogService _dialogService;
        // コンストラクタ引数を設定．Prismが自動で読み込む
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            // Navigation 画面遷移メソッドの登録
            NavigationAButton = new DelegateCommand(NavigationAButtonExe);
            NavigationBButton = new DelegateCommand(NavigationBButtonExe);
            NavigationCButton = new DelegateCommand(NavigationCButtonExe);
            NavigationDButton = new DelegateCommand(NavigationDButtonExe);

            // Window Pop-Up メソッドの登録
            WindowAButton = new DelegateCommand(WindowAButtonExe);
            WindowBButton = new DelegateCommand(WindowBButtonExe);
            WindowCButton = new DelegateCommand(WindowCButtonExe);
            WindowDButton = new DelegateCommand(WindowDButtonExe);

            // Tools example View 表示メソッドの登録
            ToolsListBoxButton = new DelegateCommand(ToolsListBoxButtonExe);
            ToolsComboBoxButton = new DelegateCommand(ToolsComboBoxButtonExe);
            ToolsControlEventButton = new DelegateCommand(ToolsControlEventButtonExe);
            ToolsRadioCheckButton = new DelegateCommand(ToolsRadioCheckButtonExe);
            ToolsSliderButton = new DelegateCommand(ToolsSliderButtonExe);
        }

        // プロパティの定型（デフォルト記述）
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        //******************************
        // Navigation 画面遷移
        //******************************
        // 画面遷移ボタンの登録
        public DelegateCommand NavigationAButton { get; }
        public DelegateCommand NavigationBButton { get; }
        public DelegateCommand NavigationCButton { get; }
        public DelegateCommand NavigationDButton { get; }

        //-----------------------------------------------
        // ViewA の表示
        private void NavigationAButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NavigationA));
        }

        //-----------------------------------------------
        // パラメータを渡しつつ ViewB の表示
        private void NavigationBButtonExe()
        {
            // パラメータの型は NavigatioParameters
            var p = new NavigationParameters();

            // string/object の Key/Value で Add する．受取先のプロパティ名を Key としておくと便利
            p.Add(nameof(NavigationBViewModel.ViewBText), "Main View から値を渡す");

            // Key は string だが，Value は何でもよい
            p.Add("testKey1", 123);
            p.Add("testKey2", 333.333f);
            p.Add("testKey3", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            // RequestNavigate の第三引数として NavigationParameters を渡す
            _regionManager.RequestNavigate("ContentRegion", nameof(NavigationB), p);
        }

        //-----------------------------------------------
        // ViewC の表示
        private void NavigationCButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NavigationC));
        }

        //-----------------------------------------------
        // ViewD の表示
        private void NavigationDButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NavigationD));
        }
        // パラメータを受け取るプロパティを定義しておき，遷移先の自インスタンスで代入する
        private string _navigationDText = string.Empty;
        public string NavigationDText
        {
            get { return _navigationDText; }
            set { SetProperty(ref _navigationDText, value); }
        }




        //******************************
        // Pop Up 画面遷移
        //******************************
        public DelegateCommand WindowAButton { get; }
        public DelegateCommand WindowBButton { get; }
        public DelegateCommand WindowCButton { get; }
        public DelegateCommand WindowDButton { get; }

        //-----------------------------------------------
        // WindowA の表示
        private void WindowAButtonExe()
        {
            _dialogService.ShowDialog(nameof(WindowA), null, null);
        }

        //-----------------------------------------------
        // パラメータを渡しつつ WindowB の表示
        private void WindowBButtonExe()
        {
            // パラメータの型は DialogParameters
            var p = new DialogParameters();

            // string/object の Key/Value で Add する．受取先のプロパティ名を Key としておくと便利
            p.Add(nameof(WindowBViewModel.WindowBText), "Main View から値を渡す");

            // Key は string だが，Value は何でもよい
            p.Add("testKey1", 123);
            p.Add("testKey2", 333.333f);
            p.Add("testKey3", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            // ShowDialog の第二引数として DialogParameters を渡す
            _dialogService.ShowDialog(nameof(WindowB), p, null);
        }

        //-----------------------------------------------
        // WindowC の表示と パラメータの受領
        private void WindowCButtonExe()
        {
            // ShowDialog の第三引数にメソッドを渡す
            // そのメソッドの引数に DialogResultが渡され，メソッドが実行される
            _dialogService.ShowDialog(nameof(WindowC), null, WindowCClose);
        }
        // WindowC からパラメータを戻すときのアクション
        // 引数の型がインターフェイスなのはなぜ…？
        private void WindowCClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result == ButtonResult.OK)
            {
                WindowCText = dialogResult.Parameters.GetValue<string>(nameof(WindowCViewModel.WindowCText));
            }
        }
        // パラメータを受け取るプロパティの定義
        private string _windowCText = string.Empty;
        public string WindowCText
        {
            get { return _windowCText; }
            set { SetProperty(ref _windowCText, value); }
        }

        //-----------------------------------------------
        // WindowD の表示
        private void WindowDButtonExe()
        {
            _dialogService.ShowDialog(nameof(WindowD), null, null);
        }


        //******************************
        // Tools 
        //******************************
        public DelegateCommand ToolsListBoxButton { get; }
        public DelegateCommand ToolsComboBoxButton { get; }
        public DelegateCommand ToolsControlEventButton { get; }
        public DelegateCommand ToolsRadioCheckButton { get; }
        public DelegateCommand ToolsSliderButton { get; }
        //-----------------------------------------------
        // リストボックス
        private void ToolsListBoxButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ToolsListBox));
        }

        //-----------------------------------------------
        // コンボボックス
        private void ToolsComboBoxButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ToolsComboBox));
        }
        // パラメータを受け取るプロパティ
        private string _toolsComboBoxText = string.Empty;
        public string ToolsComboBoxText
        {
            get { return _toolsComboBoxText; }
            set { SetProperty(ref _toolsComboBoxText, value); }
        }
        //-----------------------------------------------
        // イベントトリガ
        private void ToolsControlEventButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ToolsControlEvent));
        }

        // ラジオボタン/チェックボタン
        private void ToolsRadioCheckButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ToolsRadioCheckButton));
        }

        // スライダー
        private void ToolsSliderButtonExe()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ToolsSlider));
        }
        private string _toolsSliderText = string.Empty;
        public string ToolsSliderText
        {
            get { return _toolsSliderText; }
            set { SetProperty(ref _toolsSliderText, value); }
        }
        private string _toolsSliderTextColor = string.Empty;
        public string ToolsSliderTextColor
        {
            get { return _toolsSliderTextColor; }
            set { SetProperty(ref _toolsSliderTextColor, value); }
        }



        //******************************
        // メインウインドウコントロール
        //******************************
        //ProgressBarValue
        private int _progressBarValue;
        public int ProgressBarValue
        {
            get { return _progressBarValue; }
            set { SetProperty(ref _progressBarValue, value); }
        }

    }
}

