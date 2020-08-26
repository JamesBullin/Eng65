using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFGetStarted
{
	class Program
	{
		static void Main(string[] args)
		{

			using (var db = new BloggingContext())
			{
				//Create

				//var newUser = new User { Name = "Nish Mandal" };
				//var newblog = new Blog { Url = "www.spartaglobal.com", User = newUser };
				//var newPost = new Post { Blog = newblog, Content = "Heya Engineering-65" };

				//db.Users.Add(newUser);
				//db.Blogs.Add(newblog);
				//db.Posts.Add(newPost);

				//Create 2

				//var selectedUser = db.Users.Where(u => u.Name == "Nish Mandal").FirstOrDefault();
				//var newblog2 = new Blog { Url = "www.youtube.com", User = selectedUser };
				//var newPost2 = new Post { Blog = newblog2, Title = "Too much", Content = "Too many vidz, imo." };


				//db.Blogs.Add(newblog2);
				//db.Posts.Add(newPost2);

				//Create 3
				//var newUser = new User { Name = "Terence Babarinsa" };
				//var newblog = new Blog { Url = "www.reddit.com", User = newUser };
				//var newPost = new Post { Blog = newblog, Title = "Hey", Content = "Heya Engineering-65" };

				//db.Users.Add(newUser);
				//db.Blogs.Add(newblog);
				//db.Posts.Add(newPost);

				var query1 = db.Users.Include(b => b.Blogs).Select( c => new
				{
					Name = c.Name,
					Url = c.Blogs
				}
				);

				foreach (var item in query1)
				{
					Console.WriteLine(item);
				}
				//db.SaveChanges();
			}

		}
	}
}
