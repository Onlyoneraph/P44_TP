<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        GestionToolStripMenuItem = New ToolStripMenuItem()
        ProgrammeToolStripMenuItem = New ToolStripMenuItem()
        ÉtudiantsToolStripMenuItem = New ToolStripMenuItem()
        QuitterToolStripMenuItem = New ToolStripMenuItem()
        RapportToolStripMenuItem = New ToolStripMenuItem()
        ProgrammeToolStripMenuItem1 = New ToolStripMenuItem()
        ListeDesÉtudiantsToolStripMenuItem = New ToolStripMenuItem()
        ListeDesÉtudiantsParProgrammeToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {GestionToolStripMenuItem, RapportToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(2278, 33)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' GestionToolStripMenuItem
        ' 
        GestionToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProgrammeToolStripMenuItem, ÉtudiantsToolStripMenuItem, QuitterToolStripMenuItem})
        GestionToolStripMenuItem.Name = "GestionToolStripMenuItem"
        GestionToolStripMenuItem.Size = New Size(88, 29)
        GestionToolStripMenuItem.Text = "Gestion"
        ' 
        ' ProgrammeToolStripMenuItem
        ' 
        ProgrammeToolStripMenuItem.Name = "ProgrammeToolStripMenuItem"
        ProgrammeToolStripMenuItem.Size = New Size(208, 34)
        ProgrammeToolStripMenuItem.Text = "Programme"
        ' 
        ' ÉtudiantsToolStripMenuItem
        ' 
        ÉtudiantsToolStripMenuItem.Name = "ÉtudiantsToolStripMenuItem"
        ÉtudiantsToolStripMenuItem.Size = New Size(208, 34)
        ÉtudiantsToolStripMenuItem.Text = "Étudiants"
        ' 
        ' QuitterToolStripMenuItem
        ' 
        QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        QuitterToolStripMenuItem.Size = New Size(208, 34)
        QuitterToolStripMenuItem.Text = "Quitter"
        ' 
        ' RapportToolStripMenuItem
        ' 
        RapportToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProgrammeToolStripMenuItem1, ListeDesÉtudiantsToolStripMenuItem, ListeDesÉtudiantsParProgrammeToolStripMenuItem})
        RapportToolStripMenuItem.Name = "RapportToolStripMenuItem"
        RapportToolStripMenuItem.Size = New Size(93, 29)
        RapportToolStripMenuItem.Text = "Rapport"
        ' 
        ' ProgrammeToolStripMenuItem1
        ' 
        ProgrammeToolStripMenuItem1.Name = "ProgrammeToolStripMenuItem1"
        ProgrammeToolStripMenuItem1.Size = New Size(391, 34)
        ProgrammeToolStripMenuItem1.Text = "Liste des Programmes"
        ' 
        ' ListeDesÉtudiantsToolStripMenuItem
        ' 
        ListeDesÉtudiantsToolStripMenuItem.Name = "ListeDesÉtudiantsToolStripMenuItem"
        ListeDesÉtudiantsToolStripMenuItem.Size = New Size(391, 34)
        ListeDesÉtudiantsToolStripMenuItem.Text = "Liste des Étudiants"
        ' 
        ' ListeDesÉtudiantsParProgrammeToolStripMenuItem
        ' 
        ListeDesÉtudiantsParProgrammeToolStripMenuItem.Name = "ListeDesÉtudiantsParProgrammeToolStripMenuItem"
        ListeDesÉtudiantsParProgrammeToolStripMenuItem.Size = New Size(391, 34)
        ListeDesÉtudiantsParProgrammeToolStripMenuItem.Text = "Liste des étudiants par programme"
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(2278, 1450)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "frmPrincipal"
        Text = "Gestion"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GestionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgrammeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÉtudiantsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RapportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgrammeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListeDesÉtudiantsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListeDesÉtudiantsParProgrammeToolStripMenuItem As ToolStripMenuItem
End Class
