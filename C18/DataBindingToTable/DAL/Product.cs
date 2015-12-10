using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DAL
{
    public class Product : INotifyPropertyChanged, IDataErrorInfo
	{
		#region 成员字段区
		protected int? _productID;
		protected string _productName = String.Empty;
		protected int? _supplierID;
		protected int? _categoryID;
		protected string _quantityPerUnit = String.Empty;
		protected decimal? _unitPrice;
		protected short _unitsInStock;
		protected short _unitsOnOrder;
		protected short _reorderLevel;
		protected bool _discontinued;
		#endregion
		#region 公共属性区
        //产品编码
		public int? ProductID
		{
			get {return _productID;}
            set { _productID = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ProductID"));
            }
		}
        //产品名称
		public string ProductName
		{
			get {return _productName;}
            set { _productName = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ProductName"));
            }
		}
        //供应商编码
		public int? SupplierID
		{
			get {return _supplierID;}
            set { _supplierID = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SupplierID"));
            }
		}
        //产品分类编码
		public int? CategoryID
		{
			get {return _categoryID;}
            set { _categoryID = value;
            OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
            }
		}
        //单位数量
		public string QuantityPerUnit
		{
			get {return _quantityPerUnit;}
            set { _quantityPerUnit = value;
            OnPropertyChanged(new PropertyChangedEventArgs("QuantityPerUnit"));
            }
		}
        //产品单价
		public decimal? UnitPrice
		{
			get {return _unitPrice;}
            set { _unitPrice = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UnitPrice"));
            }
		}
        //库存单位
		public short UnitsInStock
		{
			get {return _unitsInStock;}
            set { _unitsInStock = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UnitsInStock"));
            }
		}
        //存货单位
		public short UnitsOnOrder
		{
			get {return _unitsOnOrder;}
            set { _unitsOnOrder = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UnitsOnOrder")); 
            }
		}
        //安全库存数
		public short ReorderLevel
		{
			get {return _reorderLevel;}
            set { _reorderLevel = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ReorderLevel")); 
            }
		}   
        //产品报废
		public bool Discontinued
		{
			get {return _discontinued;}
            set
            {
                _discontinued = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Discontinued"));
            }
		}
		#endregion

        //重载ToString函数，使其返回产品名称。
        public override string ToString()
        {
            return ProductName + " (" + ProductID + ")";
        }

        #region INotifyPropertyChanged 成员
        //OnPropertyChanged方法用于触发PropertyChanged事件
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        #endregion
        #region IDataErrorInfo 成员

        public string Error
        {
            get { return null; }
        }
        //判断ProductName是否由字母和数字组成
        public string this[string columnName]
        {
            get
            {
                if (columnName == "ProductName")
                {
                    bool valid = true;
                    foreach (char c in ProductName)
                    {
                        if (!Char.IsLetterOrDigit(c))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid) return "The ProductName can only contain letters and numbers.";
                }
                return null;
            }
        }
        #endregion
    }
}
