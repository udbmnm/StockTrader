/*
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
using System.Windows.Forms;

using System.Window;
using System.Runtime.InteropServices;
using System.Threading;

namespace Stock.Trader.HuaTai
{
    /// <summary>
    /// 华泰的外挂交易接口
    /// </summary>
    public class TdxStockTrader : BaseStockTrader, IStockTrader
    {
        const int MDI_FRAME = 0xE900;

        #region 各个重要的句柄和基本操作
        IntPtr hWnd;    // 窗口句柄
        IntPtr hTdxWsjy;    // 主程序句柄
        IntPtr htvi;    // 功能树形控件句柄

        // 主功能菜单
        int hBuy, hSell, hCancel, hDmdm, hSjmr, hSjmc, hGzxt, hXgsg, hQuery, hPlxd, hEtfwx, hCnjj, hJjphyw, hQtjy, hYmd, hYzzz, hZqhg, hBjhg, hDzjy, hHbjj, hFezr, hXgmm, hXgkhzl, hZhqxgl;
        // 查询菜单
        int hQueryZjgf, hQueryDrwt, hQueryDrcj, hQueryZjls, hQueryzPhcx, hQueryZqcx, hQueryLscjcx;
        // 其他交易菜单
        int hQtjyQtmm, hQtjyYsyy, hQtjyJcyy, hQtjyXq, hQtjyZzxq, hQtjyGqjlrzyw, hQtjyFjjj, hQtjyWltp, hQtjySzLOFjj;
        // 其他交易-分级基金业务
        int hQtjyFjjjywJjsg, hQtjyFjjjywJjsh, hQtjyFjjjywJjfc, hQtjyFjjjywJjhb, hQtjyFjjjywJjrg;
        // 其他交易-上证LOF基金
        int hQtjySzLOFjjRg, hQtjySzLOFjjSg, hQtjySzLOFjjSh, hQtjySzLOFjjHb, hQtjySzLOFjjFc, hQtjySzLOFjjCd, hQtjySzLOFjjCxdrwt, hQtjySzLOFjjCxdrcj;

        /// <summary>
        /// 获取左侧功能菜单treeview 句柄
        /// </summary>
        /// <returns></returns>
        private IntPtr GetFuncTreeView()
        {
            
            return IntPtr.Zero;
        }

        IntPtr temp, hBuyPanel, hSellPanel, hCancelPanel, hOrderPanel, hPositionPanel;
       

        private IntPtr GetTdxWsjyAfxMDIFrame()
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// 获取右侧主面板句柄
        /// </summary>
        /// <returns></returns>
        private IntPtr GetDetailPanel()
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// 获取持仓列表信息控件
        /// </summary>
        /// <returns></returns>
        private IntPtr GetPositonList()
        {
            return IntPtr.Zero;
        }

        #region 点击各个功能菜单

        private void ClickSellTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hSell);
        }

        private void ClickBuyTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hBuy);
        }

        private void ClickCancelTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hCancel);
        }

        private void ClickQueryTreeViewItem()
        {
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQueryZjgf);
        }

        #endregion

        #region init handler

         private void InitQueryFuncHandler()
        {
            hQueryZjgf = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_CHILD, hQuery);
            hQueryDrwt = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryZjgf);
            hQueryDrcj = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryDrwt);
            hQueryZjls = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryDrcj);
            hQueryzPhcx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryZjls);
            hQueryZqcx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryzPhcx);
            hQueryLscjcx = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hQueryZqcx);
        }

        private void InitMainFuncHandler()
        {
            hBuy = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_ROOT, 0);
            hSell = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hBuy);
            hDmdm = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSell);
            hSjmr = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hDmdm);
            hSjmc = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSjmr);
            hCancel = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSjmc);

            hQuery = Win32API.SendMessage(htvi, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hCancel);
        }

        #endregion
        #endregion

        #region 接口实现

        /// <summary>
        /// 检测
        /// </summary>
        public override void Init()
        {
        }

        public TraderResult SellStock(string code, float price, int num)
        {
            return null ;
        }

        public TraderResult BuyStock(string code, float price, int num)
        {

            return null;
        }

        public TraderResult CancelStock(String entrust_no)
        {
            ClickCancelTreeViewItem();
            return null ;
        }

        public void Keep()
        {
            // 刷新
            Win32API.PostMessage(hWnd, Win32Code.WM_KEYDOWN, Win32Code.VK_F5, 0);
        }

        private IntPtr findWndClass(IntPtr hWnd, IntPtr child)
        {
            IntPtr hc = Win32API.FindWindowEx(hWnd, child, "CLIPBRDWNDCLASS", null);
            STRINGBUFFER sb;
            Win32API.GetClassName(hc, out sb, 15);
            if (sb.szText.ToUpper().Equals("CLIPBRDWNDCLASS"))
            {
                MessageBox.Show(sb.szText);
            }
            else
            {
                findWndClass(hWnd, hc);
            }
            Console.WriteLine(sb.szText);

            return hc;
      }

        public TraderResult GetTradingAccountInfo()
        {

            return null;

        }

        public TraderResult GetTodayTradeList()
        {
            throw new NotImplementedException();
        }

        public string PurchaseFundSZ(string code, float total)
        {
            return "";
        }

        public string RedempteFundSZ(string code, int num)
        {
            return "";
       
        }

        public string MergeFundSZ(string code, int num)
        {
            return "";
       
        }

        public string PartFundSZ(string code, int num)
        {
            return "";
      
        }

        public string PurchaseFundSH(string code, float total)
        {
            return "";
        }

        public string RedempteFundSH(string code, int num)
        {
            return "";
        }

        /// <summary>
        /// 合并
        /// </summary>
        /// <param name="code"></param>
        /// <param name="num"></param>
        public string MergeFundSH(string code, int num)
        {
            return "";
        }

        public string PartFundSH(string code, int num)
        {
            return "";
        }

        #endregion

    }
}
