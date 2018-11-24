using System;
using System.Collections.Generic;
using System.IO;
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
    class DatabaseService
    {
        SQLiteConnection db;
        //public List<PostInfo> post = new List<PostInfo>();
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<PostInfo>();
        }

        public void CreateTableWithData()
        {
            db.CreateTable<PostInfo>();
            if (db.Table<PostInfo>().Count() == 0)
            {
                var post = new PostInfo();
                post.PostName = "Robert";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Can we hit 50 likes?";
                post.PostLikes = 49;
                post.PostCommentsAmount = 3;
                post.PostProfilePic = "okhand";
                post.PostImage = "longboy";
                //post.PostCommentsInfo = new List<CommentsInfo>
                //{
                //    new CommentsInfo
                //    {
                //        PostName = "Jeff",
                //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                //        PostText = "So close",
                //        PostLikes = 3,
                //        PostProfilePic = "bridge",
                //        PostImage = ""
                //    },
                //    new CommentsInfo
                //    {
                //        PostName = "Tere",
                //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                //        PostText = "very funny",
                //        PostLikes = 0,
                //        PostProfilePic = "okhand",
                //        PostImage = ""
                //    }
                //};
                db.Insert(post);

                post.PostName = "Jüri";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Lorem ipsum dolor sit amet, vestibulum lectus luctus amet. Sed class dui eu diam, commodo nec mi turpis. Sollicitudin pellentesque wisi diam ipsum ultricies, ante volutpat netus in vivamus vero turpis, purus auctor condimentum neque, pharetra lorem. Tristique massa ipsum";
                post.PostLikes = 1337;
                post.PostCommentsAmount = 439;
                post.PostProfilePic = "bread";
                post.PostImage = "";
                //post.PostCommentsInfo = new List<CommentsInfo>
                //{
                //    new CommentsInfo
                //    {
                //        PostName = "Lorem Ipsum",
                //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                //        PostText = "Your post is a lorem ipsum text",
                //        PostLikes = 4,
                //        PostProfilePic = "okhand",
                //        PostImage = "longboy"
                //    }
                //};
                db.Insert(post);

                post.PostName = "Memer";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "They don't think it do be like this sometimes, but it do lmao";
                post.PostLikes = 133;
                post.PostCommentsAmount = 1;
                post.PostProfilePic = "pic2";
                post.PostImage = "butitdo";
                //post.PostCommentsInfo = new List<CommentsInfo>
                //{
                //    new CommentsInfo
                //    {
                //        PostName = "Lorem Ipsum",
                //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                //        PostText = "hueh",
                //        PostLikes = 4,
                //        PostProfilePic = "bridge",
                //        PostImage = ""
                //    }
                //};
                db.Insert(post);

                post.PostName = "Virko";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Jeff";
                post.PostLikes = 68;
                post.PostCommentsAmount = 439;
                post.PostProfilePic = "bridge";
                post.PostImage = "";
                //post.PostCommentsInfo = new List<CommentsInfo>
                //    {
                //    new CommentsInfo
                //    {
                //        PostName = "Lebread James",
                //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
                //        PostText = "Approved",
                //        PostLikes = 4,
                //        PostProfilePic = "okhand",
                //        PostImage = ""
                //    }
                //};
                db.Insert(post);
            }
        }

        public void AddStock(string postText)
        {
            var newPost = new PostInfo();
            newPost.PostName = "NewUser";
            newPost.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            newPost.PostText = postText;
            newPost.PostLikes = 35;
            newPost.PostCommentsAmount = 1;
            newPost.PostProfilePic = "bridge";
            newPost.PostImage = "";
            //newPost.PostCommentsInfo = new List<CommentsInfo>
            //    {
            //    new CommentsInfo
            //    {
            //        PostName = "Lebread James",
            //        PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
            //        PostText = "Approved",
            //        PostLikes = 4,
            //        PostProfilePic = "okhand",
            //        PostImage = ""
            //    }
            //};
            db.Insert(newPost);
        }

        public void DeleteStock(long id)
        {
            db.Delete<PostInfo>(id);
        }

        public TableQuery<PostInfo> GetAllStocks()
        {
            var table = db.Table<PostInfo>();
            return table;
        }
    }
}