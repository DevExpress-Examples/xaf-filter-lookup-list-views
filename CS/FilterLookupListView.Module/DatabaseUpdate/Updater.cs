using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;

using FilterLookupListView.Module.BusinessObjects;

namespace FilterLookupListView.Module.DatabaseUpdate
{
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Accessory accessory1 = EnsureAccessory("Canon Case Dcc-400", false);
            Accessory accessory2 = EnsureAccessory("Canon Case Dcc-600", false);
            Accessory accessory3 = EnsureAccessory("Digitex Secure Digital, 2Gb", true);
            Accessory accessory4 = EnsureAccessory("A-Data Secure Digital, 2Gb, Super", true);

            Product product1 = EnsureProduct("Canon PowerShot G7", accessory1, accessory2);

            Order order1 = EnsureOrder(10, product1);

            ObjectSpace.CommitChanges();
        }
        private Accessory EnsureAccessory(string name, bool isGlobal) {
            Accessory accessory = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse("AccessoryName == ?", name));
            if(accessory == null) {
                accessory = ObjectSpace.CreateObject<Accessory>();
                accessory.AccessoryName = name;
                accessory.IsGlobal = isGlobal;
                accessory.Save();
            }
            return accessory;
        }
        private Product EnsureProduct(string name, params Accessory[] accessories) {
            Product product = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("ProductName == ?", name));
            if(product == null) {
                product = ObjectSpace.CreateObject<Product>();
                product.ProductName = name;
                foreach(Accessory accessory in accessories) {
                    product.Accessories.Add(accessory);
                }
                product.Save();
            }
            return product;
        }
        private Order EnsureOrder(int orderId, Product product) {
            Order order = ObjectSpace.FindObject<Order>(CriteriaOperator.Parse("OrderId == ?", orderId));
            if(order == null) {
                order = ObjectSpace.CreateObject<Order>();
                order.OrderId = orderId;
                order.Product = product;
                order.Save();
            }
            return order;
        }
    }
}
