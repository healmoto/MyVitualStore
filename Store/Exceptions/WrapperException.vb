Imports System.Xml.Serialization

<XmlRoot("DataException")> _
Public Class WrapperException

    Private _exception As Exception

    Sub New()

    End Sub

    Sub New(ByVal ex As Exception)
        _exception = ex
    End Sub

    <XmlElement("ExceptionTypeName")> _
    Public ReadOnly Property ExceptionType() As String
        Get
            Return _exception.GetType().AssemblyQualifiedName
        End Get

    End Property



    <XmlElement("Message")> _
    Public ReadOnly Property Message() As String
        Get
            Return _exception.Message
        End Get
    End Property





    <XmlElement("Source")> _
    Public ReadOnly Property Source() As String
        Get
            Return _exception.Source
        End Get
    End Property

    <XmlElement("StackTrace")> _
    Public ReadOnly Property StackTrace() As String
        Get
            Return _exception.StackTrace
        End Get
    End Property


    <XmlElement("HelpLink")> _
       Public ReadOnly Property HelpLink() As String
        Get
            Return _exception.HelpLink
        End Get
    End Property

    <XmlIgnore()> _
    Public Property OriginalException() As Exception
        Get
            Return _exception
        End Get
        Set(ByVal value As Exception)
            _exception = value
        End Set
    End Property


End Class
