using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

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

            //List<string> names = new List<string>();
            //List<string> dates = new List<string>();
            //List<string> texts = new List<string>();

            //names.Add("Robert Tohver");
            //dates.Add(Convert.ToString(DateTime.Now));
            //texts.Add("test");

            //names.Add("Jüri test");
            //dates.Add(Convert.ToString(DateTime.Now));
            //texts.Add("test2");

            //PostInfo.PostNames = names.ToArray();
            //PostInfo.PostDates = dates.ToArray();
            //PostInfo.PostTexts = texts.ToArray();

            List<PostInfo> post = new List<PostInfo>();
            post.Add(
                new PostInfo
                {
                    PostName = "Robert",
                    PostDate = Convert.ToString(DateTime.Now),
                    PostText = "test"
                });

            ListAdapter = new CustomAdapter(this, post);
        }
    }
}