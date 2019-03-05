Public Class NegocioException
    Inherits Exception

    Sub New()

    End Sub

    Sub New(ByVal Mensaje As String)
        MyBase.New(Mensaje)

    End Sub

    Sub New(ByVal ex As Exception)
        MyBase.New("", ex)
    End Sub


End Class
