<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PL_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PL_Main))
        Me.SerialArduino = New System.IO.Ports.SerialPort(Me.components)
        Me.txtSerialText = New System.Windows.Forms.TextBox()
        Me.tbMsg = New System.Windows.Forms.TextBox()
        Me.btSend = New System.Windows.Forms.Button()
        Me.cbManual = New System.Windows.Forms.CheckBox()
        Me.statusRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SerialArduino
        '
        Me.SerialArduino.PortName = "COM3"
        '
        'txtSerialText
        '
        Me.txtSerialText.Location = New System.Drawing.Point(291, 12)
        Me.txtSerialText.Multiline = True
        Me.txtSerialText.Name = "txtSerialText"
        Me.txtSerialText.Size = New System.Drawing.Size(469, 312)
        Me.txtSerialText.TabIndex = 7
        '
        'tbMsg
        '
        Me.tbMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMsg.Location = New System.Drawing.Point(13, 12)
        Me.tbMsg.Name = "tbMsg"
        Me.tbMsg.Size = New System.Drawing.Size(272, 26)
        Me.tbMsg.TabIndex = 8
        '
        'btSend
        '
        Me.btSend.BackColor = System.Drawing.Color.DodgerBlue
        Me.btSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSend.ForeColor = System.Drawing.Color.White
        Me.btSend.Location = New System.Drawing.Point(12, 44)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(273, 46)
        Me.btSend.TabIndex = 9
        Me.btSend.Text = "SEND"
        Me.btSend.UseVisualStyleBackColor = False
        '
        'cbManual
        '
        Me.cbManual.AutoSize = True
        Me.cbManual.Location = New System.Drawing.Point(13, 97)
        Me.cbManual.Name = "cbManual"
        Me.cbManual.Size = New System.Drawing.Size(89, 17)
        Me.cbManual.TabIndex = 10
        Me.cbManual.Text = "Manual Send"
        Me.cbManual.UseVisualStyleBackColor = True
        '
        'statusRun
        '
        Me.statusRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusRun.ForeColor = System.Drawing.Color.DimGray
        Me.statusRun.Location = New System.Drawing.Point(13, 120)
        Me.statusRun.Name = "statusRun"
        Me.statusRun.Size = New System.Drawing.Size(67, 30)
        Me.statusRun.TabIndex = 11
        Me.statusRun.Text = "RUN"
        Me.statusRun.UseVisualStyleBackColor = True
        '
        'PL_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 336)
        Me.Controls.Add(Me.statusRun)
        Me.Controls.Add(Me.cbManual)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.tbMsg)
        Me.Controls.Add(Me.txtSerialText)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PL_Main"
        Me.Text = "SMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialArduino As System.IO.Ports.SerialPort
    Friend WithEvents txtSerialText As System.Windows.Forms.TextBox
    Friend WithEvents tbMsg As System.Windows.Forms.TextBox
    Friend WithEvents btSend As System.Windows.Forms.Button
    Friend WithEvents cbManual As System.Windows.Forms.CheckBox
    Friend WithEvents statusRun As System.Windows.Forms.Button

End Class
