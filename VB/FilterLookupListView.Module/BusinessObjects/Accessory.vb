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
   Public Class Accessory
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
      End Sub
      Public Overrides Sub AfterConstruction()
         MyBase.AfterConstruction()
      End Sub

      Private accessoryName_Renamed As String
      Public Property AccessoryName() As String
         Get
            Return accessoryName_Renamed
         End Get
         Set(ByVal value As String)
            SetPropertyValue("AccessoryName", accessoryName_Renamed, value)
         End Set
      End Property

      Private isGlobal_Renamed As Boolean
      Public Property IsGlobal() As Boolean
         Get
            Return isGlobal_Renamed
         End Get
         Set(ByVal value As Boolean)
            SetPropertyValue("IsGlobal", isGlobal_Renamed, value)
         End Set
      End Property

      Private product_Renamed As Product
      <Association("P-To-C")> _
      Public Property Product() As Product
         Get
            Return product_Renamed
         End Get
         Set(ByVal value As Product)
            SetPropertyValue("Product", product_Renamed, value)
         End Set
      End Property
   End Class

End Namespace
