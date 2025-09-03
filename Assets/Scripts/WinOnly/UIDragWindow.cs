using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class UIDragWindow : MonoBehaviour, IPointerDownHandler
{
    [DllImport("user32.dll")]
    static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    const int WM_NCLBUTTONDOWN = 0x00A1;
    const int HTCAPTION = 0x02;

    public void OnPointerDown(PointerEventData eventData)
    {
        IntPtr hWnd = GetUnityWindowHandle();
        if (hWnd == IntPtr.Zero) return;

        ReleaseCapture();
        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0);
    }

    IntPtr GetUnityWindowHandle()
    {
        using (Process process = Process.GetCurrentProcess())
        {
            return process.MainWindowHandle;
        }
    }
}
