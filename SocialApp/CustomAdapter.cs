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

namespace SocialApp
{
    class CustomAdapter : BaseAdapter<PostInfo>
    {
        private Activity _context;
        //public bool likeOnce = false;
        //constructor
        public CustomAdapter(Activity context)
        {
            _context = context;
        }
        List<PostInfo> items;
        Activity context;
        public CustomAdapter(Activity context, List<PostInfo> items) : base()
        {
            this.context = context;
            this.items = items;

        }

        public override PostInfo this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.postLayout, null);
            view.FindViewById<TextView>(Resource.Id.ownerTextView).Text = items[position].PostName;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position].PostDate;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = items[position].PostText;
            view.FindViewById<Button>(Resource.Id.button1).Text = "Comments: " + items[position].PostCommentsAmount;
            view.FindViewById<Button>(Resource.Id.likeButton1).Text = "👍: " + Convert.ToString(items[position].PostLikes);
            var mydrw = (int)typeof(Resource.Drawable).GetField(items[position].PostProfilePic).GetValue(null);
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(mydrw);
            if (!String.IsNullOrEmpty(items[position].PostImage))
            {
                var postdraw = (int)typeof(Resource.Drawable).GetField(items[position].PostImage).GetValue(null);
                view.FindViewById<ImageView>(Resource.Id.imageView2).SetImageResource(postdraw);
            }
            else
            {
                view.FindViewById<ImageView>(Resource.Id.imageView2).Visibility = ViewStates.Invisible;
            }
            var like = view.FindViewById<Button>(Resource.Id.likeButton1);
            like.Tag = position;
            like.Click += Like_Click;
            //like.Click += (sender, e) =>
            //{
            //    if (likeOnce == false)
            //    {
            //        var text = like.Text;
            //        like.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) + 1);
            //        likeOnce = true;
            //    }
            //    else
            //    {
            //        var text = like.Text;
            //        like.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) - 1);
            //        likeOnce = false;
            //    }
            //};

            var commentButton = view.FindViewById<Button>(Resource.Id.button1);
            commentButton.Tag = position;
            commentButton.Click -= CommentButton_Click;
            commentButton.Click += CommentButton_Click;
            //{
            //    DataTransfer.Tranfer = items[position].PostCommentsInfo;
            //    context.StartActivity(typeof(CommentsActivity));
            //};
            return view;
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            var commentButton = (Button)sender;
            var position = (int)commentButton.Tag;
            DataTransfer.SelectedPostID = items[position].Id;
            context.StartActivity(typeof(CommentsActivity));
        }

        private void Like_Click(object sender, EventArgs e)
        {
            var clickButton = (Button)sender;
            int position = (int)clickButton.Tag;
            if (items[position].LikedOnce == false)
            {
                var text = clickButton.Text;
                clickButton.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) + 1);
                items[position].LikedOnce = true;
            }
            else
            {
                var text = clickButton.Text;
                clickButton.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) - 1);
                items[position].LikedOnce = false;
            }
        }
    }
}