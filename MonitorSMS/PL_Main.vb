Public Class PL_Main
    Dim _t As System.Threading.Thread
    Dim rst As System.Threading.Thread
    Dim StatusSMS As Boolean = True
    Dim numSMS As Integer = 0
    Dim CountRun As Double = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbMsg.Enabled = False
        btSend.Enabled = False
        SPSetup()
        _t = New Threading.Thread(AddressOf Run)
        _t.IsBackground = True
        _t.Start()
        rst = New Threading.Thread(AddressOf CheckRun)
        rst.IsBackground = True
        rst.Start()
    End Sub

    Public Sub SPSetup()
        On Error Resume Next
        If SerialArduino.IsOpen Then
            SerialArduino.Close()
        End If
        SerialArduino.PortName = "COM3"
        SerialArduino.BaudRate = 9600
        SerialArduino.DataBits = 8
        SerialArduino.StopBits = IO.Ports.StopBits.One
        SerialArduino.Handshake = IO.Ports.Handshake.None
        SerialArduino.Parity = IO.Ports.Parity.None
        SerialArduino.Open()
    End Sub

    Delegate Sub myMethodDelegate(ByVal [text] As String)
    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)

    Delegate Sub DelUpMsg(ByVal _Data As String)
    Public Sub UpMsg(ByVal _Data As String)
        tbMsg.Text = _Data
    End Sub

    Delegate Sub DelStatusRunProcess()
    Public Sub StatusRunProcess()
        statusRun.BackColor = IIf(statusRun.BackColor <> Color.Green, Color.Green, Color.Gainsboro)
    End Sub

    Sub myShowStringMethod(ByVal myString As String)
        txtSerialText.AppendText(myString)
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialArduino.DataReceived
        Dim str As String = SerialArduino.ReadExisting
        Invoke(myD1, str)
        Threading.Thread.Sleep(1000)
        If str.Contains("SMS sent OK") Then
            CountRun = 0
            StatusSMS = True
            _t.Abort()
            Threading.Thread.Sleep(100)
            _t = New Threading.Thread(AddressOf Run)
            _t.IsBackground = True
            _t.Start()
        End If
    End Sub

    Private Sub btSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSend.Click
        SendSMS()
    End Sub

    Public Sub SendSMS()
        If SerialArduino.IsOpen Then
            SerialArduino.Write(tbMsg.Text)
        Else
            SPSetup()
            SendSMS()
        End If
    End Sub

    Public Sub CheckRun()
        While rst.IsAlive
            If _t.IsAlive = False Then
                CountRun += 0.1
                If CountRun >= 60 Then
                    StatusSMS = True

                    _t = New Threading.Thread(AddressOf Run)
                    _t.IsBackground = True
                    _t.Start()
                End If
            End If
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Public Sub Run()
        While _t.IsAlive
            Invoke(New DelStatusRunProcess(AddressOf StatusRunProcess))
            If StatusSMS Then
                CountRun = 0
                Dim BLL_Main As BLL_Main = New BLL_Main
                Dim Dt As DataTable = BLL_Main.GetMSG
                If Dt.Rows.Count > 0 Then
                    Dim _tel As String = Dt.Rows(0)("smsPhone")
                    Dim _msg As String = Dt.Rows(0)("smsMessage")
                    If Len(_msg) <= 140 Then
                        Invoke(New DelUpMsg(AddressOf UpMsg), _tel & "*" & _msg & "#")
                        SendSMS()
                        BLL_Main.UpdateSMS(Dt.Rows(0)("smsSEQ"), 1)
                        StatusSMS = False
                        _t.Abort()
                    Else
                        BLL_Main.UpdateSMS(Dt.Rows(0)("smsSEQ"), 2)
                        StatusSMS = False
                        _t.Abort()
                    End If
                End If
            End If
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub cbManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbManual.CheckedChanged
        tbMsg.Enabled = cbManual.Checked
        btSend.Enabled = cbManual.Checked
    End Sub

    Private Sub statusRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statusRun.Click
        _t.Abort()
        Threading.Thread.Sleep(100)
        If _t.IsAlive = False Then
            StatusSMS = True
            _t = New Threading.Thread(AddressOf Run)
            _t.IsBackground = True
            _t.Start()
        End If

    End Sub
End Class
