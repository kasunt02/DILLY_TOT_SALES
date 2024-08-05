Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports LiveCharts
Imports LiveCharts.WinForms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1

    Dim sSql As String
'test'
    ' Use the local IP address or server name
    Dim serverAddress As String = "124.43.7.123" ' "192.168.1.100" Replace with your actual local IP address
    Dim databaseName As String = "EasyWayNew"
    Dim username As String = "sa" ' If using SQL Server authentication
    Dim password As String = "tstc123" ' If using SQL Server authentication

    'Dim connectionString As String = "Data Source={serverAddress};Initial Catalog={databaseName};User ID={username};Password={password};"
    'Dim connectionString As String = "Data Source=YourServerName;Initial Catalog=EvolutionCommon1;Integrated Security=True"
    'Dim connectionString As String = "10.10.1.4;Database=EvolutionCommon1;User Id=sa;Password=tstc123;"
    Dim connectionString As String = "Server=10.10.1.30;Database=EasyWayNew;User Id=sa;Password=tstc123;"
    'Private Chart1 As Object
    'Provider=MSOLEDBSQL;DataTypeCompatibility=80;Server=myServerAddress;Database=myDataBase;UID=myUsername;PWD=myPassword;
    'Dim connectionString As String = "Server=124.43.7.123,1331;Database=EasyWayNew;User Id=sa;Password=tstc123;"

    Private Sub clearT()

        TextBox1.Text = "0.00"
        TextBox2.Text = "0.00"
        TextBox3.Text = "0.00"
        TextBox4.Text = "0.00"
        TextBox5.Text = "0.00"
        TextBox6.Text = "0.00"
        TextBox7.Text = "0.00"

    End Sub

    Private Sub MnChart()

        'Dim value1, value2, value3, value4, value5, value6 As Decimal
        Dim T1, T2, T3, T4, T5, T6 As Integer
        'Dim T1 As Integer
        Dim formattedValue1 As Integer
        Dim formattedValue2 As Integer
        Dim sum As Double
        Dim value1 As Decimal

        Dim DT1 As String
        Dim DTM As String
        DT1 = Format(Now, "yyyy-MM-dd")
        'DTM = Left(DT1, 2)
        DTM = Format(Now.Day)
        MsgBox(DTM)
        MsgBox(DT1)

        'For DT1 = 1 To 31
        'DTM = DT1
        'MsgBox(DTM)
        'Next

        'Dim xx As Date = New DateTime(2024, 3, 1)
        Dim xx As Date = DT1
        Dim yy As Date = New DateTime(2024, 6, 30)

        Chart1.Series.Clear()

        Dim series1 As Series = Chart1.Series.Add("46 - HCM")
        series1.ChartType = SeriesChartType.Line
        series1.Points.AddXY(0, 0)

        Dim series2 As Series = Chart1.Series.Add("17 - Flower Road")
        series2.ChartType = SeriesChartType.Line
        series2.Points.AddXY(0, 0)

        Dim series3 As Series = Chart1.Series.Add("08 - Crescat")
        series3.ChartType = SeriesChartType.Line
        series3.Points.AddXY(0, 0)

        Dim series4 As Series = Chart1.Series.Add("33 - OGF")
        series4.ChartType = SeriesChartType.Line
        series4.Points.AddXY(0, 0)

        Dim series5 As Series = Chart1.Series.Add("19 - MC")
        series5.ChartType = SeriesChartType.Line
        series5.Points.AddXY(0, 0)

        Dim series6 As Series = Chart1.Series.Add("09 - BLUEWATER")
        series6.ChartType = SeriesChartType.Line
        series6.Points.AddXY(0, 0)

        xx = xx.AddDays(0 - DTM)

        While xx <= yy
            'MsgBox(xx)
            xx = xx.AddDays(1)
            'MsgBox(xx)
            T1 = 0

            'enformattedValue1 = "0"
            formattedValue1 = 0

            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='46' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T1 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T1)

            End Using

            Dim X13 As String
            X13 = 0
            X13 = X13 + 1

            'Chart1.Series.Clear()
            'Dim series1 As Series = Chart1.Series.Add("DataSeries 1")
            'series1.ChartType = SeriesChartType.Line
            series1.Points.AddXY(X13, T1)
            'series1.Points.AddXY(2, 20)
            'series1.Points.AddXY(3, 15)
            'series1.Points.AddXY(4, 30)
            'series1.Points.AddXY(5, 35)

            '*********************************************************************************************************************
            T2 = 0
            formattedValue1 = "0"

            'TextBox1.Text 
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='17' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='17' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T2 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T2)

            End Using

            series2.Points.AddXY(X13, T2)

            '*********************************************************************************************************************
            T3 = 0
            formattedValue1 = "0"

            'TextBox1.Text 
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='08' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='08' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T3 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T2)

            End Using

            series3.Points.AddXY(X13, T3)


            '*********************************************************************************************************************
            T4 = 0
            formattedValue1 = "0"

            'TextBox1.Text 
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='33' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='33' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T4 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T2)

            End Using

            series4.Points.AddXY(X13, T4)

            '*********************************************************************************************************************
            T5 = 0
            formattedValue1 = "0"

            'TextBox1.Text 
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='19' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='19' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T5 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T2)

            End Using

            series5.Points.AddXY(X13, T5)


            '*********************************************************************************************************************
            T6 = 0
            formattedValue1 = "0"

            'TextBox1.Text 
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='09' AND IDate='" & xx & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='09' AND SalDate='" & xx & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                'TextBox1.Text = formattedValue1 + formattedValue2
                T6 = formattedValue1 + formattedValue2
                'TextBox1.Text = T1.ToString("#,##0.00")
                'MsgBox(T2)

            End Using

            series6.Points.AddXY(X13, T6)


            Chart1.ChartAreas(0).AxisX.Title = "Date"
            Chart1.ChartAreas(0).AxisY.Title = "Amount [LKR]"
            Chart1.ChartAreas(0).AxisX.Minimum = 0  ' xx1 '0
            Chart1.ChartAreas(0).AxisX.Maximum = 31  'yy1 '31
            Chart1.ChartAreas(0).AxisY.Minimum = 0
            'Chart1.ChartAreas(0).AxisY.Maximum = 40
            Chart1.ChartAreas(0).AxisX.Interval = 1
            'Chart1.ChartAreas(0).AxisX.m = 100
            'Chart1.ChartAreas(0).AxisY.Interval = 5
            Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
            Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray


        End While

        ' Customize chart appearance
        Dim xx1 As Double = 0
        Dim yy1 As Double = 31



    End Sub
    Private Sub CHT1()

        ' Add data points to the chart
        Chart1.Series.Clear()
        Dim series1 As Series = Chart1.Series.Add("DataSeries 1")
        series1.ChartType = SeriesChartType.Line
        series1.Points.AddXY(1, 10)
        series1.Points.AddXY(2, 20)
        series1.Points.AddXY(3, 15)
        series1.Points.AddXY(4, 30)
        series1.Points.AddXY(5, 35)

        Dim series2 As Series = Chart1.Series.Add("DataSeries 2")
        series2.ChartType = SeriesChartType.Line
        series2.Points.AddXY(0, 7)
        series2.Points.AddXY(1, 10)
        series2.Points.AddXY(2, 5)
        series2.Points.AddXY(3, 20)
        series2.Points.AddXY(4, 18)
        series2.Points.AddXY(5, 35)

        Dim series3 As Series = Chart1.Series.Add("DataSeries 3")
        series3.ChartType = SeriesChartType.Line
        series3.Points.AddXY(0, 2)
        series3.Points.AddXY(1, 8)
        series3.Points.AddXY(2, 17)
        series3.Points.AddXY(3, 4)
        series3.Points.AddXY(4, 11)
        series3.Points.AddXY(5, 30)


        ' Customize chart appearance
        Chart1.ChartAreas(0).AxisX.Title = "X Axis"
        Chart1.ChartAreas(0).AxisY.Title = "Y Axis"
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.Maximum = 31
        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = 40
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisY.Interval = 5
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray

    End Sub
    Private Function BMI(Height As Single, weight As Single) As Double
        BMI = weight / Height ^ 2
    End Function
    Private Sub CHT1_LOCA08(T2 As Integer, xx As Date)

        Dim value1, value2, value3, value4, value5, value6 As Decimal
        'Dim T1, T2, T3, T4, T5, T6 As Integer
        Dim formattedValue1 As Integer
        Dim formattedValue2 As Integer
        Dim sum As Double

        Dim DT1 As String

        formattedValue1 = 0

        Using connection As New SqlConnection(connectionString)
            'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
            'Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
            Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='08' AND IDate='" & xx & "'"
            Dim command As New SqlCommand(query, connection)

            connection.Open()
            Dim result = command.ExecuteScalar()

            If result IsNot DBNull.Value Then
                'sum = Convert.ToDecimal(result)
                'sum = Convert.ToString(result)
                value1 = sum
                sum = result
                formattedValue1 = sum.ToString("#,##0.00")
                'TextBox1.Text = formattedValue1
            End If

            formattedValue2 = "0"
            sum = "0"
            Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='08' AND SalDate='" & xx & "' AND sal='T'"
            Dim command2 As New SqlCommand(query2, connection)

            'connection.Open()
            Dim result2 = command2.ExecuteScalar()

            If result2 IsNot DBNull.Value Then
                'sum = Convert.ToDecimal(result)
                'sum = Convert.ToString(result)
                value1 = sum
                sum = result2
                formattedValue2 = sum.ToString("#,##0.00")

            End If
            'TextBox1.Text = formattedValue1 + formattedValue2
            T2 = formattedValue1 + formattedValue2
            'TextBox1.Text = T1.ToString("#,##0.00")
            'MsgBox(T1)

        End Using


    End Sub

    Private Sub CHT1_LOCA46()

        Dim value1, value2, value3, value4, value5, value6 As Decimal
        Dim T1, T2, T3, T4, T5, T6 As Integer
        Dim formattedValue1 As Integer
        Dim formattedValue2 As Integer
        Dim sum As Double

        Dim DT1 As String
        formattedValue1 = "0"
        Using connection As New SqlConnection(connectionString)
            'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
            Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
            Dim command As New SqlCommand(query, connection)

            connection.Open()
            Dim result = command.ExecuteScalar()

            If result IsNot DBNull.Value Then
                'sum = Convert.ToDecimal(result)
                'sum = Convert.ToString(result)
                value1 = sum
                sum = result
                formattedValue1 = sum.ToString("#,##0.00")
                'TextBox1.Text = formattedValue1
            End If

            formattedValue2 = "0"
            sum = "0"
            Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='46' AND SalDate='" & DT1 & "' AND sal='T'"
            Dim command2 As New SqlCommand(query2, connection)

            'connection.Open()
            Dim result2 = command2.ExecuteScalar()

            If result2 IsNot DBNull.Value Then
                'sum = Convert.ToDecimal(result)
                'sum = Convert.ToString(result)
                value1 = sum
                sum = result2
                formattedValue2 = sum.ToString("#,##0.00")

            End If
            TextBox1.Text = formattedValue1 + formattedValue2
            T1 = formattedValue1 + formattedValue2
            TextBox1.Text = T1.ToString("#,##0.00")

        End Using

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckBox1.Checked = 1
        CheckBox2.Checked = 1
        CheckBox3.Checked = 1
        CheckBox4.Checked = 1
        CheckBox5.Checked = 1
        CheckBox6.Checked = 1

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                MessageBox.Show("Connection Successful!", "SALES", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error connecting to the database: " & ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Call clearT()

        Dim value1, value2, value3, value4, value5, value6 As Decimal
        Dim T1, T2, T3, T4, T5, T6 As Integer
        Dim formattedValue1 As Integer
        Dim formattedValue2 As Integer
        Dim sum As Double

        Dim checkboxE As New CheckBox
        'Dim checkabox As String
        Dim DT1 As String
        DT1 = Format(DateTimePicker1.Value, "yyyy-MM-d")
        'MsgBox(DT1)

        If CheckBox1.Checked = True Then '************************* 111111111111111111111111111111
            'sum = Format(sum, "###,###.00")
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='46' AND IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox1.Text = formattedValue1
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='46' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value1 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If
                TextBox1.Text = formattedValue1 + formattedValue2
                T1 = formattedValue1 + formattedValue2
                TextBox1.Text = T1.ToString("#,##0.00")

            End Using
        Else
            TextBox1.Text = "0.00"
        End If


        If CheckBox2.Checked = True Then '************************* 2222222222222222222222222222
            'Dim sum As Double
            'sum = Format(sum, "###,###.00")
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='33' and IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value2 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox2.Text = formattedValue
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='33' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value2 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If

                TextBox2.Text = formattedValue1 + formattedValue2
                T2 = formattedValue1 + formattedValue2
                TextBox2.Text = T2.ToString("#,##0.00")

            End Using
        Else
            TextBox2.Text = "0.00"
        End If

        If CheckBox3.Checked = True Then '************************* 3333333333333333333333333
            'Dim sum As Double
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='17' and IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value3 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox3.Text = formattedValue
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='17' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value3 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If

                TextBox3.Text = formattedValue1 + formattedValue2
                T3 = formattedValue1 + formattedValue2
                TextBox3.Text = T3.ToString("#,##0.00")
            End Using
        Else
            TextBox3.Text = "0.00"
        End If

        If CheckBox4.Checked = True Then '************************ 44444444444444
            'Dim sum As Double
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='08' and IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value4 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox4.Text = formattedValue
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='08' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value4 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If

                TextBox4.Text = formattedValue1 + formattedValue2
                T4 = formattedValue1 + formattedValue2
                TextBox4.Text = T4.ToString("#,##0.00")
            End Using
        Else
            TextBox4.Text = "0.00"

        End If

        If CheckBox5.Checked = True Then '************************* 555555555555555555555
            'Dim sum As Double
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='19' and IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value5 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox5.Text = formattedValue
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='19' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value5 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If

                TextBox5.Text = formattedValue1 + formattedValue2
                T5 = formattedValue1 + formattedValue2
                TextBox5.Text = T5.ToString("#,##0.00")

            End Using
        Else
            TextBox5.Text = "0.00"

        End If

        If CheckBox6.Checked = True Then '************************* 666666666666666666666
            'Dim sum As Double
            formattedValue1 = "0"
            Using connection As New SqlConnection(connectionString)
                'Dim query As String = $"SELECT SUM({columnName}) FROM YourTableName
                Dim query As String = $"SELECT SUM(netamount) FROM tb_InvSumm WHERE locacode='09' and IDate='" & DT1 & "'"
                Dim command As New SqlCommand(query, connection)

                connection.Open()
                Dim result = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value6 = sum
                    sum = result
                    formattedValue1 = sum.ToString("#,##0.00")
                    'TextBox6.Text = formattedValue
                End If

                formattedValue2 = "0"
                sum = "0"
                Dim query2 As String = $"SELECT SUM(amount) FROM tb_GiftVoucher WHERE IssueLoca='09' AND SalDate='" & DT1 & "' AND sal='T'"
                Dim command2 As New SqlCommand(query2, connection)

                'connection.Open()
                Dim result2 = command2.ExecuteScalar()

                If result2 IsNot DBNull.Value Then
                    'sum = Convert.ToDecimal(result)
                    'sum = Convert.ToString(result)
                    value6 = sum
                    sum = result2
                    formattedValue2 = sum.ToString("#,##0.00")

                End If

                TextBox6.Text = formattedValue1 + formattedValue2
                T6 = formattedValue1 + formattedValue2
                TextBox6.Text = T6.ToString("#,##0.00")

            End Using
        Else
            TextBox6.Text = "0.00"

        End If

        ' Parse text from TextBox controls to numeric values
        If Decimal.TryParse(TextBox1.Text, value1) AndAlso Decimal.TryParse(TextBox2.Text, value2) AndAlso Decimal.TryParse(TextBox3.Text, value3) AndAlso Decimal.TryParse(TextBox4.Text, value4) AndAlso Decimal.TryParse(TextBox5.Text, value5) AndAlso Decimal.TryParse(TextBox6.Text, value6) Then
            ' Calculate the sum
            Dim sum2 As Decimal = T1 + T2 + T3 + T4 + T5 + T6

            ' Display the sum in TextBox3 or MessageBox
            TextBox7.Text = sum2.ToString("#,##0.00") ' Display in TextBox3
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Call CHT1()
        Call MnChart()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call CHT1()
    End Sub

End Class
