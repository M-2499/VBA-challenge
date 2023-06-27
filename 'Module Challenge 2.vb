'Module Challenge 2


Sub Alphabetical_Test()
    Dim tickersymbol As String
    Dim priceChange As Double
    Dim percentageChange As Double
    Dim totalStockVolume As Double
    Dim RowNumber As Double
    
For Each ws In Worksheets
ws.Activate
    lastrow = ws.Cells(Rows.Count, 1).End(xlUp).Row
    Range("I1").Value = "Ticker Symbol"
    Range("J1").Value = "Yearly Change"
    Range("K1").Value = "Percent Change"
    Range("L1").Value = "Total Stock Value"
    Range("N1").Value = "Greatest % Increase"
    Range("N2").Value = "Greatest % Decrease"
    RowNumber = 2
    Opening = Cells(2, 3).Value
For i = 2 To lastrow
    If Cells(i + 1, 1).Value <> Cells(i, 1) Then
        Ticker = Cells(i, 1).Value
        Cells(RowNumber, "i").Value = Ticker
        Cells(RowNumber, "L").Value = totalStockVolume
        totalStockVolume = 0
        Closing = Cells(i, "F").Value
        yearlychange = Closing - Opening
        Cells(RowNumber, "j").Value = yearlychange
        Opening = Cells(i + 1, "C")
        RowNumber = RowNumber + 1
       
        
    Else
       totalStockVolume = Cells(i, 7).Value + totalStockVolume
       
       
       
    
    End If
Next i
    
Next ws
     

'

'For Each ws In Worksheets
'ws.Activate
'lastrow = ws.Cells(Rows.Count, 1).End(xlUp).Row
 Sub abc()
    lastrow = Cells(Rows.Count, 1).End(xlUp).Row
    Range("I1").Value = "Ticker Symbol"
    Range("J1").Value = "Yearly Change"
    Range("K1").Value = "Percent Change"
    Range("L1").Value = "Total Stock Value"
    Range("N2").Value = "Greatest % Increase"
    Range("N3").Value = "Greatest % Decrease"
    Range("O1").Value = "Ticker"
    Range("P1").Value = "Value"
    rownumber = 2

For i = 2 To lastrow
    If Cells(i - 1, 1).Value <> Cells(i, 1) Then
        
        tickersymbol = Cells(i, 1).Value
        Range("i" & rownumber).Value = tickersymbol
        
        
        opening = Cells(i, 3).Value
        'Range("P" & rownumber).Value = opening
        
        
        
      ElseIf Cells(i + 1, 1).Value <> Cells(i, 1) Then
      
        closing = Cells(i, 6).Value
        'Range("Q" & rownumber).Value = closing
        
        
        yearlychange = closing - opening
        'Range("J" & rownumber).Value = yearlychange
        
        
        PercentChange = yearlychange / opening
        Range("K" & rownumber).Value = PercentChange
        
        
        totalStockVolume = Cells(i, 7).Value
        Range("l" & rownumber).Value = totalStockVolume
      
        totalStockVolume = 0
        rownumber = rownumber + 1
        
        
    Else
       totalStockVolume = Cells(i, 7).Value + totalStockVolume
             

    End If
Next i

Dim upper As Long
Dim lower As Long
Dim uppervolume As Long

    'upper = WorksheetFunction.Max(Range("K2:K" & rownumber))
      Range("P2") = upper
    'lower = WorksheetFunction.Min(Range("K2:K" & rownumber))
      Range("P3") = lower
    'uppervolume = WorksheetFunction.Max(Range("L2:L" & rownumber))
      'Range("P4") = uppervolume


    
    i = Cells(Rows.Count, "I").End(xlUp).Row
    Range("K2:K" & i).NumberFormat = "0.00%"
    
    
'Next ws
     
    



End Sub



