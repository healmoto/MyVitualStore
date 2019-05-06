Imports System.Web
Imports System.Web.UI
Imports System.Text

Public Class Utilidad

    Public Shared Sub Alert(ByVal page As Page, ByVal Mensaje As String, ByVal sUrl As String)
        Dim sJscrpt As StringBuilder = New StringBuilder("")

        If (Mensaje <> "" And Not IsNothing(page)) Then
            Mensaje = Mensaje.Replace("'", "").Replace("''", "")
            Mensaje = Mensaje.Replace("\\r\\n", "")
            sJscrpt.Append("<script language=javascript> ")
            sJscrpt.Append("alert('" + Mensaje + "'); ")
            If (sUrl <> "") Then
                sJscrpt.Append("document.location.href('" + sUrl + "'); ")
            End If
            sJscrpt.Append("</script>")

            If (Not page.ClientScript.IsClientScriptBlockRegistered("Mensaje")) Then
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "Mensaje", sJscrpt.ToString(), False)
            End If
                

        End If


    End Sub


            

End Class
