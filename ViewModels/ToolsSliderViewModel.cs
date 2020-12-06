using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUI.ViewModels
{
    public class ToolsSliderViewModel : BindableBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ToolsSliderViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            ToolsSliderValueChanged1 = new DelegateCommand(ToolsSliderValueChanged1Exe);
            ToolsSliderValueChanged2 = new DelegateCommand(ToolsSliderValueChanged2Exe);
            ToolsSliderValueChanged3 = new DelegateCommand(ToolsSliderValueChanged3Exe);
        }

        // スライドバーの値を string で取得してそのまま Main Window に渡す
        private string _toolsSliderValue1 = string.Empty;
        public string ToolsSliderValue1
        {
            get { return _toolsSliderValue1; }
            set { SetProperty(ref _toolsSliderValue1, value); }
        }
        public DelegateCommand ToolsSliderValueChanged1 { get; }
        private void ToolsSliderValueChanged1Exe()
        {
            _mainWindowViewModel.ToolsSliderTextColor = "Red";
            _mainWindowViewModel.ToolsSliderText = ToolsSliderValue1;
        }

        // スライドバーの値を double で取得して丸めて Main Window に渡す
        private double _toolsSliderValue2;
        public double ToolsSliderValue2
        {
            get { return _toolsSliderValue2; }
            set { SetProperty(ref _toolsSliderValue2, value); }
        }
        private string _toolsSliderValue2Round;
        public string ToolsSliderValue2Round
        {
            get { return _toolsSliderValue2Round; }
            set { SetProperty(ref _toolsSliderValue2Round, value); }
        }
        public DelegateCommand ToolsSliderValueChanged2 { get; }
        private void ToolsSliderValueChanged2Exe()
        {
            ToolsSliderValue2Round = SliderValueRound(ToolsSliderValue2);
            _mainWindowViewModel.ToolsSliderTextColor = "Green";
            _mainWindowViewModel.ToolsSliderText = SliderValueRound(ToolsSliderValue2);
            //_mainWindowViewModel.ToolsSliderText = ToolsSliderValue2.ToString();
        }
        private string SliderValueRound(double value)
        {
            //var i = double.Parse(value);
            return Math.Round(value, 3).ToString();
        }


        // スライドバーの値を Main Window のプログレスバーに反映する
        private int _toolsSliderValue3;
        public int ToolsSliderValue3
        {
            get { return _toolsSliderValue3; }
            set { SetProperty(ref _toolsSliderValue3, value); }
        }
        public DelegateCommand ToolsSliderValueChanged3 { get; }
        private void ToolsSliderValueChanged3Exe()
        {
            _mainWindowViewModel.ToolsSliderText = "";
            _mainWindowViewModel.ProgressBarValue = ToolsSliderValue3;
        }


    }
}
