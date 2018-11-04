using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;

namespace SocialApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            List<PostInfo> post = new List<PostInfo>();
            post.Add(
                    new PostInfo
                    {
                        PostName = "Robert",
                        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                        PostText = "Can we hit 50 likes?",
                        PostLikes = 49,
                        PostCommentsAmount = 3,
                        PostProfilePic = "okhand",
                        PostImage = "longboy",
                        PostCommentsInfo = new List<CommentsInfo>
                        {
                        new CommentsInfo
                        {
                            PostName = "Jeff",
                            PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                            PostText = "So close",
                            PostLikes = 3,
                            PostProfilePic = "bridge",
                            PostImage = ""
                        },
                        new CommentsInfo
                        {
                            PostName = "Tere",
                            PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                            PostText = "very funny",
                            PostLikes = 0,
                            PostProfilePic = "okhand",
                            PostImage = ""
                        }
                        }
                    });
            post.Add(
                new PostInfo
                {
                    PostName = "Jüri",
                    PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                    PostText = "Lorem ipsum dolor sit amet, vestibulum lectus luctus amet. Sed class dui eu diam, commodo nec mi turpis. Sollicitudin pellentesque wisi diam ipsum ultricies, ante volutpat netus in vivamus vero turpis, purus auctor condimentum neque, pharetra lorem. Tristique massa ipsum",
                    PostLikes = 1337,
                    PostCommentsAmount = 439,
                    PostProfilePic = "bridge",
                    PostImage = "",
                    PostCommentsInfo = new List<CommentsInfo>
                        {
                        new CommentsInfo
                        {
                            PostName = "Lorem Ipsum",
                            PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                            PostText = "Your post is a lorem ipsum text",
                            PostLikes = 4,
                            PostProfilePic = "okhand",
                            PostImage = ""
                        }
                    }
                });
            var comments = FindViewById<Button>(Resource.Id.button1);
            //comments.Click += Comments_Click;
            ListAdapter = new CustomAdapter(this, post);
        }

        //private void Comments_Click(object sender, EventArgs e)
        //{
        //    DataTransfer.Tranfer = post[e.Position].PostCommentsInfo;
        //    var comments = new Intent(this, typeof(CommentsActivity));
        //    StartActivity(comments);
        //}
    }
}