Sub stock_analysis():
    ' Set dimensions
    Dim total As Double
    Dim i As Long
    Dim change As Double
    Dim j As Integer
    Dim start As Long
    Dim rowCount As Long
    Dim percentChange As Double
    Dim days As Integer
    Dim dailyChange As Double
    Dim averageChange As Double
    Dim ws As Worksheet
    For Each ws In Worksheets
        ' Set values for each worksheet
        j = 0
        total = 0
        change = 0
        start = 2
        dailyChange = 0
        ' Set title row
        ws.Range("I1").Value = "Ticker"
        ws.Range("J1").Value = "Yearly Change"
        ws.Range("K1").Value = "Percent Change"
        ws.Range("L1").Value = "Total Stock Volume"
        ws.Range("P1").Value = "Ticker"
        ws.Range("Q1").Value = "Value"
        ws.Range("O2").Value = "Greatest % Increase"
        ws.Range("O3").Value = "Greatest % Decrease"
        ws.Range("O4").Value = "Greatest Total Volume"
        ' get the row number of the last row with data
        rowCount = Cells(Rows.Count, "A").End(xlUp).Row
        For i = 2 To rowCount
            ' If ticker changes then print results
            If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
                ' Stores results in variables
                total = total + ws.Cells(i, 7).Value
                ' Handle zero total volume
                If total = 0 Then
                    ' print the results
                    ws.Range("I" & 2 + j).Value = Cells(i, 1).Value
                    ws.Range("J" & 2 + j).Value = 0
                    ws.Range("K" & 2 + j).Value = "%" & 0
                    ws.Range("L" & 2 + j).Value = 0
                Else
                    ' Find First non zero starting value
                    If ws.Cells(start, 3) = 0 Then
                        For find_value = start To i
                            If ws.Cells(find_value, 3).Value <> 0 Then
                                start = find_value
                                Exit For
                            End If
                        Next find_value
                    End If
                    ' Calculate Change
                    change = (ws.Cells(i, 6) - ws.Cells(start, 3))
                    percentChange = change / ws.Cells(start, 3)
                    ' start of the next stock ticker
                    start = i + 1
                    ' print the results
                    ws.Range("I" & 2 + j).Value = ws.Cells(i, 1).Value
                    ws.Range("J" & 2 + j).Value = change
                    ws.Range("J" & 2 + j).NumberFormat = "0.00"
                    ws.Range("K" & 2 + j).Value = percentChange
                    ws.Range("K" & 2 + j).NumberFormat = "0.00%"
                    ws.Range("L" & 2 + j).Value = total
                    ' colors positives green and negatives red
                    Select Case change
                        Case Is > 0
                            ws.Range("J" & 2 + j).Interior.ColorIndex = 4
                        Case Is < 0
                            ws.Range("J" & 2 + j).Interior.ColorIndex = 3
                        Case Else
                            ws.Range("J" & 2 + j).Interior.ColorIndex = 0
                    End Select
                End If
                ' reset variables for new stock ticker
                total = 0
                change = 0
                j = j + 1
                days = 0
                dailyChange = 0
            ' If ticker is still the same add results
            Else
                total = total + ws.Cells(i, 7).Value
            End If
        Next i
        ' take the max and min and place them in a separate part in the worksheet
        ws.Range("Q2") = "%" & WorksheetFunction.Max(ws.Range("K2:K" & rowCount)) * 100
        ws.Range("Q3") = "%" & WorksheetFunction.Min(ws.Range("K2:K" & rowCount)) * 100
ws.Range("Q4") = WorksheetFunction.Max(ws.Range("L2:L" & rowCount))
        ' returns one less because header row not a factor
        increase_number = WorksheetFunction.Match(WorksheetFunction.Max(ws.Range("K2:K" & rowCount)), ws.Range("K2:K" & rowCount), 0)
        decrease_number = WorksheetFunction.Match(WorksheetFunction.Min(ws.Range("K2:K" & rowCount)), ws.Range("K2:K" & rowCount), 0)
        volume_number = WorksheetFunction.Match(WorksheetFunction.Max(ws.Range("L2:L" & rowCount)), ws.Range("L2:L" & rowCount), 0)
        ' final ticker symbol for  total, greatest % of increase and decrease, and average
        ws.Range("P2") = ws.Cells(increase_number + 1, 9)
        ws.Range("P3") = ws.Cells(decrease_number + 1, 9)
        ws.Range("P4") = ws.Cells(volume_number + 1, 9)
    Next ws
End Sub
