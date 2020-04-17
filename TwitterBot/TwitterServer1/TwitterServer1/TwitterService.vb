Imports System
Imports System.Configuration 'Added reference to use updated configurationManager class 
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Net
Imports System.Data.SqlClient
Imports System.IO
'Imports TweetSharp 'added reference for tweetsharp
Imports TwitterVB2



Public Class TwitterService

    Private consumerKey As String = ConfigurationManager.AppSettings("ConsumerKey")
    Private ConsumerSecret As String = ConfigurationManager.AppSettings("ConsumerSecret")
    Private AccessToken As String = ConfigurationManager.AppSettings("AccessToken")
    Private AccessTokenSecret As String = ConfigurationManager.AppSettings("AccessTokenSecret")




    Public Function getPin() As String


        Dim twitter As New TwitterAPI

        'Dim OAuth As TwitterVB2.TwitterOAuth = New TwitterOAuth(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret)

        Try
            Dim url As String = (twitter.GetAuthenticationLink(consumerKey, ConsumerSecret))
            Process.Start(url)


        Catch ex As TwitterAPIException

            MsgBox(ex.StackTrace)


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try




        Return ""
    End Function




    Public Function SendDirectMSG() As String


        Dim twitter As New TwitterAPI()

        Dim OAuth As TwitterVB2.TwitterOAuth = New TwitterOAuth(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret)

        twitter.AuthenticateWith(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret)

        Try
            twitter.SendDirectMessage("@brienzhere", "wazzupBro")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        '   Dim message As New TwitterVB2.TwitterDirectMessage()
        '   Message.SenderScreenName = "Brienzhere"










        Return ""
    End Function








End Class
