﻿Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Test code.
            Dim aquarium As New Aquarium With {
                .AquariumGraphic = New Uri("http://www.contoso.com/aquarium-graphic-new.jpg")
            }
            Debug.WriteLine($"Aquarium graphic: {aquarium.AquariumGraphic}")
        End Sub

        ' Output:
        ' OnUriChanged http://www.contoso.com/aquarium-graphic-new.jpg
        ' Aquarium graphic: http://www.contoso.com/aquarium-graphic-new.jpg
    End Class

    Public Class Aquarium
        Inherits DependencyObject

        '<RegisterDependencyPropertyWithWrapper>
        '<RegisterDependencyProperty>
        ' Register a dependency property with the specified property name,
        ' property type, owner type, and property metadata. Store the dependency
        ' property identifier as a public static readonly member of the class.
        Public Shared ReadOnly AquariumGraphicProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="AquariumGraphic",
                propertyType:=GetType(Uri),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=New Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    flags:=FrameworkPropertyMetadataOptions.AffectsRender,
                    propertyChangedCallback:=New PropertyChangedCallback(AddressOf OnUriChanged)))
        '</RegisterDependencyProperty>

        ' Declare a read-write property wrapper.
        Public Property AquariumGraphic As Uri
            Get
                Return CType(GetValue(AquariumGraphicProperty), Uri)
            End Get
            Set
                SetValue(AquariumGraphicProperty, Value)
            End Set
        End Property
        '</RegisterDependencyPropertyWithWrapper>

        Private Shared Sub OnUriChanged(dependencyObject As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim value As Uri = CType(dependencyObject.GetValue(AquariumGraphicProperty), Uri)
            Debug.WriteLine($"OnUriChanged: {value}")
        End Sub

    End Class

End Namespace
