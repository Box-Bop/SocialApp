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
    class CommentsAdapter : BaseAdapter<CommentsInfo>
    {
        private Activity _context;
        public string postText;
        //constructor
        public CommentsAdapter(Activity context)
        {
            _context = context;
        }
        List<CommentsInfo> items;
        Activity context;
        public CommentsAdapter(Activity context, List<CommentsInfo> item) : base()
        {
            this.context = context;
            this.items = item;

        }

        public override CommentsInfo this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.commentsLayout, null);
            view.FindViewById<TextView>(Resource.Id.ownerTextView).Text = items[position].PostName;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position].PostDate;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = items[position].PostText;
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
            return view;
        }

        private void Like_Click(object sender, EventArgs e)
        {
            bool likeOnce = false;
            var clickButton = (Button)sender;
            int position = (int)clickButton.Tag;
            if (likeOnce == false)
            {
                var text = clickButton.Text;
                clickButton.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) + 1);
                likeOnce = true;
            }
            else
            {
                var text = clickButton.Text;
                clickButton.Text = "👍: " + Convert.ToString(Convert.ToDouble(text.Substring(3)) - 1);
                likeOnce = false;
            }
        }
    }
}