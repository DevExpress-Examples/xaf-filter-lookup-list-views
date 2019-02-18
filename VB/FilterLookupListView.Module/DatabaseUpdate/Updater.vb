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
            Dim accessory1 As Accessory = EnsureAccessory("Canon Case Dcc-400", False)
            Dim accessory2 As Accessory = EnsureAccessory("Canon Case Dcc-600", False)
            Dim accessory3 As Accessory = EnsureAccessory("Digitex Secure Digital, 2Gb", True)
            Dim accessory4 As Accessory = EnsureAccessory("A-Data Secure Digital, 2Gb, Super", True)

            Dim product1 As Product = EnsureProduct("Canon PowerShot G7", accessory1, accessory2)

            Dim order1 As Order = EnsureOrder(10, product1)

            ObjectSpace.CommitChanges()
        End Sub
        Private Function EnsureAccessory(ByVal name As String, ByVal isGlobal As Boolean) As Accessory
            Dim accessory As Accessory = ObjectSpace.FindObject(Of Accessory)(CriteriaOperator.Parse("AccessoryName == ?", name))
            If accessory Is Nothing Then
                accessory = ObjectSpace.CreateObject(Of Accessory)()
                accessory.AccessoryName = name
                accessory.IsGlobal = isGlobal
                accessory.Save()
            End If
            Return accessory
        End Function
        Private Function EnsureProduct(ByVal name As String, ParamArray ByVal accessories As Accessory()) As Product
            Dim product As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("ProductName == ?", name))
            If product Is Nothing Then
                product = ObjectSpace.CreateObject(Of Product)()
                product.ProductName = name
                For Each accessory As Accessory In accessories
                    product.Accessories.Add(accessory)
                Next accessory
                product.Save()
            End If
            Return product
        End Function
        Private Function EnsureOrder(ByVal orderId As Integer, ByVal product As Product) As Order
            Dim order As Order = ObjectSpace.FindObject(Of Order)(CriteriaOperator.Parse("OrderId == ?", orderId))
            If order Is Nothing Then
                order = ObjectSpace.CreateObject(Of Order)()
                order.OrderId = orderId
                order.Product = product
                order.Save()
            End If
            Return order
        End Function
    End Class
End Namespace
