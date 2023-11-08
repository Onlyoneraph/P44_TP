Imports System.IO
Imports Microsoft.Data.SqlClient
Imports Newtonsoft.Json

Public Class frmPrincipal

    Private frmProgramme As Form = Nothing
    Private frmEtudiant As Form = Nothing

    'Déclaration de mes variables DataSet et Connexion qui me serviront partout dans le programme
    Dim ds As New DataSet("tp_p44")
    Dim cn As New SqlConnection(My.Settings.ConnectionString)

    Dim modeConnecte As Boolean


    Private Sub ProgrammeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgrammeToolStripMenuItem.Click

        If frmProgramme Is Nothing OrElse frmProgramme.IsDisposed Then

            frmProgramme = New frmProgramme(ds, cn) With {
                .MdiParent = Me,
                .Tag = modeConnecte
            }
            frmProgramme.Show()

        Else

            frmProgramme.BringToFront()

        End If

    End Sub

    Private Sub ÉtudiantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÉtudiantsToolStripMenuItem.Click

        If frmEtudiant Is Nothing OrElse frmEtudiant.IsDisposed Then

            frmEtudiant = New frmEtudiants(ds, cn) With {
                .MdiParent = Me,
                .Tag = modeConnecte
            }
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

        'Ajout d'une table pour accueillir le rapport des Etudiants par programme
        ds.Tables.Add("T_EtuParProg")


    End Sub


