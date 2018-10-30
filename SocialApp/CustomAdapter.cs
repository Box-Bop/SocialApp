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
    class CustomAdapter : BaseAdapter<PostInfo>
    {
        List<PostInfo> items;
        Activity context;
        public CustomAdapter(Activity context, List<PostInfo> item) : base()
        {
            this.context = context;
            this.items = item;

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
            view.FindViewById<Button>(Resource.Id.button1).Text = "Comments: " + items[position].PostComments;
            view.FindViewById<Button>(Resource.Id.likeButton1).Text = "👍: " + Convert.ToString(items[position].PostLikes);
            var like = view.FindViewById<Button>(Resource.Id.likeButton1);

            like.Click += (sender, e) =>
            {
                var text = like.Text;
                like.Text = "👍: " + Convert.ToString(Convert.ToInt16(text.Substring(3)) + 1);
            };
            //view.FindViewById<ImageView>(Resource.Id.imageView2);
            return view;
        }
    }
}