Imports System.Drawing.Drawing2D
Public Class FLine
    Private Sub FLine_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim wfactor As Integer = 4 'half the line width, kinda
        ' create 6 points for path
        Dim pts As Point() = {
            New Point(0, 0),
            New Point(wfactor, 0),
            New Point(Width, Height - wfactor),
            New Point(Width, Height),
            New Point(Width - wfactor, Height),
            New Point(0, wfactor)
        }
        ' magic numbers! 
        Dim types As Byte() = {
            0, ' start point
            1, ' line
            1, ' line
            1, ' line
            1, ' line 
            1  ' line
        }
        Dim path As GraphicsPath = New GraphicsPath(pts, types)
        Region = New Region(path)
    End Sub

    Private Sub FLine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim wfactor As Integer = 4 'half the line width, kinda
        ' create 6 points for path
        Dim pts As Point() = {
            New Point(0, 0),
            New Point(wfactor, 0),
            New Point(Width, Height - wfactor),
            New Point(Width, Height),
            New Point(Width - wfactor, Height),
            New Point(0, wfactor)
        }
        ' magic numbers! 
        Dim types As Byte() = {
            0, ' start point
            1, ' line
            1, ' line
            1, ' line
            1, ' line 
            1  ' line
        }
        Dim path As GraphicsPath = New GraphicsPath(pts, types)
        Region = New Region(path)
    End Sub
End Class
