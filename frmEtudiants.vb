Imports Microsoft.Data.SqlClient

Public Class frmEtudiants

    Dim errorProv As New ErrorProvider()

    ' Chargement du Formulaire - Initialisation
    Private Sub frmEtudiants_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDeDonnee.GetBD()

        InitialiserNoProg()

        ExtraireDonneesVersListViewEtu()

        If lvEtudiantsEtu.Items.Count > 0 Then

            lvEtudiantsEtu.SelectedIndices.Add(0)
            lvEtudiantsEtu.Focus()

        End If

    End Sub

#Region "Début Bloc fonctions | Event et modification Formulaire"

    Private Sub lvEtudiantsEtu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvEtudiantsEtu.SelectedIndexChanged

        If lvEtudiantsEtu.SelectedItems.Count > 0 Then

            Dim idEtudiant As Integer

            idEtudiant = lvEtudiantsEtu.SelectedItems.Item(0).SubItems.Item(0).Text

            ChargerEtudiantFormulaire(idEtudiant)
            DebarrerControles(btnEnlever, btnModifier)

        Else
            BarrerControles(btnEnlever, btnModifier)
        End If

    End Sub

    Private Sub ViderFormulaire()

        mtbNoDAEtu.Clear()
        txtboxPrenomEtu.Clear()
        txtBoxNomEtu.Clear()
        txtBoxAdresseEtu.Clear()
        txtBoxVilleEtu.Clear()
        mtbCPEtu.Clear()
        mtbTelEtu.Clear()
        rbMasculinEtu.Checked = False
        rbFemininEtu.Checked = False

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
    Private Sub InsererNouvelEtudiant()

        Dim sexeEtudiant As Char

        Dim cpCount As Integer = mtbCPEtu.Text.Length
        Dim telCount As Integer = mtbTelEtu.Text.Length
        Dim province As String

        If cbProvinceEtu.SelectedItem = Nothing Then
            province = "Québec"
        Else
            province = cbProvinceEtu.SelectedItem.ToString()
        End If


        If rbFemininEtu.Checked Then
            sexeEtudiant = "F"
        ElseIf rbMasculinEtu.Checked Then
            sexeEtudiant = "M"
        Else
            sexeEtudiant = "X"
        End If



        If cpCount < 7 AndAlso telCount < 14 AndAlso sexeEtudiant = "X" Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_adresse, etu_ville, etu_province) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_adresse, @etu_ville, @etu_province)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province
           })

        ElseIf cpCount < 7 AndAlso sexeEtudiant = "X" Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_adresse, etu_ville, etu_province, etu_telephone) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_adresse, @etu_ville, @etu_province, @etu_telephone)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbTelEtu.Text
           })

        ElseIf telCount < 14 AndAlso sexeEtudiant = "X" Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_adresse, etu_ville, etu_province, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_adresse, @etu_ville, @etu_province, @etu_codepostal)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbCPEtu.Text.ToUpper()
           })

        ElseIf telCount < 14 Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_codepostal)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            sexeEtudiant,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbCPEtu.Text.ToUpper()
           })

        ElseIf cpCount < 7 Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_telephone) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_telephone)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            sexeEtudiant,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbTelEtu.Text
           })

        ElseIf sexeEtudiant = "X" Then

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_adresse, etu_ville, etu_province, etu_telephone, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_adresse, @etu_ville, @etu_province, @etu_telephone, @etu_codepostal)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbTelEtu.Text,
            mtbCPEtu.Text.ToUpper()
           })
        Else

            BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_telephone, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_telephone, @etu_codepostal)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            sexeEtudiant,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            province,
            mtbTelEtu.Text,
            mtbCPEtu.Text.ToUpper()
           })


        End If

    End Sub

    'Read
    Private Sub ExtraireDonneesVersListViewEtu()

        lvEtudiantsEtu.Items.Clear()

        Dim lvi As ListViewItem

        Try

            Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_etudiants").GetReader()

                Do While dr.Read()

                    lvi = New ListViewItem(dr("etu_da").ToString())
                    lvi.SubItems.Add(dr("pro_no").ToString())
                    lvi.SubItems.Add(dr("etu_nom").ToString())
                    lvi.SubItems.Add(dr("etu_prenom").ToString())
                    lvi.SubItems.Add(dr("etu_sexe").ToString())
                    lvi.SubItems.Add(dr("etu_adresse").ToString())
                    lvi.SubItems.Add(dr("etu_ville").ToString())
                    lvi.SubItems.Add(dr("etu_codepostal").ToString())
                    lvi.SubItems.Add(dr("etu_telephone").ToString())
                    lvi.SubItems.Add(dr("etu_province").ToString())

                    lvEtudiantsEtu.Items.Add(lvi)

                Loop

            End Using


        Catch sqlEx As SqlException
            MsgBox("Une erreur est survenue lors de la connexion en lien avec SQL : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)

        Catch ex As Exception
            MsgBox("Une erreur autre est survenue lors de la connexion : " & ex.Message)

        End Try

    End Sub

    Private Sub ChargerEtudiantFormulaire(idEtudiant As Integer)

        Try

            Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_etudiants WHERE etu_da=@etu_da", New Object() {idEtudiant}).GetReader()

                If dr.Read() Then

                    mtbNoDAEtu.Text = dr("etu_da").ToString()
                    cbNoProgrammeEtu.Text = dr("pro_no").ToString()
                    txtboxPrenomEtu.Text = dr("etu_prenom").ToString()
                    txtBoxNomEtu.Text = dr("etu_nom").ToString()
                    txtBoxAdresseEtu.Text = dr("etu_adresse").ToString()
                    txtBoxVilleEtu.Text = dr("etu_ville").ToString()
                    cbProvinceEtu.Text = dr("etu_province").ToString()
                    mtbCPEtu.Text = dr("etu_codepostal").ToString()
                    mtbTelEtu.Text = dr("etu_telephone").ToString()


                    'Tentative de convertir char du sexe de l'étudiant en string, sinon nothing
                    Dim sexe As Char = TryCast(dr("etu_sexe"), String)

                    If sexe = "M" Then
                        rbMasculinEtu.Checked = True
                    ElseIf sexe = "F" Then
                        rbFemininEtu.Checked = True
                    Else
                        rbMasculinEtu.Checked = False
                        rbFemininEtu.Checked = False
                    End If

                End If

            End Using

        Catch Sqlex As SqlException
            MsgBox("Une erreur est survenue avec SQL pour extraire les données dans le Formulaire : " & Sqlex.Message & " Numéro d'erreur : " & Sqlex.Number)

        Catch ex As Exception
            MsgBox("Une erreur est survenue pour extraire les données dans le Formulaire : " & ex.Message)

        End Try

    End Sub

    Private Sub InitialiserNoProg()

        Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_programme").GetReader()

            Do While dr.Read()
                cbNoProgrammeEtu.Items.Add(dr("pro_no"))
            Loop

        End Using

    End Sub

    'Update
    Private Sub UpdateEtudiant()

        Dim sexeEtudiant As Char

        If rbFemininEtu.Checked Then
            sexeEtudiant = "F"
        ElseIf rbMasculinEtu.Checked Then
            sexeEtudiant = "M"
        End If

        BaseDeDonnee.GetBD().Query(
            "UPDATE dbo.T_etudiants SET pro_no=@pro_no, etu_nom=@etu_nom, 
            etu_prenom=@etu_prenom, etu_sexe=@etu_sexe, etu_adresse=@etu_adresse, 
            etu_ville=@etu_ville, etu_province=@etu_province, etu_codepostal=@etu_codepostal, etu_telephone=@etu_telephone WHERE etu_da=@etu_da", New Object() {
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            sexeEtudiant,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            cbProvinceEtu.SelectedItem.ToString(),
            mtbCPEtu.Text,
            mtbTelEtu.Text,
            mtbNoDAEtu.Text
                                                                                                                                                  })

    End Sub

    'Delete
    Private Sub supprimerEtudiant(daEtu As String, prenomEtu As String, nomEtu As String)
        BaseDeDonnee.GetBD().Query("DELETE FROM dbo.T_etudiants WHERE etu_da=@etu_da", New Object() {daEtu})
        ExtraireDonneesVersListViewEtu()
    End Sub

