using Prism.Commands;
using Prism.Mvvm;
using PrismUI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class ToolsControlEventViewModel : BindableBase
    {
        public ToolsControlEventViewModel()
        {
            ToolsEventSelectionChanged = new DelegateCommand<object[]>(ToolsEventSelectionChangedExe);

            // ひとまずコンストラクタでデフォルトのリストを作ってみる
            _toolsEventComboBoxItems.Add(new ComboBoxModel(11, "Event Item1"));
            _toolsEventComboBoxItems.Add(new ComboBoxModel(12, "Event Item2"));
            _toolsEventComboBoxItems.Add(new ComboBoxModel(13, "Event Item3"));
            _toolsEventComboBoxItems.Add(new ComboBoxModel(14, "Event Item4"));
        }        
        
        // ComboBox にバインドするプロパティを定義
        // ComboBox のソースも基本的に ObservableCollection を使えば OK だが，DisplayValue
        // など項目の紐づけをよく使うので，ComboBox用の ViewModelを作っておくとよい
        private ObservableCollection<ComboBoxModel> _toolsEventComboBoxItems = new ObservableCollection<ComboBoxModel>();
        public ObservableCollection<ComboBoxModel> ToolsEventComboBoxItems
        {
            get { return _toolsEventComboBoxItems; }
            set { SetProperty(ref _toolsEventComboBoxItems, value); }
        }

        // ComboBox で選択したアイテムをとってくる
        // 値が入ってくるプロパティなので，インスタンス化する必要はない
        private ComboBoxModel _toolsEventComboBoxSelectedItem;
        public ComboBoxModel ToolsEventComboBoxSelectedItem
        {
            get { return _toolsEventComboBoxSelectedItem; }
            set { SetProperty(ref _toolsEventComboBoxSelectedItem, value); }
        }

        // イベントが起こった時の実行メソッド
        // イベント引数を TriggerParameterPath で渡すときは，object配列で型指定する
        public DelegateCommand<object[]> ToolsEventSelectionChanged { get; }
        private void ToolsEventSelectionChangedExe(object[] items)
        {
            // イベント発火自の SelectedItem などをとってきてもよいし
            ToolsEventLabel = ToolsEventComboBoxSelectedItem.Value + " : " + ToolsEventComboBoxSelectedItem.DisplayValue;
            // TriggerParameterPath でとってきたイベント引数の中身を処理してもよい
            // イベント引数は object型なのでキャストする必要がある（もっと良い方法がありそう…）
            ComboBoxModel p = (ComboBoxModel)items[0];
            ToolsEventLabelArgs = p.DisplayValue;
        }
        private string _toolsEventLabel;
        public string ToolsEventLabel
        {
            get { return _toolsEventLabel; }
            set { SetProperty(ref _toolsEventLabel, value); }
        }
        private string _toolsEventLabelArgs;
        public string ToolsEventLabelArgs
        {
            get { return _toolsEventLabelArgs; }
            set { SetProperty(ref _toolsEventLabelArgs, value); }
        }

    }
}
