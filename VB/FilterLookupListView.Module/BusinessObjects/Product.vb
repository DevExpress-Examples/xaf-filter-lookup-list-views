Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace FilterLookupListView.Module.BusinessObjects
	Public Class Product
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The field productName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private productName_Renamed As String
		Public Property ProductName() As String
			Get
				Return productName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(ProductName), productName_Renamed, value)
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
