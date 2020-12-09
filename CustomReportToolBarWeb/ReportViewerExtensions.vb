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
