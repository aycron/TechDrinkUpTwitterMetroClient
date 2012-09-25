using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TechDrinkUpTwitterMetroClient.TwitterService
{
    [DataContract]
    public class TwitterSearchResponse
    {
        [DataMember]
        public float completed_in;

        [DataMember]
        public long max_id;

        [DataMember]
        public string max_id_str;

        [DataMember]
        public string next_page;

        [DataMember]
        public int page;

        [DataMember]
        public string query;

        [DataMember]
        public string refresh_url;

        [DataMember]
        public IEnumerable<TwitterResult> results;

        [DataContract]
        public class TwitterResult
        {

           // [DataMember]
           // public DateTime created_at;
            [DataMember]
            public string from_user;
            [DataMember]
            public long from_user_id;
            [DataMember]
            public string from_user_id_str;

            [DataMember]
            public string from_user_name;

            //geo: null,
            [DataMember]
            public long id;
            [DataMember]
            public string id_str;

            [DataMember]
            public string iso_language_code;

            //metadata: {
            //result_type: "recent"
            //},

            [DataMember]
            public string profile_image_url;

            [DataMember]
            public string profile_image_url_https;
            [DataMember]
            public string source;
            [DataMember]
            public string text;
            //to_user: null,
            //to_user_id: 0,
            //to_user_id_str: "0",
            //to_user_name: null

        }
    }
}

