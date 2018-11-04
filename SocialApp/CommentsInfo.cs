using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SocialApp
{
    public class CommentsInfo
    {
        public string PostName { get; set; } = " ";
        public string PostDate { get; set; } = " ";
        public string PostText { get; set; } = " ";
        public int PostLikes { get; set; }
        public string PostProfilePic { get; set; } = " ";
        public string PostImage { get; set; } = " ";
    }
}