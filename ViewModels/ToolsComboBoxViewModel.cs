using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismUI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class ToolsComboBoxViewModel : BindableBase
    {
        private MainWindowViewModel _mainWindowViewModel; 
        public ToolsComboBoxViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            // ひとまずコンストラクタでデフォルトのリストを作ってみる
            _toolsComboBoxItems.Add(new ComboBoxModel(1, "CBox Item 1"));
            _toolsComboBoxItems.Add(new ComboBoxModel(2, "CBox Item 2"));
            _toolsComboBoxItems.Add(new ComboBoxModel(3, "CBox Item 3"));

            ToolsComboBoxSelectedItem = _toolsComboBoxItems[1];

            // イベントのメソッド定義
            ToolsComboBoxButton = new DelegateCommand(ToolsComboBoxButtonExe);
        }

        // ComboBox にバインドするプロパティを定義
        // ComboBox のソースも基本的に ObservableCollection を使えば OK だが，DisplayValue
        // など項目の紐づけをよく使うので，ComboBox用の ViewModelを作っておくとよい
        private ObservableCollection<ComboBoxModel> _toolsComboBoxItems = new ObservableCollection<ComboBoxModel>();
        public ObservableCollection<ComboBoxModel> ToolsComboBoxItems
        {
            get { return _toolsComboBoxItems; }
            set { SetProperty(ref _toolsComboBoxItems, value); }
        }

        // ComboBox で選択したアイテムをとってくる
        // 値が入ってくるプロパティなので，インスタンス化する必要はない
        private ComboBoxModel _toolsComboBoxSelectedItem;
        public ComboBoxModel ToolsComboBoxSelectedItem
        {
            get { return _toolsComboBoxSelectedItem; }
            set { SetProperty(ref _toolsComboBoxSelectedItem, value); }
        }

        // ComboBox で選択した値をMainView に返す
        //ToolsComboBoxButton
        public DelegateCommand ToolsComboBoxButton { get; }
        private void ToolsComboBoxButtonExe()
        {
            _mainWindowViewModel.ToolsComboBoxText = ToolsComboBoxSelectedItem.DisplayValue;
        }

    }
}
