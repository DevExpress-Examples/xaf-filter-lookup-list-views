using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Accessory : BaseObject {
        public virtual string AccessoryName {            get;set;        }
        public virtual bool IsGlobal { get; set; }
    
        public virtual Product Product { get; set; }
    }

}
