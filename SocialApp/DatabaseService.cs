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
        SQLiteConnection db2;
        //public List<PostInfo> post = new List<PostInfo>();
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase.db3");
            db = new SQLiteConnection(dbPath);
            db2 = new SQLiteConnection(dbPath);
            db.CreateTable<PostInfo>();
            db2.CreateTable<CommentsInfo>();
        }

        public void CreateTableWithData()
        {
            db.CreateTable<PostInfo>();
            db2.CreateTable<CommentsInfo>();
            if (db.Table<PostInfo>().Count() == 0)
            {
                var post = new PostInfo();
                var comment = new CommentsInfo();
                post.PostName = "Robert";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Can we hit 50 likes?";
                post.PostLikes = 49;
                post.PostCommentsAmount = 3;
                post.PostProfilePic = "okhand";
                post.PostImage = "longboy";

                db.Insert(post);

                comment.Id = post.Id;
                comment.PostName = "Jeff";
                comment.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                comment.PostText = "So close";
                comment.PostLikes = 3;
                comment.PostProfilePic = "bridge";
                comment.PostImage = "";

                db2.Insert(comment);

                comment.Id = post.Id;
                comment.PostName = "Tere";
                comment.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                comment.PostText = "very funny";
                comment.PostLikes = 0;
                comment.PostProfilePic = "okhand";
                comment.PostImage = "";

                db2.Insert(comment);

                post.PostName = "Jüri";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Lorem ipsum dolor sit amet, vestibulum lectus luctus amet. Sed class dui eu diam, commodo nec mi turpis. Sollicitudin pellentesque wisi diam ipsum ultricies, ante volutpat netus in vivamus vero turpis, purus auctor condimentum neque, pharetra lorem. Tristique massa ipsum";
                post.PostLikes = 1337;
                post.PostCommentsAmount = 439;
                post.PostProfilePic = "bread";
                post.PostImage = "";

                db.Insert(post);

                comment.Id = post.Id;
                comment.PostName = "Lorem Ipsum";
                comment.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                comment.PostText = "Your post is a lorem ipsum text";
                comment.PostLikes = 4;
                comment.PostProfilePic = "okhand";
                comment.PostImage = "longboy";

                db2.Insert(comment);

                post.PostName = "Memer";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "They don't think it do be like this sometimes, but it do lmao";
                post.PostLikes = 133;
                post.PostCommentsAmount = 1;
                post.PostProfilePic = "pic2";
                post.PostImage = "butitdo";

                db.Insert(post);

                comment.Id = post.Id;
                comment.PostName = "Lorem Ipsum";
                comment.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                comment.PostText = "hueh";
                comment.PostLikes = 4;
                comment.PostProfilePic = "bridge";
                comment.PostImage = "";

                db2.Insert(comment);

                post.PostName = "Virko";
                post.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                post.PostText = "Jeff";
                post.PostLikes = 68;
                post.PostCommentsAmount = 439;
                post.PostProfilePic = "bridge";
                post.PostImage = "";

                db.Insert(post);

                comment.Id = post.Id;
                comment.PostName = "Lebread James";
                comment.PostDate = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                comment.PostText = "Approved";
                comment.PostLikes = 4;
                comment.PostProfilePic = "okhand";
                comment.PostImage = "";

                db2.Insert(comment);

            }
        }

        public void AddPost(string postText)
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

        public void DeletePost(long id)
        {
            db.Delete<PostInfo>(id);
        }

        public TableQuery<PostInfo> GetAllPosts()
        {
            var table = db.Table<PostInfo>();
            return table;
        }

        public void DeleteAllPosts()
        {
            db.DropTable<PostInfo>();
            db.DropTable<CommentsInfo>();
            db2.DropTable<CommentsInfo>();
        }
    }
}