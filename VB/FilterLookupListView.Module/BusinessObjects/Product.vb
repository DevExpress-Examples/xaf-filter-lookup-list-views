Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace FilterLookupListView.Module.BusinessObjects
   '[DefaultClassOptions]
   Public Class Product
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
      End Sub
      Public Overrides Sub AfterConstruction()
         MyBase.AfterConstruction()
      End Sub

      Private productName_Renamed As String
      Public Property ProductName() As String
         Get
            Return productName_Renamed
         End Get
         Set(ByVal value As String)
            SetPropertyValue("ProductName", productName_Renamed, value)
         End Set
      End Property
      <Association("P-To-C")> _
      Public ReadOnly Property Accessories() As XPCollection(Of Accessory)
         Get
            Return GetCollection(Of Accessory)("Accessories")
         End Get
      End Property
   End Class

End Namespace
