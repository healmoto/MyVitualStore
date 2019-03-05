

Public Class PersistenciaException
    Inherits Exception

    Sub New()

    End Sub

    Sub New(ByVal Mensaje As String)
        MyBase.New(Mensaje)
    End Sub

    Sub New(ByVal mensaje As String, ByVal ex As Exception)
        MyBase.New(mensaje, ex)
    End Sub

    Public ReadOnly Property NumeroError() As String
        Get
            Return String.Format("{0}{1}{2}{3}{4}{5}{6}.txt", Date.Now.Year.ToString, _
                                  Date.Now.Month.ToString, Date.Now.Day.ToString, Date.Now.Hour.ToString, _
                                   Date.Now.Second.ToString, Date.Now.Millisecond.ToString)
        End Get
    End Property

End Class
