using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Helpers
    {
        public static string Center(this string strText, int nWidth)
        {
            int nSpaces = (nWidth - strText.Length) / 2;
            string strRes = "";

            for (int i = 0; i < nSpaces; i++)
                strRes += ' ';
            
            return strRes + strText;
        }
        public static string Center(this string strText, int nWidth, out int nOffset)
        {
            nOffset = (nWidth - strText.Length) / 2;
            string strRes = "";

            for (int i = 0; i < nOffset; i++)
                strRes += ' ';
            strRes += strText;

            return strRes;
        }
        public static string FillChar(this string strText, char cChar, int nCount)
        {
            string strRes = "";
            for (int i = 0; i < nCount; i++)
                strRes += cChar;

            return strRes + strText;
        }
    }
}
