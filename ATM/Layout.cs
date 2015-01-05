using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnotherStrangerMe
{
    class Layout
    {
        StreamReader intro = new StreamReader("intro.txt");
        StreamReader layout = new StreamReader("layout.txt");

        public void DrawIntro()
        {
            string line = intro.ReadToEnd();
            Console.WriteLine(line);
        }

        public void DrawLayout()
        {
            string draw = layout.ReadToEnd();
            Console.WriteLine(draw);
        }
    }
}
