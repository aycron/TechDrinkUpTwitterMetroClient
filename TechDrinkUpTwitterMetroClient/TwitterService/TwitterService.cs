using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TechDrinkUpTwitterMetroClient.Data;
using TechDrinkUpTwitterMetroClient.TwitterService;

namespace TechDrinkUpTwitterMetroClient.TwitterServiceNamespace
{
    class TwitterService
    {
        private static string HASHTAG = "test";
        private static TwitterService _instance;
        public static TwitterService Instance
        {
            get
            {
                if (TwitterService._instance == null)
                    TwitterService._instance = new TwitterService();
                return TwitterService._instance; 
            }
            set { TwitterService._instance= value; }
        }

        private string _endpoint = "http://search.twitter.com/search.json";
        private string _refreshUrl = "?q=%23" + TwitterService.HASHTAG;

        public async Task<IEnumerable<TwitterDataItem>> GetTweets()
        {
            //return GetMockedTweets();
            var ret = new List<TwitterDataItem>();

            //string rawresponse = GetMockedRawResponse();

            HttpClient http = new HttpClient();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TwitterSearchResponse));
            var url = this._endpoint + this._refreshUrl;
            var objs = (ser.ReadObject(await http.GetStreamAsync(new Uri(url))) as TwitterSearchResponse);
            foreach (TwitterSearchResponse.TwitterResult i in objs.results)
                ret.Add(GetTwitterDataItem(i));
            this._refreshUrl = objs.refresh_url;
            return ret;
        }

        private TwitterDataItem GetTwitterDataItem(TwitterSearchResponse.TwitterResult i)
        {
            var original_profile_image_url = i.profile_image_url.Replace("_normal", "");
            return new TwitterDataItem(i.id_str, i.from_user_name, i.from_user_id_str, original_profile_image_url, i.text);
        }

        private string GetMockedRawResponse()
        {
            return "{\"completed_in\":0.028,\"max_id\":249269328418066432,\"max_id_str\":\"249269328418066432\",\"page\":1,\"query\":\"%23techdrinkup\",\"refresh_url\":\"?since_id=249269328418066432&q=%23techdrinkup\",\"results\":[{\"created_at\":\"Fri, 21 Sep 2012 22:10:13 +0000\",\"from_user\":\"michaelgold\",\"from_user_id\":10756682,\"from_user_id_str\":\"10756682\",\"from_user_name\":\"Michael Gold\",\"geo\":null,\"id\":249269328418066432,\"id_str\":\"249269328418066432\",\"iso_language_code\":\"en\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/2425857560\\/om7vg8k1ayxtvaa1l8bz_normal.jpeg\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/2425857560\\/om7vg8k1ayxtvaa1l8bz_normal.jpeg\",\"source\":\"&lt;a href=&quot;http:\\/\\/twitter.com\\/download\\/iphone&quot;&gt;Twitter for iPhone&lt;\\/a&gt;\",\"text\":\"RT @smx: Live in or travel to NYC often? Check out @techdrinkup, our SMX East association partner! http:\\/\\/t.co\\/lysgd5U9 #techdrinkup\",\"to_user\":null,\"to_user_id\":0,\"to_user_id_str\":\"0\",\"to_user_name\":null},{\"created_at\":\"Fri, 21 Sep 2012 22:08:16 +0000\",\"from_user\":\"techdrinkup\",\"from_user_id\":262424864,\"from_user_id_str\":\"262424864\",\"from_user_name\":\"Techdrinkup Party\",\"geo\":null,\"id\":249268835289554944,\"id_str\":\"249268835289554944\",\"iso_language_code\":\"en\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/1568211180\\/techdrinkup-white-logo_normal.png\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/1568211180\\/techdrinkup-white-logo_normal.png\",\"source\":\"&lt;a href=&quot;http:\\/\\/twitter.com\\/download\\/iphone&quot;&gt;Twitter for iPhone&lt;\\/a&gt;\",\"text\":\"RT @smx: Live in or travel to NYC often? Check out @techdrinkup, our SMX East association partner! http:\\/\\/t.co\\/lysgd5U9 #techdrinkup\",\"to_user\":null,\"to_user_id\":0,\"to_user_id_str\":\"0\",\"to_user_name\":null},{\"created_at\":\"Fri, 21 Sep 2012 21:20:48 +0000\",\"from_user\":\"andreat76\",\"from_user_id\":15777718,\"from_user_id_str\":\"15777718\",\"from_user_name\":\"Andrea T\",\"geo\":null,\"id\":249256889194520577,\"id_str\":\"249256889194520577\",\"iso_language_code\":\"en\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/1095107236\\/Deep_in_thought_sun_on_face_by_DK_normal.jpg\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/1095107236\\/Deep_in_thought_sun_on_face_by_DK_normal.jpg\",\"source\":\"&lt;a href=&quot;http:\\/\\/twitter.com\\/download\\/iphone&quot;&gt;Twitter for iPhone&lt;\\/a&gt;\",\"text\":\"RT @smx: Live in or travel to NYC often? Check out @techdrinkup, our SMX East association partner! http:\\/\\/t.co\\/lysgd5U9 #techdrinkup\",\"to_user\":null,\"to_user_id\":0,\"to_user_id_str\":\"0\",\"to_user_name\":null},{\"created_at\":\"Fri, 21 Sep 2012 21:19:00 +0000\",\"from_user\":\"smx\",\"from_user_id\":1061961,\"from_user_id_str\":\"1061961\",\"from_user_name\":\"SearchMarketingExpo\",\"geo\":null,\"id\":249256437526712321,\"id_str\":\"249256437526712321\",\"iso_language_code\":\"en\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/1693213298\\/smx_logo_normal.png\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/1693213298\\/smx_logo_normal.png\",\"source\":\"&lt;a href=&quot;http:\\/\\/www.exacttarget.com\\/social&quot;&gt;SocialEngage&lt;\\/a&gt;\",\"text\":\"Live in or travel to NYC often? Check out @techdrinkup, our SMX East association partner! http:\\/\\/t.co\\/lysgd5U9 #techdrinkup\",\"to_user\":null,\"to_user_id\":0,\"to_user_id_str\":\"0\",\"to_user_name\":null},{\"created_at\":\"Wed, 19 Sep 2012 15:42:27 +0000\",\"from_user\":\"GenaKoveshnikov\",\"from_user_id\":39800195,\"from_user_id_str\":\"39800195\",\"from_user_name\":\"Gena Koveshnikov\",\"geo\":null,\"id\":248446965313060865,\"id_str\":\"248446965313060865\",\"iso_language_code\":\"ru\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/1488280091\\/IMG_8497_normal.JPG\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/1488280091\\/IMG_8497_normal.JPG\",\"source\":\"&lt;a href=&quot;https:\\/\\/chrome.google.com\\/webstore\\/detail\\/ikknnkomiokeodcdkknnhgjmncfiefmn&quot;&gt;Notifier for Chrome&lt;\\/a&gt;\",\"text\":\"@k0shk @inxaoc \\u0447\\u0442\\u043e-\\u0442\\u043e \\u0434\\u0430\\u0432\\u043d\\u043e #techdrinkup \\u043d\\u0435 \\u0431\\u044b\\u043b\\u043e, \\u0445\\u043e\\u0447\\u0443 \\u0437\\u0430\\u043c\\u0435\\u0442\\u0438\\u0442\\u044c :)\",\"to_user\":\"k0shk\",\"to_user_id\":20785771,\"to_user_id_str\":\"20785771\",\"to_user_name\":\"Olya Parkhimovich\",\"in_reply_to_status_id\":248445977487368192,\"in_reply_to_status_id_str\":\"248445977487368192\"},{\"created_at\":\"Wed, 19 Sep 2012 15:20:06 +0000\",\"from_user\":\"k0shk\",\"from_user_id\":20785771,\"from_user_id_str\":\"20785771\",\"from_user_name\":\"Olya Parkhimovich\",\"geo\":null,\"id\":248441343792259073,\"id_str\":\"248441343792259073\",\"iso_language_code\":\"ru\",\"metadata\":{\"result_type\":\"recent\"},\"profile_image_url\":\"http:\\/\\/a0.twimg.com\\/profile_images\\/1191857684\\/________normal.jpg\",\"profile_image_url_https\":\"https:\\/\\/si0.twimg.com\\/profile_images\\/1191857684\\/________normal.jpg\",\"source\":\"&lt;a href=&quot;http:\\/\\/twitter.com\\/&quot;&gt;web&lt;\\/a&gt;\",\"text\":\"24 \\u0447\\u0430\\u0441\\u0430 \\u0434\\u043b\\u044f \\u0442\\u043e\\u0433\\u043e, \\u0447\\u0442\\u043e\\u0431\\u044b #TechDrinkUp #Russia \\u043d\\u0435 \\u0437\\u0430\\u043a\\u0440\\u044b\\u043b\\u0438\\u0441\\u044c\",\"to_user\":null,\"to_user_id\":0,\"to_user_id_str\":\"0\",\"to_user_name\":null}],\"results_per_page\":15,\"since_id\":0,\"since_id_str\":\"0\"}";
        }

        public ObservableCollection<TwitterDataItem> GetMockedTweets()
        {
            var ret = new ObservableCollection<TwitterDataItem>();
            ret.Add(new TwitterDataItem("12389741623598172",
                    "@techdrinkup",
                    "2190675848",
                    "http://a0.twimg.com/sticky/default_profile_images/default_profile_0.png",
                    "#Test waschtrockner stiftung warentest http://t.co/b9GyagIs #shop #tests waschtrockner stiftung warentest kaufen"));
            ret.Add(new TwitterDataItem("12389741623598173",
                    "@lucasvidalutn",
                    "208112063",
                    "https://twimg0-a.akamaihd.net/profile_images/1473386819/profile.jpg",
                    "RT @ShauniLatu: “@blasfloss: Time to #fail this #math #test...” You fail at life."));
            ret.Add(new TwitterDataItem("12389741623598174",
                    "@oso_arturo",
                    "467767993",
                    "http://a0.twimg.com/profile_images/2191494082/virtuellemiss.jpg",
                    "#2010 #maximebataille #test #coiffure #mode #model #mannequin  http://t.co/yiQEygfr"));
            ret.Add(new TwitterDataItem("12389741623598175",
                    "@ggonzalez30",
                    "241319155",
                    "http://a0.twimg.com/profile_images/2639300174/19fcbfeb78327fc6329c9d877b5b69dc.jpeg",
                    "Time to #fail this #math #test..."));
            ret.Add(new TwitterDataItem("123897416235981726",
                    "@juan_carlos_batman",
                    "824545292",
                    "https://twimg0-a.akamaihd.net/profile_images/2475729655/gjr49jeorqfcd6rm7djv.jpeg",
                    "Studying all this week better have been worth it for my test on monday #collegebound #test"));
            return ret;
        }

    
    }
}
