param(
    [Parameter(Mandatory = $true)]
    [string]$ExePath,

    [Parameter(Mandatory = $true)]
    [string]$OutputDir
)

Add-Type -AssemblyName System.Drawing
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName UIAutomationClient
Add-Type -AssemblyName UIAutomationTypes

Add-Type @"
using System;
using System.Runtime.InteropServices;

public static class NativeWindowTools
{
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int flags);

    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
"@

function Save-WindowImage {
    param(
        [IntPtr]$Handle,
        [string]$Path
    )

    [NativeWindowTools+RECT]$rect = New-Object NativeWindowTools+RECT
    [void][NativeWindowTools]::GetWindowRect($Handle, [ref]$rect)
    $width = $rect.Right - $rect.Left
    $height = $rect.Bottom - $rect.Top

    $bitmap = New-Object System.Drawing.Bitmap($width, $height)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    $hdc = $graphics.GetHdc()
    [void][NativeWindowTools]::PrintWindow($Handle, $hdc, 0)
    $graphics.ReleaseHdc($hdc)
    $graphics.Dispose()
    $bitmap.Save($Path, [System.Drawing.Imaging.ImageFormat]::Png)
    $bitmap.Dispose()
}

New-Item -ItemType Directory -Force -Path $OutputDir | Out-Null

$process = Start-Process -FilePath $ExePath -PassThru
try {
    $process.WaitForInputIdle(10000) | Out-Null
    Start-Sleep -Milliseconds 1200
    $handle = $process.MainWindowHandle
    [void][NativeWindowTools]::SetForegroundWindow($handle)

    $fileNames = @(
        "01_default_binding.png",
        "02_two_way_binding.png",
        "03_one_time_binding.png",
        "04_one_way_bindings.png",
        "05_triggers.png"
    )

    for ($i = 0; $i -lt $fileNames.Count; $i++) {
        if ($i -gt 0) {
            [System.Windows.Forms.SendKeys]::SendWait("^{TAB}")
            Start-Sleep -Milliseconds 700
        }

        $fileName = $fileNames[$i]
        Save-WindowImage -Handle $handle -Path (Join-Path $OutputDir $fileName)
    }
}
finally {
    if ($process -and -not $process.HasExited) {
        $process.CloseMainWindow() | Out-Null
        Start-Sleep -Milliseconds 300
        if (-not $process.HasExited) {
            $process.Kill()
        }
    }
}
