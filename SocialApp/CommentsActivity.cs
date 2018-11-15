using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SocialApp
{
    [Activity(Label = "CommentsActivity")]
    class CommentsActivity : AppCompatActivity
    {
        public string postText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.commentSection);
            var commentsList = FindViewById<ListView>(Resource.Id.list);
            commentsList.Adapter = new CommentsAdapter(this, DataTransfer.Tranfer);


            var comment = FindViewById<Button>(Resource.Id.postButton);
            comment.Click += Comment_Click;
            var postComment = FindViewById<EditText>(Resource.Id.textInputEditText1);
            postComment.TextChanged += PostText_TextChanged;

        }

        private void PostText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            postText = e.Text.ToString();
        }
        private void Comment_Click(object sender, EventArgs e)
        {
            DataTransfer.Tranfer.Add(
                    new CommentsInfo
                    {
                        PostName = "NewUser",
                        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                        PostText = postText,
                        PostLikes = 4,
                        PostProfilePic = "okhand",
                        PostImage = ""
                    }
                 );
            var commentsList = FindViewById<ListView>(Resource.Id.list);
            commentsList.Adapter = new CommentsAdapter(this, DataTransfer.Tranfer);
        }
    }
}