#End Region

#Region "Début Bloc fonctions | Action des Boutons Click"

    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant, gbSexeEtu, mtbNoDAEtu)
        BarrerControles(btnNouveau, btnModifier, btnEnlever, lvEtudiantsEtu)
        ViderFormulaire()

        btnOK.Tag = "Nouveau"

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If btnOK.Tag = "Nouveau" Then

            Try

                InsererNouvelEtudiant()

            Catch ex As Exception
                MsgBox("Une erreur est survenue lors de l'insertion du programme dans la DB : " & ex.Message)
            End Try

        ElseIf btnOK.Tag = "Modifier" Then

            Try

                UpdateEtudiant()

            Catch ex As Exception

                MsgBox("Une erreur est survenue lors de la modification du programme dans la DB")

            End Try

        End If


        DebarrerControles(btnNouveau, btnEnlever, btnModifier, lvEtudiantsEtu)
        BarrerControles(btnOK, btnAnnuler, gbEtudiant, mtbNoDAEtu)
        ExtraireDonneesVersListViewEtu()

        btnOK.Tag = ""

    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant, gbSexeEtu)
        BarrerControles(btnNouveau, btnModifier, btnEnlever, lvEtudiantsEtu)

        btnOK.Tag = "Modifier"

    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click

        DebarrerControles(btnModifier, btnEnlever, btnNouveau, lvEtudiantsEtu)
        BarrerControles(btnOK, btnAnnuler, gbEtudiant)

        ViderFormulaire()

        If lvEtudiantsEtu.Items.Count > 0 Then

            lvEtudiantsEtu.SelectedIndices.Add(0)
            lvEtudiantsEtu.Focus()

        End If

    End Sub

    Private Sub btnEnlever_Click(sender As Object, e As EventArgs) Handles btnEnlever.Click

        Dim suppression As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'étudiant : " & txtboxPrenomEtu.Text & " " & txtBoxNomEtu.Text & vbCrLf & "DA : " & mtbNoDAEtu.Text, "Suppression", MessageBoxButtons.YesNo)

        If suppression = DialogResult.Yes Then

            supprimerEtudiant(mtbNoDAEtu.Text, txtboxPrenomEtu.Text, txtBoxNomEtu.Text)

        End If

    End Sub

