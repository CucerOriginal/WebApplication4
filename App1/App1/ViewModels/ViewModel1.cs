using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using App1.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Hangfire.Annotations;

namespace App1.ViewModels
{
    class ViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<SomeData> _someData;
        public ObservableCollection<SomeData> someData { get => _someData; set { _someData = value; OnPropertyChanged(); } }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Output()
        {
            var client = new HttpClient(GetInsecureHandler());
            var res = await client.GetAsync("https://localhost:44340/home/getJson").ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            someData = JsonConvert.DeserializeObject<ObservableCollection<SomeData>>(json);

        }
        public ICommand LoadData => new Command(async value =>
        {
            await Output();
        });
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

    }
}
