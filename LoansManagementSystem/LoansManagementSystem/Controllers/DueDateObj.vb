Public Class DueDateObj
    Private m_ad As Byte
    Private m_duedate As String

    Public Sub New(ad As Byte, duedate As String)
        m_ad = ad
        m_duedate = duedate

    End Sub

    Public Sub New(duedate As String)
        m_duedate = duedate
    End Sub
    Public Property ad() As Byte
        Get
            Return m_ad
        End Get
        Set(value As Byte)
            m_ad = value
        End Set
    End Property
    Public Property duedate() As String
        Get
            Return m_duedate
        End Get
        Set(value As String)
            m_duedate = value
        End Set
    End Property


End Class
