using Hirdavat.M.MobilModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;

namespace Hirdavat.M
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        


    const string apiurl = "https://jsonplaceholder.typicode.com/users";
   // const string apiurl = "http://192.168.1.34:8080/Api/Products";
           private HttpClient _client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();


        
             
        }



        ListView lst = new ListView();
        protected override async void OnAppearing()
        {
            var result = await _client.GetStringAsync(apiurl);
            LstView.ItemsSource = JsonConvert.DeserializeObject<List<Mobil_Model_Products>>(result);

            base.OnAppearing();
        }
    }


}
