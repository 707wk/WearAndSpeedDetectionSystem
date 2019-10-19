<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ComboBoxItem2 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ComboBoxItem4 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.QatCustomizeItem1 = New DevComponents.DotNetBar.QatCustomizeItem()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.RibbonControl1.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AutoExpand = False
        Me.RibbonControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.RibbonControl1.BackgroundImage = CType(resources.GetObject("RibbonControl1.BackgroundImage"), System.Drawing.Image)
        '
        '
        '
        Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RibbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem1})
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.QatCustomizeItem1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1232, 102)
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl1.TabGroupHeight = 14
        Me.RibbonControl1.TabIndex = 0
        Me.RibbonControl1.Text = "RibbonControl1"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 25)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanel1.Size = New System.Drawing.Size(1232, 77)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.DragDropSupport = True
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem4, Me.ButtonItem6})
        Me.RibbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar2.Location = New System.Drawing.Point(809, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(304, 75)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 1
        Me.RibbonBar2.Text = "RibbonBar2"
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.TitleVisible = False
        '
        'ButtonItem4
        '
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ButtonItem4.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.control_32px
        Me.ButtonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.SubItemsExpandWidth = 14
        Me.ButtonItem4.Text = "编辑设备列表"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ButtonItem6.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.history_32px
        Me.ButtonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.SubItemsExpandWidth = 14
        Me.ButtonItem6.Text = "历史数据"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.ItemContainer2, Me.ItemContainer4, Me.ButtonItem2, Me.ButtonItem3, Me.ButtonItem5})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(806, 75)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = "RibbonBar1"
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.TitleVisible = False
        '
        'LabelItem3
        '
        Me.LabelItem3.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.logo_64px
        Me.LabelItem3.Name = "LabelItem3"
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ItemContainer3})
        '
        '
        '
        Me.ItemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ComboBoxItem1, Me.ButtonItem1})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem1
        '
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "串口号:"
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.ItemHeight = 16
        Me.ComboBoxItem1.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        Me.ComboBoxItem1.WatermarkFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.refresh_16px
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItemsExpandWidth = 14
        Me.ButtonItem1.Text = "刷新"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ComboBoxItem2})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem2
        '
        Me.LabelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "波特率:"
        '
        'ComboBoxItem2
        '
        Me.ComboBoxItem2.ComboWidth = 90
        Me.ComboBoxItem2.DropDownHeight = 106
        Me.ComboBoxItem2.ItemHeight = 16
        Me.ComboBoxItem2.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ComboBoxItem2.Name = "ComboBoxItem2"
        Me.ComboBoxItem2.WatermarkFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'ItemContainer4
        '
        '
        '
        '
        Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer4.Name = "ItemContainer4"
        Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer6})
        '
        '
        '
        Me.ItemContainer4.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer6
        '
        '
        '
        '
        Me.ItemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer6.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.ItemContainer6.Name = "ItemContainer6"
        Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.ComboBoxItem4})
        '
        '
        '
        Me.ItemContainer6.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem4
        '
        Me.LabelItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.Text = "设备轮询间隔:"
        '
        'ComboBoxItem4
        '
        Me.ComboBoxItem4.ComboWidth = 90
        Me.ComboBoxItem4.DropDownHeight = 106
        Me.ComboBoxItem4.ItemHeight = 16
        Me.ComboBoxItem4.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ComboBoxItem4.Name = "ComboBoxItem4"
        Me.ComboBoxItem4.WatermarkFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'ButtonItem2
        '
        Me.ButtonItem2.BeginGroup = True
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ButtonItem2.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.start_32px
        Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItemsExpandWidth = 14
        Me.ButtonItem2.Text = "连接串口"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ButtonItem3.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.stop_32px
        Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.SubItemsExpandWidth = 14
        Me.ButtonItem3.Text = "断开串口"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ButtonItem5.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.test_32px
        Me.ButtonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItemsExpandWidth = 14
        Me.ButtonItem5.Text = "发送测试指令"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.RibbonTabItem1.Checked = True
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel1
        Me.RibbonTabItem1.Text = "开始"
        '
        'QatCustomizeItem1
        '
        Me.QatCustomizeItem1.Name = "QatCustomizeItem1"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1230, 596)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(1, 1)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(1230, 596)
        Me.TextBox1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1, 1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1230, 596)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Legend3.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(4, 39)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1224, 555)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Chart1"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Button3.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.refresh_16px
        Me.Button3.Location = New System.Drawing.Point(579, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 26)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "加载历史数据"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(491, 8)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(82, 25)
        Me.ComboBox3.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(426, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "参数类型:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Button2.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.refresh_16px
        Me.Button2.Location = New System.Drawing.Point(394, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 26)
        Me.Button2.TabIndex = 5
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(267, 8)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 25)
        Me.ComboBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(202, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "历史文件:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Button1.Image = Global.WearAndSpeedDetectionSystem.My.Resources.Resources.refresh_16px
        Me.Button1.Location = New System.Drawing.Point(170, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(82, 8)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(82, 25)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "刀具编号:"
        '
        'MetroStatusBar1
        '
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        Me.MetroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem5, Me.LabelItem6})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Location = New System.Drawing.Point(0, 739)
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.ResizeHandleVisible = False
        Me.MetroStatusBar1.Size = New System.Drawing.Size(1232, 22)
        Me.MetroStatusBar1.TabIndex = 4
        Me.MetroStatusBar1.Text = "MetroStatusBar1"
        '
        'LabelItem5
        '
        Me.LabelItem5.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.Text = "当前时间:"
        '
        'LabelItem6
        '
        Me.LabelItem6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.Text = "0000-00-00 00:00:00"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabControl2.CanReorderTabs = True
        Me.TabControl2.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TabControl2.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1.0!)})
        Me.TabControl2.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(234, Byte), Integer)), 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1.0!)})
        Me.TabControl2.ColorScheme.TabItemHotText = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TabControl2.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)), 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1.0!)})
        Me.TabControl2.ColorScheme.TabItemSelectedText = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TabControl2.ColorScheme.TabItemText = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TabControl2.Controls.Add(Me.TabControlPanel4)
        Me.TabControl2.Controls.Add(Me.TabControlPanel3)
        Me.TabControl2.Controls.Add(Me.TabControlPanel1)
        Me.TabControl2.Controls.Add(Me.TabControlPanel2)
        Me.TabControl2.FixedTabSize = New System.Drawing.Size(120, 0)
        Me.TabControl2.ForeColor = System.Drawing.Color.White
        Me.TabControl2.Location = New System.Drawing.Point(0, 108)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 1
        Me.TabControl2.Size = New System.Drawing.Size(1232, 625)
        Me.TabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl2.TabIndex = 5
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.TabItem1)
        Me.TabControl2.Tabs.Add(Me.TabItem3)
        Me.TabControl2.Tabs.Add(Me.TabItem2)
        Me.TabControl2.Tabs.Add(Me.TabItem4)
        Me.TabControl2.Text = "TabControl2"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.PictureBox1)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(1232, 598)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "概览"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.Chart1)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox1)
        Me.TabControlPanel4.Controls.Add(Me.Button3)
        Me.TabControlPanel4.Controls.Add(Me.Label1)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox3)
        Me.TabControlPanel4.Controls.Add(Me.Button1)
        Me.TabControlPanel4.Controls.Add(Me.Label3)
        Me.TabControlPanel4.Controls.Add(Me.Label2)
        Me.TabControlPanel4.Controls.Add(Me.Button2)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox2)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(1232, 598)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 13
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "历史数据"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.TextBox1)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(1232, 598)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "检测日志"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(1232, 598)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 9
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "设备状态"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1232, 761)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RibbonControl1.ResumeLayout(False)
        Me.RibbonControl1.PerformLayout()
        Me.RibbonPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel4.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents QatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ComboBoxItem2 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ComboBoxItem4 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
End Class
