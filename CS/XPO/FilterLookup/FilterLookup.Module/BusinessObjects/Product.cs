using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Product : BaseObject {
        public Product(Session session) : base(session) { }
        private string productName;
        public string ProductName {
            get { return productName; }
            set { SetPropertyValue(nameof(ProductName), ref productName, value); }
        }
        [Association("P-To-C")]
        public XPCollection<Accessory> Accessories {
            get { return GetCollection<Accessory>("Accessories"); }
        }
    }
}
