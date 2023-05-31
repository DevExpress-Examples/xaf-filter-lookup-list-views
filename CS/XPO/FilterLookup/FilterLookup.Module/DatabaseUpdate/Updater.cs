using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using FilterLookupListView.Module.BusinessObjects;

namespace FilterLookup.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        Accessory accessory1 = EnsureAccessory("Canon Case Dcc-400", false);
        Accessory accessory2 = EnsureAccessory("Canon Case Dcc-600", false);
        Accessory accessory3 = EnsureAccessory("Digitex Secure Digital, 2Gb", true);
        Accessory accessory4 = EnsureAccessory("A-Data Secure Digital, 2Gb, Super", true);
        Accessory accessory5 = EnsureAccessory("Unrelated accessory", false);

        Product product1 = EnsureProduct("Canon PowerShot G7", accessory1, accessory2);

        Order order1 = EnsureOrder(10, product1);

        ObjectSpace.CommitChanges();
    }
    private Accessory EnsureAccessory(string name, bool isGlobal) {
        Accessory accessory = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse("AccessoryName == ?", name));
        if (accessory == null) {
            accessory = ObjectSpace.CreateObject<Accessory>();
            accessory.AccessoryName = name;
            accessory.IsGlobal = isGlobal;
            
        }
        return accessory;
    }
    private Product EnsureProduct(string name, params Accessory[] accessories) {
        Product product = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("ProductName == ?", name));
        if (product == null) {
            product = ObjectSpace.CreateObject<Product>();
            product.ProductName = name;
            foreach (Accessory accessory in accessories) {
                product.Accessories.Add(accessory);
            }
            
        }
        return product;
    }
    private Order EnsureOrder(int orderId, Product product) {
        Order order = ObjectSpace.FindObject<Order>(CriteriaOperator.Parse("OrderId == ?", orderId));
        if (order == null) {
            order = ObjectSpace.CreateObject<Order>();
            order.OrderId = orderId;
            order.Product = product;
            
        }
        return order;
    }
}
