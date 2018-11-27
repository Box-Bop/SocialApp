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
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var postsListView = FindViewById<ListView>(Resource.Id.listView1);
            var addPostEditText = FindViewById<EditText>(Resource.Id.textInputEditText1);
            var addPostButton = FindViewById<Button>(Resource.Id.postButton);

            var databaseService = new DatabaseService();

            databaseService.CreateDatabase();
            databaseService.CreateTableWithData();

            var posts = databaseService.GetAllPosts();
            var test = posts.ToList();
            postsListView.Adapter = new CustomAdapter(this, posts.ToList());

            //databaseService.DeleteAllPosts();

            addPostButton.Click += delegate
            {
                var postText = addPostEditText.Text;
                databaseService.AddPost(postText);

                posts = databaseService.GetAllPosts();
                postsListView.Adapter = new CustomAdapter(this, posts.ToList());

                addPostEditText.Text = "";
            };
        }

        //private void Comments_Click(object sender, EventArgs e)
        //{
        //    DataTransfer.Tranfer = post[e.Position].PostCommentsInfo;
        //    var comments = new Intent(this, typeof(CommentsActivity));
        //    StartActivity(comments);
        //}
    }
}