Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace FilterLookupListView.Module.BusinessObjects
	Public Class Accessory
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _accessoryName As String
		Public Property AccessoryName() As String
			Get
				Return _accessoryName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(AccessoryName), _accessoryName, value)
			End Set
		End Property
		Private _isGlobal As Boolean
		Public Property IsGlobal() As Boolean
			Get
				Return _isGlobal
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue(NameOf(IsGlobal), _isGlobal, value)
			End Set
		End Property
		Private _product As Product
		<Association("P-To-C")>
		Public Property Product() As Product
			Get
				Return _product
			End Get
			Set(ByVal value As Product)
				SetPropertyValue(NameOf(Product), _product, value)
			End Set
		End Property
	End Class

End Namespace
