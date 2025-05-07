Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form

    'Global Variables
    Dim filename As String
    Dim copilot As Object


	Private Sub Cmd1553_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmd1553.Click
        'Variable Declaration
        Dim field As Object
		Dim sa As Object
		Dim rt As Object
		Dim chan As Object
		Dim card As Object
        Dim bOpenDialog As Boolean
        Dim msgText As String
        msgText = "Error! No SubAddress fields found on Core 0."

        If copilot.Equals(Nothing) Then
            Call MsgBox("Error! CoPilot Application has been closed", MsgBoxStyle.SystemModal And MsgBoxStyle.Information, "Result")
            Exit Sub
        End If

        If filename = "" Then
            filename = "Project1.cpj"
        End If

        'Open the example project if necessary
        If (copilot.CurProject = "") Then
            bOpenDialog = True
        ElseIf MsgBoxResult.Yes = MsgBox("A project is opened. Open a new project?", MsgBoxStyle.YesNo, "Open CoPilot Project") Then
            bOpenDialog = True
        Else
            bOpenDialog = False
        End If

        If bOpenDialog = True Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "CoPilot Project|*.cpj"
            openFileDialog1.Title = "Select a CoPilot Project File"

            ' Show the Dialog.
            ' If the user clicked OK in the dialog and a file was selected, open it.
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                filename = openFileDialog1.FileName
            End If

            Call copilot.Open(filename, True)
            copilot.Visible = True
        End If

        'Find the target object and value
        If copilot.cards.count Then
            For Each card In copilot.cards
                If card.Description <> "" Then
                    Dim count As Integer
                    count = card.CoreCount

                    'THIS ASSUMES CORE 0

                    If card.Chan1553s.count Then
                        For Each chan In card.Chan1553s
                            If chan.RTs.count Then
                                For Each rt In chan.RTs
                                    If rt.SAs.count Then
                                        For Each sa In rt.SAs
                                            If sa.Field1553s.count Then
                                                For Each field In sa.Field1553s
                                                    If field.Name = "Latitude" Then
                                                        'Format the result string
                                                        msgText = "Latitude Field Found!" & vbNewLine
                                                        msgText = msgText & "Card: " & card.Description & vbNewLine
                                                        msgText = msgText & "Channel #" & chan.ChanNum & ": " & chan.Description & vbNewLine
                                                        msgText = msgText & "RT #" & rt.RTNum & ": " & rt.Name & vbNewLine
                                                        msgText = msgText & "SA #" & sa.SANum & ": " & sa.Name & vbNewLine
                                                        msgText = msgText & "Field: " & field.Name & vbNewLine
                                                        msgText = msgText & "Value: " & field.Value & " " & field.Units
                                                    Else
                                                        'Format the result string
                                                        msgText = "Card: " & card.Description & vbNewLine
                                                        msgText = msgText & "Channel #" & chan.ChanNum & ": " & chan.Description & vbNewLine
                                                        msgText = msgText & "RT #" & rt.RTNum & ": " & rt.Name & vbNewLine
                                                        msgText = msgText & "SA #" & sa.SANum & ": " & sa.Name & vbNewLine
                                                        msgText = msgText & "Field: " & field.Name & vbNewLine
                                                        msgText = msgText & "Value: " & field.Value & " " & field.Units
                                                    End If

                                                    'Do not continue looping through all fields
                                                    Exit For

                                                Next field
                                            End If
                                        Next sa
                                    End If
                                Next rt
                            End If
                        Next chan
                    End If

                End If
            Next card
        End If

        'Show the message
        Call MsgBox(msgText, MsgBoxStyle.SystemModal And MsgBoxStyle.Information, "Result")
    End Sub
	
	Private Sub Cmd429_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmd429.Click
        'Variable Declaration
        Dim Label As Object
		Dim chan As Object
		Dim card As Object
        Dim bOpenDialog As Boolean
        Dim msgText As String

        msgText = "Error! No ARINC 429 labels found on Core 0."

        If copilot.Equals(Nothing) Then
            Call MsgBox("Error! CoPilot Application has been closed", MsgBoxStyle.SystemModal And MsgBoxStyle.Information, "Result")
            Exit Sub
        End If

        If filename = "" Then
            filename = "Project1.cpj"
        End If

        'Open the example project if necessary
        If (copilot.CurProject = "") Then
            bOpenDialog = True
        ElseIf MsgBoxResult.Yes = MsgBox("A project is opened. Open a new project?", MsgBoxStyle.YesNo, "Open CoPilot Project") Then
            bOpenDialog = True
        Else
            bOpenDialog = False
        End If

        If bOpenDialog = True Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "CoPilot Project|*.cpj"
            openFileDialog1.Title = "Select a CoPilot Project File"

            ' Show the Dialog.
            ' If the user clicked OK in the dialog and a file was selected, open it.
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                filename = openFileDialog1.FileName
            End If

            Call copilot.Open(filename, True)
            copilot.Visible = True
        End If

        'Find the target object and value
        For Each card In copilot.cards
            If card.Description <> "" Then
                Dim count As Integer
                count = card.CoreCount

                'THIS ASSUMES CORE 0

                For Each chan In card.Chan429s
                    For Each Label In chan.Labels
                        If Label.LabelNum <> 0 Then
                            'Format the result string
                            msgText = "Card: " & card.Description & vbNewLine
                            msgText = msgText & "Channel: " & chan.Description & vbNewLine
                            msgText = msgText & "Label: " & Label.Description & vbNewLine
                            msgText = msgText & "Value: " & Label.ValueString & " " & Label.Units

                            'Do not continue looping through all labels
                            Exit For
                        End If
                    Next Label
                Next chan
            End If
        Next card

        'Show the message
        Call MsgBox(msgText, MsgBoxStyle.SystemModal And MsgBoxStyle.Information, "Result")

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Clean up any structures/objects
        If Equals(Nothing, copilot) Then
            'Do Nothing!
        Else
            ''''''''''''''''''''''''''''
            '  Optionally close CoPilot
            'copilot.Visible = False
            'Call copilot.Quit()
            ''''''''''''''''''''''''''''

            copilot = Nothing
        End If
        
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        copilot = Nothing

        'Create the CoPilot application automation object
        If Equals(Nothing, copilot) Then
            copilot = CreateObject("BallardCoPilot.CopilotShell.1")
        End If

        If copilot.Equals(Nothing) Then
            Call MsgBox("Error! CoPilot Application Object could not be created", MsgBoxStyle.SystemModal And MsgBoxStyle.Information, "Result")
            Exit Sub
        End If
    End Sub
End Class