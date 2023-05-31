using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Product : BaseObject {
        public virtual string ProductName { get; set; }
        public virtual IList<Accessory> Accessories { get; set; } = new ObservableCollection<Accessory>();

    }
}
