using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

//namespace QHC.LojaVirtual.Web.StringHelpers
//{
    public static class StringHelpers
    {
        public static string ToSeoUrl(this string url)
        {
            string encodeURl = (url?? "").ToLower();

            
            encodeURl = Regex.Replace(encodeURl, @"\&+", "and");
            encodeURl = encodeURl.Replace("'", "");
            encodeURl = Regex.Replace(encodeURl, @"[^a-z0-9]", "-");
            encodeURl = Regex.Replace(encodeURl, @"-+", "-");
            encodeURl = encodeURl.Trim('-');
            
            return encodeURl;
        }
    }
//}