using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MyPost;

namespace MyGuestbook
{
    public class Guestbook
    {
        // Egenskap för att få åtkomst till posts
        public IReadOnlyList<Post> Posts => posts;

        // Lista för att lagra posts
        private List<Post> posts;

        // Konstruktor för att skapa en gästbok
        public Guestbook()
        {
            posts = new List<Post>();
        }

        // Metod för att lägga till post
        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        // Metod för att radera post
        public void RemovePost(Post post)
        {
            posts.Remove(post);
        }

        // Metod för att visa lista på alla posts
        public void ShowAllPosts()
        {
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"[{i}] Av: {posts[i].AuthorName}, Inlägg: {posts[i].Content}");
            }
        }

        public void SaveToFile(string fileName)
        {
            string json = JsonConvert.SerializeObject(Posts, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        // Deserialisera gästbokens inlägg från JSON-fil
        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                posts = JsonConvert.DeserializeObject<List<Post>>(json) ?? new List<Post>();
            }
        }
    }
}
