Imports Microsoft.Data
Imports Microsoft.Data.SqlClient

Public Class frmProgramme

    Private Sub frmProgramme_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        BaseDeDonnee.GetBD()

        ExtraireDonneesVersListView()

    End Sub

    Private Sub ExtraireDonneesVersListView()

        lvProgramme.Items.Clear()

        Dim lvi As ListViewItem

        Try

            Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_programme").GetReader()

                Do While dr.Read()

                    lvi = New ListViewItem(dr("pro_no").ToString())
                    lvi.SubItems.Add(dr("pro_nom").ToString())
                    lvi.SubItems.Add(dr("pro_nbr_unites").ToString())
                    lvi.SubItems.Add(dr("pro_nbr_heures").ToString())

                    lvProgramme.Items.Add(lvi)

                Loop

            End Using


        Catch sqlEx As SqlException
            MsgBox("Une erreur est survenue lors de la connexion en lien avec SQL : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)

        Catch ex As Exception
            MsgBox("Une erreur autre est survenue lors de la connexion : " & ex.Message)

        End Try


        If lvProgramme.Items.Count > 0 Then

            lvProgramme.SelectedIndices.Add(0)
            lvProgramme.Focus()

        End If

    End Sub

    Private Sub frmProgramme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        BaseDeDonnee.GetBD().Dispose()

    End Sub

    Private Sub lvProgramme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvProgramme.SelectedIndexChanged

        If lvProgramme.SelectedItems.Count > 0 Then

            Dim idCours As String

            idCours = lvProgramme.SelectedItems.Item(0).SubItems.Item(0).Text.ToString()

            DebarrerControles(btnModifier, btnEnlever)
            ChargerProgrammeFormulaire(idCours)
            ChargerEtudiantsListView(idCours)
        Else
            BarrerControles(btnModifier, btnEnlever)
        End If

    End Sub

    Private Sub ChargerEtudiantsListView(idCours As String)

        lvEtudiants.Items.Clear()

        Dim lvi As ListViewItem

        Try

            Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_etudiants WHERE pro_no=@pro_no", New Object() {idCours}).GetReader()

                Do While dr.Read()

                    lvi = New ListViewItem(dr("etu_da").ToString())
                    lvi.SubItems.Add(dr("pro_no").ToString())
                    lvi.SubItems.Add(dr("etu_prenom").ToString())
                    lvi.SubItems.Add(dr("etu_nom").ToString())

                    lvEtudiants.Items.Add(lvi)

                Loop

            End Using


        Catch sqlEx As SqlException
            MsgBox("Une erreur est survenue lors de la connexion en lien avec SQL : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)

        Catch ex As Exception
            MsgBox("Une erreur autre est survenue lors de la connexion : " & ex.Message)

        End Try

    End Sub

    Private Sub ChargerProgrammeFormulaire(idCours As String)


        Try

            Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_programme WHERE pro_no=@pro_no", New Object() {idCours}).GetReader()

                If dr.Read() Then

                    mtbNoProgramme.Text = dr("pro_no").ToString()
                    txtBoxNom.Text = dr("pro_nom").ToString()
                    mtbNbrUnites.Text = dr("pro_nbr_unites").ToString()
                    mtbNbrHeures.Text = dr("pro_nbr_heures").ToString()

                End If

            End Using


        Catch Sqlex As SqlException
            MsgBox("Une erreur est survenue avec SQL pour extraire les données dans le Formulaire : " & Sqlex.Message & " Numéro d'erreur : " & Sqlex.Number)

        Catch ex As Exception
            MsgBox("Une erreur est survenue pour extraire les données dans le Formulaire : " & ex.Message)


        End Try



    End Sub

    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click, btnNouveau.Click

        BarrerControles(btnModifier, btnEnlever, btnNouveau, lvProgramme)
        DebarrerControles(btnOK, btnAnnuler, gbProgramme)

        ViderFormulaire()
        mtbNoProgramme.Focus()

        btnOK.Tag = "Nouveau"

    End Sub

    Private Sub ViderFormulaire()
        mtbNoProgramme.Clear()
        txtBoxNom.Clear()
        mtbNbrUnites.Clear()
        mtbNbrHeures.Clear()
    End Sub

    Private Sub InsererNouveauProgramme()

        BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_Programme (pro_no, pro_nom, pro_nbr_unites, pro_nbr_heures) Values(@pro_no, @pro_nom, @pro_nbr_unites, @pro_nbr_heures)", New Object() {
            mtbNoProgramme.Text,
            txtBoxNom.Text,
            Convert.ToDecimal(mtbNbrUnites.Text),
            Convert.ToInt32(mtbNbrHeures.Text)
        })

        ViderFormulaire()

    End Sub

    Private Sub BarrerControles(ParamArray ctrls() As Control)

        For Each control In ctrls
            control.Enabled = False
        Next

    End Sub

    Private Sub DebarrerControles(ParamArray ctrls() As Control)

        For Each control In ctrls
            control.Enabled = True
        Next

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnOK.Click

        If btnOK.Tag = "Nouveau" Then

            Try

                InsererNouveauProgramme()

            Catch ex As Exception
                MsgBox("Une erreur est survenue lors de l'insertion du programme dans la DB : " & ex.Message)
            End Try

        ElseIf btnOK.Tag = "Modifier" Then

            Try

                UpdateProgramme()

            Catch ex As Exception

                MsgBox("Une erreur est survenue lors de la modification du programme dans la DB")

            End Try

        End If


        DebarrerControles(btnModifier, btnEnlever, btnNouveau, mtbNoProgramme, lvProgramme)
        BarrerControles(btnOK, btnAnnuler, gbProgramme)
        ExtraireDonneesVersListView()

        btnOK.Tag = ""

    End Sub

    Private Sub UpdateProgramme()
        BaseDeDonnee.GetBD().Query("UPDATE dbo.T_Programme SET pro_nom=@pro_nom, pro_nbr_unites=@pro_nbr_unites, pro_nbr_heures=@pro_nbr_heures WHERE pro_no=@pro_no", New Object() {
            txtBoxNom.Text,
            Convert.ToSingle(mtbNbrUnites.Text),
            Convert.ToInt32(mtbNbrHeures.Text),
            mtbNoProgramme.Text
        })
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click

        btnOK.Tag = "Modifier"

        DebarrerControles(btnOK, btnAnnuler, gbProgramme)
        BarrerControles(btnModifier, btnEnlever, btnNouveau, lvProgramme, mtbNoProgramme)

    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click

        DebarrerControles(btnModifier, btnEnlever, btnNouveau)
        BarrerControles(btnOK, btnAnnuler, lvProgramme)

    End Sub

    Private Sub btnEnlever_Click(sender As Object, e As EventArgs) Handles btnEnlever.Click

        If lvEtudiants.Items.Count > 0 Then
            MsgBox("Ce programme contient des étudiants, vous ne pouvez pas le supprimer", Title:="Action interdite")
        Else
            Dim suppression As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer le cours No : " & mtbNoProgramme.Text, "Suppression", MessageBoxButtons.YesNo)

            If suppression = DialogResult.Yes Then

                SupprimerProgramme(mtbNoProgramme.Text, txtBoxNom.Text)

            End If
        End If

    End Sub

    Private Sub SupprimerProgramme(noProgramme As String, nomProg As String)

        BaseDeDonnee.GetBD().Query("DELETE FROM dbo.T_Programme WHERE pro_no=@pro_no", New Object() {noProgramme})
        MsgBox("Le cours No : " & noProgramme & vbCrLf & "Du nom de : " & nomProg & vbCrLf & "A été supprimé avec succès", Title:="Succès")
        ExtraireDonneesVersListView()

    End Sub
End Class