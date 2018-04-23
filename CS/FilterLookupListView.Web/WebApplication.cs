using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace FilterLookupListView.Web {
   public partial class FilterLookupListViewAspNetApplication : WebApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
      private DevExpress.ExpressApp.SystemModule.SystemModule module1;
      private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
      private FilterLookupListView.Module.FilterLookupListViewModule module3;
      private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
      private DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule scriptRecorderAspNetModule1;
      private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase1;
      private DevExpress.ExpressApp.Validation.ValidationModule module5;

      public FilterLookupListViewAspNetApplication() {
         InitializeComponent();
      }

      private void FilterLookupListViewAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
			e.Updater.Update();
			e.Handled = true;
#else
         if (System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
         }
         else {
            throw new InvalidOperationException(
               "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
               "This error occurred  because the automatic database update was disabled when the application was started without debugging.\r\n" +
               "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " +
               "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
               "or manually create a database using the 'DBUpdater' tool.\r\n" +
               "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " +
               "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/");
         }
#endif
      }

      private void InitializeComponent() {
         this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
         this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
         this.module3 = new FilterLookupListView.Module.FilterLookupListViewModule();
         this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
         this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
         this.scriptRecorderAspNetModule1 = new DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule();
         this.scriptRecorderModuleBase1 = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // module5
         // 
         this.module5.AllowValidationDetailsAccess = true;
         // 
         // FilterLookupListViewAspNetApplication
         // 
         this.ApplicationName = "FilterLookupListView";
         this.Modules.Add(this.module1);
         this.Modules.Add(this.module2);
         this.Modules.Add(this.module6);
         this.Modules.Add(this.module3);
         this.Modules.Add(this.module5);
         this.Modules.Add(this.scriptRecorderModuleBase1);
         this.Modules.Add(this.scriptRecorderAspNetModule1);
         this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.FilterLookupListViewAspNetApplication_DatabaseVersionMismatch);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }
   }
}
