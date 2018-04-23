Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security

Imports FilterLookupListView.Module.BusinessObjects

Namespace FilterLookupListView.Module.DatabaseUpdate
   Public Class Updater
       Inherits ModuleUpdater

      Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
          MyBase.New(objectSpace, currentDBVersion)
      End Sub
      Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
         MyBase.UpdateDatabaseAfterUpdateSchema()
         Dim accessory1 As Accessory = ObjectSpace.FindObject(Of Accessory)(CriteriaOperator.Parse("AccessoryName == 'Canon Case Dcc-400'"))
         If accessory1 Is Nothing Then
            accessory1 = ObjectSpace.CreateObject(Of Accessory)()
            accessory1.AccessoryName = "Canon Case Dcc-400"
            accessory1.IsGlobal = False
            accessory1.Save()
         End If
         Dim accessory2 As Accessory = ObjectSpace.FindObject(Of Accessory)(CriteriaOperator.Parse("AccessoryName == 'Canon Case Dcc-600'"))
         If accessory2 Is Nothing Then
            accessory2 = ObjectSpace.CreateObject(Of Accessory)()
            accessory2.AccessoryName = "Canon Case Dcc-600"
            accessory2.IsGlobal = False
            accessory2.Save()
         End If
         Dim accessory3 As Accessory = ObjectSpace.FindObject(Of Accessory)(CriteriaOperator.Parse("AccessoryName == 'Digitex Secure Digital, 2Gb'"))
         If accessory3 Is Nothing Then
            accessory3 = ObjectSpace.CreateObject(Of Accessory)()
            accessory3.AccessoryName = "Digitex Secure Digital, 2Gb"
            accessory3.IsGlobal = True
            accessory3.Save()
         End If
         Dim accessory4 As Accessory = ObjectSpace.FindObject(Of Accessory)(CriteriaOperator.Parse("AccessoryName == 'A-Data Secure Digital, 2Gb, Super'"))
         If accessory4 Is Nothing Then
            accessory4 = ObjectSpace.CreateObject(Of Accessory)()
            accessory4.AccessoryName = "A-Data Secure Digital, 2Gb, Super"
            accessory4.IsGlobal = True
            accessory4.Save()
         End If

         Dim product1 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("ProductName == 'Canon PowerShot G7'"))
         If product1 Is Nothing Then
            product1 = ObjectSpace.CreateObject(Of Product)()
            product1.ProductName = "Canon PowerShot G7"
            product1.Accessories.Add(accessory1)
            product1.Accessories.Add(accessory2)
            product1.Save()
         End If
         Dim order1 As Order = ObjectSpace.FindObject(Of Order)(CriteriaOperator.Parse("OrderId == 10"))
            If order1 Is Nothing Then
                order1 = ObjectSpace.CreateObject(Of Order)()
                order1.OrderId = 10
                order1.Product = product1
                order1.Save()
            End If
            ObjectSpace.CommitChanges()
        End Sub
   End Class
End Namespace
