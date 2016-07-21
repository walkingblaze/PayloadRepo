using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Payload.Controllers;
using Payload.Models;

namespace PayloadTestProject
{
    [TestClass]
    public class FilterShowsServiceTest
    {
        private static string _validRequestJson;
        private static string _validResponseJson;

        [TestMethod]
        public void FilterTest()
        {
            PayloadsController controller = new PayloadsController();

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:55016/api/Payloads")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "",
                defaults: new
                {
                    controller = "Payloads",
                    action = "FilterShows"
                }
           );


            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "Payloads" } });

            PayloadViewModel payload = JsonConvert.DeserializeObject<PayloadViewModel>(GetValidRequestJSON());
            HttpResponseMessage actionResult = controller.FilterShows(payload);
            Assert.IsTrue(actionResult.StatusCode == HttpStatusCode.OK);

            ResponseViewModel requiredResponse = JsonConvert.DeserializeObject<ResponseViewModel>(GetValidResponseJSON());
            ResponseViewModel contentValue;
            Assert.IsTrue(actionResult.TryGetContentValue(out contentValue));
            Assert.IsTrue(contentValue.Response.Count == requiredResponse.Response.Count);
        }

        private string GetValidRequestJSON()
        {
            if(!string.IsNullOrEmpty(_validRequestJson)) return _validRequestJson;

            _validRequestJson = "\n{\n    \"payload\": [\n        {\n            \"country\": \"UK\"" +
                   ",\n            \"description\": \"What's life like when you have enough children to field your own football team?\"" +
                   ",\n            \"drm\": true,\n            \"episodeCount\": 3,\n            \"genre\": \"Reality\"" +
                   ",\n            \"image\": {\n                \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg\"\n            }" +
                   ",\n            \"language\": \"English\",\n            \"nextEpisode\": null,\n            \"primaryColour\": \"#ff7800\"" +
                   ",\n            \"seasons\": [\n                {\n                    \"slug\": \"show/16kidsandcounting/season/1\"\n                }\n            ]" +
                   ",\n            \"slug\": \"show/16kidsandcounting\",\n            \"title\": \"16 Kids and Counting\",\n            \"tvChannel\": \"GEM\"\n        }" +
                   ",\n        {\n            \"slug\": \"show/seapatrol\",\n            \"title\": \"Sea Patrol\",\n            \"tvChannel\": \"Channel 9\"\n        }" +
                   ",\n        {\n            \"country\": \" USA\",\n            \"description\": \"The Taste puts 16 culinary competitors in the kitchen, where four of the World's most notable culinary masters" +
                   " of the food world judges their creations based on a blind taste. Join judges Anthony Bourdain, Nigella Lawson, Ludovic Lefebvre " +
                   "and Brian Malarkey in this pressure-packed contest where a single spoonful can catapult a contender to the top or send them packing.\"" +
                   ",\n            \"drm\": true,\n            \"episodeCount\": 2,\n            \"genre\": \"Reality\",\n            \"image\": {\n      " +
                   "          \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/TheTaste1280.jpg\"\n            },\n            \"language\": \"English\"" +
                   ",\n            \"nextEpisode\": {\n                \"channel\": null,\n                \"channelLogo\": \"http://mybeautifulcatchupservice.com/img/player/logo_go.gif\"" +
                   ",\n                \"date\": null,\n                \"html\": \"<br><span class=\\\"visit\\\">Visit the Official Website</span></span>\"" +
                   ",\n                \"url\": \"http://go.ninemsn.com.au/\"\n            },\n            \"primaryColour\": \"#df0000\"" +
                   ",\n            \"seasons\": [\n                {\n                    \"slug\": \"show/thetaste/season/1\"\n       " +
                   "         }\n            ],\n            \"slug\": \"show/thetaste\",\n            \"title\": \"The Taste\",\n            \"tvChannel\": \"GEM\"\n        }" +
                   ",\n        {\n            \"country\": \"UK\",\n            \"description\": \"The series follows the adventures of International Rescue" +
                   ", an organisation created to help those in grave danger using technically advanced equipment and machinery. The series focuses on the head of the organisation," +
                   " ex-astronaut Jeff Tracy, and his five sons who piloted the \\\"Thunderbird\\\" machines.\",\n            \"drm\": true,\n            \"episodeCount\": 24,\n   " +
                   "         \"genre\": \"Action\",\n            \"image\": {\n                \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/Thunderbirds_1280.jpg\"\n      " +
                   "      },\n            \"language\": \"English\",\n            \"nextEpisode\": null,\n            \"primaryColour\": \"#0084da\",\n          " +
                   "  \"seasons\": [\n                {\n                    \"slug\": \"show/thunderbirds/season/1\"\n                },\n                {\n     " +
                   "               \"slug\": \"show/thunderbirds/season/3\"\n                },\n                {\n                    \"slug\": \"show/thunderbirds/season/4\"\n   " +
                   "             },\n                {\n                    \"slug\": \"show/thunderbirds/season/5\"\n                },\n                {\n           " +
                   "         \"slug\": \"show/thunderbirds/season/6\"\n                },\n                {\n                    \"slug\": \"show/thunderbirds/season/8\"\n  " +
                   "              }\n            ],\n            \"slug\": \"show/thunderbirds\",\n            \"title\": \"Thunderbirds\",\n         " +
                   "   \"tvChannel\": \"Channel 9\"\n        },\n        {\n            \"country\": \"USA\",\n            \"description\": \"A sleepy little village" +
                   ", Crystal Cove boasts a long history of ghost sightings, poltergeists, demon possessions, phantoms and other paranormal occurrences. The renowned " +
                   "sleuthing team of Fred, Daphne, Velma, Shaggy and Scooby-Doo prove all of this simply isn't real, and along the way, uncover a larger, season-long mystery " +
                   "that will change everything.\",\n            \"drm\": true,\n            \"episodeCount\": 4,\n            \"genre\": \"Kids\",\n       " +
                   "     \"image\": {\n                \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/ScoobyDoo1280.jpg\"\n            }" +
                   ",\n            \"language\": \"English\",\n            \"nextEpisode\": null,\n            \"primaryColour\": \"#1b9e00\",\n         " +
                   "   \"seasons\": [\n                {\n                    \"slug\": \"show/scoobydoomysteryincorporated/season/1\"\n                }\n      " +
                   "      ],\n            \"slug\": \"show/scoobydoomysteryincorporated\",\n            \"title\": \"Scooby-Doo! Mystery Incorporated\",\n         " +
                   "   \"tvChannel\": \"GO!\"\n        },\n        {\n            \"country\": \"USA\",\n            \"description\": \"Toy Hunter follows toy" +
                   " and collectibles expert and dealer Jordan Hembrough as he scours the U.S. for hidden treasures to sell to buyers around the world. In each " +
                   "episode, he travels from city to city, strategically manoeuvring around reluctant sellers, abating budgets, and avoiding unforeseen roadblocks.\"" +
                   ",\n            \"drm\": true,\n            \"episodeCount\": 2,\n            \"genre\": \"Reality\",\n            \"image\": {\n              " +
                   "  \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/ToyHunter1280.jpg\"\n            },\n            \"language\": \"English\",\n   " +
                   "         \"nextEpisode\": null,\n            \"primaryColour\": \"#0084da\",\n            \"seasons\": [\n                {\n                 " +
                   "   \"slug\": \"show/toyhunter/season/1\"\n                }\n            ],\n            \"slug\": \"show/toyhunter\",\n      " +
                   "      \"title\": \"Toy Hunter\",\n            \"tvChannel\": \"GO!\"\n        },\n        {\n            \"country\": \"AUS\",\n        " +
                   "    \"description\": \"A series of documentary specials featuring some of the world's most frightening moments, greatest daredevils and craziest weddings.\"" +
                   ",\n            \"drm\": true,\n            \"episodeCount\": 1,\n            \"genre\": \"Documentary\",\n            \"image\": {\n  " +
                   "              \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/Worlds1280.jpg\"\n            },\n            \"language\": \"English\",\n " +
                   "           \"nextEpisode\": null,\n            \"primaryColour\": \"#ff7800\",\n            \"seasons\": [\n                {\n         " +
                   "           \"slug\": \"show/worlds/season/1\"\n                }\n            ],\n            \"slug\": \"show/worlds\",\n         " +
                   "   \"title\": \"World's...\",\n            \"tvChannel\": \"Channel 9\"\n        },\n        {\n            \"country\": \"USA\",\n         " +
                   "   \"description\": \"Another year of bachelorhood brought many new adventures for roommates Walden Schmidt and Alan Harper. After his girlfriend turned down his marriage proposal" +
                   ", Walden was thrown back into the dating world in a serious way. The guys may have thought things were going to slow down once" +
                   " Jake got transferred to Japan, but they're about to be proven wrong when a niece of Alan's, who shares more than a few characteristics with her father" +
                   ", shows up at the beach house.\",\n            \"drm\": true,\n            \"episodeCount\": 0,\n            \"genre\": \"Comedy\",\n     " +
                   "       \"image\": {\n                \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/TwoandahHalfMen_V2.jpg\"\n       " +
                   "     },\n            \"language\": \"English\",\n            \"nextEpisode\": {\n                \"channel\": null,\n              " +
                   "  \"channelLogo\": \"http://mybeautifulcatchupservice.com/img/player/Ch9_new_logo.gif\",\n                \"date\": null,\n          " +
                   "      \"html\": \"Next episode airs: <span> 10:00pm Monday on<br><span class=\\\"visit\\\">Visit the Official Website</span></span>\",\n          " +
                   "      \"url\": \"http://channelnine.ninemsn.com.au/twoandahalfmen/\"\n            },\n            \"primaryColour\": \"#ff7800\",\n      " +
                   "      \"seasons\": null,\n            \"slug\": \"show/twoandahalfmen\",\n            \"title\": \"Two and a Half Men\",\n      " +
                   "      \"tvChannel\": \"Channel 9\"\n        },\n        {\n            \"country\": \"USA\",\n            \"description\": \"Simmering with " +
                   "supernatural elements and featuring familiar and fan-favourite characters from the immensely popular drama The Vampire Diaries, it's The Originals. This" +
                   " sexy new series centres on the Original vampire family and the dangerous vampire/werewolf hybrid, Klaus, who returns to the magical melting pot that is the French " +
                   "Quarter of New Orleans, a town he helped build centuries ago.\",\n            \"drm\": true,\n            \"episodeCount\": 1" +
                   ",\n            \"genre\": \"Action\",\n            \"image\": {\n                \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/TheOriginals1280.jpg\"\n     " +
                   "       },\n            \"language\": \"English\",\n            \"nextEpisode\": {\n                \"channel\": null,\n           " +
                   "     \"channelLogo\": \"http://mybeautifulcatchupservice.com/img/player/logo_go.gif\",\n                \"date\": null,\n            " +
                   "    \"html\": \"<br><span class=\\\"visit\\\">Visit the Official Website</span></span>\",\n          " +
                   "      \"url\": \"http://go.ninemsn.com.au/\"\n            },\n            \"primaryColour\": \"#df0000\",\n          " +
                   "  \"seasons\": [\n                {\n                    \"slug\": \"show/theoriginals/season/1\"\n                }\n          " +
                   "  ],\n            \"slug\": \"show/theoriginals\",\n            \"title\": \"The Originals\",\n            \"tvChannel\": \"GO!\"\n   " +
                   "     },\n        {\n            \"country\": \"AUS\",\n            \"description\": \"Join the most dynamic TV judging panel Australia" +
                   " has ever seen as they uncover the next breed of superstars every Sunday night. UK comedy royalty Dawn French, international pop superstar Geri Halliwell," +
                   " (in) famous Aussie straight-talking radio jock Kyle Sandilands, and chart -topping former AGT alumni Timomatic.\",\n            \"drm\": false,\n  " +
                   "          \"episodeCount\": 0,\n            \"genre\": \"Reality\",\n            \"image\": {\n         " +
                   "       \"showImage\": \"http://mybeautifulcatchupservice.com/img/shows/AGT.jpg\"\n            },\n            \"language\": \"English\",\n        " +
                   "    \"nextEpisode\": {\n                \"channel\": null,\n                \"channelLogo\": \"http://mybeautifulcatchupservice.com/img/player/Ch9_new_logo.gif\",\n      " +
                   "          \"date\": null,\n                \"html\": \"Next episode airs:<span>6:30pm Sunday on<br><span class=\\\"visit\\\">Visit the Official Website</span></span>\",\n  " +
                   "              \"url\": \"http://agt.ninemsn.com.au\"\n            },\n            \"primaryColour\": \"#df0000\",\n         " +
                   "   \"seasons\": null,\n            \"slug\": \"show/australiasgottalent\",\n            \"title\": \"Australia's Got Talent\",\n         " +
                   "   \"tvChannel\": \"Channel 9\"\n        }\n    ],\n    \"skip\": 0,\n    \"take\": 10,\n    \"totalRecords\": 75\n}";

            return _validRequestJson;
        }
        private string GetValidResponseJSON()
        {
            if (!string.IsNullOrEmpty(_validResponseJson)) return _validResponseJson;

            _validResponseJson =
                "\n{\n    \"response\": [\n        {\n            \"image\": \"http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg\",\n " +
                "           \"slug\": \"show/16kidsandcounting\",\n            \"title\": \"16 Kids and Counting\"\n        },\n        {\n        " +
                "    \"image\": \"http://mybeautifulcatchupservice.com/img/shows/TheTaste1280.jpg\",\n            \"slug\": \"show/thetaste\",\n      " +
                "      \"title\": \"The Taste\"\n        },\n        {\n            \"image\": \"http://mybeautifulcatchupservice.com/img/shows/Thunderbirds_1280.jpg\",\n     " +
                "       \"slug\": \"show/thunderbirds\",\n            \"title\": \"Thunderbirds\"\n        },\n        {\n      " +
                "      \"image\": \"http://mybeautifulcatchupservice.com/img/shows/ScoobyDoo1280.jpg\",\n            \"slug\": \"show/scoobydoomysteryincorporated\",\n     " +
                "       \"title\": \"Scooby-Doo! Mystery Incorporated\"\n        },\n        {\n            \"image\": \"http://mybeautifulcatchupservice.com/img/shows/ToyHunter1280.jpg\",\n    " +
                "        \"slug\": \"show/toyhunter\",\n            \"title\": \"Toy Hunter\"\n        },\n        {\n       " +
                "     \"image\": \"http://mybeautifulcatchupservice.com/img/shows/Worlds1280.jpg\",\n            \"slug\": \"show/worlds\",\n            \"title\": \"World's...\"\n     " +
                "   },\n        {\n            \"image\": \"http://mybeautifulcatchupservice.com/img/shows/TheOriginals1280.jpg\",\n            \"slug\": \"show/theoriginals\",\n         " +
                "   \"title\": \"The Originals\"\n        }\n    ]\n}";

            return _validResponseJson;
        }
    }
}
