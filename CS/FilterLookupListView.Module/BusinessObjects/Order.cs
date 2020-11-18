using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Order : BaseObject {
        public Order(Session session) : base(session) { }
        private int orderId;
        public int OrderId {
            get { return orderId; }
            set { SetPropertyValue(nameof(OrderId), ref orderId, value); }
        }
        private Product product;
        public Product Product {
            get { return product; }
            set {
                SetPropertyValue(nameof(Product), ref product, value);
                //Scenario 4 - Custom Lookup Property Data Source
                // Refresh the Accessory Property data source 
                RefreshAvailableAccessories();
            }
        }
        private Accessory accessory;
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
        public Accessory Accessory {
            get { return accessory; }
            set { SetPropertyValue(nameof(Accessory), ref accessory, value); }
        }

        #region Scenario 4 - Custom Lookup Property Data Source
        private XPCollection<Accessory> availableAccessories;
        [Browsable(false)] // Prohibits showing the AvailableAccessories collection separately 
        public XPCollection<Accessory> AvailableAccessories {
            get {
                if(availableAccessories == null) {
                    // Retrieve all Accessory objects 
                    availableAccessories = new XPCollection<Accessory>(Session);
                    // Filter the retrieved collection according to current conditions 
                    RefreshAvailableAccessories();
                }
                // Return the filtered collection of Accessory objects 
                return availableAccessories;
            }
        }
        private void RefreshAvailableAccessories() {
            if(availableAccessories == null)
                return;
            // Process the situation when the Product is not specified (see the Scenario 3 above) 
            if(Product == null) {
                // Show only Global Accessories when the Product is not specified 
                availableAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true");
            }
            else {
                // Leave only the current Product's Accessories in the availableAccessories collection 
                availableAccessories.Criteria = new BinaryOperator("Product", Product);
                if(IncludeGlobalAccessories == true) {
                    // Add Global Accessories 
                    XPCollection<Accessory> availableGlobalAccessories =
                       new XPCollection<Accessory>(Session);
                    availableGlobalAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true");
                    availableAccessories.AddRange(availableGlobalAccessories);
                }
            }
            // Set null for the Accessory property to allow an end-user  
            //to set a new value from the refreshed data source 
            Accessory = null;
        }
        private bool includeGlobalAccessories;
        [ImmediatePostData] //Use this attribute to refresh the Accessory  
        public bool IncludeGlobalAccessories {
            get {
                return includeGlobalAccessories;
            }
            set {
                if(includeGlobalAccessories != value) {
                    includeGlobalAccessories = value;
                    if(!IsLoading) {
                        // Refresh the Accessory Property data source                     
                        RefreshAvailableAccessories();
                        SetPropertyValue(nameof(IncludeGlobalAccessories), ref includeGlobalAccessories, value);
                    }
                }
            }
        }
        #endregion
    }
}
