using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 个税计算
    /// </summary>
    public class PITTotal
    {
        /// <summary>
        /// 计算应缴个税
        /// </summary>
        /// <param name="yjse">应缴税额</param>
        /// <returns>返回应缴个税</returns>
        public static double PITSum(double yjse)
        {
            double yjgs = 0;
            string grade = Grade(yjse);
            switch (grade)
            { 
                case "A" :
                    yjgs=yjse*0.03;
                    break;
                case "B" :
                    yjgs=yjse*0.1-2520;
                    break;
                case "C":
                    yjgs = yjse * 0.2 - 16920;
                    break;
                case "D":
                    yjgs = yjse * 0.25 - 31920;
                    break;
                case "E":
                    yjgs = yjse * 0.3 - 52920;
                    break;
                case "F":
                    yjgs = yjse * 0.35 - 85920;
                    break;
                case "G":
                    yjgs = yjse * 0.45 - 181920;
                    break;
            }
            return yjgs;
        }
        /// <summary>
        /// 对个税不同的金额进行分级
        /// 0-36000 为 A，36000-144000为B等依次类推
        /// </summary>
        /// <param name="yjse">应缴税额</param>
        /// <returns>返回级别字符串</returns>
        public static string Grade(double yjse)
        {
            string gradeStr = "";
            if (yjse <= 36000)
            {
                gradeStr = "A";
            }
            if (yjse > 36000 & yjse <= 144000)
            {
                gradeStr = "B";
            }
            if (yjse > 144000 && yjse <= 300000)
            {
                gradeStr = "C";
            }
            if (yjse > 300000 && yjse <= 420000)
            {
                gradeStr = "D";
            }
            if (yjse > 420000 && yjse <= 660000)
            {
                gradeStr = "E";
            }
            if (yjse > 660000 && yjse <= 960000)
            {
                gradeStr = "F";
            }
            if (yjse > 960000)
            {
                gradeStr = "G";
            }

            return gradeStr;
        }
    }
}
