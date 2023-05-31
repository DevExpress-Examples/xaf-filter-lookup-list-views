using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Accessory : BaseObject {
        public Accessory(Session session) : base(session) { }
        private string accessoryName;
        public string AccessoryName {
            get { return accessoryName; }
            set { SetPropertyValue(nameof(AccessoryName), ref accessoryName, value); }
        }
        private bool isGlobal;
        public bool IsGlobal {
            get { return isGlobal; }
            set { SetPropertyValue(nameof(IsGlobal), ref isGlobal, value); }
        }
        private Product product;
        [Association("P-To-C")]
        public Product Product {
            get { return product; }
            set { SetPropertyValue(nameof(Product), ref product, value); }
        }
    }

}
