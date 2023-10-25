Imports Microsoft.Data.SqlClient

Public Class frmEtudiants

    Dim errorProv As New ErrorProvider()
    Dim modeConnecte As Boolean = Me.Tag
    Dim cn As SqlConnection

    'Assignation d'une Propriétée pour reçevoir le DataSet
    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Me.ds = ds
    End Sub

    'Declaration des variables nécessaires au Mode Déconnecté
    Dim sqlCommandTblEtudiants As SqlCommand
    Dim sqlInsertCommandEtudiants As SqlCommand
    Dim sqlUpdateCommandEtudiants As SqlCommand
    Dim sqlDeleteCommandEtudiants As SqlCommand
    Dim sqlDataTblEtudiants As SqlDataAdapter
    Dim bindSourceEtudiants As BindingSource

    Dim da As SqlDataAdapter
    Public Property ds As DataSet


    Dim sqlCommandTblProgrammes As SqlCommand
    Dim sqlDataTblProgrammes As SqlDataAdapter
    Dim bindSourceProgrammes As BindingSource



    ' Chargement du Formulaire - Initialisation
    Private Sub frmEtudiants_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If modeConnecte Then

            BaseDeDonnee.GetBD()

            InitialiserNoProg()

            ExtraireDonneesVersListViewEtu()

            lvEtudiantsEtu.Visible = True
            dgvEtudiants.Visible = False

            If lvEtudiantsEtu.Items.Count > 0 Then

                lvEtudiantsEtu.SelectedIndices.Add(0)
                lvEtudiantsEtu.Focus()

            End If

        Else

            dgvEtudiants.Visible = True
            lvEtudiantsEtu.Visible = False

            ds = New DataSet("tp_p44")
            da = New SqlDataAdapter()

            cn = New SqlConnection(My.Settings.ConnectionString)

            sqlCommandTblEtudiants = New SqlCommand("SELECT * FROM dbo.T_etudiants", cn)
            sqlInsertCommandEtudiants = New SqlCommand("INSERT INTO dbo.T_etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_telephone, etu_codepostal) Values(@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_telephone, @etu_codepostal)", cn)
            sqlUpdateCommandEtudiants = New SqlCommand("UPDATE dbo.T_etudiants SET pro_no=@pro_no, etu_nom=@etu_nom, etu_prenom=@etu_prenom, etu_sexe=@etu_sexe, etu_adresse=@etu_adresse, etu_ville=@etu_ville, etu_province=@etu_province, etu_codepostal=@etu_codepostal, etu_telephone=@etu_telephone WHERE etu_da=@etu_da", cn)
            sqlDeleteCommandEtudiants = New SqlCommand("DELETE FROM dbo.T_etudiants WHERE etu_da=@etu_da", cn)
            sqlDataTblEtudiants = New SqlDataAdapter(sqlCommandTblEtudiants)
            bindSourceEtudiants = New BindingSource()

            sqlCommandTblProgrammes = New SqlCommand("SELECT * FROM dbo.T_programme", cn)
            sqlDataTblProgrammes = New SqlDataAdapter(sqlCommandTblProgrammes)
            bindSourceProgrammes = New BindingSource()


            'Assignation des Parametres pour mon CUD Programme... Qui fera le lien avec la Query Insert, Update, Delete
            sqlInsertCommandEtudiants.Parameters.AddRange({
            New SqlParameter("@etu_da", SqlDbType.VarChar, 0, "etu_da"),
            New SqlParameter("@pro_no", SqlDbType.VarChar, 0, "pro_no"),
            New SqlParameter("@etu_nom", SqlDbType.VarChar, 0, "etu_nom"),
            New SqlParameter("@etu_prenom", SqlDbType.VarChar, 0, "etu_prenom"),
            New SqlParameter("@etu_sexe", SqlDbType.Char, 0, "etu_sexe"),
            New SqlParameter("@etu_adresse", SqlDbType.VarChar, 0, "etu_adresse"),
            New SqlParameter("@etu_ville", SqlDbType.VarChar, 0, "etu_ville"),
            New SqlParameter("@etu_province", SqlDbType.VarChar, 0, "etu_province"),
            New SqlParameter("@etu_telephone", SqlDbType.VarChar, 0, "etu_telephone"),
            New SqlParameter("@etu_codepostal", SqlDbType.VarChar, 0, "etu_codepostal")
        })


            sqlUpdateCommandEtudiants.Parameters.AddRange({
            New SqlParameter("@pro_no", SqlDbType.VarChar, 0, "pro_no"),
            New SqlParameter("@etu_nom", SqlDbType.VarChar, 0, "etu_nom"),
            New SqlParameter("@etu_prenom", SqlDbType.VarChar, 0, "etu_prenom"),
            New SqlParameter("@etu_sexe", SqlDbType.Char, 0, "etu_sexe"),
            New SqlParameter("@etu_adresse", SqlDbType.VarChar, 0, "etu_adresse"),
            New SqlParameter("@etu_ville", SqlDbType.VarChar, 0, "etu_ville"),
            New SqlParameter("@etu_province", SqlDbType.VarChar, 0, "etu_province"),
            New SqlParameter("@etu_codepostal", SqlDbType.VarChar, 0, "etu_codepostal"),
            New SqlParameter("@etu_telephone", SqlDbType.VarChar, 0, "etu_telephone"),
            New SqlParameter("@etu_da", SqlDbType.VarChar, 0, "etu_da")
        })

            sqlDeleteCommandEtudiants.Parameters.Add("@etu_da", SqlDbType.VarChar, 0, "etu_da")

            sqlDataTblEtudiants.InsertCommand = sqlInsertCommandEtudiants
            sqlDataTblEtudiants.UpdateCommand = sqlUpdateCommandEtudiants
            sqlDataTblEtudiants.DeleteCommand = sqlDeleteCommandEtudiants


            DisconnectedExtraireDonneesVersDataGridViewEtu()

            DisconnectedInitialiserNoProg()


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

        If modeConnecte Then

            BarrerControles(lvEtudiantsEtu)
            ViderFormulaire()

            btnOK.Tag = "Nouveau"

        Else

            bindSourceEtudiants.AddNew()
            BarrerControles(dgvEtudiants)
            rbFemininEtu.Checked = False
            rbMasculinEtu.Checked = False

        End If

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant, gbSexeEtu, mtbNoDAEtu)
        BarrerControles(btnNouveau, btnModifier, btnEnlever)


    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If modeConnecte Then

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


            DebarrerControles(lvEtudiantsEtu)
            ExtraireDonneesVersListViewEtu()

            btnOK.Tag = ""

        Else
            Try

                DisconnectedUpdateSource("T_etudiants")

            Catch ex As Exception
                MsgBox("Une erreur est survenue lors de l'insertion du programme dans la DB : " & ex.Message)
            End Try

            DebarrerControles(dgvEtudiants)
        End If

        DebarrerControles(btnNouveau, btnEnlever, btnModifier)
        BarrerControles(btnOK, btnAnnuler, gbEtudiant, mtbNoDAEtu)



    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click

        If modeConnecte Then
            BarrerControles(lvEtudiantsEtu)
            btnOK.Tag = "Modifier"
        Else
            BarrerControles(dgvEtudiants)
        End If

        DebarrerControles(btnOK, btnAnnuler, gbEtudiant)
        BarrerControles(btnModifier, btnEnlever, btnNouveau)


    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click

        If modeConnecte Then

            DebarrerControles(lvEtudiantsEtu)

            ViderFormulaire()

            If lvEtudiantsEtu.Items.Count > 0 Then

                lvEtudiantsEtu.SelectedIndices.Add(0)
                lvEtudiantsEtu.Focus()

            End If

        Else
            bindSourceEtudiants.CancelEdit()
            DebarrerControles(dgvEtudiants)
        End If

        DebarrerControles(btnModifier, btnEnlever, btnNouveau)
        BarrerControles(btnOK, btnAnnuler, gbEtudiant)


    End Sub

    Private Sub btnEnlever_Click(sender As Object, e As EventArgs) Handles btnEnlever.Click


        Dim suppression As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'étudiant : " & txtboxPrenomEtu.Text & " " & txtBoxNomEtu.Text & vbCrLf & "DA : " & mtbNoDAEtu.Text, "Suppression", MessageBoxButtons.YesNo)

        If suppression = DialogResult.Yes Then

            If modeConnecte Then

                supprimerEtudiant(mtbNoDAEtu.Text, txtboxPrenomEtu.Text, txtBoxNomEtu.Text)

            Else

                Try
                    bindSourceEtudiants.RemoveCurrent()
                    DisconnectedUpdateSource("T_etudiants")
                Catch ex As Exception
                    MsgBox("Une erreur est survenue lors de la suppression d'un étudiant : " & ex.Message)
                End Try

            End If



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


    ' Mode Déconnecté

