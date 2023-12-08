using System;

namespace MyPost
{
    public class Post
    {
        // Namn på författaren + innehållet
        private string authorName;
        private string content;

        // Konstruktor för namn på författaren och innehåll
        public Post(string authorName, string content)
        {
            this.authorName = authorName;
            this.content = content;
        }

        // Egenskaper för att hämta och sätta värden för namn och innehåll
        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
