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
using System.Runtime.CompilerServices;

namespace Stock.Trader.HuaTai
{

    public class Response
    {
        public string cssweb_code { get; set; }
        public string cssweb_msg { get; set; }
        public string cssweb_type { get; set; }
    }

    public class RespAccountInfo : Response
    {
        public string branch_no { get; set; }
        public string fund_account { get; set; }
        public List<AccountInfoItem> Item { get; set; }
        public string op_station { get; set; }
        public string trdpwd { get; set; }
        public string uid { get; set; }
    }

    public class AccountInfoItem
    {
        public string exchange_name { get; set; }
        public string exchange_type { get; set; }
        public string fund_account { get; set; }
        public int main_flag { get; set; }
        public string stock_account { get; set; }
    }

    public class GetStockPositionResp : Response
    {
        public class GetStockPositionRespItem
        {
            public float av_buy_price { get; set; }//买入均价

            public float av_income_balance { get; set; }//实现盈亏

            public float cost_price { get; set; }//成本价

            public int cssweb_test { get; set; }//

            public int current_amount { get; set; }//当前数量

            public int enable_amount { get; set; }//可用数量

            public string exchange_name { get; set; }//

            public int exchange_type { get; set; }//交易类别

            public int hand_flag { get; set; }//手标志

            public float income_balance { get; set; }//盈亏金额

            public float keep_cost_price { get; set; }//保本价

            public float last_price { get; set; }//最新价

            public float market_value { get; set; }//证券市值

            public string stock_account { get; set; }//证券账号

            public string stock_code { get; set; }//证券代码

            public string stock_name { get; set; }//证券名称
        }

        public List<GetStockPositionRespItem> Item { get; set; }
    }

    public class GetFundsResp : Response
    {
        // "{\"cssweb_code\":\"success\",\"cssweb_type\":\"GET_FUNDS\",
        // \"item\":[{\"money_type\":\"0\",\"money_name\":\"人民币\",\"current_balance\":\"0\",
        // \"enable_balance\":\"1.00\",\"fetch_balance\":\"0\",\"market_value\":\"66038.20\",
        // \"asset_balance\":\"66321.27\"},{\"cssweb_test\":\"0\"}]}"

        public class GetFundsRespItem
        {
            public int money_type { get; set; }
            public string money_name { get; set; }
            public float current_balance { get; set; }  // 资金余额
            public float enable_balance { get; set; }   // 可用金额
            public float fetch_balance { get; set; }    //可取金额
            public float market_value { get; set; }     // 股票市值
            public float asset_balance { get; set; }    // 总资产
        }

        public List<GetFundsRespItem> Item { get; set; }
    }

    public class FundGetJjszResp : Response
    {
        public class FundGetJjszRespItem {
        /*
        branch_no	N5	分支机构
        fund_account	C18	资金账户
        fund_company	C4	基金公司
        fund_code	C6	基金代码
        stock_account	C11	证券账号
        status	C1	状态
        begin_share	N16.2	基金期初份额
        current_share	N16.2	基金当前份额
        business_frozen_share	N16.2	基金交易冻结数量
        frozen_share	N16.2	基金冻结数量
        long_frozen_share	N16.2	长期冻结数量
        allot_date	N8	交易日期
        allotno	C24	申请编号
        exchange_name	C8	交易名称
        fund_name	C32	基金名称
        nav	N9.3	T-1日基金单位净值
        market_value	N16.2	证券市值
        charge_type	C1	前后收费类型
        enable_shares	N16.2	可用份额
        auto_buy	C1	自动再投资标志
        cost_price	N9.3	成本价
        income_balance	N16.2	盈亏金额
        begin_amount	N16.2	期初数量
        current_amount	N16.2	当前数量
        business_frozen_amount	N16.2	交易冻结数量
        frozen_amount	N16.2	冻结数量
        long_frozen_amount	N16.2	长期冻结数量
        enable_amount	N16.2	可用数量
        enable_redeem_share	N16.2	基金当日可赎回数量
        position_str	C32	定位串
        */  
        }

        public List<FundGetJjszRespItem> Item { get; set; }

    }


    /// <summary>
    /// 买股票response
    /// </summary>
    public class StockBuyResp : Response
    {
        public List<StockBuyRespItem> Item { get; set; }

        public class StockBuyRespItem
        {
            public int cssweb_test { get; set; }
            public int entrust_no { get; set; }
        }
    }

    /// <summary>
    /// 卖股票response
    /// </summary>
    public class StockSaleResp : Response
    {
        public List<StockSaleRespItem> Item { get; set; }

        public class StockSaleRespItem
        {
            public int cssweb_test { get; set; }
            public int entrust_no { get; set; }
        }
    }

