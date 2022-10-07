using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballSharp.DTO
{
     // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Contributor
    {
        public string name { get; set; }
    }

    public class Cut
    {
        public string aspectRatio { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string src { get; set; }
        public string at2x { get; set; }
        public string at3x { get; set; }
    }

    public class Editorial
    {
        public Preview preview { get; set; }
        public object articles { get; set; }
        public Recap recap { get; set; }
        public Wrap wrap { get; set; }
    }

    public class Epg
    {
        public string title { get; set; }
        public List<Item> items { get; set; }
    }

    public class EpgAlternate
    {
        public List<Item> items { get; set; }
        public string title { get; set; }
    }

    public class FeaturedMedia
    {
        public string id { get; set; }
    }

    public class GameNotes
    {
    }

    public class Highlights
    {
        public object scoreboard { get; set; }
        public object gameCenter { get; set; }
        public object milestone { get; set; }
        public Highlights highlights { get; set; }
        public Live live { get; set; }
        public ScoreboardPreview scoreboardPreview { get; set; }
        public List<Item> items { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string altText { get; set; }
        public string templateUrl { get; set; }
        public List<Cut> cuts { get; set; }
    }

    public class Item
    {
        public string callLetters { get; set; }
        public bool espnAuthRequired { get; set; }
        public bool tbsAuthRequired { get; set; }
        public string gameDate { get; set; }
        public string contentId { get; set; }
        public bool fs1AuthRequired { get; set; }
        public string mediaId { get; set; }
        public string mediaFeedType { get; set; }
        public bool mlbnAuthRequired { get; set; }
        public bool foxAuthRequired { get; set; }
        public string mediaFeedSubType { get; set; }
        public bool freeGame { get; set; }
        public int id { get; set; }
        public string mediaState { get; set; }
        public string renditionName { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public DateTime date { get; set; }
        public string headline { get; set; }
        public string seoTitle { get; set; }
        public string slug { get; set; }
        public string blurb { get; set; }
        public List<KeywordsAll> keywordsAll { get; set; }
        public List<KeywordsDisplay> keywordsDisplay { get; set; }
        public Image image { get; set; }
        public bool noIndex { get; set; }
        public string mediaPlaybackId { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string mediaPlaybackUrl { get; set; }
        public List<Playback> playbacks { get; set; }
        public string guid { get; set; }
    }

    public class KeywordsAll
    {
        public string value { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
    }

    public class KeywordsDisplay
    {
        public string type { get; set; }
        public string value { get; set; }
        public string displayName { get; set; }
    }

    public class Live
    {
        public List<object> items { get; set; }
    }

    public class Media
    {
        public string type { get; set; }
        public string state { get; set; }
        public DateTime date { get; set; }
        public string id { get; set; }
        public string headline { get; set; }
        public string seoTitle { get; set; }
        public string slug { get; set; }
        public string blurb { get; set; }
        public List<KeywordsAll> keywordsAll { get; set; }
        public List<object> keywordsDisplay { get; set; }
        public Image image { get; set; }
        public bool noIndex { get; set; }
        public string mediaPlaybackId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public string mediaPlaybackUrl { get; set; }
        public List<Playback> playbacks { get; set; }
        public List<Epg> epg { get; set; }
        public List<EpgAlternate> epgAlternate { get; set; }
        public object milestones { get; set; }
        public FeaturedMedia featuredMedia { get; set; }
        public bool freeGame { get; set; }
        public bool enhancedGame { get; set; }
    }

    public class Mlb
    {
        public string type { get; set; }
        public string state { get; set; }
        public DateTime date { get; set; }
        public string headline { get; set; }
        public string seoTitle { get; set; }
        public string slug { get; set; }
        public string blurb { get; set; }
        public List<KeywordsAll> keywordsAll { get; set; }
        public List<object> keywordsDisplay { get; set; }
        public Image image { get; set; }
        public string seoKeywords { get; set; }
        public string body { get; set; }
        public List<Contributor> contributors { get; set; }
        public Photo photo { get; set; }
        public string url { get; set; }
        public Media media { get; set; }
    }

    public class Photo
    {
        public string title { get; set; }
        public string altText { get; set; }
        public string templateUrl { get; set; }
        public List<Cut> cuts { get; set; }
    }

    public class Playback
    {
        public string name { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Preview
    {
    }

    public class Recap
    {
        public Mlb mlb { get; set; }
    }

    public class ContentRoot
    {
//        public string copyright { get; set; }
//        public string link { get; set; }
        public Editorial editorial { get; set; }
//        public Media media { get; set; }
//        public Highlights highlights { get; set; }
//        public Summary summary { get; set; }
//        public GameNotes gameNotes { get; set; }
    }

    public class ScoreboardPreview
    {
        public List<object> items { get; set; }
    }

    public class Summary
    {
        public bool hasPreviewArticle { get; set; }
        public bool hasRecapArticle { get; set; }
        public bool hasWrapArticle { get; set; }
        public bool hasHighlightsVideo { get; set; }
    }

    public class Wrap
    {
    }

}
