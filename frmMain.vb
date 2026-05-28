Option Compare Text

<CodeAnalysis.SuppressMessage("Naming Style", "IDE1006")>
Public Class frmMain
    Private ReadOnly m_dbContext As New ZhongYao.Context

    Private ReadOnly Property QuestionCollection As Dictionary(Of String, String)
        Get
            Try
                Return m_dbContext.ZhongYaoTable.ToDictionary(
                    Function(itm) itm.Name, Function(itm) itm.Description)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "加载题库失败",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return New Dictionary(Of String, String)
            End Try
        End Get
    End Property

    Private m_currQuestion As String
    Private m_currAnswer As String
    Private m_score As Integer
    Private m_timeLeft As Integer
    Private m_shuffle As Boolean
    Private m_questionList As List(Of String)
    Private m_questIdx As Integer

    Private Const INITIAL_TIME_LIMIT As Integer = 30

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDatabase()
        m_questionList = New List(Of String)
        m_questIdx = 0
        If QuestionCollection.Count = 0 Then
            btnStart.Enabled = False
            MessageBox.Show("题库中没有数据，请确保数据库已正确初始化", "加载题库失败",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            btnStart.Enabled = True
        End If
        btnSubmit.Enabled = False
        tmrTimeLimit.Enabled = False
    End Sub

    Private Sub InitializeDatabase()
        Try
            m_dbContext.Database.EnsureCreated()
            If Not m_dbContext.ZhongYaoTable.Any() Then
                InitializeDefaultData()
            End If
        Catch ex As Exception
            MessageBox.Show($"数据库初始化失败: {ex.Message}", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeDefaultData()
        For Each item In ZhongYao.DefaultData
            m_dbContext.ZhongYaoTable.Add(New ZhongYao With {
                .Name = item.Key,
                .Description = item.Value
            })
        Next
        m_dbContext.SaveChanges()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        tmrTimeLimit.Stop()
        If btnStart.Text = "重新开始" Then
            Dim dialogRes = MessageBox.Show(
                "当前答题进度将清空！确定重新开始吗？", "CAUTION!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            )
            If dialogRes = DialogResult.No Then
                tmrTimeLimit.Start()
                Exit Sub
            End If
        End If
        m_shuffle = MessageBox.Show(
            "如果你不确定能倒背如流，可以先不打乱题库", "是否打乱中药功效题库？(Y/N)",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question
        ) = DialogResult.Yes
        m_score = 0
        lblScore.Text = $"得分: {m_score}"
        btnStart.Text = "重新开始"
        txtAnswer.Enabled = True
        btnSubmit.Enabled = True
        TryShuffleQuestions()
        NextQuestion()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        tmrTimeLimit.Enabled = False
        If txtAnswer.Text.Trim() = m_currAnswer Then
            m_score += 1
            MessageBox.Show($"牢记正确答案：{m_currAnswer}", "回答正确！得分+1",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"正确答案是：{m_currAnswer}", "很抱歉，回答错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        NextQuestion()
    End Sub

    Private Sub TryShuffleQuestions()
        Dim keys = QuestionCollection.Keys.ToList()
        If m_shuffle Then
            Dim rnd As New Random
            For i As Integer = keys.Count - 1 To 1 Step -1
                Dim j = rnd.Next(i)
                Dim temp = keys(i) : keys(i) = keys(j) : keys(j) = temp
            Next i
        End If
        m_questionList = keys
        m_questIdx = 0
    End Sub

    Private Sub NextQuestion()
        lblScore.Text = $"得分: {m_score}"
        Dim numQuest = QuestionCollection.Count
        If m_questIdx >= numQuest Then
            lblQuestion.Text = If(m_score = numQuest,
                "恭喜全部答对所有题目！考研加油", $"距离满分还差{numQuest - m_score}分，再来一次？")
            lblQuestionNum.Text = "题库已完成！"
            btnSubmit.Enabled = False
            Exit Sub
        End If

        txtAnswer.Text = String.Empty
        m_currQuestion = m_questionList(m_questIdx)
        m_currAnswer = QuestionCollection(m_currQuestion)

        lblQuestion.Text = $"请说出 {m_currQuestion} 的药用功效："
        lblQuestionNum.Text = $"第{m_questIdx + 1}题，共{numQuest}题"
        m_timeLeft = INITIAL_TIME_LIMIT
        lblTimer.Text = $"剩余时间: {m_timeLeft}"
        tmrTimeLimit.Enabled = True
        m_questIdx += 1
    End Sub

    Private Sub tmrTimeLimit_Tick(sender As Object, e As EventArgs) Handles tmrTimeLimit.Tick
        m_timeLeft -= 1
        lblTimer.Text = $"剩余时间: {m_timeLeft}"

        If m_timeLeft <= 0 Then
            tmrTimeLimit.Enabled = False
            Dim isCorrectAnswer = (txtAnswer.Text.Trim() = m_currAnswer)
            Dim prompt = If(isCorrectAnswer, "回答正确，+1分", "回答错误")
            Dim msgBoxIcon =
                If(isCorrectAnswer, MessageBoxIcon.Information, MessageBoxIcon.Warning)
            m_score += If(isCorrectAnswer, 1, 0)
            MessageBox.Show($"正确答案是：{m_currAnswer}（{prompt}）", "时间到！已自动提交答案",
                            MessageBoxButtons.OK, msgBoxIcon)
            NextQuestion()
        End If
    End Sub

    Private Sub txtAnswer_TextChanged(sender As Object, e As EventArgs) Handles txtAnswer.TextChanged
        Static timer As New Timer With {.Interval = 500}
        If btnSubmit.Enabled Then
            tmrTimeLimit.Stop()
            timer.Start()
            AddHandler timer.Tick, Sub()
                                       tmrTimeLimit.Start()
                                       timer.Stop()
                                   End Sub
        Else
            timer.Enabled = False
        End If
    End Sub

    <STAThread>
    Friend Shared Sub Main()
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain)
    End Sub
End Class