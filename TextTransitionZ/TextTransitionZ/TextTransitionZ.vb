Public Class TextTransitionZ
    Dim CharSet As String = "!""#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~"
    Dim LoadingPattern As New List(Of String())({New String() {"\", "|", "/", "--"}, New String() {"〇", "◑", "◒", "◐", "◓", "◉"}, New String() {"〇", "◔", "◑", "◕", "◉"}, New String() {"↑", "↗", "→", "↘", "↓", "↙", "←", "↖"}, New String() {"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█"}, New String() {"█", "▇", "▆", "▅", "▄", "▃", "▂", "▁"}, New String() {"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█", "▇", "▆", "▅", "▄", "▃", "▁"}, New String() {"▖", "▘", "▝", "▗"}, New String() {"┤", "┘", "┴", "└", "├", "┌", "┬", "┐"}, New String() {"◢", "◣", "◤", "◥"}, New String() {"◰", "◳", "◲", "◱"}, New String() {"◴", "◷", "◶", "◵"}, New String() {"◡◡", "⊙⊙", "◠◠"}, New String() {"⣾", "⣽", "⣻", "⢿", "⡿", "⣟", "⣯", "⣷"}, New String() {"⠁", "⠂", "⠄", "⡀", "⢀", "⠠", "⠐", "⠈"}})
    Public Enum LoadingPatterns
        Slashes
        Circles
        Circles2
        Arrows
        Rectangles
        RectanglesReversed
        RectanglesForwardAndBackward
        Dots
        Pillars
        Corners
        SquaresWithCorners
        CirclesWithCorners
        Faces
        Tetris
        Points
    End Enum
    Private Sub Init()
        LoadingPattern.Add({"\", "|", "/", "--"})
        LoadingPattern.Add({"〇", "◑", "◒", "◐", "◓", "◉"})
        LoadingPattern.Add({"〇", "◔", "◑", "◕", "◉"})
        LoadingPattern.Add({"↑", "↗", "→", "↘", "↓", "↙", "←", "↖"})
        LoadingPattern.Add({"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█"})
        LoadingPattern.Add({"█", "▇", "▆", "▅", "▄", "▃", "▂", "▁"})
        LoadingPattern.Add({"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█", "▇", "▆", "▅", "▄", "▃", "▁"})
        LoadingPattern.Add({"▖", "▘", "▝", "▗"})
        LoadingPattern.Add({"┤", "┘", "┴", "└", "├", "┌", "┬", "┐"})
        LoadingPattern.Add({"◢", "◣", "◤", "◥"})
        LoadingPattern.Add({"◰", "◳", "◲", "◱"})
        LoadingPattern.Add({"◴", "◷", "◶", "◵"})
        LoadingPattern.Add({"◡◡", "⊙⊙", "◠◠"})
        LoadingPattern.Add({"⣾", "⣽", "⣻", "⢿", "⡿", "⣟", "⣯", "⣷"})
        LoadingPattern.Add({"⠁", "⠂", "⠄", "⡀", "⢀", "⠠", "⠐", "⠈"})
    End Sub
    Private Function ValToPercentage(Val As Double, Min As Double, Max As Double) As Integer
        If Val > Min AndAlso Val < Max Then
            Return ((Val - Min) * 100) / (Max - Min)
        ElseIf Val = Max Then
            Return 100
        Else
            Return 0
        End If
    End Function
    Private Function PercentageToVal(Percentage As Double, Min As Double, Max As Double) As Integer
        If Percentage > 0 AndAlso Percentage < 100 Then
            Return (((Max - Min) * Percentage) + (Min * 100)) / 100
        ElseIf Percentage >= 100 Then
            Return Max
        Else
            Return Min
        End If
    End Function
    Public Async Function TextRandomToText(ToText As String, TB As TextBlock) As Task 'Random To Text
        Dim RND As New Random
        Dim RNDCharLen As Integer() = Nothing
        For i As Integer = 0 To ToText.Length - 1
            ReDim Preserve RNDCharLen(i + 1) : RNDCharLen(i) = RND.Next(5, 50)
        Next
        Dim SB As New Text.StringBuilder
        Do
            SB.Clear()
            For i As Integer = 0 To ToText.Length - 1
                If RNDCharLen(i) <> 0 Then
                    SB.Append(CharSet(RND.Next(0, 96)))
                    RNDCharLen(i) -= 1
                Else
                    SB.Append(ToText.Substring(i, 1))
                End If
            Next
            TB.Text = SB.ToString
            If TB.Text = ToText Then Exit Do
            Await Task.Delay(50)
        Loop
    End Function
    Public Async Function TextShowHide(TB As TextBlock, HideChar As String, Wait1 As Integer, Wait2 As Integer) As Task 'ShowHide Transition
        Dim CText = TB.Text
        For i As Integer = 0 To CText.Length - 1
                TB.Text = TB.Text.Replace(TB.Text.Substring(i, 1), HideChar)
                Await Task.Delay(Wait1)
            Next
            Await Task.Delay(Wait2)
            Dim SB As New Text.StringBuilder(TB.Text)
        For i As Integer = 0 To CText.Length - 1
            TB.Text = TB.Text.Replace(TB.Text.Substring(i, 1), HideChar)
            TB.Text = SB.Remove(i, 1).Insert(i, CText.Substring(i, 1)).ToString
            Await Task.Delay(Wait1)
        Next
    End Function
    Public Async Function TextHide(TB As TextBlock, HideChar As String, Wait1 As Integer) As Task 'Hide Transition
        Dim CText = TB.Text
        For i As Integer = 0 To CText.Length - 1
            TB.Text = TB.Text.Replace(TB.Text.Substring(i, 1), HideChar)
            Await Task.Delay(Wait1)
        Next
    End Function
    Public Async Function TextShow(TB As TextBlock, HideChar As String, Text As String, Wait1 As Integer) As Task 'Show Transition
        Dim SB As New Text.StringBuilder(TB.Text)
        For i As Integer = 0 To Text.Length - 1
            Try
                TB.Text = SB.Remove(i, 1).Insert(i, Text.Substring(i, 1)).ToString
            Catch ex As Exception
                TB.Text = SB.Insert(i, Text.Substring(i, 1)).ToString
            End Try
            Await Task.Delay(Wait1)
        Next
        TB.Text.Remove(Text.Length - 1)
    End Function
    Public Async Function TextRandomOnce(TB As TextBlock, Wait1 As Integer) As Task 'Random 1 char at time
        Dim RND As New Random
        Do
            For i As Integer = 0 To TB.Text.Length - 1
                TB.Text = TB.Text.Replace(TB.Text.Substring(i, 1), CharSet(RND.Next(0, 96)))
                Await Task.Delay(Wait1)
            Next
        Loop
    End Function
    Public Async Function TextRandom(TB As TextBlock, Wait1 As Integer) As Task 'Random
        Dim RND As New Random
        Dim SB As New Text.StringBuilder
        Do
            SB.Clear()
            For i As Integer = 0 To TB.Text.Length - 1
                SB.Append(CharSet(RND.Next(0, 96)))
            Next
            TB.Text = SB.ToString
            Await Task.Delay(Wait1)
        Loop
    End Function
    Public Async Function TextLoading(TB As TextBlock, Pattern As LoadingPatterns, Wait1 As Integer, Optional CloneCount As Integer = 0) As Task 'Loading
        Dim i As Integer = 0
        Dim Chars As String() = LoadingPattern(Pattern)
        Do
            TB.Text = Chars(i)
            For _i As Integer = 1 To CloneCount
                TB.Text += Chars(i)
            Next
            If i = Chars.Length - 1 Then
                'i = 0
                Exit Do
            Else
                i += 1
            End If
            Await Task.Delay(Wait1)
        Loop
    End Function
    Public Async Function TextLoadingInfinite(TB As TextBlock, Pattern As LoadingPatterns, Wait1 As Integer, Optional CloneCount As Integer = 0) As Task 'Loading
        Dim i As Integer = 0
        Dim Chars As String() = LoadingPattern(Pattern)
        Do
            TB.Text = Chars(i)
            For _i As Integer = 1 To CloneCount
                TB.Text += Chars(i)
            Next
            If i = Chars.Length - 1 Then
                i = 0
            Else
                i += 1
            End If
            Await Task.Delay(Wait1)
        Loop
    End Function
    Public Function TextProgressBar(Value As Integer, Min As Integer, Max As Integer, Optional Spacing As String = "") As String '▁ ▂ ▃ ▄ ▅ ▆ ▇ █ Min:0 Max:8 Step:12.5        
        Dim ProgCharSet As String() = {"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█"}
        Select Case PercentageToVal(Value, 0, 8)
            Case = 0
                Return String.Empty
            Case = 1
                Return ProgCharSet(0) & Spacing
            Case = 2
                Return ProgCharSet(0) & Spacing & ProgCharSet(1)
            Case = 3
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2)
            Case = 4
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2) & Spacing & ProgCharSet(3)
            Case = 5
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2) & Spacing & ProgCharSet(3) & Spacing & ProgCharSet(4)
            Case = 6
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2) & Spacing & ProgCharSet(3) & Spacing & ProgCharSet(4) & Spacing & ProgCharSet(5)
            Case = 7
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2) & Spacing & ProgCharSet(3) & Spacing & ProgCharSet(4) & Spacing & ProgCharSet(5) & Spacing & ProgCharSet(6)
            Case = 8
                Return ProgCharSet(0) & Spacing & ProgCharSet(1) & Spacing & ProgCharSet(2) & Spacing & ProgCharSet(3) & Spacing & ProgCharSet(4) & Spacing & ProgCharSet(5) & Spacing & ProgCharSet(6) & Spacing & ProgCharSet(7)
            Case Else
                Return String.Empty
        End Select
    End Function
    Public Function TextVerticalProgressBar(Value As Integer, Min As Integer, Max As Integer, Optional Spacing As String = "") As String '▁ ▂ ▃ ▄ ▅ ▆ ▇ █ Min:0 Max:8 Step:12.5        
        Dim ProgCharSet As String() = {"▁", "▂", "▃", "▄", "▅", "▆", "▇", "█"}
        Select Case PercentageToVal(ValToPercentage(Value, Min, Max), 0, 8)
            Case = 0
                Return ProgCharSet(0) & Spacing
            Case = 1
                Return ProgCharSet(0) & Spacing
            Case = 2
                Return ProgCharSet(1) & Spacing
            Case = 3
                Return ProgCharSet(2) & Spacing
            Case = 4
                Return ProgCharSet(3) & Spacing
            Case = 5
                Return ProgCharSet(4) & Spacing
            Case = 6
                Return ProgCharSet(5) & Spacing
            Case = 7
                Return ProgCharSet(6) & Spacing
            Case = 8
                Return ProgCharSet(7) & Spacing
            Case Else
                Return String.Empty & Spacing
        End Select
    End Function
    Public Function TextAudioVisualiser(Bands As Integer, Peaks As Integer(), Min As Integer, Max As Integer, Spacing As String) As String
        Dim SB As New Text.StringBuilder
        For i As Integer = 0 To Bands - 1
            SB.Append(TextVerticalProgressBar(Peaks(i), Min, Max, Spacing))
        Next
        Return SB.ToString
    End Function
    Public Async Function TextBlink(TB As TextBlock, BlinkCount As Integer, Wait1 As Integer) As Task
        Dim CText = TB.Text
        For i As Integer = 0 To (BlinkCount * 2) - 1
            If TB.Text = CText Then
                TB.Text = String.Empty
            Else
                TB.Text = CText
            End If
            Await Task.Delay(Wait1)
        Next
    End Function
End Class