    /// <summary>
    /// 获取可撤单列表response
    /// </summary>
   public class GetCancelListResp : Response {
       // {"cssweb_code":"success","cssweb_type":"GET_CANCEL_LIST",
       // "item":[{"stock_name":"Ҹȱ","entrust_time":"145933","entrust_bs":"1","bs_name":"²ȫ",
       // "entrust_amount":"62900.00","entrust_price":"1.007","business_amount":"38100.00",
       // "business_price":"1.007","stock_code":"150019","entrust_no":"36566","stock_account":"0103648609",
       // "exchange_type":"2","exchange_name":"ɮۚb,"entrust_status":"7","status_name":"ɢ,
       // "entrust_prop":"0","prop_name":"²´"},{"cssweb_test":"0"}]}
       public List<GetCancelListRespItem> Item { get; set; }
 
       public class GetCancelListRespItem
       {
           public string stock_name;//证券名称
           public string entrust_time;//委托时间
           public string entrust_bs;//买卖方向
           public string bs_name;//
           public string entrust_amount;//委托数量
           public string entrust_price;//委托价格
           public string business_amount;//成交数量
           public string business_price;//成交价格
           public string stock_code;//证券代码
           public string entrust_no;//委托编号
           public string stock_account;//证券账号
           public string exchange_type;//交易类别
           public string exchange_name;//
           public string entrust_status;//委托状态
           public string status_name;//
           public string entrust_prop;//委托属性
           public string prop_name;//
           public string cssweb_test;
        /*
        委托状态说明：
          值 说明     是否可撤
           0  未报     可以
           1  待报     不可以
           2  已报     可以
           3  已报待撤 不可以
           4  部成待撤 不可以
           5  部撤     不可以
           6  已撤     不可以
           7  部成     可以
           8  已成     不可以
           9  废单     不可以
           W  待确认   不可以
        */
       }
   }

    /// <summary>
    /// 股票撤单response
    /// </summary>
   public class StockCancelResp : Response
   {
       public List<CancelResultItem> Item
       {
           get;
           set;
       }

       public class CancelResultItem
       {
           public int cssweb_test { get; set; }
           public int entrust_no { get; set; }
       }
   }

    /// <summary>
    /// 今日成交response
    /// </summary>
   public class GetTodayTradeResponse : Response
   {
       // {"cssweb_code":"success","cssweb_type":"GET_TODAY_TRADE",
       // "item":[{"stock_name":"银华锐进","date":"20151019","bs_name":"²ȫ","business_amount":"10000.00",
       // "business_price":"1.007","business_balance":"10070.00","stock_code":"150019","entrust_no":"36566",
       // "serial_no":"37830","stock_account":"0103648609","exchange_type":"ɮۚb,"remark":"成交"}]}

       public class GetTodayTradeRespItem
       {
           public string stock_name;//证券名称
           public string date;//日期
           public string bs_name;//
           public int business_amount;//成交数量
           public float business_price;//成交价格
           public float business_balance;//成交金额
           public string stock_code;//证券代码
           public int entrust_no;//委托编号
           public int serial_no;//流水序号
           public string stock_account;//证券账号
           public string exchange_type;//交易类别
           public string remark;//
           //real_type 成交类别 0：‘买卖’2：‘撤单’
           //real_status 成交状态 0：‘成交’，2：‘废单’4：‘确认’
       }

       public List<GetTodayTradeRespItem> Item
       {
           get;
           set;
       }

   }
   public class GetTodayEntrustResp : Response
   {
        //{"cssweb_code":"success","cssweb_type":"GET_TODAY_ENTRUST",
        //"item":[{"stock_name":"֤ͨȯ","entrust_time":"102647","entrust_bs":"2",
        //"bs_name":"´","entrust_amount":"800.00","entrust_price":"15.430",
        //"business_amount":"800.00","business_price":"15.430","stock_code":"600837",
        //"entrust_no":"13859","stock_account":"A763438769","exchange_type":"1",
        //"exchange_name":"ɏb,"entrust_status":"8","status_name":"ґɢ,"entrust_prop":"0",
        //"prop_name":"²´"}]}

       public class GetTodayEntrustRespItem
       {
           public string stock_name;//证券名称
           public string entrust_time;//委托时间（query_mode送'2'时返回0）
           public string entrust_bs;//买卖方向
           public string bs_name;//
           public string entrust_amount;//委托数量
           public string entrust_price;//委托价格
           public string business_amount;//成交数量
           public string business_price;//成交价格
           public string stock_code;//证券代码
           public string entrust_no;//委托编号（query_mode送'2'时返回0）
           public string stock_account;//证券账号
           public string exchange_type;//交易类别
           public string exchange_name;//
           public string entrust_status;//委托状态（query_mode送'2'时返回' '）
           public string status_name;//
           public string entrust_prop;//委托属性（query_mode送'2'时返回' '）
           public string prop_name;//
       }


       public List<GetTodayEntrustRespItem> Item
       {
           get;
           set;
       }

   }

}
