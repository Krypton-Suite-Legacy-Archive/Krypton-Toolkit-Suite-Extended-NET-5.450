﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using ExtendedFileDialogs.Classes;
using ExtendedFileDialogs.Enumerations;
using System;
using System.Runtime.InteropServices;

namespace ExtendedFileDialogs.Interop
{
    [ComImport]
    [Guid(CLSIDGuid.ProgressDialog)]
    internal class ProgressDialogRCW
    {
    }

    [ComImport,
    Guid(IIDGuid.IProgressDialog),
    CoClass(typeof(ProgressDialogRCW))]
    internal interface ProgressDialog : IProgressDialog
    {
    }

    [ComImport]
    [Guid(IIDGuid.IProgressDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IProgressDialog
    {
        [PreserveSig]
        void StartProgressDialog(
            IntPtr hwndParent,
            [MarshalAs(UnmanagedType.IUnknown)]
            object punkEnableModless,
            ProgressDialogFlags dwFlags,
            IntPtr pvReserved
            );

        [PreserveSig]
        void StopProgressDialog();

        [PreserveSig]
        void SetTitle([MarshalAs(UnmanagedType.LPWStr)]string pwzTitle);

        [PreserveSig]
        void SetAnimation(SafeModuleHandle hInstAnimation, ushort idAnimation);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool HasUserCancelled();

        [PreserveSig]
        void SetProgress(uint dwCompleted, uint dwTotal);

        [PreserveSig]
        void SetProgress64(ulong ullCompleted, ulong ullTotal);

        [PreserveSig]
        void SetLine(
            uint dwLineNum,
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwzString,
            [MarshalAs(UnmanagedType.VariantBool)]
            bool fCompactPath,
            IntPtr pvReserved
            );

        [PreserveSig]
        void SetCancelMsg([MarshalAs(UnmanagedType.LPWStr)]string pwzCancelMsg, object pvReserved);

        [PreserveSig]
        void Timer(uint dwTimerAction, object pvReserved);
    }
}