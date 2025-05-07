Option Strict Off
Option Explicit On
Friend Class Form1
    Inherits System.Windows.Forms.Form
    'Options

    'Variable Declarations
    Dim copilot As Object

    Private Sub CmdMonitor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdMonitor.Click
        Dim card, monitor As Object
        Dim record As Object
        Dim index As Short
        Dim itemStr As String

        MonRecList.Items.Clear()

        If Combo1.SelectedIndex > 0 Then
            ' Get the card object
            card = copilot.Cards.Item(VB6.GetItemData(Combo1, Combo1.SelectedIndex))

            If card Is Nothing Then
                Exit Sub
            End If

            ' MONITOR
            If card.Monitors.count Then
                For Each monitor In card.Monitors
                    index = 0
                    MonRecList.Items.Add((monitor.Description))

                    '1553 RECORD
                    If monitor.Record1553s.count Then
                        MonRecList.Items.Add("--1553 Records--")
                        For Each record In monitor.Record1553s
                            itemStr = "  " & VB6.Format(index, "0000")
                            itemStr = itemStr & " Cwd1:" & Hex(record.Cwd1)
                            itemStr = itemStr & " Swd1:" & Hex(record.Swd1)
                            'Look for no response error
                            If record.ErrorVal And &H8000S Then
                                itemStr = itemStr & " No Response!"
                            End If
                            'Add item to list
                            MonRecList.Items.Add((itemStr))
                            index = index + 1
                        Next record '1553 RECORD
                    End If

                    '429 RECORD
                    If monitor.Record429s.count Then
                        MonRecList.Items.Add("--429 Records--")
                        For Each record In monitor.Record429s
                            itemStr = "  " & VB6.Format(index, "0000")
                            itemStr = itemStr & " Label:" & VB6.Format(Oct(record.LabelNum), "000")
                            itemStr = itemStr & " " & Hex(record.MsgVal)
                            'Add item to list
                            MonRecList.Items.Add((itemStr))
                            index = index + 1
                        Next record '429 RECORD
                    End If

                    '708 RECORD
                    If monitor.Record708s.count Then
                        MonRecList.Items.Add("--708 Records--")
                        For Each record In monitor.Record708s
                            itemStr = "  " & VB6.Format(index, "0000")
                            'UPGRADE_WARNING: Couldn't resolve default property of object record.DataCount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            itemStr = itemStr & " Data Count:" & record.DataCount
                            'Add item to list
                            MonRecList.Items.Add((itemStr))
                            index = index + 1
                        Next record '708 RECORD
                    End If

                Next monitor ' MONITOR

            End If

            card = Nothing
        End If
    End Sub

    Private Sub CmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOpen.Click
        On Error GoTo ErrHandler

        'If running then stop
        'UPGRADE_WARNING: Couldn't resolve default property of object copilot.Running. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If copilot.Running Then
            'UPGRADE_WARNING: Couldn't resolve default property of object copilot.Stop. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call copilot.Stop()
        End If

        'Close the current project
        'UPGRADE_WARNING: Couldn't resolve default property of object copilot.Close. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call copilot.Close(False)

        'Browse for new project
        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        CommonDialog1Open.Filter = "CoPilot Projects (*.CPJ)|*.CPJ" ' Set Filters
        CommonDialog1Open.FilterIndex = 1 ' Specify default filter
        'UPGRADE_WARNING: Couldn't resolve default property of object copilot.ProjectDir. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        CommonDialog1Open.InitialDirectory = copilot.ProjectDir ' Specify initial path
        CommonDialog1Open.ShowDialog() ' Display the Open dialog box

        'Open new project
        If "" <> CommonDialog1Open.FileName Then
            'UPGRADE_WARNING: Couldn't resolve default property of object copilot.Open. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call copilot.Open(CommonDialog1Open.FileName, True)
            'UPGRADE_WARNING: Couldn't resolve default property of object copilot.ProjectName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TextStatus.Text = copilot.ProjectName & " - Stopped..."
        End If

        Call InitCombo()

