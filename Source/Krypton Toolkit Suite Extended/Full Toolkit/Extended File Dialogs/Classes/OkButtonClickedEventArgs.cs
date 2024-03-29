﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using System.ComponentModel;

namespace ExtendedFileDialogs.Classes
{
    /// <summary>
    /// Provides data for the <see cref="InputDialog.OkButtonClicked"/> event.
    /// </summary>
    /// <threadsafety instance="false" static="true" />
    public class OkButtonClickedEventArgs : CancelEventArgs
    {
        private string _input;
        private System.Windows.Forms.IWin32Window _inputBoxWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="OkButtonClickedEventArgs"/> class with the specified input text
        /// and input box window.
        /// </summary>
        /// <param name="input">The current value of the input field on the dialog.</param>
        /// <param name="inputBoxWindow">The input box window.</param>
        public OkButtonClickedEventArgs(string input, System.Windows.Forms.IWin32Window inputBoxWindow)
        {
            _input = input;
            _inputBoxWindow = inputBoxWindow;
        }

        /// <summary>
        /// Gets the current value of the input field on the dialog.
        /// </summary>
        /// <value>
        /// The current value of the input field on the dialog.
        /// </value>
        /// <remarks>
        /// The <see cref="InputDialog.Input"/> property will not be updated until the dialog has been closed,
        /// so this property can be used to determine the value entered by the user when this event is raised.
        /// </remarks>
        public string Input
        {
            get { return _input; }
        }

        /// <summary>
        /// Gets the input box window.
        /// </summary>
        /// <value>
        /// The <see cref="System.Windows.Forms.IWin32Window"/> for the input box window.
        /// </value>
        /// <remarks>
        /// You can use this property if you need to display a modal dialog (for example to alert the user if the current input value
        /// is invalid) and you want the input box to be the parent of that dialog.
        /// </remarks>
        public System.Windows.Forms.IWin32Window InputBoxWindow
        {
            get { return _inputBoxWindow; }
        }
    }
}