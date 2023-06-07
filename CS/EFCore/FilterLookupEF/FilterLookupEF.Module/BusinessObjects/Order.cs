using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Order : BaseObject {
        public Order() {
            ((INotifyPropertyChanged)this).PropertyChanged += Order_PropertyChanged;
        }

        private void Order_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == nameof(Product) || e.PropertyName == nameof(IncludeGlobalAccessories)) {
                RefreshAvailableAccessories();
            }
        }

        public virtual int OrderId { get; set; }
        public virtual Product Product { get; set; }
        //Scenario 1
        //Specify Lookup Property Data Source Related to the Selected Product
        //[DataSourceProperty("Product.Accessories")]
        //Scenario 2
        //Specify Criteria for Lookup Property Data Source
        //[DataSourceCriteria("IsGlobal = true")]
        //Scenario 3
        //Specify Lookup Property Data Source for an Unspecified Product
        //[DataSourceProperty("Product.Accessories", DataSourcePropertyIsNullMode.CustomCriteria, "IsGlobal = true")]
        //Scenario 4
        //Custom Lookup Property Data Source
        [DataSourceProperty("AvailableAccessories")]
        public virtual Accessory Accessory { get; set; }

        #region Scenario 4 - Custom Lookup Property Data Source
        private readonly ObservableCollection<Accessory> availableAccessories = new ObservableCollection<Accessory>();

        [Browsable(false)] // Prohibits showing the AvailableAccessories collection separately 
        public virtual IList<Accessory> AvailableAccessories {
            get {
                if (availableAccessories.Count == 0) {
                    // Filter the retrieved collection according to current conditions 
                    RefreshAvailableAccessories();
                }
                // Return the filtered collection of Accessory objects 
                return availableAccessories;
            }
        }
        private void RefreshAvailableAccessories() {
            var os = ((IObjectSpaceLink)this).ObjectSpace;
            IQueryable<Accessory> available;
            // Process the situation when the Product is not specified (see the Scenario 3 above) 
            if (Product == null) {
                // Show only Global Accessories when the Product is not specified 
                available = os.GetObjectsQuery<Accessory>().Where(t => t.IsGlobal == true);
            } else {
                // Leave only the current Product's Accessories in the availableAccessories collection 
                if (IncludeGlobalAccessories == false) {
                    available = os.GetObjectsQuery<Accessory>().Where(t => t.Product == Product);
                } else {
                    available = os.GetObjectsQuery<Accessory>().Where(t => t.Product == Product || t.IsGlobal == true);
                }
            }

            RefreshAvailableAccessories(available);

            // Set null for the Accessory property to allow an end-user  
            //to set a new value from the refreshed data source 
            Accessory = null;
        }

        private void RefreshAvailableAccessories(IEnumerable<Accessory> accessories) {
            while (availableAccessories.Count > 0) {
                availableAccessories.RemoveAt(availableAccessories.Count - 1);
            }
            foreach (var accesoire in accessories) {
                availableAccessories.Add(accesoire);
            }
        }

        [ImmediatePostData] //Use this attribute to refresh the Accessory  
        public virtual bool IncludeGlobalAccessories { get; set; }

        #endregion
    }
}