ErrHandler:
        ' User pressed Cancel button
        Exit Sub

    End Sub

    Private Sub InitCombo()
        'Fill the combo box with boards from the project
        Dim index As Integer

        OutputList.Items.Clear()
        MonRecList.Items.Clear()

        Combo1.Items.Clear()
        Combo1.Items.Add(("Select A Card"))
        Combo1.SelectedIndex = 0

        For index = 1 To copilot.Cards.Count
            Combo1.Items.Add(New VB6.ListBoxItem((copilot.Cards.Item(index).Description & " #" & copilot.Cards.Item(index).CardNum), index))
        Next
    End Sub

    Private Sub CmdRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdRun.Click
        MonRecList.Items.Clear()
        If "" <> copilot.CurProject Then
            Call copilot.Run()
            TextStatus.Text = copilot.ProjectName & " - Running"
        Else
            Call MsgBox("No project is open.", MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub

    Private Sub CmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStop.Click
        Call copilot.Stop()
        Call RefreshOutput()

        TextStatus.Text = copilot.ProjectName & " - Stopped..."
    End Sub

    Private Sub RefreshOutput()
        Dim label, chan, card, msg, field As Object
        Dim monitor As Object
        Dim BC, RT As Object
        Dim SA As Object
        Dim recCount As Short

        OutputList.Items.Clear()

        If Combo1.SelectedIndex > 0 Then
            ' CARD
            card = copilot.Cards.Item(VB6.GetItemData(Combo1, Combo1.SelectedIndex))

            If card Is Nothing Then
                If copilot.Running Then
                    TextStatus.Text = copilot.ProjectName & " - Running " & CStr(CInt(copilot.runtime) / 1000)
                End If

                Exit Sub
            End If

            ' 1553 CHANNELS
            If card.Chan1553s.count Then
                For Each chan In card.Chan1553s
                    OutputList.Items.Add(("-- " & chan.Description))

                    ' BUS CONTROLLER
                    BC = chan.BC
                    OutputList.Items.Add(("    -- " & BC.Description))
                    ' BC MESSAGES
                    If BC.BCMsgs.count Then
                        For Each msg In BC.BCMsgs
                            OutputList.Items.Add(("      -- " & msg.Description))
                            ' FIELDS
                            If msg.Field1553s.count Then
                                For Each field In msg.Field1553s
                                    OutputList.Items.Add(("        -- " & field.Description))
                                Next field ' FIELDS
                            End If
                        Next msg ' BC MESSAGES
                        BC = Nothing
                    End If


                    ' RTS
                    If chan.RTs.count Then
                        For Each RT In chan.RTs
                            OutputList.Items.Add(("    -- " & RT.Description))
                            ' SAS
                            If RT.SAs.count Then
                                For Each SA In RT.SAs
                                    OutputList.Items.Add(("      -- " & SA.Description))
                                    ' FIELDS
                                    If SA.Field1553s.count Then
                                        For Each field In SA.Field1553s
                                            OutputList.Items.Add(("        -- " & field.Description))
                                        Next field ' FIELDS
                                    End If
                                Next SA ' SAS
                            End If
                        Next RT ' RTS
                    End If
                Next chan '1553 CHANNEL
            End If


            ' 429 CHANNEL
            If card.Chan429s.count Then
                For Each chan In card.Chan429s
                    OutputList.Items.Add(("-- " & chan.Description))
                    ' 429 LABEL
                    If chan.Labels.count Then
                        For Each label In chan.Labels
                            OutputList.Items.Add(("    -- " & label.Description))
                            ' 429 FIELDS
                            If label.Field429s.count Then
                                For Each field In label.Field429s
                                    OutputList.Items.Add(("        -- " & field.Description))
                                Next field ' 429 FIELDS
                            End If
                        Next label ' 429 LABEL
                    End If
                Next chan '429 CHANNEL
            End If

            ' 708 CHANNEL
            If card.Chan708s.count Then
                For Each chan In card.Chan708s
                    OutputList.Items.Add(("-- " & chan.Description))
                Next chan ' 708 CHANNEL
            End If

            ' MONITOR
            If card.Monitors.count Then
                For Each monitor In card.Monitors
                    recCount = 0
                    recCount = recCount + monitor.Record1553s.Count
                    recCount = recCount + monitor.Record429s.Count
                    recCount = recCount + monitor.Record708s.Count
                    OutputList.Items.Add(("-- " & monitor.Description & " (" & recCount & ")"))
                Next monitor ' MONITOR
            End If

            card = Nothing
        End If

        If copilot.Running Then
            TextStatus.Text = copilot.ProjectName & " - Running " & CStr(CInt(copilot.runtime) / 1000)
        End If

    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
        Call RefreshOutput()
        MonRecList.Items.Clear()
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Create the CoPilot application automation object
        copilot = CreateObject("BallardCoPilot.CopilotShell.1")
        'Verify copilot was created
        If copilot Is Nothing Then
            MsgBox("Unable to create CoPilot. Application will close.")
            'End the application
            End
        End If
        'Init the status text
        TextStatus.Text = "Open a project..."
        'Init the board combo box
        Combo1.Items.Clear()
        'Init the OutputList
        OutputList.Items.Clear()
        'Init the MonRecList
        MonRecList.Items.Clear()
    End Sub

    Private Sub Form_Terminate_Renamed()
        ' Clean up any structures/objects
        If Not copilot Is Nothing Then
            'The following line stops CoPilot from running
            'Call copilot.Stop()

            'The following line closes CoPilot
            'Call copilot.Quit()

            copilot = Nothing
        End If

    End Sub

    Public Sub MenuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MenuFileExit.Click
        ' Clean up any structures/objects
        Form_Terminate_Renamed()
        ' End the application
        End
    End Sub

    Public Sub MenuProjectOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MenuProjectOpen.Click
        'CmdOpen.Item(0)
        CmdOpen_Click(eventSender, New System.EventArgs())
    End Sub

    Public Sub MenuProjectRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MenuProjectRun.Click
        'CmdRun.Item(0)
        CmdRun_Click(eventSender, New System.EventArgs())
    End Sub

    Public Sub MenuProjectStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MenuProjectStop.Click
        'CmdStop.Item(0)
        CmdStop_Click(eventSender, New System.EventArgs())
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If Not copilot Is Nothing Then
            If copilot.Running Then
                Call RefreshOutput()
            End If
        End If
    End Sub

End Class