﻿'Carson Bogart
'RCET 0265
'Spring 22
'Shuffle the Deck
'

Option Explicit On
Option Strict On
Module ShuffleTheDeck_CB
    Sub Main()
        Dim Hand(3, 12) As Boolean
        Dim Suit As Integer
        Dim Card As Integer

        For i = 0 To 52
            'see if card has been drawn from the deck
            'if card is drawn then displayed in array
            'if card hasn't been drawn it won't display

            Do
                Suit = RandomNumberInRange(3)
                Card = RandomNumberInRange(12)
            Loop While Hand(Suit, Card)

            Hand(Suit, Card) = True

            Console.Clear()
            DisplayHand(Hand)
            Console.ReadLine()

        Next

        DisplayHand(Hand)
        Console.Read()
        'press enter to draw a card
    End Sub
    Sub DisplayHand(ByRef Hand(,) As Boolean)
        'array to create categories for cards to be drawn
        Dim header() As String = {"Hearts", "Spades", "Clubs", "Diamonds"}
        Dim columnWidth As Integer = 8
        Dim columnData As String
        For row = 0 To Hand.GetLength(1)
            For column = 0 To Hand.GetLength(0) - 1
                Select Case row
                    Case 0 'first row is column headers
                        columnData = header(column).PadLeft(columnWidth)
                    Case Else
                        If Not Hand(column, row - 1) Then 'mark if card has been drawn from the deck
                            columnData = "  "
                        Else 'show number if card hasn't been drawn in the deck
                            columnData = CStr(row)
                            If row = 1 Then
                                columnData = ("Ace")
                            ElseIf row = 11 Then
                                columnData = ("Jack")
                            ElseIf row = 12 Then
                                columnData = ("Queen")
                            ElseIf row = 13 Then
                                columnData = ("King")
                            End If
                        End If
                End Select
                Console.Write(columnData.PadLeft(columnWidth) & " |")
            Next
            Console.WriteLine()
        Next
    End Sub

    ''' <summary>
    ''' function for randomizing the card shuffling
    ''' </summary>
    ''' <param name="max%"></param>
    ''' <param name="min%"></param>
    ''' <returns>random value of card</returns>
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function
End Module
