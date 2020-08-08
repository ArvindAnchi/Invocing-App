<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatementForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.SendAsPDF = New DevExpress.XtraBars.BarButtonItem()
        Me.SendAsEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.StmtTotalLBL = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.CompLB = New System.Windows.Forms.ListBox()
        Me.SDateLB = New System.Windows.Forms.ListBox()
        Me.EDateLB = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StmtDGV = New System.Windows.Forms.DataGridView()
        Me.SYearNBtn = New System.Windows.Forms.Button()
        Me.SYearPBtn = New System.Windows.Forms.Button()
        Me.SYearLBL = New System.Windows.Forms.Label()
        Me.EYearLBL = New System.Windows.Forms.Label()
        Me.EYearPBtn = New System.Windows.Forms.Button()
        Me.EYearNBtn = New System.Windows.Forms.Button()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StmtDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.SendAsPDF, Me.SendAsEmail, Me.StmtTotalLBL})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 5
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.Size = New System.Drawing.Size(1117, 162)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'SendAsPDF
        '
        Me.SendAsPDF.Caption = "Send as PDF"
        Me.SendAsPDF.Id = 1
        Me.SendAsPDF.ImageOptions.Image = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.sendpdf_16x16
        Me.SendAsPDF.ImageOptions.LargeImage = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.sendpdf_32x32
        Me.SendAsPDF.Name = "SendAsPDF"
        '
        'SendAsEmail
        '
        Me.SendAsEmail.Caption = "Send as E-Mail"
        Me.SendAsEmail.Id = 2
        Me.SendAsEmail.ImageOptions.Image = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.emailtemplate_16x16
        Me.SendAsEmail.ImageOptions.LargeImage = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.emailtemplate_32x32
        Me.SendAsEmail.Name = "SendAsEmail"
        '
        'StmtTotalLBL
        '
        Me.StmtTotalLBL.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.StmtTotalLBL.Id = 4
        Me.StmtTotalLBL.Name = "StmtTotalLBL"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Statement"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.SendAsPDF)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.SendAsEmail)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.StmtTotalLBL)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 603)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1117, 26)
        '
        'CompLB
        '
        Me.CompLB.FormattingEnabled = True
        Me.CompLB.Location = New System.Drawing.Point(0, 186)
        Me.CompLB.Name = "CompLB"
        Me.CompLB.Size = New System.Drawing.Size(293, 407)
        Me.CompLB.TabIndex = 2
        '
        'SDateLB
        '
        Me.SDateLB.FormattingEnabled = True
        Me.SDateLB.Location = New System.Drawing.Point(299, 186)
        Me.SDateLB.Name = "SDateLB"
        Me.SDateLB.Size = New System.Drawing.Size(120, 160)
        Me.SDateLB.TabIndex = 3
        '
        'EDateLB
        '
        Me.EDateLB.FormattingEnabled = True
        Me.EDateLB.Location = New System.Drawing.Point(299, 407)
        Me.EDateLB.Name = "EDateLB"
        Me.EDateLB.Size = New System.Drawing.Size(120, 160)
        Me.EDateLB.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(299, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Start Month"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(296, 383)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "End Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Company"
        '
        'StmtDGV
        '
        Me.StmtDGV.AllowUserToAddRows = False
        Me.StmtDGV.AllowUserToDeleteRows = False
        Me.StmtDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.StmtDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.StmtDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StmtDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.StmtDGV.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.StmtDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StmtDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.StmtDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StmtDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.StmtDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StmtDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.StmtDGV.EnableHeadersVisualStyles = False
        Me.StmtDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.StmtDGV.Location = New System.Drawing.Point(425, 186)
        Me.StmtDGV.Name = "StmtDGV"
        Me.StmtDGV.RowHeadersVisible = False
        Me.StmtDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StmtDGV.Size = New System.Drawing.Size(692, 407)
        Me.StmtDGV.TabIndex = 185
        '
        'SYearNBtn
        '
        Me.SYearNBtn.Location = New System.Drawing.Point(386, 352)
        Me.SYearNBtn.Name = "SYearNBtn"
        Me.SYearNBtn.Size = New System.Drawing.Size(33, 22)
        Me.SYearNBtn.TabIndex = 186
        Me.SYearNBtn.Text = ">>"
        Me.SYearNBtn.UseVisualStyleBackColor = True
        '
        'SYearPBtn
        '
        Me.SYearPBtn.Location = New System.Drawing.Point(299, 352)
        Me.SYearPBtn.Name = "SYearPBtn"
        Me.SYearPBtn.Size = New System.Drawing.Size(33, 22)
        Me.SYearPBtn.TabIndex = 186
        Me.SYearPBtn.Text = "<<"
        Me.SYearPBtn.UseVisualStyleBackColor = True
        '
        'SYearLBL
        '
        Me.SYearLBL.AutoSize = True
        Me.SYearLBL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SYearLBL.Location = New System.Drawing.Point(341, 356)
        Me.SYearLBL.Name = "SYearLBL"
        Me.SYearLBL.Size = New System.Drawing.Size(35, 15)
        Me.SYearLBL.TabIndex = 189
        Me.SYearLBL.Text = "9999"
        '
        'EYearLBL
        '
        Me.EYearLBL.AutoSize = True
        Me.EYearLBL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EYearLBL.Location = New System.Drawing.Point(341, 577)
        Me.EYearLBL.Name = "EYearLBL"
        Me.EYearLBL.Size = New System.Drawing.Size(35, 15)
        Me.EYearLBL.TabIndex = 192
        Me.EYearLBL.Text = "9999"
        '
        'EYearPBtn
        '
        Me.EYearPBtn.Location = New System.Drawing.Point(299, 573)
        Me.EYearPBtn.Name = "EYearPBtn"
        Me.EYearPBtn.Size = New System.Drawing.Size(33, 22)
        Me.EYearPBtn.TabIndex = 190
        Me.EYearPBtn.Text = "<<"
        Me.EYearPBtn.UseVisualStyleBackColor = True
        '
        'EYearNBtn
        '
        Me.EYearNBtn.Location = New System.Drawing.Point(386, 573)
        Me.EYearNBtn.Name = "EYearNBtn"
        Me.EYearNBtn.Size = New System.Drawing.Size(33, 22)
        Me.EYearNBtn.TabIndex = 191
        Me.EYearNBtn.Text = ">>"
        Me.EYearNBtn.UseVisualStyleBackColor = True
        '
        'StatementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 629)
        Me.Controls.Add(Me.EYearLBL)
        Me.Controls.Add(Me.EYearPBtn)
        Me.Controls.Add(Me.EYearNBtn)
        Me.Controls.Add(Me.SYearLBL)
        Me.Controls.Add(Me.SYearPBtn)
        Me.Controls.Add(Me.SYearNBtn)
        Me.Controls.Add(Me.StmtDGV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.EDateLB)
        Me.Controls.Add(Me.SDateLB)
        Me.Controls.Add(Me.CompLB)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StatementForm"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Statement"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StmtDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents SendAsPDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SendAsEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CompLB As ListBox
    Friend WithEvents SDateLB As ListBox
    Friend WithEvents EDateLB As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents StmtDGV As DataGridView
    Friend WithEvents SYearNBtn As Button
    Friend WithEvents SYearPBtn As Button
    Friend WithEvents SYearLBL As Label
    Friend WithEvents EYearLBL As Label
    Friend WithEvents EYearPBtn As Button
    Friend WithEvents EYearNBtn As Button
    Friend WithEvents StmtTotalLBL As DevExpress.XtraBars.BarStaticItem
End Class
