﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using System;
using System.Runtime.InteropServices;

namespace ExtendedFileDialogs.Interop
{
    // Dummy base interface for CommonFileDialog coclasses
    internal interface NativeCommonFileDialog
    { }

    // ---------------------------------------------------------
    // Coclass interfaces - designed to "look like" the object 
    // in the API, so that the 'new' operator can be used in a 
    // straightforward way. Behind the scenes, the C# compiler
    // morphs all 'new CoClass()' calls to 'new CoClassWrapper()'
    [ComImport,
    Guid(IIDGuid.IFileOpenDialog),
    CoClass(typeof(FileOpenDialogRCW))]
    internal interface NativeFileOpenDialog : IFileOpenDialog
    {
    }

    [ComImport,
    Guid(IIDGuid.IFileSaveDialog),
    CoClass(typeof(FileSaveDialogRCW))]
    internal interface NativeFileSaveDialog : IFileSaveDialog
    {
    }

    [ComImport,
    Guid(IIDGuid.IKnownFolderManager),
    CoClass(typeof(KnownFolderManagerRCW))]
    internal interface KnownFolderManager : IKnownFolderManager
    {
    }

    // ---------------------------------------------------
    // .NET classes representing runtime callable wrappers
    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(CLSIDGuid.FileOpenDialog)]
    internal class FileOpenDialogRCW
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(CLSIDGuid.FileSaveDialog)]
    internal class FileSaveDialogRCW
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(CLSIDGuid.KnownFolderManager)]
    internal class KnownFolderManagerRCW
    {
    }
}