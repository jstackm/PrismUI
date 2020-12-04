using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class ToolsListBoxViewModel : BindableBase
    {
        public ToolsListBoxViewModel()
        {
            // ひとまずコンストラクタでデフォルトのリストを作ってみる
            ToolsListBoxItems.Add("ListBox Item 1");
            ToolsListBoxItems.Add("ListBox Item 2");
            ToolsListBoxItems.Add("ListBox Item 3");

            // イベントのメソッド定義
            ToolsListBoxButton = new DelegateCommand(ToolsListBoxButtonExe);
        }

        // ListBox にバインドするプロパティを定義
        // List のソースは基本的に ObservableCollection を使えば OK
        private ObservableCollection<string> _toolsListBoxItems = new ObservableCollection<string>();
        public ObservableCollection<string> ToolsListBoxItems
        {
            get { return _toolsListBoxItems; }
            set { SetProperty(ref _toolsListBoxItems, value); }
        }

        // SelectedItems にバインドするプロパティの定義
        private string _toolsListBoxSelectedItem;
        public string ToolsListBoxSelectedItem
        {
            get { return _toolsListBoxSelectedItem; }
            set { SetProperty(ref _toolsListBoxSelectedItem, value); }
        }

        // TextBlock にバインドするプロパティの定義        
        private string _toolsListBoxText;
        public string ToolsListBoxText
        {
            get { return _toolsListBoxText; }
            set { SetProperty(ref _toolsListBoxText, value); }
        }


        //ToolsListBoxButton
        public DelegateCommand ToolsListBoxButton { get; }
        private void ToolsListBoxButtonExe()
        {
            ToolsListBoxText = ToolsListBoxSelectedItem;
        }




    }
}
