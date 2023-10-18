<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramme
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
        gbProgramme = New GroupBox()
        mtbNbrHeures = New MaskedTextBox()
        mtbNbrUnites = New MaskedTextBox()
        txtBoxNom = New TextBox()
        mtbNoProgramme = New MaskedTextBox()
        lblNbrHeures = New Label()
        lblNbrUnites = New Label()
        lblNom = New Label()
        lblNo = New Label()
        lvEtudiants = New ListView()
        colDA = New ColumnHeader()
        colNoProg = New ColumnHeader()
        colPrenomEtu = New ColumnHeader()
        colNomEtu = New ColumnHeader()
        btnNouveau = New Button()
        btnOK = New Button()
        btnAnnuler = New Button()
        btnModifier = New Button()
        btnEnlever = New Button()
        colNoProgramme = New ColumnHeader()
        colNom = New ColumnHeader()
        colNbrUnit = New ColumnHeader()
        colNbrHrs = New ColumnHeader()
        lvProgramme = New ListView()
        dgvProgramme = New DataGridView()
        dgvEtudiants = New DataGridView()
        gbProgramme.SuspendLayout()
        CType(dgvProgramme, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gbProgramme
        ' 
        gbProgramme.Controls.Add(mtbNbrHeures)
        gbProgramme.Controls.Add(mtbNbrUnites)
        gbProgramme.Controls.Add(txtBoxNom)
        gbProgramme.Controls.Add(mtbNoProgramme)
        gbProgramme.Controls.Add(lblNbrHeures)
        gbProgramme.Controls.Add(lblNbrUnites)
        gbProgramme.Controls.Add(lblNom)
        gbProgramme.Controls.Add(lblNo)
        gbProgramme.Enabled = False
        gbProgramme.Location = New Point(12, 12)
        gbProgramme.Name = "gbProgramme"
        gbProgramme.Size = New Size(441, 208)
        gbProgramme.TabIndex = 0
        gbProgramme.TabStop = False
        gbProgramme.Text = "Programme"
        ' 
        ' mtbNbrHeures
        ' 
        mtbNbrHeures.Location = New Point(154, 173)
        mtbNbrHeures.Mask = "0000"
        mtbNbrHeures.Name = "mtbNbrHeures"
        mtbNbrHeures.Size = New Size(203, 31)
        mtbNbrHeures.TabIndex = 7
        ' 
        ' mtbNbrUnites
        ' 
        mtbNbrUnites.Location = New Point(154, 129)
        mtbNbrUnites.Mask = "00.00"
        mtbNbrUnites.Name = "mtbNbrUnites"
        mtbNbrUnites.Size = New Size(203, 31)
        mtbNbrUnites.TabIndex = 6
        ' 
        ' txtBoxNom
        ' 
        txtBoxNom.Location = New Point(154, 84)
        txtBoxNom.Name = "txtBoxNom"
        txtBoxNom.Size = New Size(281, 31)
        txtBoxNom.TabIndex = 5
        ' 
        ' mtbNoProgramme
        ' 
        mtbNoProgramme.Location = New Point(154, 40)
        mtbNoProgramme.Mask = "&&&&&&"
        mtbNoProgramme.Name = "mtbNoProgramme"
        mtbNoProgramme.Size = New Size(203, 31)
        mtbNoProgramme.TabIndex = 4
        ' 
        ' lblNbrHeures
        ' 
        lblNbrHeures.BorderStyle = BorderStyle.FixedSingle
        lblNbrHeures.Location = New Point(6, 170)
        lblNbrHeures.Name = "lblNbrHeures"
        lblNbrHeures.Size = New Size(142, 38)
        lblNbrHeures.TabIndex = 3
        lblNbrHeures.Text = "Nbr. Heures :"
        ' 
        ' lblNbrUnites
        ' 
        lblNbrUnites.BorderStyle = BorderStyle.FixedSingle
        lblNbrUnites.Location = New Point(6, 124)
        lblNbrUnites.Name = "lblNbrUnites"
        lblNbrUnites.Size = New Size(142, 38)
        lblNbrUnites.TabIndex = 2
        lblNbrUnites.Text = "Nbr. Unités :"
        ' 
        ' lblNom
        ' 
        lblNom.BorderStyle = BorderStyle.FixedSingle
        lblNom.Location = New Point(6, 80)
        lblNom.Name = "lblNom"
        lblNom.Size = New Size(142, 38)
        lblNom.TabIndex = 1
        lblNom.Text = "Nom :"
        ' 
        ' lblNo
        ' 
        lblNo.BorderStyle = BorderStyle.FixedSingle
        lblNo.Location = New Point(6, 36)
        lblNo.Name = "lblNo"
        lblNo.Size = New Size(142, 38)
        lblNo.TabIndex = 0
        lblNo.Text = "No :"
        ' 
        ' lvEtudiants
        ' 
        lvEtudiants.Columns.AddRange(New ColumnHeader() {colDA, colNoProg, colPrenomEtu, colNomEtu})
        lvEtudiants.Location = New Point(661, 12)
        lvEtudiants.Name = "lvEtudiants"
        lvEtudiants.Size = New Size(782, 592)
        lvEtudiants.TabIndex = 2
        lvEtudiants.UseCompatibleStateImageBehavior = False
        lvEtudiants.View = View.Details
        ' 
        ' colDA
        ' 
        colDA.Text = "DA"
        colDA.Width = 110
        ' 
        ' colNoProg
        ' 
        colNoProg.Text = "No Prog."
        colNoProg.TextAlign = HorizontalAlignment.Center
        colNoProg.Width = 110
        ' 
        ' colPrenomEtu
        ' 
        colPrenomEtu.Text = "Prénom"
        colPrenomEtu.TextAlign = HorizontalAlignment.Center
        colPrenomEtu.Width = 280
        ' 
        ' colNomEtu
        ' 
        colNomEtu.Text = "Nom"
        colNomEtu.TextAlign = HorizontalAlignment.Center
        colNomEtu.Width = 280
        ' 
        ' btnNouveau
        ' 
        btnNouveau.Location = New Point(459, 12)
        btnNouveau.Name = "btnNouveau"
        btnNouveau.Size = New Size(196, 34)
        btnNouveau.TabIndex = 3
        btnNouveau.Text = "Nouveau"
        btnNouveau.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Enabled = False
        btnOK.Location = New Point(459, 52)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(196, 34)
        btnOK.TabIndex = 4
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnAnnuler
        ' 
        btnAnnuler.Enabled = False
        btnAnnuler.Location = New Point(459, 92)
        btnAnnuler.Name = "btnAnnuler"
        btnAnnuler.Size = New Size(196, 34)
        btnAnnuler.TabIndex = 5
        btnAnnuler.Text = "Annuler"
        btnAnnuler.UseVisualStyleBackColor = True
        ' 
        ' btnModifier
        ' 
        btnModifier.Enabled = False
        btnModifier.Location = New Point(459, 132)
        btnModifier.Name = "btnModifier"
        btnModifier.Size = New Size(196, 34)
        btnModifier.TabIndex = 6
        btnModifier.Text = "Modifier"
        btnModifier.UseVisualStyleBackColor = True
        ' 
        ' btnEnlever
        ' 
        btnEnlever.Enabled = False
        btnEnlever.Location = New Point(459, 174)
        btnEnlever.Name = "btnEnlever"
        btnEnlever.Size = New Size(196, 34)
        btnEnlever.TabIndex = 7
        btnEnlever.Text = "Enlever"
        btnEnlever.UseVisualStyleBackColor = True
        ' 
        ' colNoProgramme
        ' 
        colNoProgramme.Text = "No"
        colNoProgramme.Width = 110
        ' 
        ' colNom
        ' 
        colNom.Text = "Nom"
        colNom.TextAlign = HorizontalAlignment.Center
        colNom.Width = 300
        ' 
        ' colNbrUnit
        ' 
        colNbrUnit.Text = "Nbr. Unités"
        colNbrUnit.TextAlign = HorizontalAlignment.Center
        colNbrUnit.Width = 110
        ' 
        ' colNbrHrs
        ' 
        colNbrHrs.Text = "Nbr. Heures"
        colNbrHrs.TextAlign = HorizontalAlignment.Center
        colNbrHrs.Width = 110
        ' 
        ' lvProgramme
        ' 
        lvProgramme.Columns.AddRange(New ColumnHeader() {colNoProgramme, colNom, colNbrUnit, colNbrHrs})
        lvProgramme.FullRowSelect = True
        lvProgramme.Location = New Point(12, 226)
        lvProgramme.MultiSelect = False
        lvProgramme.Name = "lvProgramme"
        lvProgramme.Size = New Size(634, 378)
        lvProgramme.TabIndex = 1
        lvProgramme.UseCompatibleStateImageBehavior = False
        lvProgramme.View = View.Details
        ' 
        ' dgvProgramme
        ' 
        dgvProgramme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProgramme.Location = New Point(13, 226)
        dgvProgramme.MultiSelect = False
        dgvProgramme.Name = "dgvProgramme"
        dgvProgramme.ReadOnly = True
        dgvProgramme.RowHeadersWidth = 62
        dgvProgramme.RowTemplate.Height = 33
        dgvProgramme.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProgramme.Size = New Size(633, 378)
        dgvProgramme.TabIndex = 8
        ' 
        ' dgvEtudiants
        ' 
        dgvEtudiants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEtudiants.Location = New Point(661, 12)
        dgvEtudiants.MultiSelect = False
        dgvEtudiants.Name = "dgvEtudiants"
        dgvEtudiants.ReadOnly = True
        dgvEtudiants.RowHeadersWidth = 62
        dgvEtudiants.RowTemplate.Height = 33
        dgvEtudiants.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEtudiants.Size = New Size(782, 592)
        dgvEtudiants.TabIndex = 9
        ' 
        ' frmProgramme
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1455, 616)
        Controls.Add(dgvEtudiants)
        Controls.Add(dgvProgramme)
        Controls.Add(btnEnlever)
        Controls.Add(btnModifier)
        Controls.Add(btnAnnuler)
        Controls.Add(btnOK)
        Controls.Add(btnNouveau)
        Controls.Add(lvEtudiants)
        Controls.Add(lvProgramme)
        Controls.Add(gbProgramme)
        Name = "frmProgramme"
        Text = "Gestion des programmes"
        gbProgramme.ResumeLayout(False)
        gbProgramme.PerformLayout()
        CType(dgvProgramme, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents gbProgramme As GroupBox
    Friend WithEvents lblNo As Label
    Friend WithEvents lvEtudiants As ListView
    Friend WithEvents colDA As ColumnHeader
    Friend WithEvents colNoProg As ColumnHeader
    Friend WithEvents colPrenomEtu As ColumnHeader
    Friend WithEvents colNomEtu As ColumnHeader
    Friend WithEvents btnNouveau As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnModifier As Button
    Friend WithEvents btnEnlever As Button
    Friend WithEvents txtBoxNom As TextBox
    Friend WithEvents mtbNoProgramme As MaskedTextBox
    Friend WithEvents lblNom As Label
    Friend WithEvents lblNbrHeures As Label
    Friend WithEvents lblNbrUnites As Label
    Friend WithEvents txtBoxPrenomEtu As TextBox
    Friend WithEvents mtbNbrHeures As MaskedTextBox
    Friend WithEvents mtbNbrUnites As MaskedTextBox
    Friend WithEvents colNoProgramme As ColumnHeader
    Friend WithEvents colNom As ColumnHeader
    Friend WithEvents colNbrUnit As ColumnHeader
    Friend WithEvents colNbrHrs As ColumnHeader
    Friend WithEvents lvProgramme As ListView
    Friend WithEvents txtBoxVilleEtu As TextBox
    Friend WithEvents lblTelEtu As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblProvinceEtu As Label
    Friend WithEvents lblVilleEtu As Label
    Friend WithEvents lblAdresseEtu As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbMasculinEtu As RadioButton
    Friend WithEvents cbNoProgEtu As ComboBox
    Friend WithEvents dgvProgramme As DataGridView
    Friend WithEvents dgvEtudiants As DataGridView
End Class