#Region "Disconnected - Début Bloc fonctions | Action vers la DB - CRUD"

    Private Sub DisconnectedUpdateSource(tableName As String)

        Try

            If tableName = "T_etudiants" Then
                bindSourceEtudiants.EndEdit()
                dgvEtudiants.EndEdit()
                sqlDataTblEtudiants.Update(ds.Tables(tableName))
            End If

        Catch ex As Exception
            MsgBox("Une erreur est survenue lors de la mise a jours vers la DB : " & ex.Message)

            bindSourceEtudiants.CancelEdit()
            ds.Tables(tableName).RejectChanges()
        End Try

    End Sub

    Private Sub DisconnectedInitialiserNoProg()

    End Sub

    Private Sub DisconnectedExtraireDonneesVersDataGridViewEtu()


        InitialiserDGVEtudiants()

        sqlDataTblEtudiants.Fill(ds, "T_etudiants")
        sqlDataTblProgrammes.Fill(ds, "T_programmes")

        bindSourceEtudiants.DataSource = ds
        bindSourceEtudiants.DataMember = "T_etudiants"

        bindSourceProgrammes.DataSource = ds
        bindSourceProgrammes.DataMember = "T_programmes"


        mtbNoDAEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_da", True))
        cbNoProgrammeEtu.DataBindings.Add(New Binding("SelectedValue", bindSourceEtudiants, "pro_no", True))
        txtboxPrenomEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_prenom", True))
        txtBoxNomEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_nom", True))
        txtBoxAdresseEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_adresse", True))
        txtBoxVilleEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_ville", True))
        cbProvinceEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_province", True))
        gbSexeEtu.DataBindings.Add(New Binding("Tag", bindSourceEtudiants, "etu_sexe", True))
        mtbCPEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_codepostal", True))
        mtbTelEtu.DataBindings.Add(New Binding("Text", bindSourceEtudiants, "etu_telephone", True))

        cbNoProgrammeEtu.DisplayMember = "pro_no"
        cbNoProgrammeEtu.ValueMember = "pro_no"

        cbNoProgrammeEtu.DataSource = bindSourceProgrammes
        dgvEtudiants.DataSource = bindSourceEtudiants

    End Sub

    Private Sub InitialiserDGVEtudiants()
        dgvEtudiants.ColumnCount = 10

        dgvEtudiants.AutoGenerateColumns = False

        dgvEtudiants.Columns(0).Name = "dgvEtudiantsColID"
        dgvEtudiants.Columns(0).HeaderText = "DA"
        dgvEtudiants.Columns(0).DataPropertyName = "etu_da"

        dgvEtudiants.Columns(1).Name = "dgvEtudiantsColNoProg"
        dgvEtudiants.Columns(1).HeaderText = "No Prog."
        dgvEtudiants.Columns(1).DataPropertyName = "pro_no"

        dgvEtudiants.Columns(2).Name = "dgvEtudiantsColPrenom"
        dgvEtudiants.Columns(2).HeaderText = "Prénom"
        dgvEtudiants.Columns(2).DataPropertyName = "etu_prenom"

        dgvEtudiants.Columns(3).Name = "dgvEtudiantsColNom"
        dgvEtudiants.Columns(3).HeaderText = "Nom"
        dgvEtudiants.Columns(3).DataPropertyName = "etu_nom"

        dgvEtudiants.Columns(4).Name = "dgvEtudiantsColSexe"
        dgvEtudiants.Columns(4).HeaderText = "Sexe"
        dgvEtudiants.Columns(4).DataPropertyName = "etu_sexe"

        dgvEtudiants.Columns(5).Name = "dgvEtudiantsColAdresse"
        dgvEtudiants.Columns(5).HeaderText = "Adresse"
        dgvEtudiants.Columns(5).DataPropertyName = "etu_adresse"

        dgvEtudiants.Columns(6).Name = "dgvEtudiantsColVille"
        dgvEtudiants.Columns(6).HeaderText = "Ville"
        dgvEtudiants.Columns(6).DataPropertyName = "etu_ville"

        dgvEtudiants.Columns(7).Name = "dgvEtudiantsColCP"
        dgvEtudiants.Columns(7).HeaderText = "Code Postal"
        dgvEtudiants.Columns(7).DataPropertyName = "etu_codepostal"

        dgvEtudiants.Columns(8).Name = "dgvEtudiantsColTel"
        dgvEtudiants.Columns(8).HeaderText = "Téléphone"
        dgvEtudiants.Columns(8).DataPropertyName = "etu_telephone"

        dgvEtudiants.Columns(9).Name = "dgvEtudiantsColProvince"
        dgvEtudiants.Columns(9).HeaderText = "Province"
        dgvEtudiants.Columns(9).DataPropertyName = "etu_province"

    End Sub

    Private Sub dgvEtudiants_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEtudiants.SelectionChanged

        If dgvEtudiants.SelectedRows.Count > 0 Then
            If Not IsDBNull(dgvEtudiants.SelectedRows(0).Cells(0).Value) Then
                DebarrerControles(btnModifier, btnEnlever)
            Else
                BarrerControles(btnModifier, btnEnlever)
            End If
            CocherSexeEtudiant()
        End If

    End Sub

    Private Sub CocherSexeEtudiant()
        If Not IsDBNull(gbSexeEtu.Tag) Then
            If gbSexeEtu.Tag = "F" Then
                rbFemininEtu.Checked = True
            ElseIf gbSexeEtu.Tag = "M" Then
                rbMasculinEtu.Checked = True
            End If
        Else
            rbFemininEtu.Checked = False
            rbMasculinEtu.Checked = False
        End If

    End Sub

    Private Sub rbFemininEtu_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemininEtu.CheckedChanged
        InscrireTagGBSexe()
    End Sub

    Private Sub InscrireTagGBSexe()
        If rbFemininEtu.Checked Then
            gbSexeEtu.Tag = "F"
        ElseIf rbMasculinEtu.Checked Then
            gbSexeEtu.Tag = "M"
        End If
    End Sub

    Private Sub rbMasculinEtu_CheckedChanged(sender As Object, e As EventArgs) Handles rbMasculinEtu.CheckedChanged
        InscrireTagGBSexe()
    End Sub


#End Region



End Class