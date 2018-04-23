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
   public class Accessory : BaseObject {
      public Accessory(Session session) : base(session) {}
      public override void AfterConstruction() {
         base.AfterConstruction();
      }
      private String accessoryName;
      public String AccessoryName {
         get {
            return accessoryName;
         }
         set {
            SetPropertyValue("AccessoryName", ref accessoryName, value);
         }
      }
      private bool isGlobal;
      public bool IsGlobal {
         get {
            return isGlobal;
         }
         set {
            SetPropertyValue("IsGlobal", ref isGlobal, value);
         }
      }
      private Product product;
      [Association("P-To-C")]
      public Product Product {
         get {
            return product;
         }
         set {
            SetPropertyValue("Product", ref product, value);
         }
      }
   }

}
