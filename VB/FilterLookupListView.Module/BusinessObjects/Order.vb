Imports System.ComponentModel
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace FilterLookupListView.Module.BusinessObjects
	<DefaultClassOptions>
	Public Class Order
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The field orderId was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private orderId_Renamed As Integer
		Public Property OrderId() As Integer
			Get
				Return orderId_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(NameOf(OrderId), orderId_Renamed, value)
			End Set
		End Property
'INSTANT VB NOTE: The field product was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private product_Renamed As Product
		Public Property Product() As Product
			Get
				Return product_Renamed
			End Get
			Set(ByVal value As Product)
				SetPropertyValue(NameOf(Product), product_Renamed, value)
				'Scenario 4 - Custom Lookup Property Data Source
				' Refresh the Accessory Property data source 
				RefreshAvailableAccessories()
			End Set
		End Property
'INSTANT VB NOTE: The field accessory was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private accessory_Renamed As Accessory
		'Scenario 1
		'Specify Lookup Property Data Source Related to the Selected Product
		'[DataSourceProperty("Product.Accessories")]
		'Scenario 2
		'Specify Criteria for Lookup Property Data Source
		'[DataSourceCriteria("IsGlobal = true")]
		'Scenario 3
		'Specify Lookup Property Data Source for an Unspecified Product
		'[DataSourceProperty("Product.Accessories", DataSourcePropertyIsNullMode.CustomCriteria, "IsGlobal = true")]
		'Scenario 4
		'Custom Lookup Property Data Source
		<DataSourceProperty("AvailableAccessories")>
		Public Property Accessory() As Accessory
			Get
				Return accessory_Renamed
			End Get
			Set(ByVal value As Accessory)
				SetPropertyValue(NameOf(Accessory), accessory_Renamed, value)
			End Set
		End Property

		#Region "Scenario 4 - Custom Lookup Property Data Source"
'INSTANT VB NOTE: The field availableAccessories was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private availableAccessories_Renamed As XPCollection(Of Accessory)
		<Browsable(False)>
		Public ReadOnly Property AvailableAccessories() As XPCollection(Of Accessory) ' Prohibits showing the AvailableAccessories collection separately
			Get
				If availableAccessories_Renamed Is Nothing Then
					' Retrieve all Accessory objects 
					availableAccessories_Renamed = New XPCollection(Of Accessory)(Session)
					' Filter the retrieved collection according to current conditions 
					RefreshAvailableAccessories()
				End If
				' Return the filtered collection of Accessory objects 
				Return availableAccessories_Renamed
			End Get
		End Property
		Private Sub RefreshAvailableAccessories()
			If availableAccessories_Renamed Is Nothing Then
				Return
			End If
			' Process the situation when the Product is not specified (see the Scenario 3 above) 
			If Product Is Nothing Then
				' Show only Global Accessories when the Product is not specified 
				availableAccessories_Renamed.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
			Else
				' Leave only the current Product's Accessories in the availableAccessories collection 
				availableAccessories_Renamed.Criteria = New BinaryOperator("Product", Product)
				If IncludeGlobalAccessories = True Then
					' Add Global Accessories 
					Dim availableGlobalAccessories As New XPCollection(Of Accessory)(Session)
					availableGlobalAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
					availableAccessories_Renamed.AddRange(availableGlobalAccessories)
				End If
			End If
			' Set null for the Accessory property to allow an end-user  
			'to set a new value from the refreshed data source 
			Accessory = Nothing
		End Sub
'INSTANT VB NOTE: The field includeGlobalAccessories was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private includeGlobalAccessories_Renamed As Boolean
		<ImmediatePostData>
		Public Property IncludeGlobalAccessories() As Boolean 'Use this attribute to refresh the Accessory
			Get
				Return includeGlobalAccessories_Renamed
			End Get
			Set(ByVal value As Boolean)
				If includeGlobalAccessories_Renamed <> value Then
					includeGlobalAccessories_Renamed = value
					If Not IsLoading Then
						' Refresh the Accessory Property data source                     
						RefreshAvailableAccessories()
						SetPropertyValue(NameOf(IncludeGlobalAccessories), includeGlobalAccessories_Renamed, value)
					End If
				End If
			End Set
		End Property
		#End Region
	End Class
End Namespace
