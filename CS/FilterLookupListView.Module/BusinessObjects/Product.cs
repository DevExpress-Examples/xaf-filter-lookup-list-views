using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace FilterLookupListView.Module.BusinessObjects {
   //[DefaultClassOptions]
   public class Product : BaseObject {
      public Product(Session session) : base(session) {}
      public override void AfterConstruction() {
         base.AfterConstruction();
      }
      private String productName;
      public String ProductName {
         get {
            return productName;
         }
         set {
            SetPropertyValue("ProductName", ref productName, value);
         }
      }
      [Association("P-To-C")]
      public XPCollection<Accessory> Accessories {
         get {
            return GetCollection<Accessory>("Accessories");
         }
      }
   }

}
