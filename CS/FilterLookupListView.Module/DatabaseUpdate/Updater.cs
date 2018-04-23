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
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            Accessory accessory1 = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse(
      "AccessoryName == 'Canon Case Dcc-400'"));
            if (accessory1 == null)
            {
                accessory1 = ObjectSpace.CreateObject<Accessory>();
                accessory1.AccessoryName = "Canon Case Dcc-400";
                accessory1.IsGlobal = false;
                accessory1.Save();
            }
            Accessory accessory2 = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse(
   "AccessoryName == 'Canon Case Dcc-600'"));
            if (accessory2 == null)
            {
                accessory2 = ObjectSpace.CreateObject<Accessory>();
                accessory2.AccessoryName = "Canon Case Dcc-600";
                accessory2.IsGlobal = false;
                accessory2.Save();
            }
            Accessory accessory3 = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse(
   "AccessoryName == 'Digitex Secure Digital, 2Gb'"));
            if (accessory3 == null)
            {
                accessory3 = ObjectSpace.CreateObject<Accessory>();
                accessory3.AccessoryName = "Digitex Secure Digital, 2Gb";
                accessory3.IsGlobal = true;
                accessory3.Save();
            }
            Accessory accessory4 = ObjectSpace.FindObject<Accessory>(CriteriaOperator.Parse(
   "AccessoryName == 'A-Data Secure Digital, 2Gb, Super'"));
            if (accessory4 == null)
            {
                accessory4 = ObjectSpace.CreateObject<Accessory>();
                accessory4.AccessoryName = "A-Data Secure Digital, 2Gb, Super";
                accessory4.IsGlobal = true;
                accessory4.Save();
            }

            Product product1 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse(
                "ProductName == 'Canon PowerShot G7'"));
            if (product1 == null)
            {
                product1 = ObjectSpace.CreateObject<Product>();
                product1.ProductName = "Canon PowerShot G7";
                product1.Accessories.Add(accessory1);
                product1.Accessories.Add(accessory2);
                product1.Save();
            }
            Order order1 = ObjectSpace.FindObject<Order>(CriteriaOperator.Parse(
                "OrderId == 10"));
            if (order1 == null)
            {
                order1 = ObjectSpace.CreateObject<Order>();
                order1.OrderId = 10;
                order1.Product = product1;
                order1.Save();
            }
            ObjectSpace.CommitChanges();
        }
    }
}
