﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using ExtendedControls.ExtendedToolkit.Calendar.Controls;

namespace ExtendedControls.ExtendedToolkit.Calendar.Enumerations
{
    /// <summary>
    /// Enumerates possible timescales for <see cref="KryptonCalendar"/> control
    /// </summary>
    public enum CalendarTimeScale
    {
        /// <summary>
        /// Makes calendar show intervals of 60 minutes
        /// </summary>
        SIXTYMINUTES = 60,

        /// <summary>
        /// Makes calendar show intervals of 30 minutes
        /// </summary>
        THIRTYMINUTES = 30,

        /// <summary>
        /// Makes calendar show intervals of 15 minutes
        /// </summary>
        FIFTEENMINUTES = 15,

        /// <summary>
        /// Makes calendar show intervals of 10 minutes
        /// </summary>
        TENMINUTES = 10,

        /// <summary>
        /// Makes calendar show intervals of 6 minutes
        /// </summary>
        SIXMINUTES = 6,

        /// <summary>
        /// Makes calendar show intervals of 5 minutes
        /// </summary>
        FIVEMINUTES = 5
    }
}