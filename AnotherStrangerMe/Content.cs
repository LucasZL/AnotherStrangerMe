using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnotherStrangerMe
{
    static class Content
    {
        public static void TextWriter(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Thread.Sleep(200);
            }
        }
    }
}
