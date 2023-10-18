Imports System.Text.RegularExpressions
Imports Microsoft.Data.SqlClient

Public Class BaseDeDonnee

    Protected Property con As SqlConnection
    Protected Property cmd As SqlCommand
    Protected Property qry As Object

    Protected regExQuery As Regex = New Regex("@\w+", RegexOptions.Multiline)

    Private Shared db As BaseDeDonnee = Nothing

    Private Sub New()

        Try
            con = New SqlConnection(My.Settings.ConnectionString)
            con.Open()
            cmd = New SqlCommand()
            cmd.Connection = con
            db = Me
        Catch sqlEx As SqlException
            MsgBox("Une erreur SQL est survenue lors de la connexion à la Base de données : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)
            Application.Exit()
        Catch ex As Exception
            MsgBox("Une erreur standard est survenue lors de la connexion à la Base de données : " & ex.Message)
            Application.Exit()
        End Try

    End Sub

    Public Shared Function GetBD() As BaseDeDonnee

        If db Is Nothing Then
            db = New BaseDeDonnee()
        End If

        Return db

    End Function

    Public Function Query(qryString As String, Optional QryParamsTab() As Object = Nothing) As BaseDeDonnee

        cmd.CommandText = qryString
        cmd.Parameters.Clear()

        Dim qryNameParameters As MatchCollection = regExQuery.Matches(qryString)

        If QryParamsTab IsNot Nothing Then
            If qryNameParameters.Count <> QryParamsTab.Length Then
                Throw New Exception("La requête entrée comprends une erreur de syntaxe")
            End If

            For i As Integer = 0 To QryParamsTab.Length - 1

                Select Case VarType(QryParamsTab(i))
                    Case vbInteger
                        cmd.Parameters.Add(New SqlParameter(qryNameParameters(i).ToString(), Convert.ToInt32(QryParamsTab(i))))
                    Case vbString
                        cmd.Parameters.Add(New SqlParameter(qryNameParameters(i).ToString(), QryParamsTab(i).ToString()))
                    Case Else
                        cmd.Parameters.Add(New SqlParameter(qryNameParameters(i).ToString(), QryParamsTab(i)))
                End Select

            Next

        End If

        Dim tSqlCmd As String
        tSqlCmd = qryString.Substring(0, qryString.IndexOf(" "))

        Try
            If tSqlCmd.ToUpper() = "SELECT" Then
                qry = cmd.ExecuteReader()
            Else
                qry = cmd.ExecuteNonQuery()
            End If
        Catch sqlEx As SqlException
            MsgBox("Une erreur SQL est survenue lors de l'exécution de la requête : " & sqlEx.Message & " Erreur No : " & sqlEx.Number)
        Catch ex As Exception
            MsgBox("Une erreur standard est survenue lors de l'exécution de la requête : " & ex.Message)

        End Try



        Return Me
    End Function

    Public Function GetReader()
        Return TryCast(qry, SqlDataReader)
    End Function

    Public Function GetAffectedRow()
        Return CInt(qry)
    End Function

    Public Sub Dispose()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MsgBox("Impossible de libérer les ressources de Base de donnée, une erreur est survenue : " & ex.Message)
        End Try
    End Sub

End Class
