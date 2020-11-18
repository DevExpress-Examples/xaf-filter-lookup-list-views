Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace FilterLookupListView.Module.BusinessObjects
	Public Class Accessory
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The field accessoryName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private accessoryName_Renamed As String
		Public Property AccessoryName() As String
			Get
				Return accessoryName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(AccessoryName), accessoryName_Renamed, value)
			End Set
		End Property
'INSTANT VB NOTE: The field isGlobal was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private isGlobal_Renamed As Boolean
		Public Property IsGlobal() As Boolean
			Get
				Return isGlobal_Renamed
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue(NameOf(IsGlobal), isGlobal_Renamed, value)
			End Set
		End Property
'INSTANT VB NOTE: The field product was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private product_Renamed As Product
		<Association("P-To-C")>
		Public Property Product() As Product
			Get
				Return product_Renamed
			End Get
			Set(ByVal value As Product)
				SetPropertyValue(NameOf(Product), product_Renamed, value)
			End Set
		End Property
	End Class

End Namespace
