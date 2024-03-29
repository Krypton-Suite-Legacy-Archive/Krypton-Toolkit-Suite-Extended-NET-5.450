﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using ExtendedControls.ExtendedToolkit.Calendar.Controls;
using System;

namespace ExtendedControls.ExtendedToolkit.Calendar.Classes
{
    /// <summary>
    /// Holds data of a Calendar Loading Items of certain date range
    /// </summary>
    public class CalendarLoadEventArgs : EventArgs
    {
        #region Fields
        private KryptonCalendar _calendar;
        private DateTime _dateStart;
        private DateTime _dateEnd;

        #endregion

        #region Ctor

        public CalendarLoadEventArgs(KryptonCalendar calendar, DateTime dateStart, DateTime dateEnd)
        {
            _calendar = calendar;
            _dateEnd = dateEnd;
            _dateStart = dateStart;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the calendar that originated the event
        /// </summary>
        public KryptonCalendar Calendar
        {
            get { return _calendar; }
        }

        /// <summary>
        /// Gets the start date of the load
        /// </summary>
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }

        /// <summary>
        /// Gets the end date of the load
        /// </summary>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
        }


        #endregion
    }
}