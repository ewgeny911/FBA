/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 11.11.2017
 * Время: 22:30
 */
 
using System;
using System.Linq;
using System.Runtime.InteropServices; 

namespace FBA
{
      
    /// <summary>
    /// Класс импорта функций операционной системы. Используется в SysForm.
    /// </summary>
	static class WinAPI
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd); 
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static internal extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static internal extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)]string lpNewItem);
        
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        static internal extern bool InsertMenu(IntPtr hmenu, uint position, MenuFlags flags,
                uint item_id, [MarshalAs(UnmanagedType.LPTStr)]string item_text);
        
        [Flags]
        internal enum MenuFlags {
            MF_BITMAP       = 0x00000004,
            MF_BYCOMMAND    = 0x00000000,
            MF_BYPOSITION   = 0x00000400,
            MF_CHECKED      = 0x00000008,
            MF_DISABLED     = 0x00000002,
            MF_ENABLED      = 0x00000000,
            MF_GRAYED       = 0x00000001,
            MF_MENUBARBREAK = 0x00000020,
            MF_MENUBREAK    = 0x00000040,
            MF_OWNERDRAW    = 0x00000100,
            MF_POPUP        = 0x00000010,
            MF_SEPARATOR    = 0x00000800,
            MF_STRING       = 0x00000000,
            MF_UNCHECKED    = 0x00000000
        }
        internal const int WM_SYSCOMMAND = 0x112;
    }
   
}
