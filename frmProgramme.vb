Imports Microsoft.Data.SqlClient

Public Class frmProgramme

    Dim errorProv As New ErrorProvider()

    ' Chargement du Formulaire - Initialisation
    Private Sub frmProgramme_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDeDonnee.GetBD()

        ExtraireDonneesVersListView()

    End Sub


#Region "Début Bloc fonctions | Event et modification Formulaire"

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

    Private Sub ViderFormulaire()
        mtbNoProgramme.Clear()
        txtBoxNom.Clear()
        mtbNbrUnites.Clear()
        mtbNbrHeures.Clear()
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

#End Region

#Region "Début Bloc fonctions | Action vers la DB - CRUD"

    'Create
    Private Sub InsererNouveauProgramme()

        Dim nbrHeures As Integer

        If mtbNbrHeures.Text.Length = 0 Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_Programme (pro_no, pro_nom, pro_nbr_unites) Values(@pro_no, @pro_nom, @pro_nbr_unites)", New Object() {
                        mtbNoProgramme.Text,
                        txtBoxNom.Text,
                        Convert.ToDecimal(mtbNbrUnites.Text)
                    })

        Else
            nbrHeures = Convert.ToInt32(mtbNbrHeures.Text)

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_Programme (pro_no, pro_nom, pro_nbr_unites, pro_nbr_heures) Values(@pro_no, @pro_nom, @pro_nbr_unites, @pro_nbr_heures)", New Object() {
                        mtbNoProgramme.Text,
                        txtBoxNom.Text,
                        Convert.ToDecimal(mtbNbrUnites.Text),
                        nbrHeures
                    })
        End If



        ViderFormulaire()

    End Sub

    'Read
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

    'Update
    Private Sub UpdateProgramme()
        BaseDeDonnee.GetBD().Query("UPDATE dbo.T_Programme SET pro_nom=@pro_nom, pro_nbr_unites=@pro_nbr_unites, pro_nbr_heures=@pro_nbr_heures WHERE pro_no=@pro_no", New Object() {
            txtBoxNom.Text,
            Convert.ToSingle(mtbNbrUnites.Text),
            Convert.ToInt32(mtbNbrHeures.Text),
            mtbNoProgramme.Text
        })
    End Sub

    'Delete
    Private Sub SupprimerProgramme(noProgramme As String, nomProg As String)

        BaseDeDonnee.GetBD().Query("DELETE FROM dbo.T_Programme WHERE pro_no=@pro_no", New Object() {noProgramme})
        MsgBox("Le cours No : " & noProgramme & vbCrLf & "Du nom de : " & nomProg & vbCrLf & "A été supprimé avec succès", Title:="Succès")
        ExtraireDonneesVersListView()

    End Sub

#End Region

#Region "Début Bloc fonctions | Action des Boutons Click"
    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click, btnNouveau.Click

        BarrerControles(btnModifier, btnEnlever, btnNouveau, lvProgramme)
        DebarrerControles(btnOK, btnAnnuler, gbProgramme)

        ViderFormulaire()
        mtbNoProgramme.Focus()

        btnOK.Tag = "Nouveau"

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

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click

        btnOK.Tag = "Modifier"

        DebarrerControles(btnOK, btnAnnuler, gbProgramme)
        BarrerControles(btnModifier, btnEnlever, btnNouveau, lvProgramme, mtbNoProgramme)

    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click

        DebarrerControles(btnModifier, btnEnlever, btnNouveau, lvProgramme)
        BarrerControles(btnOK, btnAnnuler, gbProgramme)

        ViderFormulaire()

        If lvProgramme.Items.Count > 0 Then

            lvProgramme.SelectedIndices.Add(0)
            lvProgramme.Focus()

        End If

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

#End Region

#Region "Début Bloc fonctions | Validated - Validating"


    Private Sub mtbNoProgramme_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtbNoProgramme.Validating
        If mtbNoProgramme.Text.Length < 6 Then
            errorProv.SetError(mtbNoProgramme, "Le No de programme doit contenir 6 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub mtbNoProgramme_Validated(sender As Object, e As EventArgs) Handles mtbNoProgramme.Validated
        errorProv.SetError(mtbNoProgramme, String.Empty)
    End Sub

    Private Sub txtBoxNom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBoxNom.Validating
        If txtBoxNom.Text.Length < 3 Then
            errorProv.SetError(txtBoxNom, "Le nom du programme doit contenir au moins 3 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtBoxNom_Validated(sender As Object, e As EventArgs) Handles txtBoxNom.Validated
        errorProv.SetError(txtBoxNom, String.Empty)
    End Sub

    Private Sub mtbNbrUnites_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtbNbrUnites.Validating
        If mtbNbrUnites.Text.Length < 4 Then
            errorProv.SetError(mtbNbrUnites, "Le nombre d'unités du cours doit contenir au moins 4 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub mtbNbrUnites_Validated(sender As Object, e As EventArgs) Handles mtbNbrUnites.Validated
        errorProv.SetError(mtbNbrUnites, String.Empty)
    End Sub
#End Region


End Class