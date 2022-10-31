// See https://aka.ms/new-console-template for more information
using EFStart.Models;

Console.WriteLine("Hello, World!");

using (var db=new BloggingContext())
{
    //add
    //Console.WriteLine("Insert New Blog");
   // db.Add(new Blog { Url = "https://google.com",
    //CraetedDate=DateTime.Now});
   // db.SaveChanges();


    //read
    Console.WriteLine("Quering For Blog");
    var blog = db.Blogs.Find(2);
    Console.WriteLine(blog.Url);
    db.SaveChanges();

    //update
    Console.WriteLine("Update Blog");
    blog.Url = "blog2.com";
    blog.CraetedDate = DateTime.Now;
    blog.Posts.Add(
        new Post
        {
            Title = "post1",
            Content="content1",
            BlogId=1
        });
    Console.WriteLine(blog.Url);
    db.SaveChanges();

    //Delete
    Console.WriteLine("Delete Blog");
    db.Remove(db.Blogs.Find(11));
    db.SaveChanges();



}
