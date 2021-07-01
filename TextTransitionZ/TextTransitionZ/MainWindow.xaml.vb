Class MainWindow
#Disable Warning
    Private Sub AnimateBTn_Click(sender As Object, e As RoutedEventArgs) Handles AnimateBTn.Click
        Dim A As New TextTransitionZ
        Dim RND As New Random
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       TB1.Text = A.TextAudioVisualiser(5, {RND.Next(0, 11), RND.Next(0, 11), RND.Next(0, 11), RND.Next(0, 11), RND.Next(0, 11)}, 0, 10, Space(1))
                                       Await Task.Delay(100)
                                   Loop
                               End Sub)
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       Await A.TextHide(TB2, ">", 100)
                                       Await Task.Delay(1000)
                                       Await A.TextShow(TB2, ">", "Hello!", 100)
                                   Loop
                               End Sub)
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       Await A.TextLoading(TB3, RND.Next(0, 15), 100)
                                   Loop
                               End Sub)
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       A.TextProgressBar(RND.Next(0, 11), 0, 10, Space(1))
                                       Await Task.Delay(100)
                                   Loop
                               End Sub)
        A.TextRandom(TB4, 100)
        Dim RNDSenSet As String() = {"Hello!", "Ciao!", "Salve!", "Pronto!", "Piacere!", "Ola!", "مرحبا", "Bonjour!"}
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       Await A.TextRandomToText(RNDSenSet(RND.Next(0, RNDSenSet.Count)), TB5)
                                       Await Task.Delay(250)
                                       Await A.TextBlink(TB5, 5, 250)
                                   Loop
                               End Sub)
        A.TextShowHide(TB6, "$", 100, 2000)
        Dispatcher.BeginInvoke(Async Sub()
                                   Do
                                       TB7.Text = A.TextVerticalProgressBar(RND.Next(0, 11), 0, 10)
                                       Await Task.Delay(100)
                                   Loop
                               End Sub)
        A.TextLoadingInfinite(TB6, TextTransitionZ.LoadingPatterns.Tetris, 100)
    End Sub
End Class
