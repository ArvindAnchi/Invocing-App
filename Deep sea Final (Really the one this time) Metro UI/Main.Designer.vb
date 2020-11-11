<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.SplashScreen1), False, False)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim PushTransition1 As DevExpress.Utils.Animation.PushTransition = New DevExpress.Utils.Animation.PushTransition()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.NewInvBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.CanceledBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.DeleteBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.PaidBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.GenStmtBtnItm = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.SkinDropDownButtonItem1 = New DevExpress.XtraBars.SkinDropDownButtonItem()
        Me.RefreshBtn = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.VATAccBtn = New DevExpress.XtraBars.BarButtonItem()
        Me.InvoiceRT = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.InvoiceRG = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.StmtRT = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.StmtRG = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.VatGrp = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.WorkspaceManager1 = New DevExpress.Utils.WorkspaceManager(Me.components)
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.InvoicesDGV = New System.Windows.Forms.DataGridView()
        Me.FilterGB = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RetcanRB = New System.Windows.Forms.RadioButton()
        Me.IClearBTN = New System.Windows.Forms.Button()
        Me.AllRB = New System.Windows.Forms.RadioButton()
        Me.PaidRB = New System.Windows.Forms.RadioButton()
        Me.UPaidRB = New System.Windows.Forms.RadioButton()
        Me.IEDateDTP = New System.Windows.Forms.DateTimePicker()
        Me.ISDateDTP = New System.Windows.Forms.DateTimePicker()
        Me.ISearchTB = New System.Windows.Forms.TextBox()
        Me.ISearchLBL = New System.Windows.Forms.Label()
        Me.IEDateLBL = New System.Windows.Forms.Label()
        Me.ISDateLBL = New System.Windows.Forms.Label()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoicesDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FilterGB.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager1
        '
        SplashScreenManager1.ClosingDelay = 200
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.NewInvBtnItm, Me.OpenBtnItm, Me.PrintBtnItm, Me.CanceledBtnItm, Me.DeleteBtnItm, Me.BarButtonItem3, Me.PaidBtnItm, Me.GenStmtBtnItm, Me.BarButtonItem7, Me.BarStaticItem1, Me.SkinDropDownButtonItem1, Me.RefreshBtn, Me.BarButtonItem2, Me.BarButtonItem5, Me.VATAccBtn})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 28
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.InvoiceRT, Me.StmtRT, Me.RibbonPage1})
        Me.RibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019
        Me.RibbonControl.Size = New System.Drawing.Size(941, 162)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'NewInvBtnItm
        '
        Me.NewInvBtnItm.Caption = "New Invoice"
        Me.NewInvBtnItm.Id = 4
        Me.NewInvBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("NewInvBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.NewInvBtnItm.Name = "NewInvBtnItm"
        '
        'OpenBtnItm
        '
        Me.OpenBtnItm.Caption = "Open Invoice"
        Me.OpenBtnItm.Id = 5
        Me.OpenBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("OpenBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.OpenBtnItm.Name = "OpenBtnItm"
        '
        'PrintBtnItm
        '
        Me.PrintBtnItm.Caption = "Print"
        Me.PrintBtnItm.Id = 6
        Me.PrintBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("PrintBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.PrintBtnItm.Name = "PrintBtnItm"
        '
        'CanceledBtnItm
        '
        Me.CanceledBtnItm.Caption = "Canceled"
        Me.CanceledBtnItm.Id = 7
        Me.CanceledBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("CanceledBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.CanceledBtnItm.Name = "CanceledBtnItm"
        '
        'DeleteBtnItm
        '
        Me.DeleteBtnItm.Caption = "Delete"
        Me.DeleteBtnItm.Id = 8
        Me.DeleteBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("DeleteBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.DeleteBtnItm.Name = "DeleteBtnItm"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Paid"
        Me.BarButtonItem3.Id = 9
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'PaidBtnItm
        '
        Me.PaidBtnItm.Caption = "Paid"
        Me.PaidBtnItm.Id = 11
        Me.PaidBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("PaidBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.PaidBtnItm.Name = "PaidBtnItm"
        '
        'GenStmtBtnItm
        '
        Me.GenStmtBtnItm.Caption = "Generate statement"
        Me.GenStmtBtnItm.Id = 12
        Me.GenStmtBtnItm.ImageOptions.SvgImage = CType(resources.GetObject("GenStmtBtnItm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.GenStmtBtnItm.Name = "GenStmtBtnItm"
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "BarButtonItem7"
        Me.BarButtonItem7.Id = 14
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "Records: 0"
        Me.BarStaticItem1.Id = 16
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'SkinDropDownButtonItem1
        '
        Me.SkinDropDownButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.SkinDropDownButtonItem1.Id = 17
        Me.SkinDropDownButtonItem1.Name = "SkinDropDownButtonItem1"
        '
        'RefreshBtn
        '
        Me.RefreshBtn.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.RefreshBtn.Caption = "Refresh"
        Me.RefreshBtn.Id = 21
        Me.RefreshBtn.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5)
        Me.RefreshBtn.Name = "RefreshBtn"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Edit Companies"
        Me.BarButtonItem2.Id = 23
        Me.BarButtonItem2.ImageOptions.Image = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.editcontact_16x16
        Me.BarButtonItem2.ImageOptions.LargeImage = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.editcontact_32x321
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Add Expenses"
        Me.BarButtonItem5.Id = 25
        Me.BarButtonItem5.ImageOptions.Image = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.addnewdatasource_16x16
        Me.BarButtonItem5.ImageOptions.LargeImage = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.addnewdatasource_32x32
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'VATAccBtn
        '
        Me.VATAccBtn.Caption = "VAT Report"
        Me.VATAccBtn.Id = 26
        Me.VATAccBtn.ImageOptions.SvgImage = Global.Deep_sea_Final__Really_the_one_this_time__Metro_UI.My.Resources.Resources.business_eurocircled
        Me.VATAccBtn.Name = "VATAccBtn"
        '
        'InvoiceRT
        '
        Me.InvoiceRT.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.InvoiceRG})
        Me.InvoiceRT.Name = "InvoiceRT"
        Me.InvoiceRT.Text = "Invoice"
        '
        'InvoiceRG
        '
        Me.InvoiceRG.AllowTextClipping = False
        Me.InvoiceRG.ItemLinks.Add(Me.NewInvBtnItm)
        Me.InvoiceRG.ItemLinks.Add(Me.OpenBtnItm)
        Me.InvoiceRG.ItemLinks.Add(Me.PrintBtnItm)
        Me.InvoiceRG.ItemLinks.Add(Me.CanceledBtnItm)
        Me.InvoiceRG.ItemLinks.Add(Me.DeleteBtnItm)
        Me.InvoiceRG.ItemLinks.Add(Me.PaidBtnItm)
        Me.InvoiceRG.Name = "InvoiceRG"
        Me.InvoiceRG.Text = "Invoice"
        '
        'StmtRT
        '
        Me.StmtRT.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.StmtRG, Me.VatGrp})
        Me.StmtRT.Name = "StmtRT"
        Me.StmtRT.Text = "Accounts"
        '
        'StmtRG
        '
        Me.StmtRG.ItemLinks.Add(Me.GenStmtBtnItm)
        Me.StmtRG.ItemLinks.Add(Me.BarButtonItem5)
        Me.StmtRG.Name = "StmtRG"
        Me.StmtRG.Text = "Statement"
        '
        'VatGrp
        '
        Me.VatGrp.ItemLinks.Add(Me.VATAccBtn)
        Me.VatGrp.Name = "VatGrp"
        Me.VatGrp.Text = "VAT"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Companies"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Companies"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarStaticItem1)
        Me.RibbonStatusBar.ItemLinks.Add(Me.SkinDropDownButtonItem1)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 455)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(941, 26)
        '
        'WorkspaceManager1
        '
        Me.WorkspaceManager1.TargetControl = Me
        Me.WorkspaceManager1.TransitionType = PushTransition1
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.ActAsDropDown = True
        Me.BarButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarButtonItem1.Caption = "New Invoice"
        Me.BarButtonItem1.Id = 3
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'InvoicesDGV
        '
        Me.InvoicesDGV.AllowUserToAddRows = False
        Me.InvoicesDGV.AllowUserToDeleteRows = False
        Me.InvoicesDGV.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.InvoicesDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.InvoicesDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InvoicesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.InvoicesDGV.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.InvoicesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.InvoicesDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.InvoicesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoicesDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.InvoicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InvoicesDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.InvoicesDGV.EnableHeadersVisualStyles = False
        Me.InvoicesDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.InvoicesDGV.Location = New System.Drawing.Point(3, 242)
        Me.InvoicesDGV.Name = "InvoicesDGV"
        Me.InvoicesDGV.ReadOnly = True
        Me.InvoicesDGV.RowHeadersVisible = False
        Me.InvoicesDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.InvoicesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InvoicesDGV.Size = New System.Drawing.Size(935, 211)
        Me.InvoicesDGV.TabIndex = 6
        '
        'FilterGB
        '
        Me.FilterGB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilterGB.Controls.Add(Me.Button1)
        Me.FilterGB.Controls.Add(Me.RetcanRB)
        Me.FilterGB.Controls.Add(Me.IClearBTN)
        Me.FilterGB.Controls.Add(Me.AllRB)
        Me.FilterGB.Controls.Add(Me.PaidRB)
        Me.FilterGB.Controls.Add(Me.UPaidRB)
        Me.FilterGB.Controls.Add(Me.IEDateDTP)
        Me.FilterGB.Controls.Add(Me.ISDateDTP)
        Me.FilterGB.Controls.Add(Me.ISearchTB)
        Me.FilterGB.Controls.Add(Me.ISearchLBL)
        Me.FilterGB.Controls.Add(Me.IEDateLBL)
        Me.FilterGB.Controls.Add(Me.ISDateLBL)
        Me.FilterGB.Location = New System.Drawing.Point(3, 171)
        Me.FilterGB.Name = "FilterGB"
        Me.FilterGB.Size = New System.Drawing.Size(836, 68)
        Me.FilterGB.TabIndex = 5
        Me.FilterGB.TabStop = False
        Me.FilterGB.Text = "Filter"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 21)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Search multiline"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RetcanRB
        '
        Me.RetcanRB.AutoSize = True
        Me.RetcanRB.Location = New System.Drawing.Point(705, 20)
        Me.RetcanRB.Name = "RetcanRB"
        Me.RetcanRB.Size = New System.Drawing.Size(128, 17)
        Me.RetcanRB.TabIndex = 6
        Me.RetcanRB.Text = "Returned or canceled"
        Me.RetcanRB.UseVisualStyleBackColor = True
        '
        'IClearBTN
        '
        Me.IClearBTN.Location = New System.Drawing.Point(557, 14)
        Me.IClearBTN.Name = "IClearBTN"
        Me.IClearBTN.Size = New System.Drawing.Size(67, 46)
        Me.IClearBTN.TabIndex = 5
        Me.IClearBTN.Text = "Clear"
        Me.IClearBTN.UseVisualStyleBackColor = True
        '
        'AllRB
        '
        Me.AllRB.AutoSize = True
        Me.AllRB.Location = New System.Drawing.Point(650, 20)
        Me.AllRB.Name = "AllRB"
        Me.AllRB.Size = New System.Drawing.Size(36, 17)
        Me.AllRB.TabIndex = 2
        Me.AllRB.Text = "All"
        Me.AllRB.UseVisualStyleBackColor = True
        '
        'PaidRB
        '
        Me.PaidRB.AutoSize = True
        Me.PaidRB.Location = New System.Drawing.Point(650, 38)
        Me.PaidRB.Name = "PaidRB"
        Me.PaidRB.Size = New System.Drawing.Size(45, 17)
        Me.PaidRB.TabIndex = 3
        Me.PaidRB.Text = "Paid"
        Me.PaidRB.UseVisualStyleBackColor = True
        '
        'UPaidRB
        '
        Me.UPaidRB.AutoSize = True
        Me.UPaidRB.Location = New System.Drawing.Point(705, 38)
        Me.UPaidRB.Name = "UPaidRB"
        Me.UPaidRB.Size = New System.Drawing.Size(58, 17)
        Me.UPaidRB.TabIndex = 4
        Me.UPaidRB.Text = "Unpaid"
        Me.UPaidRB.UseVisualStyleBackColor = True
        '
        'IEDateDTP
        '
        Me.IEDateDTP.Location = New System.Drawing.Point(351, 40)
        Me.IEDateDTP.Name = "IEDateDTP"
        Me.IEDateDTP.Size = New System.Drawing.Size(200, 21)
        Me.IEDateDTP.TabIndex = 2
        '
        'ISDateDTP
        '
        Me.ISDateDTP.Location = New System.Drawing.Point(80, 40)
        Me.ISDateDTP.Name = "ISDateDTP"
        Me.ISDateDTP.Size = New System.Drawing.Size(200, 21)
        Me.ISDateDTP.TabIndex = 2
        '
        'ISearchTB
        '
        Me.ISearchTB.Location = New System.Drawing.Point(80, 14)
        Me.ISearchTB.Name = "ISearchTB"
        Me.ISearchTB.Size = New System.Drawing.Size(372, 21)
        Me.ISearchTB.TabIndex = 1
        '
        'ISearchLBL
        '
        Me.ISearchLBL.AutoSize = True
        Me.ISearchLBL.Location = New System.Drawing.Point(33, 17)
        Me.ISearchLBL.Name = "ISearchLBL"
        Me.ISearchLBL.Size = New System.Drawing.Size(44, 13)
        Me.ISearchLBL.TabIndex = 0
        Me.ISearchLBL.Text = "Search:"
        '
        'IEDateLBL
        '
        Me.IEDateLBL.AutoSize = True
        Me.IEDateLBL.Location = New System.Drawing.Point(293, 44)
        Me.IEDateLBL.Name = "IEDateLBL"
        Me.IEDateLBL.Size = New System.Drawing.Size(55, 13)
        Me.IEDateLBL.TabIndex = 0
        Me.IEDateLBL.Text = "End Date:"
        '
        'ISDateLBL
        '
        Me.ISDateLBL.AutoSize = True
        Me.ISDateLBL.Location = New System.Drawing.Point(19, 44)
        Me.ISDateLBL.Name = "ISDateLBL"
        Me.ISDateLBL.Size = New System.Drawing.Size(61, 13)
        Me.ISDateLBL.TabIndex = 0
        Me.ISDateLBL.Text = "Start Date:"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Generate statement"
        Me.BarButtonItem4.Id = 12
        Me.BarButtonItem4.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(845, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 62)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 481)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.InvoicesDGV)
        Me.Controls.Add(Me.FilterGB)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.SvgImage = CType(resources.GetObject("Main.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.MinimumSize = New System.Drawing.Size(941, 354)
        Me.Name = "Main"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Ravindra Sumant curtains fixing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoicesDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FilterGB.ResumeLayout(False)
        Me.FilterGB.PerformLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents InvoiceRT As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents InvoiceRG As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents StmtRT As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents StmtRG As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents WorkspaceManager1 As DevExpress.Utils.WorkspaceManager
    Friend WithEvents NewInvBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CanceledBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DeleteBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PaidBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GenStmtBtnItm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents SkinDropDownButtonItem1 As DevExpress.XtraBars.SkinDropDownButtonItem
    Friend WithEvents InvoicesDGV As DataGridView
    Friend WithEvents FilterGB As GroupBox
    Friend WithEvents IClearBTN As Button
    Friend WithEvents AllRB As RadioButton
    Friend WithEvents PaidRB As RadioButton
    Friend WithEvents UPaidRB As RadioButton
    Friend WithEvents IEDateDTP As DateTimePicker
    Friend WithEvents ISDateDTP As DateTimePicker
    Friend WithEvents ISearchTB As TextBox
    Friend WithEvents ISearchLBL As Label
    Friend WithEvents IEDateLBL As Label
    Friend WithEvents ISDateLBL As Label
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents RefreshBtn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RetcanRB As RadioButton
    Friend WithEvents VATAccBtn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VatGrp As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
