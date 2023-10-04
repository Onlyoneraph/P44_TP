<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtudiants
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnEnlever = New Button()
        btnModifier = New Button()
        btnAnnuler = New Button()
        btnOK = New Button()
        btnNouveau = New Button()
        lvEtudiantsEtu = New ListView()
        colDAEtu = New ColumnHeader()
        colNoProgEtu = New ColumnHeader()
        colPrenomEtu = New ColumnHeader()
        colNomEtu = New ColumnHeader()
        colSexeEtu = New ColumnHeader()
        colAdresseEtu = New ColumnHeader()
        colVilleEtu = New ColumnHeader()
        colCPEtu = New ColumnHeader()
        colTelEtu = New ColumnHeader()
        colProvinceEtu = New ColumnHeader()
        gbEtudiant = New GroupBox()
        gbSexeEtu = New GroupBox()
        rbMasculinEtu = New RadioButton()
        rbFemininEtu = New RadioButton()
        mtbTelEtu = New MaskedTextBox()
        mtbCPEtu = New MaskedTextBox()
        cbProvinceEtu = New ComboBox()
        txtBoxVilleEtu = New TextBox()
        txtBoxAdresseEtu = New TextBox()
        lblTelEtu = New Label()
        lblVilleEtu = New Label()
        lblProvinceEtu = New Label()
        lblCPEtu = New Label()
        lblAdresseEtu = New Label()
        cbNoProgrammeEtu = New ComboBox()
        txtboxPrenomEtu = New TextBox()
        txtBoxNomEtu = New TextBox()
        mtbNoDAEtu = New MaskedTextBox()
        lblNoProgEtu = New Label()
        lblPrenomEtu = New Label()
        lblNomEtu = New Label()
        lblDaEtu = New Label()
        gbEtudiant.SuspendLayout()
        gbSexeEtu.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnEnlever
        ' 
        btnEnlever.Enabled = False
        btnEnlever.Location = New Point(936, 188)
        btnEnlever.Name = "btnEnlever"
        btnEnlever.Size = New Size(196, 34)
        btnEnlever.TabIndex = 15
        btnEnlever.Text = "Enlever"
        btnEnlever.UseVisualStyleBackColor = True
        ' 
        ' btnModifier
        ' 
        btnModifier.Enabled = False
        btnModifier.Location = New Point(936, 146)
        btnModifier.Name = "btnModifier"
        btnModifier.Size = New Size(196, 34)
        btnModifier.TabIndex = 14
        btnModifier.Text = "Modifier"
        btnModifier.UseVisualStyleBackColor = True
        ' 
        ' btnAnnuler
        ' 
        btnAnnuler.Enabled = False
        btnAnnuler.Location = New Point(936, 106)
        btnAnnuler.Name = "btnAnnuler"
        btnAnnuler.Size = New Size(196, 34)
        btnAnnuler.TabIndex = 13
        btnAnnuler.Text = "Annuler"
        btnAnnuler.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Enabled = False
        btnOK.Location = New Point(936, 66)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(196, 34)
        btnOK.TabIndex = 12
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnNouveau
        ' 
        btnNouveau.Location = New Point(936, 26)
        btnNouveau.Name = "btnNouveau"
        btnNouveau.Size = New Size(196, 34)
        btnNouveau.TabIndex = 11
        btnNouveau.Text = "Nouveau"
        btnNouveau.UseVisualStyleBackColor = True
        ' 
        ' lvEtudiantsEtu
        ' 
        lvEtudiantsEtu.Columns.AddRange(New ColumnHeader() {colDAEtu, colNoProgEtu, colPrenomEtu, colNomEtu, colSexeEtu, colAdresseEtu, colVilleEtu, colCPEtu, colTelEtu, colProvinceEtu})
        lvEtudiantsEtu.FullRowSelect = True
        lvEtudiantsEtu.Location = New Point(12, 364)
        lvEtudiantsEtu.MultiSelect = False
        lvEtudiantsEtu.Name = "lvEtudiantsEtu"
        lvEtudiantsEtu.Size = New Size(1137, 378)
        lvEtudiantsEtu.TabIndex = 10
        lvEtudiantsEtu.UseCompatibleStateImageBehavior = False
        lvEtudiantsEtu.View = View.Details
        ' 
        ' colDAEtu
        ' 
        colDAEtu.Text = "DA"
        colDAEtu.Width = 90
        ' 
        ' colNoProgEtu
        ' 
        colNoProgEtu.Text = "No Prog."
        colNoProgEtu.TextAlign = HorizontalAlignment.Center
        colNoProgEtu.Width = 90
        ' 
        ' colPrenomEtu
        ' 
        colPrenomEtu.Text = "Prénom"
        colPrenomEtu.TextAlign = HorizontalAlignment.Center
        colPrenomEtu.Width = 110
        ' 
        ' colNomEtu
        ' 
        colNomEtu.Text = "Nom"
        colNomEtu.TextAlign = HorizontalAlignment.Center
        colNomEtu.Width = 110
        ' 
        ' colSexeEtu
        ' 
        colSexeEtu.Text = "Sexe"
        colSexeEtu.Width = 70
        ' 
        ' colAdresseEtu
        ' 
        colAdresseEtu.Text = "Adresse"
        colAdresseEtu.Width = 200
        ' 
        ' colVilleEtu
        ' 
        colVilleEtu.Text = "Ville"
        colVilleEtu.Width = 110
        ' 
        ' colCPEtu
        ' 
        colCPEtu.Text = "Code Postal"
        colCPEtu.Width = 110
        ' 
        ' colTelEtu
        ' 
        colTelEtu.Text = "Téléphone"
        colTelEtu.Width = 110
        ' 
        ' colProvinceEtu
        ' 
        colProvinceEtu.Text = "Province"
        colProvinceEtu.Width = 110
        ' 
        ' gbEtudiant
        ' 
        gbEtudiant.Controls.Add(gbSexeEtu)
        gbEtudiant.Controls.Add(mtbTelEtu)
        gbEtudiant.Controls.Add(mtbCPEtu)
        gbEtudiant.Controls.Add(cbProvinceEtu)
        gbEtudiant.Controls.Add(txtBoxVilleEtu)
        gbEtudiant.Controls.Add(txtBoxAdresseEtu)
        gbEtudiant.Controls.Add(lblTelEtu)
        gbEtudiant.Controls.Add(lblVilleEtu)
        gbEtudiant.Controls.Add(lblProvinceEtu)
        gbEtudiant.Controls.Add(lblCPEtu)
        gbEtudiant.Controls.Add(lblAdresseEtu)
        gbEtudiant.Controls.Add(cbNoProgrammeEtu)
        gbEtudiant.Controls.Add(txtboxPrenomEtu)
        gbEtudiant.Controls.Add(txtBoxNomEtu)
        gbEtudiant.Controls.Add(mtbNoDAEtu)
        gbEtudiant.Controls.Add(lblNoProgEtu)
        gbEtudiant.Controls.Add(lblPrenomEtu)
        gbEtudiant.Controls.Add(lblNomEtu)
        gbEtudiant.Controls.Add(lblDaEtu)
        gbEtudiant.Enabled = False
        gbEtudiant.Location = New Point(12, 12)
        gbEtudiant.Name = "gbEtudiant"
        gbEtudiant.Size = New Size(905, 346)
        gbEtudiant.TabIndex = 8
        gbEtudiant.TabStop = False
        gbEtudiant.Text = "Etudiant"
        ' 
        ' gbSexeEtu
        ' 
        gbSexeEtu.Controls.Add(rbMasculinEtu)
        gbSexeEtu.Controls.Add(rbFemininEtu)
        gbSexeEtu.Location = New Point(6, 207)
        gbSexeEtu.Name = "gbSexeEtu"
        gbSexeEtu.Size = New Size(142, 133)
        gbSexeEtu.TabIndex = 20
        gbSexeEtu.TabStop = False
        gbSexeEtu.Text = "Sexe"
        ' 
        ' rbMasculinEtu
        ' 
        rbMasculinEtu.AutoSize = True
        rbMasculinEtu.Location = New Point(19, 81)
        rbMasculinEtu.Name = "rbMasculinEtu"
        rbMasculinEtu.Size = New Size(106, 29)
        rbMasculinEtu.TabIndex = 1
        rbMasculinEtu.TabStop = True
        rbMasculinEtu.Tag = "M"
        rbMasculinEtu.Text = "Masculin"
        rbMasculinEtu.UseVisualStyleBackColor = True
        ' 
        ' rbFemininEtu
        ' 
        rbFemininEtu.AutoSize = True
        rbFemininEtu.Location = New Point(19, 46)
        rbFemininEtu.Name = "rbFemininEtu"
        rbFemininEtu.Size = New Size(99, 29)
        rbFemininEtu.TabIndex = 0
        rbFemininEtu.TabStop = True
        rbFemininEtu.Tag = "F"
        rbFemininEtu.Text = "Féminin"
        rbFemininEtu.UseVisualStyleBackColor = True
        ' 
        ' mtbTelEtu
        ' 
        mtbTelEtu.Location = New Point(605, 202)
        mtbTelEtu.Mask = "(999) 999-9999"
        mtbTelEtu.Name = "mtbTelEtu"
        mtbTelEtu.Size = New Size(203, 31)
        mtbTelEtu.TabIndex = 19
        ' 
        ' mtbCPEtu
        ' 
        mtbCPEtu.Location = New Point(605, 162)
        mtbCPEtu.Mask = "L9L-9L9"
        mtbCPEtu.Name = "mtbCPEtu"
        mtbCPEtu.Size = New Size(203, 31)
        mtbCPEtu.TabIndex = 18
        ' 
        ' cbProvinceEtu
        ' 
        cbProvinceEtu.FormattingEnabled = True
        cbProvinceEtu.Items.AddRange(New Object() {"Alberta", "Colombie-Britannique", "Île-du-Prince-Édouard", "Manitoba", "Nouveau-Brunswick", "Nouvelle-Écosse", "Ontario", "Québec", "Saskatchewan", "Terre-Neuve-et-Labrador", "Nunavut", "Territoires du Nord-Ouest", "Yukon"})
        cbProvinceEtu.Location = New Point(605, 122)
        cbProvinceEtu.Name = "cbProvinceEtu"
        cbProvinceEtu.Size = New Size(203, 33)
        cbProvinceEtu.TabIndex = 17
        ' 
        ' txtBoxVilleEtu
        ' 
        txtBoxVilleEtu.Location = New Point(605, 82)
        txtBoxVilleEtu.Name = "txtBoxVilleEtu"
        txtBoxVilleEtu.Size = New Size(294, 31)
        txtBoxVilleEtu.TabIndex = 16
        ' 
        ' txtBoxAdresseEtu
        ' 
        txtBoxAdresseEtu.Location = New Point(605, 40)
        txtBoxAdresseEtu.Name = "txtBoxAdresseEtu"
        txtBoxAdresseEtu.Size = New Size(294, 31)
        txtBoxAdresseEtu.TabIndex = 15
        ' 
        ' lblTelEtu
        ' 
        lblTelEtu.BorderStyle = BorderStyle.FixedSingle
        lblTelEtu.Location = New Point(457, 202)
        lblTelEtu.Name = "lblTelEtu"
        lblTelEtu.Size = New Size(142, 31)
        lblTelEtu.TabIndex = 14
        lblTelEtu.Text = "Téléphone :"
        ' 
        ' lblVilleEtu
        ' 
        lblVilleEtu.BorderStyle = BorderStyle.FixedSingle
        lblVilleEtu.Location = New Point(457, 80)
        lblVilleEtu.Name = "lblVilleEtu"
        lblVilleEtu.Size = New Size(142, 33)
        lblVilleEtu.TabIndex = 13
        lblVilleEtu.Text = "Ville : "
        ' 
        ' lblProvinceEtu
        ' 
        lblProvinceEtu.BorderStyle = BorderStyle.FixedSingle
        lblProvinceEtu.Location = New Point(457, 122)
        lblProvinceEtu.Name = "lblProvinceEtu"
        lblProvinceEtu.Size = New Size(142, 33)
        lblProvinceEtu.TabIndex = 12
        lblProvinceEtu.Text = "Province :"
        ' 
        ' lblCPEtu
        ' 
        lblCPEtu.BorderStyle = BorderStyle.FixedSingle
        lblCPEtu.Location = New Point(457, 162)
        lblCPEtu.Name = "lblCPEtu"
        lblCPEtu.Size = New Size(142, 31)
        lblCPEtu.TabIndex = 11
        lblCPEtu.Text = "Code Postal :"
        ' 
        ' lblAdresseEtu
        ' 
        lblAdresseEtu.BorderStyle = BorderStyle.FixedSingle
        lblAdresseEtu.Location = New Point(457, 40)
        lblAdresseEtu.Name = "lblAdresseEtu"
        lblAdresseEtu.Size = New Size(142, 31)
        lblAdresseEtu.TabIndex = 10
        lblAdresseEtu.Text = "Adresse :"
        ' 
        ' cbNoProgrammeEtu
        ' 
        cbNoProgrammeEtu.FormattingEnabled = True
        cbNoProgrammeEtu.Location = New Point(154, 80)
        cbNoProgrammeEtu.Name = "cbNoProgrammeEtu"
        cbNoProgrammeEtu.Size = New Size(118, 33)
        cbNoProgrammeEtu.TabIndex = 9
        ' 
        ' txtboxPrenomEtu
        ' 
        txtboxPrenomEtu.Location = New Point(154, 122)
        txtboxPrenomEtu.Name = "txtboxPrenomEtu"
        txtboxPrenomEtu.Size = New Size(281, 31)
        txtboxPrenomEtu.TabIndex = 8
        ' 
        ' txtBoxNomEtu
        ' 
        txtBoxNomEtu.Location = New Point(154, 162)
        txtBoxNomEtu.Name = "txtBoxNomEtu"
        txtBoxNomEtu.Size = New Size(281, 31)
        txtBoxNomEtu.TabIndex = 5
        ' 
        ' mtbNoDAEtu
        ' 
        mtbNoDAEtu.Enabled = False
        mtbNoDAEtu.Location = New Point(154, 40)
        mtbNoDAEtu.Mask = "0000000"
        mtbNoDAEtu.Name = "mtbNoDAEtu"
        mtbNoDAEtu.Size = New Size(118, 31)
        mtbNoDAEtu.TabIndex = 4
        ' 
        ' lblNoProgEtu
        ' 
        lblNoProgEtu.BorderStyle = BorderStyle.FixedSingle
        lblNoProgEtu.Location = New Point(6, 80)
        lblNoProgEtu.Name = "lblNoProgEtu"
        lblNoProgEtu.Size = New Size(142, 33)
        lblNoProgEtu.TabIndex = 3
        lblNoProgEtu.Text = "No Prog :"
        ' 
        ' lblPrenomEtu
        ' 
        lblPrenomEtu.BorderStyle = BorderStyle.FixedSingle
        lblPrenomEtu.Location = New Point(6, 122)
        lblPrenomEtu.Name = "lblPrenomEtu"
        lblPrenomEtu.Size = New Size(142, 31)
        lblPrenomEtu.TabIndex = 2
        lblPrenomEtu.Text = "Prénom :"
        ' 
        ' lblNomEtu
        ' 
        lblNomEtu.BorderStyle = BorderStyle.FixedSingle
        lblNomEtu.Location = New Point(6, 162)
        lblNomEtu.Name = "lblNomEtu"
        lblNomEtu.Size = New Size(142, 31)
        lblNomEtu.TabIndex = 1
        lblNomEtu.Text = "Nom :"
        ' 
        ' lblDaEtu
        ' 
        lblDaEtu.BorderStyle = BorderStyle.FixedSingle
        lblDaEtu.Location = New Point(6, 40)
        lblDaEtu.Name = "lblDaEtu"
        lblDaEtu.Size = New Size(142, 31)
        lblDaEtu.TabIndex = 0
        lblDaEtu.Text = "DA :"
        ' 
        ' frmEtudiants
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1161, 754)
        Controls.Add(btnEnlever)
        Controls.Add(btnModifier)
        Controls.Add(btnAnnuler)
        Controls.Add(btnOK)
        Controls.Add(btnNouveau)
        Controls.Add(lvEtudiantsEtu)
        Controls.Add(gbEtudiant)
        Name = "frmEtudiants"
        Text = "Gestion des étudiants"
        gbEtudiant.ResumeLayout(False)
        gbEtudiant.PerformLayout()
        gbSexeEtu.ResumeLayout(False)
        gbSexeEtu.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnEnlever As Button
    Friend WithEvents btnModifier As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnNouveau As Button
    Friend WithEvents lvEtudiantsEtu As ListView
    Friend WithEvents colDAEtu As ColumnHeader
    Friend WithEvents colNoProgEtu As ColumnHeader
    Friend WithEvents colPrenomEtu As ColumnHeader
    Friend WithEvents colNomEtu As ColumnHeader
    Friend WithEvents gbEtudiant As GroupBox
    Friend WithEvents txtBoxNomEtu As TextBox
    Friend WithEvents mtbNoDAEtu As MaskedTextBox
    Friend WithEvents lblNoProgEtu As Label
    Friend WithEvents lblPrenomEtu As Label
    Friend WithEvents lblNomEtu As Label
    Friend WithEvents lblDaEtu As Label
    Friend WithEvents colSexeEtu As ColumnHeader
    Friend WithEvents colAdresseEtu As ColumnHeader
    Friend WithEvents colVilleEtu As ColumnHeader
    Friend WithEvents colCPEtu As ColumnHeader
    Friend WithEvents colTelEtu As ColumnHeader
    Friend WithEvents colProvinceEtu As ColumnHeader
    Friend WithEvents txtboxPrenomEtu As TextBox
    Friend WithEvents gbSexeEtu As GroupBox
    Friend WithEvents rbMasculinEtu As RadioButton
    Friend WithEvents rbFemininEtu As RadioButton
    Friend WithEvents mtbTelEtu As MaskedTextBox
    Friend WithEvents mtbCPEtu As MaskedTextBox
    Friend WithEvents cbProvinceEtu As ComboBox
    Friend WithEvents txtBoxVilleEtu As TextBox
    Friend WithEvents txtBoxAdresseEtu As TextBox
    Friend WithEvents lblTelEtu As Label
    Friend WithEvents lblVilleEtu As Label
    Friend WithEvents lblProvinceEtu As Label
    Friend WithEvents lblCPEtu As Label
    Friend WithEvents lblAdresseEtu As Label
    Friend WithEvents cbNoProgrammeEtu As ComboBox
End Class
