﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace SocialApp
{
    public class PostInfo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public long Id { get; set; }
        
        public string PostName { get; set; } = " ";
        public string PostDate { get; set; } = " ";
        public string PostText { get; set; } = " ";
        public double PostLikes { get; set; }
        public int PostCommentsAmount { get; set; }
        public string PostProfilePic { get; set; } = " ";
        public string PostImage { get; set; } = "";
        public bool LikedOnce { get; set; } = false;
    }
}