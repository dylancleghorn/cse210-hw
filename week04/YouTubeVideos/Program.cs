using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Bob's Cool Video", "Robert", 120);
        Video video2 = new Video("Jon's First Video", "Jonathan", 60);
        Video video3 = new Video("Ingrid's Video", "Ingrid", 240);
        Video video4 = new Video("Dylan's Video - the BEST!", "Dylan", 1200);

        video1.AddComment("Joe", "Nice video!");
        video1.AddComment("Sarah", "I really enjoyed this one.");
        video1.AddComment("Mark", "Short and sweet, great job!");
        video1.AddComment("Lena", "The editing was really smooth.");

        video2.AddComment("Emily", "Great first video!");
        video2.AddComment("Tom", "Keep making more content!");
        video2.AddComment("Ava", "This was fun to watch.");
        video2.AddComment("Ben", "Nice intro, very clear!");

        video3.AddComment("Carla", "Beautiful work, Ingrid!");
        video3.AddComment("Victor", "The music choice was perfect.");
        video3.AddComment("Nina", "I learned something new today.");
        video3.AddComment("Lucas", "Well done, looking forward to more.");

        video4.AddComment("Mia", "Wow, that was a long one but totally worth it!");
        video4.AddComment("Ethan", "The detail in this video is amazing.");
        video4.AddComment("Sophie", "You really put effort into this.");
        video4.AddComment("Ryan", "Hands down, your best video yet!");

        List<Video> _videos = new List<Video>();
        _videos.Add(video1);
        _videos.Add(video2);
        _videos.Add(video3);
        _videos.Add(video4);

        foreach (Video video in _videos)
        {
            video.DisplayVideoInfo();
        }
    }
}