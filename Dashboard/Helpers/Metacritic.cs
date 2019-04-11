using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using ScrapySharp.Extensions;

using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Metacritic
    {
        public static MetacriticModel Search(string query)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage home = browser.NavigateToPage(new Uri("https://www.metacritic.com/search/game/" + query + "/results"));
            HtmlNode html = home.Html;

            List<MetacriticModel> models = new List<MetacriticModel>();

            // Get all results
            for (int i = 0; i < SearchResults(query); i++)
            {
                HtmlNode htmlResult = html.CssSelect("ul.search_results").CssSelect("li.result").ElementAt(i);
                models.Add(GetResultData(htmlResult));
            }
            
            // Check if a result matches exactly
            foreach (var model in models)
            {
                if (query.ToLower() == model.Title.ToLower())
                {
                    model.ExactMatch = true;
                    return model;
                }
            }

            // If not, return first result
            models.ElementAt(0).ExactMatch = false;
            return models.ElementAt(0);
        }

        public static int SearchResults(string query)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage home = browser.NavigateToPage(new Uri("https://www.metacritic.com/search/game/" + query + "/results"));
            HtmlNode html = home.Html;

            return html.CssSelect("ul.search_results").CssSelect("li.result").Count();
        }

        private static MetacriticModel GetResultData(HtmlNode html)
        {
            var pageURL = html
                .CssSelect("div.result_wrap")
                .CssSelect("div.basic_stats")
                .CssSelect("div.main_stats")
                .CssSelect("h3.product_title")
                .CssSelect("a")
                .ElementAt(0)
                .Attributes["href"]
                .Value;

            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage page = browser.NavigateToPage(new Uri("https://www.metacritic.com" + pageURL));
            HtmlNode pageContent = page.Html;

            string title = pageContent
                .CssSelect("div.product_title")
                .CssSelect("a.hover_none")
                .CssSelect("h1")
                .ElementAt(0)
                .InnerText;

            string publisher = pageContent
                .CssSelect("ul.summary_details")
                .CssSelect("li.publisher")
                .CssSelect("span.data")
                .CssSelect("a")
                .ElementAt(0)
                .InnerText;

            string releaseDate = pageContent
                .CssSelect("ul.summary_details")
                .CssSelect("li.release_data")
                .CssSelect("span.data")
                .ElementAt(0)
                .InnerText;

            string platform = pageContent
                .CssSelect("div.product_title")
                .CssSelect("span.platform")
                .CssSelect("a")
                .ElementAt(0)
                .InnerText;

            //string metascore = pageContent
            //    .CssSelect("div.module.product_data.product_data_summary")
            //    .CssSelect("div.module_wrap")
            //    .CssSelect("div.product_media.large_media")
            //    .CssSelect("div.summary_wrap")
            //    .CssSelect("div.section.product_scores")
            //    .CssSelect("div.details.main_details")
            //    .CssSelect("div.score_summary")
            //    .CssSelect("div.metascore_wrap")
            //    .CssSelect("a.metascore_anchor")
            //    .CssSelect("div.metascore_w.xlarge.game")
            //    .CssSelect("span")
            //    .ElementAt(0)
            //    .InnerText;

            string critics = pageContent
                .CssSelect("div.summary")
                .CssSelect("span.count")
                .CssSelect("a")
                .CssSelect("span")
                .ElementAt(0)
                .InnerText;

            //string summary = pageContent
            //    .CssSelect("span.blurb")
            //    .ElementAt(0)
            //    .InnerText;

            string developers = pageContent
                .CssSelect("ul.summary_details")
                .CssSelect("li.developer")
                .CssSelect("span.data")
                .ElementAt(0)
                .InnerText;

            string genre = pageContent
                .CssSelect("ul.summary_details")
                .CssSelect("li.product_genre")
                .CssSelect("span.data")
                .ElementAt(0)
                .InnerText;

            MetacriticModel model = new MetacriticModel
            {
                Title = title,
                Publisher = publisher,
                ReleaseDate = releaseDate,
                Platform = platform,
                //Metascore = metascore,
                Critics = critics,
                //Summary = summary,
                Developers = developers,
                Genre = genre
            };

            return model;
        }
    }
}
