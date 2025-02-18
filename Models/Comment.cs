﻿namespace BlogApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; } 

        public int PostId { get; set; } 

        public User user { get; set; } 

        public Post post { get; set; }

        public ICollection<CommentLikes> commentLikes { get; set; } = [];

        public ICollection<Replies> replies { get; set; } = [];


    }
}
