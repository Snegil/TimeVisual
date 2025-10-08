using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using UnityEngine;

public class BorderlessWindow : MonoBehaviour
{
    const int GWL_STYLE = -16;
    const uint WS_BORDER = 0x00800000;
    const uint WS_CAPTION = 0x00C00000;
    const uint WS_SYSMENU = 0x00080000;
    const uint WS_THICKFRAME = 0x00040000;
    const uint WS_MINIMIZEBOX = 0x00020000;
    const uint WS_MAXIMIZEBOX = 0x00010000;

    const uint SWP_NOMOVE = 0x0002;
    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_FRAMECHANGED = 0x0020;
    const uint SWP_NOZORDER = 0x0004;
    const uint SWP_NOACTIVATE = 0x0010;
    const uint FLAGS = SWP_NOMOVE | SWP_NOSIZE | SWP_FRAMECHANGED | SWP_NOZORDER | SWP_NOACTIVATE;

    // Opacity/Transparency constants
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint LWA_ALPHA = 0x00000002;

    [DllImport("user32.dll")]
    static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    IntPtr GetUnityWindowHandle()
    {
        using (Process process = Process.GetCurrentProcess())
        {
            return process.MainWindowHandle;
        }
    }

    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    AlwaysOnTop alwaysOnTopComponent;

    [SerializeField]
    int sizeIncrement = 0;

    [Header("Window Opacity Settings")]
    [SerializeField, Range(0.1f, 1.0f)]
    float inactiveOpacity = 0.7f;
    public float InactiveOpacity
    {
        get { return inactiveOpacity; }
        set { inactiveOpacity = Mathf.Clamp(value, 0.1f, 1.0f); }
    }

    private bool isWindowActive = true;
    private IntPtr windowHandle;

    IntPtr hWnd;

    readonly List<Vector2Int> resolutions = new()
    {
        // 16:9 Aspect Ratio Resolutions
        new Vector2Int(340, 180), // 0 ;
        new Vector2Int(374, 198), // 1 ;
        new Vector2Int(408, 216), // 2 ;
        new Vector2Int(442, 234), // 3 ;
        new Vector2Int(476, 252), // 4 ;
        new Vector2Int(510, 270), // 5 ;
        new Vector2Int(544, 288), // 6 ;
        new Vector2Int(578, 306), // 7 ;
        new Vector2Int(612, 324), // 8 ;
        new Vector2Int(646, 342), // 9 ;
        new Vector2Int(680, 360)  // 10;
    };

    void Start()
    {
        alwaysOnTopComponent = GetComponent<AlwaysOnTop>();

        windowHandle = GetUnityWindowHandle();
        hWnd = windowHandle;

        uint style = GetWindowLong(hWnd, GWL_STYLE);
        style &= ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU);

        SetWindowLong(hWnd, GWL_STYLE, style);

        //SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, FLAGS);
        
        if (PlayerPrefs.HasKey("WindowPosX") && PlayerPrefs.HasKey("WindowPosY") && PlayerPrefs.HasKey("WindowSizeIncrement"))
        {
            int posX = PlayerPrefs.GetInt("WindowPosX");
            int posY = PlayerPrefs.GetInt("WindowPosY");
            sizeIncrement = PlayerPrefs.GetInt("WindowSizeIncrement");
            
            SetWindowPos(hWnd, IntPtr.Zero, posX, posY, resolutions[sizeIncrement].x, resolutions[sizeIncrement].y, SWP_FRAMECHANGED);
        }
        else
        {
            SetWindowPos(hWnd, IntPtr.Zero, 0, Screen.currentResolution.height / 2, resolutions[sizeIncrement].x, resolutions[sizeIncrement].y, SWP_FRAMECHANGED);
        }

        alwaysOnTopComponent.SetAlwaysOnTop();
        alwaysOnTopComponent.AlwaysOnTopFunction();

        EnableWindowTransparency();
        SetWindowOpacity(1);
    }

    void FixedUpdate()
    {
        CheckWindowFocus();
    }

    private void CheckWindowFocus()
    {
        if (windowHandle == IntPtr.Zero) return;

        IntPtr foregroundWindow = GetForegroundWindow();
        bool isForeground = foregroundWindow == windowHandle;

        if (isForeground && !isWindowActive)
        {
            SetActiveOpacity();
        }
        else if (!isForeground && isWindowActive)
        {
            SetInactiveOpacity();
        }
    }

    public void WindowSizeIncrement(int addedIncrement)
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) { return; }

        sizeIncrement += addedIncrement;
        sizeIncrement = Mathf.Clamp(sizeIncrement, 0, resolutions.Count - 1);

        RECT rect;
        GetWindowRect(hWnd, out rect);
        int x = rect.Left;
        int y = rect.Top;

        // Set new size
        SetWindowPos(hWnd, IntPtr.Zero, x, y, resolutions[sizeIncrement].x, resolutions[sizeIncrement].y, SWP_NOZORDER | SWP_NOACTIVATE | SWP_FRAMECHANGED);
    }
    public int SizeIncrement
    {
        get { return sizeIncrement; }
    }

    public void SaveWindowPos()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) { return; }

        // Get window rect
        if (GetWindowRect(hWnd, out RECT rect))
        {
            PlayerPrefs.SetInt("WindowPosX", rect.Left);
            PlayerPrefs.SetInt("WindowPosY", rect.Top);
        }
    }
    public void SaveWindowSizeIncrement()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) { return; }

        PlayerPrefs.SetInt("WindowSizeIncrement", sizeIncrement);
    }

    private void EnableWindowTransparency()
    {
        if (windowHandle == IntPtr.Zero) return;

        uint exStyle = GetWindowLong(windowHandle, GWL_EXSTYLE);
        exStyle |= WS_EX_LAYERED;
        SetWindowLong(windowHandle, GWL_EXSTYLE, exStyle);
    }

    public void SetWindowOpacity(float opacity)
    {
        if (windowHandle == IntPtr.Zero) return;

        opacity = Mathf.Clamp01(opacity);
        byte alpha = (byte)(opacity * 255);
        SetLayeredWindowAttributes(windowHandle, 0, alpha, LWA_ALPHA);
    }

    public void SetActiveOpacity()
    {
        SetWindowOpacity(1f);
        isWindowActive = true;
    }

    public void SetInactiveOpacity()
    {
        SetWindowOpacity(inactiveOpacity);
        isWindowActive = false;
    }
}
