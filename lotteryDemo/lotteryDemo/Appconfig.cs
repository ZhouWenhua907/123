using common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lotteryDemo
{
    public class Appconfig : ApiController
    {
        private const string C_KEY_CONNECTSTRING = "dbconn";
        private const string C_KEY_DEBUG = "isDebug";
        private const string C_TRUE = "true";

        //Connect string 
        private static string m_strConnectString = "";
        public static string ConnectString
        {
            get { return m_strConnectString; }
            set { m_strConnectString = value; }
        }

        //DEbug
        private static bool m_bIsDebug = true;
        public static bool IsDeug
        {
            get { return m_bIsDebug; }
            set { m_bIsDebug = value; }
        }

        //Timeout£¨Ãë£©
        private static int m_nDBTimeout = 30; //to execute SQL within 30Ãë

        public static int DBTimeout
        {
            get { return m_nDBTimeout; }
            set { m_nDBTimeout = value; }
        }

        public static void Load()
        {
            string strValue = ""; //value

            //initialize

            strValue = ConfigurationManager.AppSettings[C_KEY_CONNECTSTRING];
            if (strValue != null)
                m_strConnectString = strValue;
            string strIsDebug = "";
            strIsDebug = ConfigurationManager.AppSettings[C_KEY_DEBUG];
            if (strIsDebug == C_TRUE)
                m_bIsDebug = true;
            else
                m_bIsDebug = false;

            strValue = ConfigurationManager.AppSettings["DBTimeout"];
            if (strValue != null)
                m_nDBTimeout = CConvert.ToInt16(strValue);


        }
        //public static void Load()
        //{
        //    string strValue = ""; //value

        //    //initialize

        //    strValue = ConfigurationManager.AppSettings[C_KEY_CONNECTSTRING];
        //    if (strValue != null)
        //        m_strConnectString = strValue;
        //    string strIsDebug = "";
        //    strIsDebug = ConfigurationManager.AppSettings[C_KEY_DEBUG];
        //    if (strIsDebug == C_TRUE)
        //        m_bIsDebug = true;
        //    else
        //        m_bIsDebug = false;


        //    //logÊä³öÂ·¾¶
        //    m_sLogPath = ConfigurationManager.AppSettings["LogPath"];
        //    m_sImagePath = ConfigurationManager.AppSettings["ImagePath"];

        //    strValue = ConfigurationManager.AppSettings["DBTimeout"];
        //    if (strValue != null)
        //        m_nDBTimeout = CConvert.ToInt16(strValue);


        //}




        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}