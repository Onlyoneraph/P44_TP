Imports Microsoft.Data
Imports Microsoft.Data.SqlClient

Public Class frmProgramme

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dataread As SqlDataReader

    Private Sub frmProgramme_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con = New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=tp_p44;Integrated Security=SSPI;Trust Server Certificate=True")

        Try

            con.Open()


        Catch sqlEx As SqlException
            MsgBox("Une erreur est survenue lors de la connexion en lien avec SQL : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)
        Catch ex As Exception
            MsgBox("Une erreur autre est survenue lors de la connexion : " & ex.Message)
        End Try

        ExtraireDonneesVersListView()

        If lvProgramme.Items.Count > 0 Then

            lvProgramme.SelectedIndices.Add(0)
            lvProgramme.Focus()

        End If



    End Sub

    Private Sub ExtraireDonneesVersListView()

        Dim lvi As ListViewItem

        cmd = New SqlCommand("SELECT * FROM dbo.T_programme", con)

        Try


            dataread = cmd.ExecuteReader()

            Do While dataread.Read()

                lvi = New ListViewItem(dataread("pro_no").ToString())
                lvi.SubItems.Add(dataread("pro_nom").ToString())
                lvi.SubItems.Add(dataread("pro_nbr_unites").ToString())
                lvi.SubItems.Add(dataread("pro_nbr_heures").ToString())

                lvProgramme.Items.Add(lvi)


            Loop


        Catch sqlEx As SqlException
            MsgBox("Une erreur est survenue lors de la connexion en lien avec SQL : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)

        Catch ex As Exception
            MsgBox("Une erreur autre est survenue lors de la connexion : " & ex.Message)

        Finally

            dataread.Close()

        End Try

    End Sub

    Private Sub frmProgramme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If con.State = ConnectionState.Open Then

            con.Close()

        End If

    End Sub

    Private Sub lvProgramme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvProgramme.SelectedIndexChanged

        If lvProgramme.SelectedItems.Count > 0 Then

            Dim idCours As String

            idCours = lvProgramme.SelectedItems.Item(0).ToString()

            ChargerProgrammeFormulaire(idCours)

        End If

    End Sub

    Private Sub ChargerProgrammeFormulaire(listViewItem As String)

        cmd = New SqlCommand("SELECT * FROM dbo.T_programme WHERE pro_no=@pro_no", con)
        cmd.Parameters.AddWithValue("pro_no", listViewItem)


        Try

            dataread = cmd.ExecuteReader()

            If dataread.Read() Then

                mtbNoProgramme.Text = dataread("pro_no").ToString()
                txtBoxNom.Text = dataread("pro_nom").ToString()
                mtbNbrUnites.Text = dataread("pro_nbr_unites").ToString()
                mtbNbrHeures.Text = dataread("pro_nbr_heures").ToString()

            End If

        Catch Sqlex As SqlException
            MsgBox("Une erreur est survenue avec SQL pour extraire les données dans le Formulaire : " & Sqlex.Message & " Numéro d'erreur : " & Sqlex.Number)

        Catch ex As Exception
            MsgBox("Une erreur est survenue pour extraire les données dans le Formulaire : " & ex.Message)

        Finally
            dataread.Close()

        End Try



    End Sub


End Class