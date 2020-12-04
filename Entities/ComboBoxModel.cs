using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUI.Entities
{
    public sealed class ComboBoxModel
    {
        // 完全コンストラクタパターンで，インスタンス化時に値を決めてしまう形
        public ComboBoxModel(int value , string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }


        public int Value { get; }
        public string DisplayValue { get; }
    }

}
