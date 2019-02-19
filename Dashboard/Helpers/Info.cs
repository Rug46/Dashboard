using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HtmlAgilityPack;
using ScrapySharp;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Core;
using ScrapySharp.Network;
using ScrapySharp.Exceptions;

using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Info
    {
        public static InfoModel QueryGameInfo(string platform, string game)
        {
            try
            {
                string platformD = platform
                .Replace(" ", "-")
                .Replace(";", "")
                .Replace("/", "")
                .Replace("?", "")
                .Replace(":", "")
                .Replace("@", "")
                .Replace("=", "")
                .Replace("&", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("#", "")
                .Replace("%", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace("|", "")
                .Replace("\\", "")
                .Replace("^", "")
                .Replace("~", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("`", "")
                .Replace(".", "")
                .ToLower();

                string gameD = game
                    .Replace(" ", "-")
                    .Replace(";", "")
                    .Replace("/", "")
                    .Replace("?", "")
                    .Replace(":", "")
                    .Replace("@", "")
                    .Replace("=", "")
                    .Replace("&", "")
                    .Replace("<", "")
                    .Replace(">", "")
                    .Replace("#", "")
                    .Replace("%", "")
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("|", "")
                    .Replace("\\", "")
                    .Replace("^", "")
                    .Replace("~", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("`", "")
                    .Replace(".", "")
                    .ToLower();

                string url = "https://www.metacritic.com/game/" + platformD + "/" + gameD;
                //string url = "https://www.metacritic.com/game/switch/super-smash-bros-ultimate";

                ScrapingBrowser browser = new ScrapingBrowser();
                WebPage page = browser.NavigateToPage(new Uri(url));

                var NodeTitle = page.Html
                    .CssSelect("div.product_title")
                    .CssSelect("a")
                    .CssSelect("h1")
                    .Single().InnerText;

                var NodePublisher = page.Html
                    .CssSelect("ul.summary_details")
                    .CssSelect("li.summary_detail.publisher")
                    .CssSelect("span.data")
                    .CssSelect("a")
                    .Single().InnerText;

                var NodeReleaseDate = page.Html
                    .CssSelect("ul.summary_details")
                    .CssSelect("li.summary_detail.release_data")
                    .CssSelect("span.data")
                    .Single().InnerText;

                var NodePlatform = page.Html
                    .CssSelect("div.product_title")
                    .CssSelect("span.platform")
                    .CssSelect("a")
                    .Single().InnerText;

                var NodeMetascore = page.Html
                    .CssSelect("div.metascore_wrap")
                    .CssSelect("a")
                    .CssSelect("div")
                    .CssSelect("span[itemprop=ratingValue]")
                    .Single().InnerText;

                var NodeCritics = page.Html
                    .CssSelect("div.summary")
                    .CssSelect("span.count")
                    .CssSelect("a")
                    .CssSelect("span")
                    .Single().InnerText;

                var NodeBoxArt = page.Html
                    .CssSelect("div.product_image.large_image")
                    //.CssSelect("img.product_image.large_image")
                    .ElementAt(0).InnerHtml;
                //.Single().InnerText;

                var NodeSummary = page.Html
                    .CssSelect("span.blurb.blurb_expanded")
                    .ElementAt(0).InnerText;

                var NodeUserScore = page.Html
                    .CssSelect("div.userscore_wrap")
                    .CssSelect("a.metascore_anchor")
                    .CssSelect("div.metascore_w.user.large.game")
                    .Single().InnerText;

                var NodeUsers = page.Html
                    .CssSelect("div.score_summary")
                    .CssSelect("div.userscore_wrap.feature_userscore")
                    .CssSelect("div.summary")
                    .CssSelect("span.count")
                    .CssSelect("a")
                    .Single().InnerText;

                var NodeDevelopers = page.Html
                    .CssSelect("ul.summary_details")
                    .CssSelect("li.summary_detail.developer")
                    .CssSelect("span.data")
                    .Single().InnerText;

                var NodeGenre1 = page.Html
                    .CssSelect("ul.summary_details")
                    .CssSelect("li.summary_detail.product_genre")
                    .CssSelect("span.data");

                var NodeGenre = new List<string>();

                foreach (var node in NodeGenre1)
                {
                    NodeGenre.Add(node.InnerText);
                }

                var NodePlayers = page.Html
                    .CssSelect("ul.summary_details")
                    .CssSelect("li.summary_detail.product_players")
                    .CssSelect("span.data")
                    .Single().InnerText;

                var NodeBoxArtSrc1 = NodeBoxArt.Substring(NodeBoxArt.IndexOf("src=\""))
                    .Replace("src=\"", "");

                var NodeBoxArtSrc = NodeBoxArtSrc1.Substring(0, NodeBoxArtSrc1.IndexOf("\""));

                InfoModel model = new InfoModel
                {
                    Title = NodeTitle,
                    Publisher = NodePublisher,
                    ReleaseDate = NodeReleaseDate,
                    Platform = NodePlatform,
                    Metascore = NodeMetascore,
                    Critics = NodeCritics,
                    BoxArt = NodeBoxArtSrc,
                    Summary = NodeSummary,
                    UserScore = NodeUserScore,
                    Users = NodeUsers,
                    Developers = NodeDevelopers,
                    Genre = NodeGenre,
                    Players = NodePlayers,
                    Error = null
                };

                return model;
            }
            catch
            {
                InfoModel model = new InfoModel
                {
                    Title = "",
                    Publisher = "",
                    ReleaseDate = "",
                    Platform = "",
                    Metascore = "",
                    Critics = "",
                    BoxArt = "",
                    Summary = "",
                    UserScore = "",
                    Users = "",
                    Developers = "",
                    Genre = new List<string>(),
                    Players = "",
                    Error = "Unable to find game"
                };

                return model;
            }
        }
    }
}
