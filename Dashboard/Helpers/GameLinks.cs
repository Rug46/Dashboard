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
    public class GameLinks
    {
        public static string GetMetacritic(string query)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage home = browser.NavigateToPage(new Uri("https://www.metacritic.com/search/game/" + query + "/results"));
            HtmlNode html = home.Html;

            List<string> models = new List<string>();

            // Get all results
            for (int i = 0; i < SearchResults(query); i++)
            {
                string htmlResult = html
                    .CssSelect("ul.search_results")
                    .CssSelect("li.result")
                    .ElementAt(i)
                    .CssSelect("div.result_wrap")
                    .CssSelect("div.basic_stats")
                    .CssSelect("div.main_stats")
                    .CssSelect("h3.product_title")
                    .CssSelect("a")
                    .ElementAt(0)
                    .Attributes["href"]
                    .Value;

                models.Add("https://www.metacritic.com" + htmlResult);
            }
            
            // Check if a result matches exactly
            foreach (var model in models)
            {
                if (query.ToLower() == model.ToLower())
                {
                    return model;
                }
            }

            // If not, return first result
            return models.ElementAt(0);
        }

        public static int SearchResults(string query)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage home = browser.NavigateToPage(new Uri("https://www.metacritic.com/search/game/" + query + "/results"));
            HtmlNode html = home.Html;

            return html.CssSelect("ul.search_results").CssSelect("li.result").Count();
        }
    }
}
