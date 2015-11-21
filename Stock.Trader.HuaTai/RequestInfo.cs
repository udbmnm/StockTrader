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
using Stock.Sqlite;
using Stock.Common;

namespace Stock.Trader.HuaTai
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public class Request
    {
        public string uid { get; set; }

        public string cssweb_type { get; set; }

        public string version
        {
            get
            {
                return "1";
            }
        }

        public string custid { get; set; }

        public string op_branch_no { get; set; }//操作分支机构

        public string branch_no { get; set; }//分支机构

        public string op_entrust_way { get { return "7"; } }//委托方式

        public string exchange_type { get; set; }//交易类别

        public string function_id { get; set; } //系统功能号,  详细功能号参见《经纪业务运营平台V20_周边接口规范_V1.3(20121210)》

        public string fund_account { get; set; }//资金账户

        public string password { get; set; }//密码
        //password_type ''2'，交易密码

        public string op_station { get; set; }//站点地址

        public string identity_type //身份类别
        {
            get
            {
                return "";
            }
        }

        public string ram
        {
            get
            {
                return StockUtil.RandomString;
            }
        }
    }

    /// <summary>
    /// 登录
    /// </summary>
    public class LoginPostRequest
    {
        public LoginPostRequest() { }

        public string userType
        {
            get
            {
                return "jy";
            }
        }
        public string loginEvent
        {
            get { return "1"; }
        }
        public string trdpwdEns
        {
            get;
            set;
        }

        public string macaddr { get; set; }
        public string hddInfo { get; set; }
        public string lipInfo { get; set; }
        public string topPath { get { return "null"; } }
        public string accountType
        {
            get { return "1"; }
        }
        public string userName
        {
            get;
            set;
        }
        public string servicePwd { get; set; }
        public string trdpwd
        {
            get;
            set;
        }
        public string vcode { get; set; }
    }

    /// <summary>
    /// 买股票
    /// </summary>
    public class StockBuyRequest : Request
    {
        // uid=153-0679-7959208&cssweb_type=STOCK_BUY&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=302&fund_account=666600&password=ojCz+ofwfgred0kXNZv4/iTA$$&identity_type=&
        // exchange_type=1&stock_account=A763412369&stock_code=600717&entrust_amount=100&entrust_price=1&
        // entrust_prop=0&entrust_bs=1&ram=0.10738790780305862
        public StockBuyRequest() {
            this.cssweb_type = "STOCK_BUY";
            this.function_id = "302";
        }

        public int entrust_amount { get; set; }//委托数量

        public int entrust_bs//买卖方向
        {
            get
            {
                return 1;
            }
        }

        public float entrust_price { get; set; }//委托价格

        public int entrust_prop//委托属性
        {
            get
            {
                return 0;
            }
        }

        public string stock_account { get; set; }//证券账号

        public string stock_code { get; set; }//证券代码

    }

    /// <summary>
    /// 卖股票
    /// </summary>
    public class StockSaleRequest : Request
    {
        // uid=153-1f64-7915165&cssweb_type=STOCK_SALE&version=1&custid=666600111111&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$183.206.203.123;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=302&fund_account=666600111111&password=ojCz+oMyzH50kXNZv4/iTA$$&identity_type=&
        // exchange_type=1&stock_account=A763412369&stock_code=600717&entrust_amount=100&entrust_price=10&
        // entrust_prop=0&entrust_bs=2&ram=0.21561731165274978

        public StockSaleRequest()
        {
            cssweb_type = "STOCK_SELL";
            function_id = "302";
        }
        public int entrust_amount { get; set; }//委托数量

        public int entrust_bs//买卖方向
        {
            get
            {
                return 2;
            }
        }

        public float entrust_price { get; set; }//委托价格

        public int entrust_prop//委托属性
        {
            get
            {
                return 0;
            }
        }

        public string stock_account { get; set; }//证券账号

        public string stock_code { get; set; }//证券代码
     
    }

    /// <summary>
    /// 查询可撤单列表
    /// </summary>
    public class GetCancelListRequest : Request
    {
        // uid=153-0679-7959208&cssweb_type=GET_CANCEL_LIST&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=401&fund_account=666600&password=ojCz+grgw/iTA$$&identity_type=&exchange_type=&
        // stock_account=&stock_code=&locate_entrust_no=&query_direction=&sort_direction=0&request_num=100&
        // position_str=&ram=0.1280686566606164

        public GetCancelListRequest()
        {
            cssweb_type = "GET_CANCEL_LIST";
            function_id = "401";
        }

        public string stock_account { get; set; }//证券账号 空格，表示不限制
        public string stock_code { get; set; }//证券代码 空格，表示不限制
        public string locate_entrust_no {get{return "";} }//指定编号，action_in：2-委托批号，非2-委托编号 0，表示不限制
        public string query_direction { get{return "";}}//查询方向　'1'-正序　'0'-逆序
        public int sort_direction { get { return 0; } }//返回排序方式 '0'-正常 '1'-倒序
        public int request_num { get { return 100; } }//请求行数
        public string position_str { get{return "";}}//定位串
        //action_in 操作控制值，0-查询全部委托；1-查询可撤委托；2-按批号查询（通过locate_entrust_no送入）
        //query_type 查询类别　'0'-全部；'1'-不查委托类型为撤单的委托
        //query_mode 查询模式　0/空格-查明细，2-按交易类别、证券账号、证券代码、买卖类别汇总
    }

    /// <summary>
    /// 获取当日委托
    /// </summary>
    public class GetTodayEntrusterRequest : Request
    {
        // uid=152-107c-7090078&cssweb_type=GET_TODAY_ENTRUST&version=1&custid=666600001111&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$183.206.207.161;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=401&fund_account=666600001111&password=ojCz+oMyzH00kXNZv4/iTA$$&identity_type=&
        // exchange_type=&stock_account=&stock_code=&locate_entrust_no=&query_direction=&sort_direction=0&
        // request_num=100&position_str=&ram=0.5542000429704785
        public GetTodayEntrusterRequest() {
            cssweb_type = "GET_TODAY_ENTRUST";
            function_id = "401";
        }
        public string stock_account { get; set; }//证券账号 空格，表示不限制
        public string stock_code { get; set; }//证券代码 空格，表示不限制
        public string locate_entrust_no { get; set; }//指定编号，action_in：2-委托批号，非2-委托编号 0，表示不限制
        public string query_direction { get; set; }//查询方向　'1'-正序　'0'-逆序
        public int sort_direction { get { return 0; } }//返回排序方式 '0'-正常 '1'-倒序
        public int request_num { get { return 100; } }//请求行数
        public string position_str { get; set; }//定位串
        //action_in 操作控制值，0-查询全部委托；1-查询可撤委托；2-按批号查询（通过locate_entrust_no送入）
        //query_type 查询类别　'0'-全部；'1'-不查委托类型为撤单的委托
        //query_mode 查询模式　0/空格-查明细，2-按交易类别、证券账号、证券代码、买卖类别汇总
    }

    /// <summary>
    /// 获取历史委托
    /// </summary>
    public class GetHistoryEntrusterRequest : Request
    {
        //uid=152-107c-7090078&cssweb_type=HISTORY_TRADE&version=1&custid=666600001111&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$183.206.207.161;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=411&fund_account=666600001111&password=ojCz+oMyzH00kXNZv4/iTA$$&identity_type=&
        // start_date=20150918&end_date=20151019&exchange_type=&stock_account=&stock_code=&query_direction=1&
        // request_num=100&position_str=&ram=0.356126575730741
    }

    /// <summary>
    /// 撤销委托
    /// </summary>
    public class StockCancelRequest : Request
    {
        public StockCancelRequest()
        {
            cssweb_type = "STOCK_CANCEL";
            function_id = "304";
        }

        public string batch_flag
        {
            get
            {
                return "0";
            }
        }
        public string entrust_no { get; set; }//委托编号（batch_flag-'0'，委托编号；batch_flag-'1'，委托批号（委托批号为0表示批量撤销客户指定市场所有订单））
        //batch_flag 批量标志 '0'单笔 '1'批量

        // uid=153-759d-7924950&cssweb_type=STOCK_CANCEL&version=1&custid=666600111111&
        // op_branch_no=17&branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0D-27-1A-B4-32;HDD$                    &
        // function_id=304&fund_account=666600111111&password=ojCz+otgMyy5hf/iTA$$&
        // identity_type=&
        // batch_flag=0&exchange_type=&entrust_no=12140&ram=0.6111481911502779
    }

    /// <summary>
    /// 获取当日成交
    /// </summary>
    public class GetTodayTradeRequest : Request
    {
        // uid=153-0679-7959208&cssweb_type=GET_TODAY_TRADE&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=402&fund_account=66660&password=ojCz+oMyy5hf/iTA$$&identity_type=&serial_no=&
        // exchange_type=&stock_account=&stock_code=&query_direction=1&request_num=100&query_mode=0&
        // position_str=&ram=0.8150487979874015

        public GetTodayTradeRequest()
        {
            cssweb_type = "GET_TODAY_TRADE";
            function_id = "402";
        }

        public string stock_account { get { return ""; } }//证券账号
        public string stock_code { get { return ""; } }//证券代码
        public string locate_entrust_no { get { return ""; } }//
        public string query_direction { get { return "1"; } }//查询方向　'1'-正序　'0'-逆序
        public string serial_no { get { return ""; } }//流水序号（query_mode=4时，表示委托号）
        public int sort_direction { get { return 0; } }//
        public int request_num { get { return 100; } }//请求行数，不送按50行处理
        public string position_str { get { return ""; } }//定位串  空格，表示取第一页
        public string query_mode { get { return "0"; } }//查询模式，参见业务说明
        /*
        query_mode说明：
        '0'-取实时成交流水（是否返回撤单成交由系统配置决定）
        '1'-按照交易类别、席位号、申报号汇总实时成交流水（合笔）
        '2'-按照交易类别、证券账号、证券代码、买卖类别汇总实时成交流水（合笔）
        '3'-按照交易类别、证券代码、委托买卖类别、委托属性、成交类别、成交状态汇总实时成交流水（合笔）
        '4'-取实时成交流水，查询指定委托号（由serial_no输入）的成交明细记录（明细）
        */
    }

    /// <summary>
    /// 获取股票仓位
    /// </summary>
    public class GetStockPositionRequest : Request
    {
        // uid=153-0679-7959208&cssweb_type=GET_STOCK_POSITION&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=403&fund_account=666600&password=ojCz+oMyy5hf/iTA$$&identity_type=&
        // exchange_type=&stock_account=&stock_code=&query_direction=&query_mode=0&request_num=100&
        // position_str=&ram=0.8974461741745472

        public GetStockPositionRequest()
        {
            cssweb_type = "GET_STOCK_POSITION";
            function_id = "403";
        }

        public string position_str{ get { return ""; } }//定位串 空格，表示取第一页
        public string query_direction { get { return ""; } }
        public int query_mode { get { return 0; } }//查询模式，'0'-明细 '1'-汇总(营业部、交易类别和证券代码汇总证券信息)
        public int request_num { get { return 100; } }//请求行数（不能超过1000）
        public string stock_account { get { return ""; } }//证券账号
        public string stock_code { get { return ""; } }//证券代码

    }

    /// <summary>
    /// 获取资金信息
    /// </summary>
    public class GetFundsRequest : Request
    {
        // uid=153-0679-7959208&cssweb_type=GET_FUNDS&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=405&fund_account=666600&password=ojCz+oMyy5hf/iTA$$&identity_type=&
        // money_type=&ram=0.911359122954309
        public GetFundsRequest()
        {
            cssweb_type = "GET_FUNDS";
            function_id = "405";
        }

        public string money_type { get { return ""; } }//币种类别 空格，表示不限制
    }

    public class FundGetJjszRequest : Request
    {
        public FundGetJjszRequest()
        {
            cssweb_type = "FUND_GET_JJSZ";
            function_id = "741";// FIXME ? 7411
        }
        // uid=153-0679-7959208&cssweb_type=FUND_GET_JJSZ&version=1&custid=666600&op_branch_no=17&
        // branch_no=17&op_entrust_way=7&op_station=IP$192.168.1.1;MAC$00-0C-29-1A-B4-32;HDD$                    &
        // function_id=7411&fund_account=666600&password=ojCz+oMyy5hf/iTA$$&identity_type=&
        // fund_company=&fund_code=&query_mode=0&ram=0.3891886440105736
        public string fund_company { get{return "";}}//基金公司 空格，表示不限制
        public string fund_code { get { return ""; } }//基金代码 空格，表示不限制
        public string query_mode { get { return "0"; } }
    }

}
