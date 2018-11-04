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
    [Activity(Label = "CommentsActivity")]
    public class CommentsActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.commentsLayout);
            ListAdapter = new CommentsAdapter(this, DataTransfer.Tranfer);
        }
    }
}