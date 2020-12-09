# Show-Rendering-Options-ReportViewer
Projeto de exemplo para renderizar somente as opções desejadas do ReportViewer em WebForms

![image](https://user-images.githubusercontent.com/30643035/101633305-6d686780-39fd-11eb-84db-3a1839b6c616.png)


## Método de Extensão para o ReportViewer

```vb
Imports System.Runtime.CompilerServices
Imports Microsoft.Reporting.WebForms

Public Module ReportViewerExtensions

    <Extension>
    Public Sub ShowOptionRendering(ReportViewer1 As ReportViewer, name As String, visible As Boolean)
        Dim exportOption As String = name
        Dim items = ReportViewer1.LocalReport.ListRenderingExtensions().ToList()
        Dim extension As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption, StringComparison.CurrentCultureIgnoreCase))
        If extension IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension, visible)
        End If
    End Sub

End Module
```

## Tratamento no ASPX

```vb
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
```
