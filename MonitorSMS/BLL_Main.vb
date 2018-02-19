Imports DAL
Public Class BLL_Main
    Public Function GetMSG() As DataTable
        Dim _SQL As String = "SELECT TOP 1 * FROM [SMS].[dbo].[smsMain] WHERE smsStatus = 0 ORDER BY smsDate DESC"
        Return DB.ExecuteSQL(_SQL, DB.con.DB5)
    End Function

    Public Function UpdateSMS(ByVal _SEQ As Integer, ByVal _Status As Integer) As Boolean
        Dim _SQL As String = "UPDATE [SMS].[dbo].[smsMain] SET smsStatus = " & _Status & ", smsDateSend = GETDATE() WHERE smsSEQ = " & _SEQ
        Return DB.ExecuteSQL(_SQL, DB.con.DB5)
    End Function
End Class
