using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TechDrinkUpTwitterMetroClient.Data
{
    public sealed class TwitterDataSource
    {
        public static Uri _baseUri = new Uri("ms-appx:///");

        private ObservableCollection<TwitterDataItem> _items= new ObservableCollection<TwitterDataItem>();
        public ObservableCollection<TwitterDataItem> Items
        {
            get {return this._items;}
            set { this._items = value; }
        }

        private static TwitterDataSource _instance=new TwitterDataSource();
        public static TwitterDataSource Instance
        {
            get { return TwitterDataSource._instance; }
        }

        public TwitterDataSource()
        {
            
           // this._items = TechDrinkUpTwitterMetroClient.TwitterServiceNamespace.TwitterService.Instance.GetMockedTweets();      
        }

        internal async void GetTweets(Windows.UI.Xaml.Controls.GridView itemGridView, Windows.UI.Xaml.Controls.ProgressRing progressRing)
        {

            progressRing.IsActive = true;
            var list = await TechDrinkUpTwitterMetroClient.TwitterServiceNamespace.TwitterService.Instance.GetTweets();
            foreach (TwitterDataItem i in list)
                this.Items.Add(i);
            
            //itemGridView.ItemsSource = this.Items;
            itemGridView.DataContext = this.Items;
            progressRing.IsActive = false;
        }

    }

    public class TwitterDataItem
    {
        public TwitterDataItem(String tweetId, String username, String user_id, String imagePath, String description)
        {
            this._tweetId = tweetId;
            this._user_id = user_id;
            this._imagePath = imagePath;
            this._description = description;
            this._userName = username;
        }

        private ImageSource _image = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(TwitterDataSource._baseUri, this._imagePath));
                    //this._image = new BitmapImage(new Uri("https://www.google.com.ar/images/srpr/logo3w.png"));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this._image = value;
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
        }
        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        private string _tweetId;
        public string TweetId
        {
            get { return this._tweetId; }
            set { this._tweetId = value;}
        }
        private string _user_id;
        public string UserId
        {
            get {return this._user_id;}
            set { this._user_id = value; }
        }
        private string _imagePath;
        public string ImagePath
        {
            get {return this._imagePath;}
            set {this._imagePath = value;}
        }

        private string _description;
        public string Description
        {
            get { return this._description; }
            set {this._description = value;}
        }
        private string _userName;
        public string UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }
    }
}
