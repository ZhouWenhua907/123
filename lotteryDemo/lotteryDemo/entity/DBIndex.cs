using common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace entity.mutli
{
    public class DBIndex : BaseEntity
    {
        /// <summary>
        /// 获取滚动图片信息
        /// </summary>
        /// <param name="sType">类型</param>
        /// <returns></returns>
        /// 
        public DataSet GetLotteryNum(string UserId)
        {
            DataSet dst = null;
            StringBuilder sb = new StringBuilder();
            m_dbo.RemoveAllParameters();
            
            sb.Append(" select lotteryNum ");
            sb.Append(" from td_user");
            sb.Append(" where 1=1");
            sb.Append(" and uid = ?UserId");
            m_dbo.AddParameter("UserId", UserId);

            try
            {
                dst = m_dbo.Select(CConvert.ToString(sb));
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                try
                {
                    this.m_dbo.Close();
                }
                catch { }
            }
            return dst;
        }

    }  
}
