using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class AlwaysOnTop : MonoBehaviour
{
    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_NOMOVE = 0x0002;
    const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

    private IntPtr windowHandle;
    private bool isAlwaysOnTop = false;

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int X, int Y, int cx, int cy, uint uFlags);

    void Start()
    {

    }
    // THIS RUNS IMMEDIATELY AFTER BORDERLESSWINDOW SCRIPT
    public void SetAlwaysOnTop()
    {
        windowHandle = GetUnityWindowHandle();
        if (windowHandle == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("Could not get window handle.");
        }
    }
    public void ToggleAlwaysOnTop()
    {
        if (windowHandle == IntPtr.Zero) return;

        isAlwaysOnTop = !isAlwaysOnTop;

        IntPtr insertAfter = isAlwaysOnTop ? HWND_TOPMOST : HWND_NOTOPMOST;

        bool result = SetWindowPos(windowHandle, insertAfter, 0, 0, 0, 0, TOPMOST_FLAGS);
        if (result)
        {
            UnityEngine.Debug.Log(isAlwaysOnTop ? "Always on top enabled." : "Always on top disabled.");
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to set window position.");
        }
    }

    IntPtr GetUnityWindowHandle()
    {
        using (Process process = Process.GetCurrentProcess())
        {
            return process.MainWindowHandle;
        }
    }
}
