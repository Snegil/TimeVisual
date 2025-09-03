using System;
using System.Diagnostics;
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
    const uint FLAGS = SWP_NOMOVE | SWP_NOSIZE | SWP_FRAMECHANGED;

    [DllImport("user32.dll")]
    static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

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
    int width;

    [SerializeField]
    int height;

    void Start()
    {
        alwaysOnTopComponent = GetComponent<AlwaysOnTop>();

        IntPtr hWnd = GetUnityWindowHandle();

        if (hWnd == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("Could not get Unity window handle.");
            return;
        }

        uint style = GetWindowLong(hWnd, GWL_STYLE);
        style &= ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU);

        SetWindowLong(hWnd, GWL_STYLE, style);

        SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, FLAGS);

        if (PlayerPrefs.HasKey("WindowPosX") && PlayerPrefs.HasKey("WindowPosY"))
        {
            int posX = PlayerPrefs.GetInt("WindowPosX");
            int posY = PlayerPrefs.GetInt("WindowPosY");
            SetWindowPos(hWnd, IntPtr.Zero, posX, posY, width, height, SWP_FRAMECHANGED);
        }
        else
        {
            SetWindowPos(hWnd, IntPtr.Zero, 0, Screen.currentResolution.height / 2, width, height, SWP_FRAMECHANGED);
        }

        alwaysOnTopComponent.SetAlwaysOnTop();
        alwaysOnTopComponent.ToggleAlwaysOnTop();
    }
    // TEST SCREENSIZE; WORKED BUT NOT A GREAT WAY TO OPTIMISE THINGS.
    //Screen.currentResolution.width / 6, Screen.currentResolution.height / 5



    public void SaveWindowPos()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) { return; }

        IntPtr hWnd = GetUnityWindowHandle();
        if (hWnd == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("Could not get Unity window handle.");
            return;
        }

        // Get window rect
        if (GetWindowRect(hWnd, out RECT rect))
        {
            PlayerPrefs.SetInt("WindowPosX", rect.Left);
            PlayerPrefs.SetInt("WindowPosY", rect.Top);
            PlayerPrefs.Save();
        }
    }
}
