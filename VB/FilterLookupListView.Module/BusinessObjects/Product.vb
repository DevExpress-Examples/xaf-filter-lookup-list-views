Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace FilterLookupListView.Module.BusinessObjects
	Public Class Product
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _productName As String
		Public Property ProductName() As String
			Get
				Return _productName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(ProductName), _productName, value)
			End Set
		End Property
		<Association("P-To-C")>
		Public ReadOnly Property Accessories() As XPCollection(Of Accessory)
			Get
				Return GetCollection(Of Accessory)("Accessories")
			End Get
		End Property
	End Class
End Namespace
