Imports Microsoft.Data.SqlClient

Public Class frmEtudiants
    Private Sub frmEtudiants_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDeDonnee.GetBD()

        InitialiserNoProg()

        ExtraireDonneesVersListViewEtu()

        If lvEtudiantsEtu.Items.Count > 0 Then

            lvEtudiantsEtu.SelectedIndices.Add(0)
            lvEtudiantsEtu.Focus()

        End If

    End Sub

    Private Sub InitialiserNoProg()

        Using dr = BaseDeDonnee.GetBD().Query("SELECT * FROM dbo.T_programme").GetReader()

            Do While dr.Read()
                cbNoProgrammeEtu.Items.Add(dr("pro_no"))
            Loop

        End Using

    End Sub

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

                    If dr("etu_sexe") = "M" Then
                        rbMasculinEtu.Checked = True
                    ElseIf dr("etu_sexe") = "F" Then
                        rbFemininEtu.Checked = True
                    End If

                End If

            End Using

        Catch Sqlex As SqlException
            MsgBox("Une erreur est survenue avec SQL pour extraire les données dans le Formulaire : " & Sqlex.Message & " Numéro d'erreur : " & Sqlex.Number)

        Catch ex As Exception
            MsgBox("Une erreur est survenue pour extraire les données dans le Formulaire : " & ex.Message)

        End Try

    End Sub

    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant, gbSexeEtu, mtbNoDAEtu)
        BarrerControles(btnNouveau, btnModifier)
        ViderFormulaire()

        btnOK.Tag = "Nouveau"

    End Sub

    Private Sub ViderFormulaire()

        mtbNoDAEtu.Clear()
        txtboxPrenomEtu.Clear()
        txtBoxNomEtu.Clear()
        txtBoxAdresseEtu.Clear()
        txtBoxVilleEtu.Clear()
        mtbCPEtu.Clear()
        mtbTelEtu.Clear()

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


        DebarrerControles(btnNouveau)
        BarrerControles(btnOK, btnAnnuler, gbEtudiant, mtbNoDAEtu)
        ExtraireDonneesVersListViewEtu()

        btnOK.Tag = ""

    End Sub

    Private Sub UpdateEtudiant()

        Dim sexeEtudiant As Char

        If rbFemininEtu.Checked = True Then
            sexeEtudiant = "F"
        ElseIf rbMasculinEtu.Checked = True Then
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

        ViderFormulaire()
        BarrerControles(btnEnlever, btnModifier)

    End Sub

    Private Sub InsererNouvelEtudiant()

        Dim sexeEtudiant As Char

        If rbFemininEtu.Checked Then
            sexeEtudiant = "F"
        ElseIf rbMasculinEtu.Checked Then
            sexeEtudiant = "M"
        End If

        BaseDeDonnee.GetBD().Query("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_telephone, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_telephone, @etu_codepostal)", New Object() {
            mtbNoDAEtu.Text,
            cbNoProgrammeEtu.Text,
            txtBoxNomEtu.Text,
            txtboxPrenomEtu.Text,
            sexeEtudiant,
            txtBoxAdresseEtu.Text,
            txtBoxVilleEtu.Text,
            cbProvinceEtu.SelectedItem.ToString(),
            mtbTelEtu.Text,
            mtbCPEtu.Text
           })

        ViderFormulaire()

    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant, gbSexeEtu)
        BarrerControles(btnNouveau, btnModifier, btnEnlever, lvEtudiantsEtu)

        btnOK.Tag = "Modifier"

    End Sub

    Private Sub frmEtudiants_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        BaseDeDonnee.GetBD().Dispose()

    End Sub

End Class