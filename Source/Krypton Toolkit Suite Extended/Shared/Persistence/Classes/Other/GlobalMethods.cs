﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace Persistence.Classes.Other
{
    public class GlobalMethods
    {
        #region Constructor
        public GlobalMethods()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Not the implemented yet.
        /// </summary>
        /// <param name="featureName">Name of the feature.</param>
        public static void NotImplementedYet(string featureName = null)
        {
            if (featureName != null)
            {
                KryptonMessageBox.Show($"The feature: { featureName } is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("This is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}