namespace MasterDetails.Model
{
    public class Video
    {
        public Video(string videoId, string title, string description, int publishedAt, object channelId, int duration, string thumbnailUrl, object embedHtml, int viewCount, int likeCount, int dislikeCount)
        {
            VideoId = videoId;
            Title = title;
            Description = description;
            PublishedAt = publishedAt;
            ChannelId = channelId;
            Duration = duration;
            ThumbnailUrl = thumbnailUrl;
            EmbedHtml = embedHtml;
            ViewCount = viewCount;
            LikeCount = likeCount;
            DislikeCount = dislikeCount;
        }

        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedAt { get; set; }
        public object ChannelId { get; set; }
        public int Duration { get; set; }
        public string ThumbnailUrl { get; set; }
        public object EmbedHtml { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}