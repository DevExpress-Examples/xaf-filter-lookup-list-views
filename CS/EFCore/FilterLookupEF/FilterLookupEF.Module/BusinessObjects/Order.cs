using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilterLookupListView.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Order : BaseObject {
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

        // Specify that AvailableAccessories must be used as a data source property,
        // and the Product and IncludeGlobalAccessories properties are used in calculations.
        [DataSourceProperty(nameof(AvailableAccessories), nameof(Product), nameof(IncludeGlobalAccessories))]
        public virtual Accessory Accessory { get; set; }

        #region Scenario 4 - Custom Lookup Property Data Source
        [NotMapped, Browsable(false)] // Prohibits showing the AvailableAccessories collection separately 
        public virtual IList<Accessory> AvailableAccessories {
            get {
                IQueryable<Accessory> available;
                if (Product == null) {
                    // Show only Global Accessories when the Product is not specified 
                    available = ObjectSpace.GetObjectsQuery<Accessory>().Where(t => t.IsGlobal == true);
                }
                else {
                    // Leave only the current Product's Accessories in the availableAccessories collection 
                    if (IncludeGlobalAccessories == false) {
                        available = ObjectSpace.GetObjectsQuery<Accessory>().Where(t => t.Product == Product);
                    }
                    else {
                        available = ObjectSpace.GetObjectsQuery<Accessory>().Where(t => t.Product == Product || t.IsGlobal == true);
                    }
                }
                return available.ToList();
            }
        }

        public virtual bool IncludeGlobalAccessories { get; set; }

        #endregion
    }
}
