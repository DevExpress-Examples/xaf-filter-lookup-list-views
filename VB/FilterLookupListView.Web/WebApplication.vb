Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo

Namespace FilterLookupListView.Web
	' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Web.WebApplication
	Partial Public Class FilterLookupListViewAspNetApplication
		Inherits WebApplication

		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
		Private module3 As FilterLookupListView.Module.FilterLookupListViewModule
		Private module4 As FilterLookupListView.Module.Web.FilterLookupListViewAspNetModule
		Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule

		Public Sub New()
			InitializeComponent()
		End Sub
		Protected Overrides Function CreateViewUrlManager() As IViewUrlManager
			Return New ViewUrlManager()
		End Function
		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			args.ObjectSpaceProvider = New XPObjectSpaceProvider(GetDataStoreProvider(args.ConnectionString, args.Connection), True)
			args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
		End Sub
		Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
			Dim application As System.Web.HttpApplicationState = If(System.Web.HttpContext.Current IsNot Nothing, System.Web.HttpContext.Current.Application, Nothing)
			Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
			If application IsNot Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
				dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
			Else
				dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
				If application IsNot Nothing Then
					application("DataStoreProvider") = dataStoreProvider
				End If
			End If
			Return dataStoreProvider
		End Function
		Private Sub FilterLookupListViewAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
			e.Updater.Update()
			e.Handled = True
		End Sub
		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
			Me.module3 = New FilterLookupListView.Module.FilterLookupListViewModule()
			Me.module4 = New FilterLookupListView.Module.Web.FilterLookupListViewAspNetModule()
			Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' FilterLookupListViewAspNetApplication
			' 
			Me.ApplicationName = "FilterLookupListView"
			Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
			Me.Modules.Add(Me.objectsModule)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.FilterLookupListViewAspNetApplication_DatabaseVersionMismatch);
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
	End Class
End Namespace
