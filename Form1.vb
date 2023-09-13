Public Class frmPrincipal

    Private Sub ProgrammeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgrammeToolStripMenuItem.Click

        Dim childFrmProgramme As frmProgramme = New frmProgramme

        childFrmProgramme.Show(Me)

    End Sub


End Class
