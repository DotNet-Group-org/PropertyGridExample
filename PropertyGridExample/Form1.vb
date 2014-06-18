Imports System.Xml

Public Class Form1

    ' PropertyGridExample
    '
    ' written by Richard L Rosenheim
    '            richard@rosenheims.com
    '
    ' © Copyright 2007, Richard L Rosenheim
    ' All rights reserved

    Private Sub lbStates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStates.SelectedIndexChanged
        pgStates.SelectedObject = lbStates.SelectedItem
    End Sub

    Private Sub mnuFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        openFileDialog1.Filter = "xml files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.CheckFileExists = True
        openFileDialog1.CheckPathExists = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            LoadStateInfo(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        End
    End Sub

    Private Sub LoadStateInfo(ByVal filename As String)
        If IO.File.Exists(filename) Then
            Try
                Dim doc As New Xml.XmlDocument
                Dim states As Xml.XmlNodeList
                Dim info As classStateInfo
                Dim sName As String
                Dim sAbbr As String
                Dim sBird As String
                Dim sTree As String
                Dim sFlower As String
                Dim sRegion As String

                doc.Load(filename)

                If doc.HasChildNodes Then
                    lbStates.Items.Clear()

                    states = doc.SelectNodes("//states/state")
                    For Each state As Xml.XmlElement In states
                        sName = state.GetAttribute("stateName")
                        sAbbr = state.GetAttribute("stateAbbr")
                        sBird = state.GetAttribute("bird")
                        sTree = state.GetAttribute("tree")
                        sFlower = state.GetAttribute("flower")
                        sRegion = state.GetAttribute("region")

                        info = New classStateInfo(sName, sAbbr, sBird, sTree, sFlower, sRegion)
                        AddHandler info.NameChanged, AddressOf NameChangedHandler

                        lbStates.Items.Add(info)
                    Next

                    If lbStates.Items.Count > 0 Then
                        lbStates.Enabled = True
                        pgStates.Enabled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading xml data from the specified file.")
            End Try
        End If
    End Sub

    Private Sub NameChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        ' the name of the state has been changed.  need to delete the current state in the listbox and recreate it
        Dim stateInfo As classStateInfo

        stateInfo = lbStates.SelectedItem
        lbStates.Items.Remove(stateInfo)
        lbStates.SelectedIndex = lbStates.Items.Add(stateInfo)
    End Sub

End Class
