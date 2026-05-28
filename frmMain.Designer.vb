<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        btnStart = New Button()
        btnSubmit = New Button()
        txtAnswer = New TextBox()
        lblScore = New Label()
        lblTimer = New Label()
        lblQuestion = New Label()
        tmrTimeLimit = New Timer(components)
        lblQuestionNum = New Label()
        SuspendLayout()
        ' 
        ' btnStart
        ' 
        btnStart.Font = New Font("Yozai", 22F, FontStyle.Bold)
        btnStart.Location = New Point(22, 420)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(281, 90)
        btnStart.TabIndex = 2
        btnStart.Text = "开始"
        btnStart.UseVisualStyleBackColor = True
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Font = New Font("Yozai", 22F, FontStyle.Bold)
        btnSubmit.Location = New Point(464, 420)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(305, 90)
        btnSubmit.TabIndex = 3
        btnSubmit.Text = "提交答案"
        btnSubmit.UseVisualStyleBackColor = True
        ' 
        ' txtAnswer
        ' 
        txtAnswer.Font = New Font("Yozai", 22F)
        txtAnswer.Location = New Point(22, 206)
        txtAnswer.Name = "txtAnswer"
        txtAnswer.Size = New Size(747, 65)
        txtAnswer.TabIndex = 4
        ' 
        ' lblScore
        ' 
        lblScore.Font = New Font("Yozai", 22F, FontStyle.Bold)
        lblScore.ForeColor = Color.Wheat
        lblScore.Location = New Point(464, 27)
        lblScore.Name = "lblScore"
        lblScore.Size = New Size(324, 70)
        lblScore.TabIndex = 5
        lblScore.Text = "得分: 0"
        ' 
        ' lblTimer
        ' 
        lblTimer.Font = New Font("Yozai", 22F, FontStyle.Bold)
        lblTimer.ForeColor = Color.LightPink
        lblTimer.Location = New Point(12, 22)
        lblTimer.Name = "lblTimer"
        lblTimer.Size = New Size(393, 70)
        lblTimer.TabIndex = 6
        lblTimer.Text = "剩余时间: --"
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Yozai", 22F, FontStyle.Bold)
        lblQuestion.Location = New Point(12, 112)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(776, 78)
        lblQuestion.TabIndex = 0
        lblQuestion.Text = "点击开始按钮开始中药功效答题之旅"
        ' 
        ' tmrTimeLimit
        ' 
        tmrTimeLimit.Enabled = True
        tmrTimeLimit.Interval = 1000
        ' 
        ' lblQuestionNum
        ' 
        lblQuestionNum.Font = New Font("Yozai", 22F, FontStyle.Bold)
        lblQuestionNum.ForeColor = Color.Black
        lblQuestionNum.Location = New Point(198, 306)
        lblQuestionNum.Name = "lblQuestionNum"
        lblQuestionNum.Size = New Size(400, 70)
        lblQuestionNum.TabIndex = 7
        lblQuestionNum.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(11F, 24F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        ClientSize = New Size(800, 543)
        Controls.Add(lblQuestionNum)
        Controls.Add(lblQuestion)
        Controls.Add(btnSubmit)
        Controls.Add(btnStart)
        Controls.Add(txtAnswer)
        Controls.Add(lblScore)
        Controls.Add(lblTimer)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "《中药快快记》答题程序"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblTimer As Label
    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents lblScore As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents tmrTimeLimit As Timer
    Friend WithEvents lblQuestionNum As Label

End Class
