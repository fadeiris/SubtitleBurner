using SubtitleBurner.Common;
using SubtitleBurner.Extension;
using SubtitleBurner.POCO;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace SubtitleBurner;

public partial class MainForm : Form
{
    private readonly ToolTip SharedTooltip = new();

    private CancellationTokenSource? SharedCancellationTokenSource = null;
    private CancellationToken SharedCancellationToken;

    public MainForm()
    {
        InitializeComponent();

        CustomInit();
    }

    private async void BtnSelectVideoFile_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "請選擇視訊檔案",
                Filter = "MPEG-4 Part 14|*.mp4|Matroska|*.mkv",
                FilterIndex = 0
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                TBVideoFilePath.InvokeIfRequired(() =>
                {
                    TBVideoFilePath.Text = openFileDialog.FileName;
                });
            }
        }
        catch (Exception ex)
        {
            await WriteLog(ex.Message, true);
        }
    }

    private async void BtnSelectSubtitleFile_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "請選擇字幕檔案",
                Filter = "SupRip Text|*.srt|WebVTT|*.vtt|SubStation Alpha|*.ssa|Advanced SubStation Alpha|*.ass",
                FilterIndex = 0
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                TBSubtitleFilePath.InvokeIfRequired(() =>
                {
                    TBSubtitleFilePath.Text = openFileDialog.FileName;
                });
            }
        }
        catch (Exception ex)
        {
            await WriteLog(ex.Message, true);
        }
    }
    private void CBHardwareAcceleratorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        CBHardwareAcceleratorType.InvokeIfRequired(() =>
        {
            CBDeviceNo.InvokeIfRequired(() =>
            {
                string? value = CBHardwareAcceleratorType.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    foreach (VideoCardData videoCard in CBDeviceNo.Items)
                    {
                        if (!string.IsNullOrEmpty(videoCard.DeviceName) &&
                            videoCard.DeviceName.Contains(value))
                        {
                            CBDeviceNo.SelectedItem = videoCard;

                            break;
                        }
                    }
                }
            });
        });

    }

    private void CBDeviceNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CBDeviceNo.InvokeIfRequired(() =>
        {
            CBHardwareAcceleratorType.InvokeIfRequired(() =>
            {
                if (CBDeviceNo.SelectedItem is VideoCardData videoCard)
                {
                    foreach (string hardwareAcceleratorType in CBHardwareAcceleratorType.Items)
                    {
                        if (!string.IsNullOrEmpty(videoCard.DeviceName) &&
                            videoCard.DeviceName.Contains(hardwareAcceleratorType))
                        {
                            CBHardwareAcceleratorType.Text = hardwareAcceleratorType;

                            break;
                        }
                    }
                }
            });
        });

    }

    private async void BtnBurnIn_Click(object sender, EventArgs e)
    {
        try
        {
            SetControlEnabled(false);

            SharedCancellationTokenSource = new();
            SharedCancellationToken = SharedCancellationTokenSource.Token;

            SharedCancellationToken.ThrowIfCancellationRequested();

            string? videoFilePath = string.Empty,
                   subtitleFilePath = string.Empty,
                   subtitleStyle = string.Empty,
                   subtitleEncode = string.Empty,
                   hardwareAcceleratorType = string.Empty;

            bool applyFontSetting = false,
                 enableHardwareAcceleration = false;

            TBVideoFilePath.InvokeIfRequired(() =>
            {
                videoFilePath = TBVideoFilePath.Text;
            });

            TBSubtitleFilePath.InvokeIfRequired(() =>
            {
                subtitleFilePath = TBSubtitleFilePath.Text;
            });

            CBApplyFontSetting.InvokeIfRequired(() =>
            {
                applyFontSetting = CBApplyFontSetting.Checked;
            });

            CBFont.InvokeIfRequired(() =>
            {
                subtitleStyle = $"FontName='{CBFont.SelectedItem}'";
            });

            TBCustomFont.InvokeIfRequired(() =>
            {
                if (!string.IsNullOrEmpty(TBCustomFont.Text))
                {
                    subtitleStyle = $"FontName='{TBCustomFont.Text}'";
                }
            });

            CBEncode.InvokeIfRequired(() =>
            {
                subtitleEncode = CBEncode.SelectedItem.ToString();
            });

            TBCustomEncode.InvokeIfRequired(() =>
            {
                if (!string.IsNullOrEmpty(TBCustomEncode.Text))
                {
                    subtitleEncode = TBCustomEncode.Text;
                }
            });

            CBEnableHardwareAcceleration.InvokeIfRequired(() =>
            {
                enableHardwareAcceleration = CBEnableHardwareAcceleration.Checked;
            });

            CBHardwareAcceleratorType.InvokeIfRequired(() =>
            {
                hardwareAcceleratorType = CBHardwareAcceleratorType.SelectedItem.ToString();
            });

            VideoCardData videoCard = new();

            CBDeviceNo.InvokeIfRequired(() =>
            {
                videoCard = (VideoCardData)CBDeviceNo.SelectedItem;
            });

            int deviceNo = videoCard.DeviceNo;

            if (!string.IsNullOrEmpty(videoFilePath) && !string.IsNullOrEmpty(videoFilePath))
            {
                string videoExtName = Path.GetExtension(videoFilePath);
                string videoFileName = Path.GetFileName(videoFilePath);
                string videoFileNameNoExt = Path.GetFileNameWithoutExtension(videoFilePath);
                string videoNewFileName = $"{videoFileNameNoExt}_Subtitled{videoExtName}";
                string outputPath = Path.GetFullPath(videoFilePath).Replace(videoFileName, videoNewFileName);

                switch (videoExtName)
                {
                    case ".mp4":
                        IConversion conversionMP4 = await BurnInSubtitle(
                                videoFilePath,
                                subtitleFilePath,
                                outputPath,
                                subtitleEncode: subtitleEncode,
                                applyFontSetting: applyFontSetting,
                                subtitleStyle: subtitleStyle,
                                enableHardwareAcceleration,
                                hardwareAcceleratorType,
                                deviceNo);

                        SetConversionEvent(conversionMP4);

                        IConversionResult conversionResultMP4 = await conversionMP4.Start(cancellationToken: SharedCancellationToken);

                        WriteConversionResult(conversionResultMP4);

                        break;
                    case ".mkv":
                        IConversion conversionMKV = await AddSubtitleStream(
                                videoFilePath,
                                subtitleFilePath,
                                outputPath,
                                enableHardwareAcceleration,
                                hardwareAcceleratorType,
                                deviceNo);

                        SetConversionEvent(conversionMKV);

                        IConversionResult conversionResultMKV = await conversionMKV.Start(cancellationToken: SharedCancellationToken);

                        WriteConversionResult(conversionResultMKV);

                        break;
                    default:
                        BtnCancel_Click(sender, e);

                        MessageBox.Show(
                            "您選擇的視訊檔案為不支援的格式。",
                            Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        break;
                }
            }
            else
            {
                MessageBox.Show(
                    "請先選擇視訊檔案以及字幕檔案。",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            await WriteLog(ex.Message, true);
        }
        finally
        {
            SetControlEnabled(true);
        }
    }

    private async void BtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (SharedCancellationTokenSource != null &&
                !SharedCancellationTokenSource.IsCancellationRequested)
            {
                SharedCancellationTokenSource.Cancel();
            }
        }
        catch (Exception ex)
        {
            await WriteLog(ex.Message, true);
        }
        finally
        {
            SetControlEnabled(true);
        }
    }

    private async void BtnReset_Click(object sender, EventArgs e)
    {
        try
        {
            BtnCancel_Click(sender, e);

            TBVideoFilePath.InvokeIfRequired(() =>
            {
                TBVideoFilePath.Text = string.Empty;
            });

            TBSubtitleFilePath.InvokeIfRequired(() =>
            {
                TBSubtitleFilePath.Text = string.Empty;
            });

            CBFont.InvokeIfRequired(() =>
            {
                CBFont.SelectedItem = "微軟正黑體";
            });

            TBCustomFont.InvokeIfRequired(() =>
            {
                TBCustomFont.Text = string.Empty;
            });

            CBEncode.InvokeIfRequired(() =>
            {
                CBEncode.SelectedItem = "UTF-8";
            });

            TBCustomEncode.InvokeIfRequired(() =>
            {
                TBCustomEncode.Text = string.Empty;
            });

            CBEnableHardwareAcceleration.InvokeIfRequired(() =>
            {
                CBEnableHardwareAcceleration.Checked = false;
            });

            CBHardwareAcceleratorType.InvokeIfRequired(() =>
            {
                CBHardwareAcceleratorType.SelectedItem = "Intel";
            });

            CBDeviceNo.InvokeIfRequired(() =>
            {
                CBDeviceNo.SelectedValue = 0;
            });

            TBLog.InvokeIfRequired(() =>
            {
                TBLog.Clear();
            });
        }
        catch (Exception ex)
        {
            await WriteLog(ex.Message, true);
        }
        finally
        {
            SetControlEnabled(true);
        }
    }

    /// <summary>
    /// 自定義初始化
    /// </summary>
    private async void CustomInit()
    {
        Icon = Properties.Resources.app_icon;

        InitFontComboBox();
        InitEncodeComboBox();
        InitDeviceComboBox();

        SharedTooltip.SetToolTip(GBSubtitleOption, "此處設定只會影響非 *.mkv 格式的檔案");
        SharedTooltip.SetToolTip(CBApplyFontSetting, "勾選以啟用字型設定，否則會讓 FFmpeg 根據字幕檔的字型設定來選擇要使用的字型");
        SharedTooltip.SetToolTip(TBCustomFont, "在此欄位輸入值，會覆蓋在下拉清單中所選擇的項目");
        SharedTooltip.SetToolTip(TBCustomEncode, "在此欄位輸入值，會覆蓋在下拉清單中所選擇的項目");

        LVersion.InvokeIfRequired(() =>
        {
            // 設定版本號顯示。
            LVersion.Text = $"版本號：v{Assembly.GetExecutingAssembly().GetName().Version?.ToString()}";
        });

        await CheckDepdencies();
    }

    /// <summary>
    /// 檢查相依性
    /// </summary>
    /// <returns>Task</returns>
    private async Task CheckDepdencies()
    {
        SetControlEnabled(false);

        string execPath = Path.Combine(AppContext.BaseDirectory, "Bin");
        string ffmpegPath = Path.Combine(execPath, "ffmpeg.exe");
        string ffprobePath = Path.Combine(execPath, "ffprobe.exe");

        if (!Directory.Exists(execPath))
        {
            Directory.CreateDirectory(execPath);
        }

        FFmpeg.SetExecutablesPath(execPath);

        if (!File.Exists(ffmpegPath) || !File.Exists(ffprobePath))
        {
            Progress<ProgressInfo> progress = new();

            progress.ProgressChanged += async (object? sender, ProgressInfo e) =>
            {
                if (e.DownloadedBytes == 1 && e.TotalBytes == 1)
                {
                    await WriteLog("FFmpeg 已下載完成，可以開始作業。");

                    SetControlEnabled(true);
                }
                else
                {
                    double rawPercent = (double)e.DownloadedBytes / e.TotalBytes * 100.0;
                    double actulPercent = Math.Round(rawPercent, 2, MidpointRounding.AwayFromZero);

                    string message = $"FFmpeg 下載中：[{e.DownloadedBytes} / {e.TotalBytes}] {actulPercent}%";

                    await WriteLog(message);
                }
            };

            await FFmpegDownloader.GetLatestVersion(
                FFmpegVersion.Official,
                execPath,
                progress);
        }
        else
        {
            await WriteLog("已找到 FFmpeg 執行檔，可以開始作業。");

            SetControlEnabled(true);
        }
    }

    /// <summary>
    /// 初始化字型的 ComboBox
    /// </summary>
    private void InitFontComboBox()
    {
        CBFont.InvokeIfRequired(() =>
        {
            using InstalledFontCollection installedFontCollection = new();

            List<string> dataSet = new();

            for (int i = 0; i < installedFontCollection.Families.Length; i++)
            {
                dataSet.Add(installedFontCollection.Families[i].Name);
            }

            CBFont.DataSource = dataSet;
            CBFont.SelectedItem = "微軟正黑體";
        });
    }

    /// <summary>
    /// 初始化文字編碼的 ComboBox
    /// </summary>
    private void InitEncodeComboBox()
    {
        CBEncode.InvokeIfRequired(() =>
        {
            // 資料來源：https://trac.ffmpeg.org/attachment/ticket/2431/sub_charenc_parameters.txt
            CBEncode.SelectedItem = "UTF-8";
        });
    }

    /// <summary>
    /// 初始化裝置的 ComboBox
    /// </summary>
    private void InitDeviceComboBox()
    {
        CBDeviceNo.InvokeIfRequired(() =>
        {
            CBDeviceNo.DataSource = VideoCardUtil.GetDeviceList();
            CBDeviceNo.DisplayMember = "DeviceName";
            CBDeviceNo.ValueMember = "DeviceNo";

            // 預設選擇第一個 GPU 裝置。
            CBDeviceNo.SelectedIndex = 0;

            CBHardwareAcceleratorType.InvokeIfRequired(() =>
            {
                if (CBDeviceNo.SelectedItem is VideoCardData videoCard)
                {
                    foreach (string hardwareAcceleratorType in CBHardwareAcceleratorType.Items)
                    {
                        if (!string.IsNullOrEmpty(videoCard.DeviceName) &&
                            videoCard.DeviceName.Contains(hardwareAcceleratorType))
                        {
                            CBHardwareAcceleratorType.Text = hardwareAcceleratorType;

                            break;
                        }
                    }
                }
                else
                {
                    CBHardwareAcceleratorType.Text = "Intel";
                }
            });
        });
    }

    /// <summary>
    /// 燒錄字幕
    /// </summary>
    /// <param name="viedoPath">字串，視訊檔案的路徑</param>
    /// <param name="subtitlePath">字串，字幕檔案的路徑</param>
    /// <param name="outputPath">字串，輸出檔案的路徑</param>
    /// <param name="subtitleEncode">字串，字幕的文字編碼，預設值為 "UTF-8"</param>
    /// <param name="applyFontSetting">布林值，套用字型設定，預設值為 false</param>
    /// <param name="subtitleStyle">字串，字幕的覆寫風格，預設值為 null</param>
    /// <param name="enableHardAccel">布林值，使用硬體加速，預設值為 false</param>
    /// <param name="hardAccelType">字串，硬體加速類型，預設值為 null</param>
    /// <param name="deviceNo">數值，裝置的 ID 值，預設值為 0</param>
    /// <returns>Task&lt;IConversion&gt;</returns>
    public static async Task<IConversion> BurnInSubtitle(
        string viedoPath,
        string subtitlePath,
        string outputPath,
        string subtitleEncode = "UTF-8",
        bool applyFontSetting = false,
        string? subtitleStyle = null,
        bool enableHardAccel = false,
        string? hardAccelType = null,
        int deviceNo = 0)
    {
        // 取得影片的資訊。
        IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(viedoPath);

        bool isSubtitleAdded = false;

        List<IStream> outputStreams = new();

        // 循例每一個 IStream。
        foreach (IStream stream in mediaInfo.Streams)
        {
            if (stream.StreamType == StreamType.Video)
            {
                // 將 IStream 轉換成 IVideoStream。
                IVideoStream? videoStream = stream as IVideoStream;

                if (!isSubtitleAdded)
                {
                    // 判斷是否有套用字型設定。
                    if (!applyFontSetting)
                    {
                        subtitleStyle = null;
                    }

                    // 針對該 IVideoStream 燒錄字幕。
                    videoStream?.AddSubtitles(
                        subtitlePath,
                        encode: subtitleEncode,
                        style: subtitleStyle);

                    // 變更開關作用變數的值。
                    isSubtitleAdded = true;
                }

                if (videoStream != null)
                {
                    // 將 IVideoStream 加入 outputStreams。
                    outputStreams.Add(videoStream);
                }
            }
            else
            {
                // 將 IStream 加入 outputStreams。
                outputStreams.Add(stream);
            }
        }

        IConversion conversion = FFmpeg.Conversions.New()
            .AddStream(outputStreams)
            .SetOutput(outputPath)
            .SetOverwriteOutput(true);

        SetHardwareAcceleration(
            conversion,
            enableHardAccel,
            hardAccelType,
            deviceNo);

        return conversion;
    }

    /// <summary>
    /// 加入 ISubtitleStream
    /// </summary>
    /// <param name="viedoPath">字串，視訊檔案的路徑</param>
    /// <param name="subtitlePath">字串，字幕檔案的路徑</param>
    /// <param name="outputPath">字串，輸出檔案的路徑</param>
    /// <param name="enableHardAccel">布林值，使用硬體加速，預設值為 false</param>
    /// <param name="hardAccelType">字串，硬體加速類型，預設值為 null</param>
    /// <param name="deviceNo">數值，裝置的 ID 值，預設值為 0</param>
    /// <returns>Task&lt;IConversion&gt;</returns>
    public static async Task<IConversion> AddSubtitleStream(
        string viedoPath,
        string subtitlePath,
        string outputPath,
        bool enableHardAccel = false,
        string? hardAccelType = null,
        int deviceNo = 0)
    {
        // 取得影片的資訊。
        IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(viedoPath);

        // 取得字幕檔的資訊。
        IMediaInfo subtitleInfo = await FFmpeg.GetMediaInfo(subtitlePath);

        // 取得 ISubtitleStream。
        IEnumerable<ISubtitleStream> subtitleStream = subtitleInfo.SubtitleStreams;

        IConversion conversion = FFmpeg.Conversions.New()
            .AddStream(mediaInfo.Streams)
            .AddStream(subtitleStream)
            .SetOutput(outputPath)
            .SetOverwriteOutput(true);

        SetHardwareAcceleration(
            conversion,
            enableHardAccel,
            hardAccelType,
            deviceNo);

        return conversion;
    }

    /// <summary>
    /// 設定硬體加速
    /// </summary>
    /// <param name="conversion">IConversion</param>
    /// <param name="enableHardAccel">布林值，啟用硬體加速</param>
    /// <param name="hardAccelType">字串，硬體加速類型</param>
    /// <param name="deviceNo">數值，裝置的 ID</param>
    private static void SetHardwareAcceleration(IConversion conversion,
        bool enableHardAccel,
        string? hardAccelType,
        int deviceNo)
    {
        if (enableHardAccel)
        {
            switch (hardAccelType)
            {
                case "Intel":
                    conversion.UseHardwareAcceleration(
                        nameof(HardwareAccelerator.d3d11va),
                        nameof(VideoCodec.h264),
                        "h264_qsv",
                        deviceNo);

                    break;
                case "NVIDIA":
                    conversion.UseHardwareAcceleration(
                       HardwareAccelerator.d3d11va,
                       VideoCodec.h264,
                       VideoCodec.h264_nvenc,
                       deviceNo);

                    break;
                case "AMD":
                    conversion.UseHardwareAcceleration(
                         nameof(HardwareAccelerator.d3d11va),
                         nameof(VideoCodec.h264),
                         "h264_amf",
                         deviceNo);

                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 設定 IConversion 的事件
    /// </summary>
    /// <param name="conversion">IConversion</param>
    private void SetConversionEvent(IConversion conversion)
    {
        conversion.OnDataReceived += async (sender, args) =>
        {
            if (args.Data != null)
            {
                await WriteLog(args.Data);
            }
        };

        conversion.OnProgress += async (sender, args) =>
        {
            await WriteLog($"執行緒：{args.ProcessId} [{args.Duration} / {args.TotalLength}] {args.Percent}%");
        };
    }

    /// <summary>
    /// 寫 IConversionResult 的內容
    /// </summary>
    /// <param name="conversionResult">IConversionResult</param>
    private async void WriteConversionResult(IConversionResult conversionResult)
    {
        string result = $"開始時間：{conversionResult.StartTime}{Environment.NewLine}" +
            $"結束時間：{conversionResult.EndTime}{Environment.NewLine}" +
            $"耗時：{conversionResult.Duration}{Environment.NewLine}" +
            $"參數：{conversionResult.Arguments}";

        await WriteLog(result);
    }

    /// <summary>
    /// 寫紀錄
    /// </summary>
    /// <param name="message">字串，訊息</param>
    /// <param name="debug">布林值，是否用 Debug 輸出，預設值為 false</param>
    /// <returns>Task</returns>
    private async Task WriteLog(string message, bool debug = false)
    {
        await Task.Run(() =>
        {
            string outputStr = $"[{DateTime.Now:yyyy-MM-dd hh:mm:ss}] " +
                $"{message}{Environment.NewLine}";

            TBLog.InvokeIfRequired(() =>
            {
                TBLog.AppendText(outputStr);
            });

            if (debug)
            {
                Debug.WriteLine(outputStr);
            }
        });
    }

    /// <summary>
    /// 設定控制項啟用禁用
    /// </summary>
    /// <param name="enable">布林值，預設為 true</param>
    private void SetControlEnabled(bool enable = true)
    {
        TBVideoFilePath.InvokeIfRequired(() =>
        {
            TBVideoFilePath.Enabled = enable;
        });

        BtnSelectVideoFile.InvokeIfRequired(() =>
        {
            BtnSelectVideoFile.Enabled = enable;
        });

        TBSubtitleFilePath.InvokeIfRequired(() =>
        {
            TBSubtitleFilePath.Enabled = enable;
        });

        BtnSelectSubtitleFile.InvokeIfRequired(() =>
        {
            BtnSelectSubtitleFile.Enabled = enable;
        });

        CBApplyFontSetting.InvokeIfRequired(() =>
        {
            CBApplyFontSetting.Enabled = enable;
        });

        CBFont.InvokeIfRequired(() =>
        {
            CBFont.Enabled = enable;
        });

        TBCustomFont.InvokeIfRequired(() =>
        {
            TBCustomFont.Enabled = enable;
        });

        CBEncode.InvokeIfRequired(() =>
        {
            CBEncode.Enabled = enable;
        });

        TBCustomEncode.InvokeIfRequired(() =>
        {
            TBCustomEncode.Enabled = enable;
        });

        CBEnableHardwareAcceleration.InvokeIfRequired(() =>
        {
            CBEnableHardwareAcceleration.Enabled = enable;
        });

        CBHardwareAcceleratorType.InvokeIfRequired(() =>
        {
            CBHardwareAcceleratorType.Enabled = enable;
        });

        CBDeviceNo.InvokeIfRequired(() =>
        {
            CBDeviceNo.Enabled = enable;
        });

        BtnBurnIn.InvokeIfRequired(() =>
        {
            BtnBurnIn.Enabled = enable;
        });

        BtnCancel.InvokeIfRequired(() =>
        {
            BtnCancel.Enabled = !enable;
        });
    }
}