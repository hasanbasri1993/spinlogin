Public Class Form1
    Dim con As New OleDb.OleDbConnection
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String
    Dim inc As Integer
    Dim MaxRows As Integer
    Dim max As String

    Private Sub Spin_Indi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Spin_Indi.Click
        WebBrowser1.Navigate("http://welcome.indonesiawifi.net/wifi.id/spin_indi/?switch_url=http://1.1.1.1/login.html")
    End Sub

    Private Sub Spin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Spin.Click
        WebBrowser1.Navigate("http://welcome.indonesiawifi.net/wifi.id/spin/?switch_url=http://1.1.1.1/login.html")
    End Sub

    Private Sub Speedy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Speedy.Click
        WebBrowser1.Navigate("http://welcome.indonesiawifi.net/wifi.id/speedy/?switch_url=http://1.1.1.1/login.html")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebBrowser1.Document.GetElementById("username-login").SetAttribute("Value", TextBox1.Text)
        WebBrowser1.Document.GetElementById("pass-login").SetAttribute("Value", TextBox2.Text)




    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SpinDataSet.Spin' table. You can move, or remove it, as needed.
        Me.SpinTableAdapter.Fill(Me.SpinDataSet.Spin)
        WebBrowser1.ScriptErrorsSuppressed = True
        Dim x As Integer
        con.ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source = spin.mdb"

        sql = "SELECT * FROM Spin"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "Spin")
        max = ds.Tables("Spin").Rows.Count
        For x = 0 To 20
            ComboBox1.Items.Add(ds.Tables("Spin").Rows(ComboBox1.SelectedIndex).Item(1) + "  " + ds.Tables("Spin").Rows(ComboBox1.SelectedIndex).Item(2))
        Next
        con.Close()

        MaxRows = ds.Tables("Spin").Rows.Count
        inc = -1


       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ds.Tables("Spin").Rows(ComboBox1.SelectedIndex).Item(1)
        TextBox2.Text = ds.Tables("Spin").Rows(ComboBox1.SelectedIndex).Item(2)
    End Sub

End Class
