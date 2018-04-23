Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace FilterLookupListView.Web
   Partial Public Class FilterLookupListViewAspNetApplication
       Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
        End Sub
      Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
      Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
      Private module3 As FilterLookupListView.Module.FilterLookupListViewModule
      Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
      Private scriptRecorderAspNetModule1 As DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule
      Private scriptRecorderModuleBase1 As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
      Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub FilterLookupListViewAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
         If System.Diagnostics.Debugger.IsAttached Then
            e.Updater.Update()
            e.Handled = True
         Else
            Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & ControlChars.CrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & ControlChars.CrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & ControlChars.CrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
         End If
#End If
      End Sub

      Private Sub InitializeComponent()
         Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
         Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
         Me.module3 = New FilterLookupListView.Module.FilterLookupListViewModule()
         Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
         Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
         Me.scriptRecorderAspNetModule1 = New DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule()
         Me.scriptRecorderModuleBase1 = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
         DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
         ' 
         ' module5
         ' 
         Me.module5.AllowValidationDetailsAccess = True
         ' 
         ' FilterLookupListViewAspNetApplication
         ' 
         Me.ApplicationName = "FilterLookupListView"
         Me.Modules.Add(Me.module1)
         Me.Modules.Add(Me.module2)
         Me.Modules.Add(Me.module6)
         Me.Modules.Add(Me.module3)
         Me.Modules.Add(Me.module5)
         Me.Modules.Add(Me.scriptRecorderModuleBase1)
         Me.Modules.Add(Me.scriptRecorderAspNetModule1)
         DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

      End Sub
   End Class
End Namespace
