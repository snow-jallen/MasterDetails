namespace MasterDetails.Model
{
    public class MyVideoMetaData
    {
        public MyVideoMetaData(string videoId, string title, string description, int publishedAt, object channelId, int duration, string thumbnailUrl, object embedHtml, int viewCount, int likeCount, int dislikeCount)
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

        public string VideoId { get; }
        public string Title { get; }
        public string Description { get; }
        public int PublishedAt { get; }
        public object ChannelId { get; }
        public int Duration { get; }
        public string ThumbnailUrl { get; }
        public object EmbedHtml { get; }
        public int ViewCount { get; }
        public int LikeCount { get; }
        public int DislikeCount { get; }
    }
}