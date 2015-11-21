﻿/*
 * This library is part of Stock Trader System
 *
 * Copyright (c) qiujoe (http://www.github.com/qiujoe)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * For further information about StockTrader, please see the
 * project website: http://www.github.com/qiujoe/StockTrader
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Common
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void LogArrivedDelegate(Type t, String log);
    public class LogHelper
    {

        private static LogHelper instance = new LogHelper();
        public static LogHelper Instance
        {
            get { return instance; }
        }
        public event LogArrivedDelegate OnLogArrived;
        /// <summary>
        /// 写LOG
        /// </summary>
        /// <param name="t"></param>
        /// <param name="message"></param>
        public void WriteLog(Type t, String message)
        {
            WriteLog(t, message, false);
        }
        public void WriteLog(Type t, String message, bool showInUI)
        {
            if (showInUI)
            {
                if (OnLogArrived != null)
                    OnLogArrived(t, message);
            }
        }



        /// <summary>
        /// 写错误发生时的LOG
        /// </summary>
        /// <param name="t"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void WriteErrorLog(Type t, String message, Exception ex)
        {
        }

    }
}
