using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SGTubeMVC.Models;
using SGTubeMVC.Mongo;
using SGTubeMVC.Mongo.Models;
using SGTubeMVC.Youtube;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Google.Apis.YouTube.v3.Data;
using System;

namespace SGTubeMVC.Controllers
{
    public class DashboardController : Controller
    {
        private Context context;

        public DashboardController()
        {
            context = new Context();
        }

        public async Task<ActionResult> Index(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return RedirectToAction("Index", "Search");

            var dashboard = new DashboardViewModel
            {
                search = texto
            };

            dashboard.history = context.Posts.AsQueryable().ToList().OrderByDescending(x => x.data).Take(10);

            if (!string.IsNullOrEmpty(texto))
            {
                var api = new Search();
                var retApi = await api.YoutubeApi_Search(texto);
                var videos = new List<SearchResult>();
                var channels = new List<SearchResult>();
                var playlists = new List<SearchResult>();
                foreach (var result in retApi.Items)
                {
                    switch (result.Id.Kind)
                    {
                        case "youtube#video":
                            videos.Add(result);
                            break;
                        case "youtube#channel":
                            channels.Add(result);
                            break;
                        case "youtube#playlist":
                            playlists.Add(result);
                            break;
                        default:
                            break;
                    }
                }
                dashboard.videos = videos;
                dashboard.channels = channels;
                dashboard.playlists = playlists;
            }

            return View(dashboard);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Create(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return RedirectToAction("Index", "Search");

            var post = new Post
            {
                Title = texto,
                data = DateTime.Now
            };

            context.Posts.InsertOne(post);
            
            return RedirectToAction("Index", "Dashboard", new { texto });
        }
    }
}