#Region "Région des Rapports"

    'Rapport des Programmes 
    Private Sub ProgrammeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgrammeToolStripMenuItem1.Click

        ds.Tables.Clear()

        Dim sqlCommandTblProgrammes = New SqlCommand("SELECT * FROM dbo.T_programme", cn)
        Dim sqlDataTblProgrammes = New SqlDataAdapter(sqlCommandTblProgrammes)

        sqlDataTblProgrammes.Fill(ds, "T_programme")
        Dim tableProgrammes = ds.Tables("T_programme")


        Dim jsonProgrammes As String = JsonConvert.SerializeObject(tableProgrammes, Formatting.Indented)

        Dim tempFilePathProgrammes As String = Path.Combine(Path.GetTempPath(), "rapportProgramme.html")

        Dim htmlProgrammes As String = $"
        <html>
        <head>
        <style>
            table, th, td {{
                border: 1px solid black;
                border-collapse: collapse;
                padding: 8px;
            }}
        </style>
        </head>
        <body>
        <div>
        <h1>Rapport des Programmes</h1>
        <div id='content'>
        </div>
        </div>
        <script>
        let jsonStr = {jsonProgrammes};
                if (Array.isArray(jsonStr)) {{
                            let contentDiv = document.getElementById('content');

                            let htmlTable = document.createElement('table');
                            let htmlTableHeader = document.createElement('thead');
                            let htmTableRow = document.createElement('tr');
                            let htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'No Programme:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nom';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nombre Unités:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nombre Heures:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableHeader.appendChild(htmTableRow);
                            htmlTable.appendChild(htmlTableHeader);

                            let htmlTableBody = document.createElement('tbody');

                            jsonStr.forEach(function(item) {{

                                htmTableRow = document.createElement('tr');
                                let htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_no;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_nom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_nbr_unites;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_nbr_heures;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableBody.appendChild(htmTableRow);
                            }});
                                htmlTable.appendChild(htmlTableBody);
                                contentDiv.appendChild(htmlTable);
                        }}
        </script>
        </body>
        </html>
        "

        File.WriteAllText(tempFilePathProgrammes, htmlProgrammes)
        Process.Start(New ProcessStartInfo(tempFilePathProgrammes) With {
        .UseShellExecute = True
                      })


    End Sub

    'Rapport des Étudiants par programme
    Private Sub ListeDesÉtudiantsParProgrammeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeDesÉtudiantsParProgrammeToolStripMenuItem.Click

        ds.Tables.Clear()

        Dim sqlCommandTblEtuParProg = New SqlCommand("SELECT E.etu_da, E.etu_nom, E.etu_prenom, p.pro_nom FROM dbo.T_etudiants E INNER JOIN dbo.T_programme P ON E.pro_no = P.pro_no;", cn)
        Dim sqlDataTblEtuParProg = New SqlDataAdapter(sqlCommandTblEtuParProg)

        sqlDataTblEtuParProg.Fill(ds, "T_EtuParProg")

        Dim tableEtuParProg = ds.Tables("T_EtuParProg")


        Dim jsonEtuParProg As String = JsonConvert.SerializeObject(tableEtuParProg, Formatting.Indented)

        Dim tempFilePathEtuParProg As String = Path.Combine(Path.GetTempPath(), "rapportEtuParProg.html")

        Dim htmlEtuParProg As String = $"

        <html>
        <head>
        <style>
            table, th, td {{
                border: 1px solid black;
                border-collapse: collapse;
                padding: 8px;
            }}
        </style>
        </head>
        <body>
        <h1>Rapport des étudiants par programme</h1>
        <div id='content'>
        </div>
        <script>
        let jsonStr = {jsonEtuParProg};
                if (Array.isArray(jsonStr)) {{
                            let contentDiv = document.getElementById('content');

                            let htmlTable = document.createElement('table');
                            let htmlTableHeader = document.createElement('thead');
                            let htmTableRow = document.createElement('tr');
                            let htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Prénom:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nom';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nom du programme:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableHeader.appendChild(htmTableRow);
                            htmlTable.appendChild(htmlTableHeader);

                            let htmlTableBody = document.createElement('tbody');

                            jsonStr.forEach(function(item) {{

                                htmTableRow = document.createElement('tr');
                                let htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_prenom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_nom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_nom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableBody.appendChild(htmTableRow);
                            }});
                                htmlTable.appendChild(htmlTableBody);
                                contentDiv.appendChild(htmlTable);
                        }}
        </script>
        </body>
        </html>
        "

        File.WriteAllText(tempFilePathEtuParProg, htmlEtuParProg)
        Process.Start(New ProcessStartInfo(tempFilePathEtuParProg) With {
        .UseShellExecute = True
                      })

    End Sub

    'Rapport des Étudiants
    Private Sub ListeDesÉtudiantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeDesÉtudiantsToolStripMenuItem.Click

        ds.Tables.Clear()

        Dim sqlCommandTblEtudiants = New SqlCommand("SELECT * FROM dbo.T_etudiants", cn)
        Dim sqlDataTblEtudiants = New SqlDataAdapter(sqlCommandTblEtudiants)
        sqlDataTblEtudiants.Fill(ds, "T_etudiants")

        Dim tableEtudiants = ds.Tables("T_etudiants")


        Dim jsonEtudiants As String = JsonConvert.SerializeObject(tableEtudiants, Formatting.Indented)

        Dim tempFilePathEtudiants As String = Path.Combine(Path.GetTempPath(), "rapportEtudiants.html")

        Dim htmlEtudiants As String = $"
        <html>
        <head>
        <style>
            table, th, td {{
                border: 1px solid black;
                border-collapse: collapse;
                padding: 8px;
            }}
        </style>
        </head>
        <body>
        <div>
        <h1>Rapport des Étudiants</h1>
        <div id='content'>
        </div>
        </div>
        <script>
        let jsonStr = {jsonEtudiants};
                if (Array.isArray(jsonStr)) {{
                            let contentDiv = document.getElementById('content');

                            let htmlTable = document.createElement('table');
                            let htmlTableHeader = document.createElement('thead');
                            let htmTableRow = document.createElement('tr');
                            let htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'No DA Etudiant:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'No Programme:';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Nom';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Prénom';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Sexe';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Adresse';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Ville';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Province';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Telephone';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableTH = document.createElement('th');
                            htmlTableTH.innerText = 'Code Postal';
                            htmTableRow.appendChild(htmlTableTH);
                            htmlTableHeader.appendChild(htmTableRow);
                            htmlTable.appendChild(htmlTableHeader);

                            let htmlTableBody = document.createElement('tbody');

                            jsonStr.forEach(function(item) {{

                                htmTableRow = document.createElement('tr');
                                let htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_da;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.pro_no;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_nom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_prenom;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_sexe;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_adresse;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_ville;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_province;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_telephone;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableTD = document.createElement('td');
                                htmlTableTD.innerText = item.etu_codepostal;
                                htmTableRow.appendChild(htmlTableTD);
                                htmlTableBody.appendChild(htmTableRow);
                            }});
                                htmlTable.appendChild(htmlTableBody);
                                contentDiv.appendChild(htmlTable);
                        }}
        </script>
        </body>
        </html>
        "

        File.WriteAllText(tempFilePathEtudiants, htmlEtudiants)
        Process.Start(New ProcessStartInfo(tempFilePathEtudiants) With {
        .UseShellExecute = True
                      })


    End Sub

#End Region


End Class
