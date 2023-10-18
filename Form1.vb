Public Class frmPrincipal

    Private frmProgramme As Form = Nothing
    Private frmEtudiant As Form = Nothing
    Dim ds As New DataSet("tp_p44")

    Dim modeConnecte As Boolean

    Private Sub ProgrammeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgrammeToolStripMenuItem.Click

        If frmProgramme Is Nothing OrElse frmProgramme.IsDisposed Then

            frmProgramme = New frmProgramme(ds)
            frmProgramme.MdiParent = Me
            frmProgramme.Tag = modeConnecte
            frmProgramme.Show()

        Else

            frmProgramme.BringToFront()

        End If

    End Sub

    Private Sub ÉtudiantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÉtudiantsToolStripMenuItem.Click

        If frmEtudiant Is Nothing OrElse frmEtudiant.IsDisposed Then

            frmEtudiant = New frmEtudiants(ds)
            frmEtudiant.MdiParent = Me
            frmEtudiant.Tag = modeConnecte
            frmEtudiant.Show()

        Else

            frmEtudiant.BringToFront()

        End If



    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click

        Dim quitter As DialogResult

        quitter = MessageBox.Show("Souhaitez-vous fermer le logiciel?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If quitter = DialogResult.Yes Then
            BaseDeDonnee.GetBD().Dispose()
            Application.Exit()
        End If

    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        BaseDeDonnee.GetBD().Dispose()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If MessageBox.Show("Souhaitez-vous utiliser le mode connecté?", "Connexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            modeConnecte = True
            Me.Text = "Gestion (Mode connecté)"
        Else
            modeConnecte = False
            Me.Text = "Gestion (Mode déconnecté)"
        End If


    End Sub

End Class