#End Region

#Region "Début Bloc fonctions | Validated - Validating"

    Private Sub mtbNoDAEtu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mtbNoDAEtu.Validating
        If mtbNoDAEtu.Text.Length < 7 Then
            errorProv.SetError(mtbNoDAEtu, "Le numéro de DA de l'étudiant doit contenir 7 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub mtbNoDAEtu_Validated(sender As Object, e As EventArgs) Handles mtbNoDAEtu.Validated
        errorProv.SetError(mtbNoDAEtu, String.Empty)
    End Sub

    Private Sub txtboxPrenomEtu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtboxPrenomEtu.Validating
        If txtboxPrenomEtu.Text.Length < 2 Then
            errorProv.SetError(txtboxPrenomEtu, "Le prénom de l'étudiant doit au moins contenir 2 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtboxPrenomEtu_Validated(sender As Object, e As EventArgs) Handles txtboxPrenomEtu.Validated
        errorProv.SetError(txtboxPrenomEtu, String.Empty)
    End Sub

    Private Sub txtBoxNomEtu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBoxNomEtu.Validating
        If txtBoxNomEtu.Text.Length < 2 Then
            errorProv.SetError(txtBoxNomEtu, "Le nom de l'étudiant doit au moins contenir 2 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtBoxNomEtu_Validated(sender As Object, e As EventArgs) Handles txtBoxNomEtu.Validated
        errorProv.SetError(txtBoxNomEtu, String.Empty)
    End Sub

    Private Sub cbNoProgrammeEtu_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbNoProgrammeEtu.Validating
        If cbNoProgrammeEtu.Text.Length < 6 Then
            errorProv.SetError(cbNoProgrammeEtu, "Le numéro de programme doit contenir 6 caractères")
            e.Cancel = True
        End If
    End Sub

    Private Sub cbNoProgrammeEtu_Validated(sender As Object, e As EventArgs) Handles cbNoProgrammeEtu.Validated
        errorProv.SetError(cbNoProgrammeEtu, String.Empty)
    End Sub

#End Region









End Class