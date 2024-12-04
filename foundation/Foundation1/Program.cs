using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Understanding AI", "Alice", 300);
        Video video2 = new Video("Top 10 Coding Tips", "Bob", 450);
        Video video3 = new Video("Exploring Space", "Charlie", 600);

        // Add comments to videos
        video1.AddComment(new Comment("Dave", "Great video!"));
        video1.AddComment(new Comment("Eva", "Very informative."));
        video1.AddComment(new Comment("Frank", "Loved it!"));

        video2.AddComment(new Comment("Grace", "Super helpful!"));
        video2.AddComment(new Comment("Henry", "Nice tips."));
        video2.AddComment(new Comment("Ivy", "Thanks for sharing."));

        video3.AddComment(new Comment("Jack", "Amazing content."));
        video3.AddComment(new Comment("Kelly", "Fascinating topic."));
        video3.AddComment(new Comment("Leo", "Well explained."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display videos and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}