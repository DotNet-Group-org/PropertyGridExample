Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.design

<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", _
              GetType(Design.IDesigner))> _
Public Class classStateInfo

    ' PropertyGridExample
    '
    ' written by Richard L Rosenheim
    '            richard@rosenheims.com
    '
    ' © Copyright 2007, Richard L Rosenheim
    ' All rights reserved


    Public Enum Region
        Northeast
        MidAtlantic
        Southeast
        Midwest
        Southwest
        Northwest
        West
    End Enum

    Private m_stateName As String
    Private m_stateAbbr As String
    Private m_stateTree As String
    Private m_stateBird As String
    Private m_stateFlower As String
    Private m_stateRegion As String

    Public Event NameChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Public Sub New()
        m_stateName = String.Empty
        m_stateAbbr = String.Empty
        m_stateTree = String.Empty
        m_stateBird = String.Empty
        m_stateFlower = String.Empty
    End Sub

    Public Sub New(ByVal stateName As String, ByVal stateAbbr As String, _
                   ByVal stateTree As String, ByVal stateBird As String, _
                   ByVal stateFlower As String, ByVal stateRegion As String)
        m_stateName = stateName
        m_stateAbbr = stateAbbr
        m_stateTree = stateTree
        m_stateBird = stateBird
        m_stateFlower = stateFlower

        Try
            m_stateRegion = System.Enum.Parse(GetType(Region), stateRegion)
        Catch ex As Exception
            m_stateRegion = Region.West
        End Try
    End Sub

    <CategoryAttribute("Information"), _
      DescriptionAttribute("The name of the state.")> _
      Public Property stateName() As String
        Get
            Return m_stateName
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                m_stateName = value

                RaiseEvent NameChanged(Me, New System.EventArgs())
            End If
        End Set
    End Property

    <CategoryAttribute("Information"), _
      DescriptionAttribute("The abbreviation of the state.")> _
    Public Property stateAbbr() As String
        Get
            Return m_stateAbbr
        End Get
        Set(ByVal value As String)
            m_stateAbbr = value
        End Set
    End Property

    <CategoryAttribute("Triva"), _
      DescriptionAttribute("The official tree of the state.")> _
    Public Property stateTree() As String
        Get
            Return m_stateTree
        End Get
        Set(ByVal value As String)
            m_stateTree = value
        End Set
    End Property

    <CategoryAttribute("Triva"), _
      DescriptionAttribute("The official bird of the state.")> _
    Public Property stateBird() As String
        Get
            Return m_stateBird
        End Get
        Set(ByVal value As String)
            m_stateBird = value
        End Set
    End Property

    <CategoryAttribute("Triva"), _
      DescriptionAttribute("The official flower of the state.")> _
    Public Property stateFlower() As String
        Get
            Return m_stateFlower
        End Get
        Set(ByVal value As String)
            m_stateFlower = value
        End Set
    End Property

    <CategoryAttribute("Location"), _
      DescriptionAttribute("The region of the state's location.")> _
    Public Property stateRegion() As Region
        Get
            Return m_stateRegion
        End Get
        Set(ByVal value As Region)
            m_stateRegion = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return m_stateName
    End Function

End Class
