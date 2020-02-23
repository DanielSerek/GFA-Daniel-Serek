using System;
using System.Collections.Generic;
using System.Text;

namespace PostIt
{
    class PostIt
    {
        public string BackgroundColor { get; set; }
        public string Text { get; set; }
        public string TextColor { get; set; }

        PostIt(string backgroundColor, string text, string textcolor)
        {
            BackgroundColor = backgroundColor;

            // if (backroundcolor == "orange") Textcolor = "black";
            // if (backgroundcolor == "") Backgroundcolor = "white";
            // else                       Backgroundcolor = backgroundcolor;

            Text = text;
            TextColor = textcolor;
        }


        //PostIt(string text)
        //    : this (.., ..., ...) // using a previous constructor with different values
        //{

        //}

        PostIt Idea1 = new PostIt("orange", "Idea1", "blue");
        PostIt Awesome = new PostIt("pink", "Awesome", "black");
        PostIt Superb = new PostIt("yellow", "Superb", "green");
        
    }

}
