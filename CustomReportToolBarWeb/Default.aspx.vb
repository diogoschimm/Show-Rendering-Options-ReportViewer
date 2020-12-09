Imports Microsoft.Reporting.WebForms

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregarRelatorio()
        End If
    End Sub

    Private Sub CarregarRelatorio()
        ReportViewer1.LocalReport.ReportPath = "RptClientes.rdlc"
        ReportViewer1.ShowPrintButton = False
        ReportViewer1.ShowZoomControl = False
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        ReportViewer1.ShowOptionRendering("PDF", True)
        ReportViewer1.ShowOptionRendering("WORDOPENXML", False)
        ReportViewer1.ShowOptionRendering("EXCELOPENXML", True)
    End Sub

End Class