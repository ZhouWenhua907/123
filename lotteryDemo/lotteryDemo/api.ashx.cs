using common;
using entity.mutli;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace lotteryDemo
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
          //  context.Response.Write("Hello World");

            Hashtable htRet = new Hashtable();
            htRet["ok"] = false;
            
            string action = context.Request["act"];

            switch (action)
            {
                case InfoAction.QueryLotNum:
                    htRet = GetLotteryNum(context);
                    break;
                case InfoAction.DoLottery:
                    //htRet = DoLottery(context);
                    break;
                case InfoAction.QueryLotResult:
                    //htRet = GetCoupon(context);
                    break;
                default:
                    htRet["msg"] = "无效的请求";
                    break;
            }

            string callback = (context.Request["callback"]).ToString();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            string sJson = jss.Serialize(htRet);
            if (callback != "")
            {
                sJson = callback + "(" + sJson + ")"; ;
            }
            context.Response.Write(sJson);

        }

        private Hashtable GetLotteryNum(HttpContext context)
        {
            Hashtable htRet = new Hashtable();
            Hashtable rowData = new Hashtable();

            try
            {
              
                string UserId = (context.Request["UserId"]).ToString();

                DBIndex dbm = new DBIndex();
                DataSet ds = dbm.GetLotteryNum(UserId);    //获取抽奖次数
                if (ds.Tables[0].Rows.Count == 0)
                {
                    htRet["ok"] = true;
                    htRet["cnt"] = 0;
                    htRet["msg"] = "无数据";
                }
                else
                {
                    ArrayList lst = new ArrayList();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Hashtable htItem = new Hashtable();

                        htItem["LotteryNum"] = (dr["lotteryNum"]).ToString();

                        lst.Add(htItem);
                    }
                    htRet["ok"] = true;
                    htRet["lst"] = lst;               
                }
            }
            catch(Exception e)
            {
                htRet["ok"] = false;
                htRet["msg"] = "获取轮番信息失败！" + e.Message;
            }

            return htRet;
        }

        public class InfoAction
        {
            public const string QueryLotNum = "lotterytNum";//抽奖次数查询
            public const string DoLottery = "lottery";//抽奖
            public const string QueryLotResult = "lotteryCoupon";//查询结果
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}