namespace SubtitleBurner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBVideoFilePath = new System.Windows.Forms.TextBox();
            this.TBSubtitleFilePath = new System.Windows.Forms.TextBox();
            this.TBLog = new System.Windows.Forms.TextBox();
            this.BtnSelectVideoFile = new System.Windows.Forms.Button();
            this.BtnSelectSubtitleFile = new System.Windows.Forms.Button();
            this.BtnBurnIn = new System.Windows.Forms.Button();
            this.CBFont = new System.Windows.Forms.ComboBox();
            this.TBCustomFont = new System.Windows.Forms.TextBox();
            this.GBSubtitleOption = new System.Windows.Forms.GroupBox();
            this.CBApplyFontSetting = new System.Windows.Forms.CheckBox();
            this.TBCustomEncode = new System.Windows.Forms.TextBox();
            this.CBEncode = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GBFFmpegHardwareAcceleration = new System.Windows.Forms.GroupBox();
            this.CBDeviceNo = new System.Windows.Forms.ComboBox();
            this.CBHardwareAcceleratorType = new System.Windows.Forms.ComboBox();
            this.CBEnableHardwareAcceleration = new System.Windows.Forms.CheckBox();
            this.LVersion = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.GBSubtitleOption.SuspendLayout();
            this.GBFFmpegHardwareAcceleration.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBVideoFilePath
            // 
            this.TBVideoFilePath.Location = new System.Drawing.Point(9, 9);
            this.TBVideoFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBVideoFilePath.Name = "TBVideoFilePath";
            this.TBVideoFilePath.PlaceholderText = "（視訊檔案的路徑）";
            this.TBVideoFilePath.Size = new System.Drawing.Size(408, 23);
            this.TBVideoFilePath.TabIndex = 0;
            // 
            // TBSubtitleFilePath
            // 
            this.TBSubtitleFilePath.Location = new System.Drawing.Point(9, 36);
            this.TBSubtitleFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBSubtitleFilePath.Name = "TBSubtitleFilePath";
            this.TBSubtitleFilePath.PlaceholderText = "（字幕檔案的路徑）";
            this.TBSubtitleFilePath.Size = new System.Drawing.Size(408, 23);
            this.TBSubtitleFilePath.TabIndex = 2;
            // 
            // TBLog
            // 
            this.TBLog.Location = new System.Drawing.Point(9, 62);
            this.TBLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBLog.Multiline = true;
            this.TBLog.Name = "TBLog";
            this.TBLog.PlaceholderText = "（紀錄）";
            this.TBLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBLog.Size = new System.Drawing.Size(408, 312);
            this.TBLog.TabIndex = 4;
            // 
            // BtnSelectVideoFile
            // 
            this.BtnSelectVideoFile.Location = new System.Drawing.Point(422, 9);
            this.BtnSelectVideoFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSelectVideoFile.Name = "BtnSelectVideoFile";
            this.BtnSelectVideoFile.Size = new System.Drawing.Size(129, 23);
            this.BtnSelectVideoFile.TabIndex = 1;
            this.BtnSelectVideoFile.Text = "選擇視訊檔案";
            this.BtnSelectVideoFile.UseVisualStyleBackColor = true;
            this.BtnSelectVideoFile.Click += new System.EventHandler(this.BtnSelectVideoFile_Click);
            // 
            // BtnSelectSubtitleFile
            // 
            this.BtnSelectSubtitleFile.Location = new System.Drawing.Point(422, 37);
            this.BtnSelectSubtitleFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSelectSubtitleFile.Name = "BtnSelectSubtitleFile";
            this.BtnSelectSubtitleFile.Size = new System.Drawing.Size(129, 23);
            this.BtnSelectSubtitleFile.TabIndex = 3;
            this.BtnSelectSubtitleFile.Text = "選擇字幕檔案";
            this.BtnSelectSubtitleFile.UseVisualStyleBackColor = true;
            this.BtnSelectSubtitleFile.Click += new System.EventHandler(this.BtnSelectSubtitleFile_Click);
            // 
            // BtnBurnIn
            // 
            this.BtnBurnIn.Location = new System.Drawing.Point(424, 326);
            this.BtnBurnIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBurnIn.Name = "BtnBurnIn";
            this.BtnBurnIn.Size = new System.Drawing.Size(129, 23);
            this.BtnBurnIn.TabIndex = 7;
            this.BtnBurnIn.Text = "燒錄字幕";
            this.BtnBurnIn.UseVisualStyleBackColor = true;
            this.BtnBurnIn.Click += new System.EventHandler(this.BtnBurnIn_Click);
            // 
            // CBFont
            // 
            this.CBFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFont.FormattingEnabled = true;
            this.CBFont.Location = new System.Drawing.Point(5, 45);
            this.CBFont.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBFont.Name = "CBFont";
            this.CBFont.Size = new System.Drawing.Size(118, 23);
            this.CBFont.TabIndex = 1;
            // 
            // TBCustomFont
            // 
            this.TBCustomFont.Location = new System.Drawing.Point(5, 72);
            this.TBCustomFont.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBCustomFont.Name = "TBCustomFont";
            this.TBCustomFont.PlaceholderText = "（自定義字型名稱）";
            this.TBCustomFont.Size = new System.Drawing.Size(118, 23);
            this.TBCustomFont.TabIndex = 2;
            // 
            // GBSubtitleOption
            // 
            this.GBSubtitleOption.Controls.Add(this.CBApplyFontSetting);
            this.GBSubtitleOption.Controls.Add(this.TBCustomEncode);
            this.GBSubtitleOption.Controls.Add(this.CBEncode);
            this.GBSubtitleOption.Controls.Add(this.TBCustomFont);
            this.GBSubtitleOption.Controls.Add(this.CBFont);
            this.GBSubtitleOption.Location = new System.Drawing.Point(422, 65);
            this.GBSubtitleOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBSubtitleOption.Name = "GBSubtitleOption";
            this.GBSubtitleOption.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBSubtitleOption.Size = new System.Drawing.Size(129, 156);
            this.GBSubtitleOption.TabIndex = 5;
            this.GBSubtitleOption.TabStop = false;
            this.GBSubtitleOption.Text = "字幕設定";
            // 
            // CBApplyFontSetting
            // 
            this.CBApplyFontSetting.AutoSize = true;
            this.CBApplyFontSetting.Location = new System.Drawing.Point(5, 21);
            this.CBApplyFontSetting.Name = "CBApplyFontSetting";
            this.CBApplyFontSetting.Size = new System.Drawing.Size(98, 19);
            this.CBApplyFontSetting.TabIndex = 0;
            this.CBApplyFontSetting.Text = "套用字型設定";
            this.CBApplyFontSetting.UseVisualStyleBackColor = true;
            // 
            // TBCustomEncode
            // 
            this.TBCustomEncode.Location = new System.Drawing.Point(5, 126);
            this.TBCustomEncode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBCustomEncode.Name = "TBCustomEncode";
            this.TBCustomEncode.PlaceholderText = "（自定義文字編碼）";
            this.TBCustomEncode.Size = new System.Drawing.Size(118, 23);
            this.TBCustomEncode.TabIndex = 4;
            // 
            // CBEncode
            // 
            this.CBEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEncode.FormattingEnabled = true;
            this.CBEncode.Items.AddRange(new object[] {
            "850",
            "862",
            "866",
            "ANSI_X3.4-1968",
            "ANSI_X3.4-1986",
            "ARABIC",
            "ARMSCII-8",
            "ASCII",
            "ASMO-708",
            "BIG-5",
            "BIG-FIVE",
            "BIG5",
            "BIG5-HKSCS",
            "BIG5-HKSCS:1999",
            "BIG5-HKSCS:2001",
            "BIG5-HKSCS:2004",
            "BIG5-HKSCS:2008",
            "BIG5HKSCS",
            "BIGFIVE",
            "C99",
            "CHAR",
            "CHINESE",
            "CN",
            "CN-BIG5",
            "CN-GB",
            "CN-GB-ISOIR165",
            "CP1131",
            "CP1133",
            "CP1250",
            "CP1251",
            "CP1252",
            "CP1253",
            "CP1254",
            "CP1255",
            "CP1256",
            "CP1257",
            "CP1258",
            "CP1361",
            "CP154",
            "CP367",
            "CP819",
            "CP850",
            "CP862",
            "CP866",
            "CP874",
            "CP932",
            "CP936",
            "CP949",
            "CP950",
            "CSASCII",
            "CSBIG5",
            "CSEUCKR",
            "CSEUCPKDFMTJAPANESE",
            "CSEUCTW",
            "CSGB2312",
            "CSHALFWIDTHKATAKANA",
            "CSHPROMAN8",
            "CSIBM866",
            "CSISO14JISC6220RO",
            "CSISO159JISX02121990",
            "CSISO2022CN",
            "CSISO2022JP",
            "CSISO2022JP2",
            "CSISO2022KR",
            "CSISO57GB1988",
            "CSISO58GB231280",
            "CSISO87JISX0208",
            "CSISOLATIN1",
            "CSISOLATIN2",
            "CSISOLATIN3",
            "CSISOLATIN4",
            "CSISOLATIN5",
            "CSISOLATIN6",
            "CSISOLATINARABIC",
            "CSISOLATINCYRILLIC",
            "CSISOLATINGREEK",
            "CSISOLATINHEBREW",
            "CSKOI8R",
            "CSKSC56011987",
            "CSKZ1048",
            "CSMACINTOSH",
            "CSPC850MULTILINGUAL",
            "CSPC862LATINHEBREW",
            "CSPTCP154",
            "CSSHIFTJIS",
            "CSUCS4",
            "CSUNICODE",
            "CSUNICODE11",
            "CSUNICODE11UTF7",
            "CSVISCII",
            "CYRILLIC",
            "CYRILLIC-ASIAN",
            "ECMA-114",
            "ECMA-118",
            "ELOT_928",
            "EUC-CN",
            "EUC-JP",
            "EUC-KR",
            "EUC-TW",
            "EUCCN",
            "EUCJP",
            "EUCKR",
            "EUCTW",
            "EXTENDED_UNIX_CODE_PACKED_FORMAT_FOR_JAPANESE",
            "GB_1988-80",
            "GB_2312-80",
            "GB18030",
            "GB2312",
            "GBK",
            "GEORGIAN-ACADEMY",
            "GEORGIAN-PS",
            "GREEK",
            "GREEK8",
            "HEBREW",
            "HP-ROMAN8",
            "HZ",
            "HZ-GB-2312",
            "IBM-CP1133",
            "IBM367",
            "IBM819",
            "IBM850",
            "IBM862",
            "IBM866",
            "ISO-10646-UCS-2",
            "ISO-10646-UCS-4",
            "ISO-2022-CN",
            "ISO-2022-CN-EXT",
            "ISO-2022-JP",
            "ISO-2022-JP-1",
            "ISO-2022-JP-2",
            "ISO-2022-KR",
            "ISO-8859-1",
            "ISO-8859-10",
            "ISO-8859-11",
            "ISO-8859-13",
            "ISO-8859-14",
            "ISO-8859-15",
            "ISO-8859-16",
            "ISO-8859-2",
            "ISO-8859-3",
            "ISO-8859-4",
            "ISO-8859-5",
            "ISO-8859-6",
            "ISO-8859-7",
            "ISO-8859-8",
            "ISO-8859-9",
            "ISO-CELTIC",
            "ISO-IR-100",
            "ISO-IR-101",
            "ISO-IR-109",
            "ISO-IR-110",
            "ISO-IR-126",
            "ISO-IR-127",
            "ISO-IR-138",
            "ISO-IR-14",
            "ISO-IR-144",
            "ISO-IR-148",
            "ISO-IR-149",
            "ISO-IR-157",
            "ISO-IR-159",
            "ISO-IR-165",
            "ISO-IR-166",
            "ISO-IR-179",
            "ISO-IR-199",
            "ISO-IR-203",
            "ISO-IR-226",
            "ISO-IR-57",
            "ISO-IR-58",
            "ISO-IR-6",
            "ISO-IR-87",
            "ISO_646.IRV:1991",
            "ISO_8859-1",
            "ISO_8859-1:1987",
            "ISO_8859-10",
            "ISO_8859-10:1992",
            "ISO_8859-11",
            "ISO_8859-13",
            "ISO_8859-14",
            "ISO_8859-14:1998",
            "ISO_8859-15",
            "ISO_8859-15:1998",
            "ISO_8859-16",
            "ISO_8859-16:2001",
            "ISO_8859-2",
            "ISO_8859-2:1987",
            "ISO_8859-3",
            "ISO_8859-3:1988",
            "ISO_8859-4",
            "ISO_8859-4:1988",
            "ISO_8859-5",
            "ISO_8859-5:1988",
            "ISO_8859-6",
            "ISO_8859-6:1987",
            "ISO_8859-7",
            "ISO_8859-7:1987",
            "ISO_8859-7:2003",
            "ISO_8859-8",
            "ISO_8859-8:1988",
            "ISO_8859-9",
            "ISO_8859-9:1989",
            "ISO646-CN",
            "ISO646-JP",
            "ISO646-US",
            "ISO8859-1",
            "ISO8859-10",
            "ISO8859-11",
            "ISO8859-13",
            "ISO8859-14",
            "ISO8859-15",
            "ISO8859-16",
            "ISO8859-2",
            "ISO8859-3",
            "ISO8859-4",
            "ISO8859-5",
            "ISO8859-6",
            "ISO8859-7",
            "ISO8859-8",
            "ISO8859-9",
            "JAVA",
            "JIS_C6220-1969-RO",
            "JIS_C6226-1983",
            "JIS_X0201",
            "JIS_X0208",
            "JIS_X0208-1983",
            "JIS_X0208-1990",
            "JIS_X0212",
            "JIS_X0212-1990",
            "JIS_X0212.1990-0",
            "JIS0208",
            "JISX0201-1976",
            "JOHAB",
            "JP",
            "KOI8-R",
            "KOI8-RU",
            "KOI8-T",
            "KOI8-U",
            "KOREAN",
            "KS_C_5601-1987",
            "KS_C_5601-1989",
            "KSC_5601",
            "KZ-1048",
            "L1",
            "L10",
            "L2",
            "L3",
            "L4",
            "L5",
            "L6",
            "L7",
            "L8",
            "LATIN-9",
            "LATIN1",
            "LATIN10",
            "LATIN2",
            "LATIN3",
            "LATIN4",
            "LATIN5",
            "LATIN6",
            "LATIN7",
            "LATIN8",
            "MAC",
            "MACARABIC",
            "MACCENTRALEUROPE",
            "MACCROATIAN",
            "MACCYRILLIC",
            "MACGREEK",
            "MACHEBREW",
            "MACICELAND",
            "MACINTOSH",
            "MACROMAN",
            "MACROMANIA",
            "MACTHAI",
            "MACTURKISH",
            "MACUKRAINE",
            "MS-ANSI",
            "MS-ARAB",
            "MS-CYRL",
            "MS-EE",
            "MS-GREEK",
            "MS-HEBR",
            "MS-TURK",
            "MS_KANJI",
            "MS936",
            "MULELAO-1",
            "NEXTSTEP",
            "PT154",
            "PTCP154",
            "R8",
            "RK1048",
            "ROMAN8",
            "SHIFT-JIS",
            "SHIFT_JIS",
            "SJIS",
            "STRK1048-2002",
            "TCVN",
            "TCVN-5712",
            "TCVN5712-1",
            "TCVN5712-1:1993",
            "TIS-620",
            "TIS620",
            "TIS620-0",
            "TIS620.2529-1",
            "TIS620.2533-0",
            "TIS620.2533-1",
            "UCS-2",
            "UCS-2-INTERNAL",
            "UCS-2-SWAPPED",
            "UCS-2BE",
            "UCS-2LE",
            "UCS-4",
            "UCS-4-INTERNAL",
            "UCS-4-SWAPPED",
            "UCS-4BE",
            "UCS-4LE",
            "UHC",
            "UNICODE-1-1",
            "UNICODE-1-1-UTF-7",
            "UNICODEBIG",
            "UNICODELITTLE",
            "US",
            "US-ASCII",
            "UTF-16",
            "UTF-16BE",
            "UTF-16LE",
            "UTF-32",
            "UTF-32BE",
            "UTF-32LE",
            "UTF-7",
            "UTF-8",
            "VISCII",
            "VISCII1.1-1",
            "WCHAR_T",
            "WINBALTRIM",
            "WINDOWS-1250",
            "WINDOWS-1251",
            "WINDOWS-1252",
            "WINDOWS-1253",
            "WINDOWS-1254",
            "WINDOWS-1255",
            "WINDOWS-1256",
            "WINDOWS-1257",
            "WINDOWS-1258",
            "WINDOWS-874",
            "WINDOWS-936",
            "X0201",
            "X0208",
            "X0212"});
            this.CBEncode.Location = new System.Drawing.Point(5, 99);
            this.CBEncode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBEncode.Name = "CBEncode";
            this.CBEncode.Size = new System.Drawing.Size(118, 23);
            this.CBEncode.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(424, 351);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(129, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GBFFmpegHardwareAcceleration
            // 
            this.GBFFmpegHardwareAcceleration.Controls.Add(this.CBDeviceNo);
            this.GBFFmpegHardwareAcceleration.Controls.Add(this.CBHardwareAcceleratorType);
            this.GBFFmpegHardwareAcceleration.Controls.Add(this.CBEnableHardwareAcceleration);
            this.GBFFmpegHardwareAcceleration.Location = new System.Drawing.Point(424, 225);
            this.GBFFmpegHardwareAcceleration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBFFmpegHardwareAcceleration.Name = "GBFFmpegHardwareAcceleration";
            this.GBFFmpegHardwareAcceleration.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GBFFmpegHardwareAcceleration.Size = new System.Drawing.Size(129, 97);
            this.GBFFmpegHardwareAcceleration.TabIndex = 6;
            this.GBFFmpegHardwareAcceleration.TabStop = false;
            this.GBFFmpegHardwareAcceleration.Text = "FFmpeg 硬體加速";
            // 
            // CBDeviceNo
            // 
            this.CBDeviceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDeviceNo.FormattingEnabled = true;
            this.CBDeviceNo.Location = new System.Drawing.Point(5, 69);
            this.CBDeviceNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBDeviceNo.Name = "CBDeviceNo";
            this.CBDeviceNo.Size = new System.Drawing.Size(118, 23);
            this.CBDeviceNo.TabIndex = 2;
            this.CBDeviceNo.SelectedIndexChanged += new System.EventHandler(this.CBDeviceNo_SelectedIndexChanged);
            // 
            // CBHardwareAcceleratorType
            // 
            this.CBHardwareAcceleratorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBHardwareAcceleratorType.FormattingEnabled = true;
            this.CBHardwareAcceleratorType.Items.AddRange(new object[] {
            "Intel",
            "NVIDIA",
            "AMD"});
            this.CBHardwareAcceleratorType.Location = new System.Drawing.Point(5, 43);
            this.CBHardwareAcceleratorType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBHardwareAcceleratorType.Name = "CBHardwareAcceleratorType";
            this.CBHardwareAcceleratorType.Size = new System.Drawing.Size(118, 23);
            this.CBHardwareAcceleratorType.TabIndex = 1;
            this.CBHardwareAcceleratorType.SelectedIndexChanged += new System.EventHandler(this.CBHardwareAcceleratorType_SelectedIndexChanged);
            // 
            // CBEnableHardwareAcceleration
            // 
            this.CBEnableHardwareAcceleration.AutoSize = true;
            this.CBEnableHardwareAcceleration.Location = new System.Drawing.Point(5, 21);
            this.CBEnableHardwareAcceleration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBEnableHardwareAcceleration.Name = "CBEnableHardwareAcceleration";
            this.CBEnableHardwareAcceleration.Size = new System.Drawing.Size(98, 19);
            this.CBEnableHardwareAcceleration.TabIndex = 0;
            this.CBEnableHardwareAcceleration.Text = "使用硬體加速";
            this.CBEnableHardwareAcceleration.UseVisualStyleBackColor = true;
            // 
            // LVersion
            // 
            this.LVersion.AutoSize = true;
            this.LVersion.Location = new System.Drawing.Point(11, 384);
            this.LVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LVersion.Name = "LVersion";
            this.LVersion.Size = new System.Drawing.Size(43, 15);
            this.LVersion.TabIndex = 10;
            this.LVersion.Text = "版本：";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(424, 376);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(129, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重設";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 412);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.LVersion);
            this.Controls.Add(this.GBFFmpegHardwareAcceleration);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GBSubtitleOption);
            this.Controls.Add(this.BtnBurnIn);
            this.Controls.Add(this.BtnSelectSubtitleFile);
            this.Controls.Add(this.BtnSelectVideoFile);
            this.Controls.Add(this.TBLog);
            this.Controls.Add(this.TBSubtitleFilePath);
            this.Controls.Add(this.TBVideoFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "簡易字幕燒錄器";
            this.GBSubtitleOption.ResumeLayout(false);
            this.GBSubtitleOption.PerformLayout();
            this.GBFFmpegHardwareAcceleration.ResumeLayout(false);
            this.GBFFmpegHardwareAcceleration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TBVideoFilePath;
        private TextBox TBSubtitleFilePath;
        private TextBox TBLog;
        private Button BtnSelectVideoFile;
        private Button BtnSelectSubtitleFile;
        private Button BtnBurnIn;
        private ComboBox CBFont;
        private TextBox TBCustomFont;
        private GroupBox GBSubtitleOption;
        private TextBox TBCustomEncode;
        private ComboBox CBEncode;
        private Button BtnCancel;
        private GroupBox GBFFmpegHardwareAcceleration;
        private CheckBox CBEnableHardwareAcceleration;
        private ComboBox CBHardwareAcceleratorType;
        private ComboBox CBDeviceNo;
        private Label LVersion;
        private Button BtnReset;
        private CheckBox CBApplyFontSetting;
    }
}