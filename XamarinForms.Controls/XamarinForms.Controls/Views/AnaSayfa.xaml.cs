using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Model;

namespace XamarinForms.Controls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnaSayfa : ContentPage
	{
		public AnaSayfa ()
		{
			InitializeComponent ();
            initMyComponent();  // Program çalıştığında Componentlerimizi tetikleyecek metod.
            BindingContext = new MockData();   // Combobox 3. yontem için gerekli
        }


        private void initMyComponent()
        {
            var red = Color.Red;
            var orange = Color.FromHex("FF6A00");
            var yellow = Color.FromHsla(0.167, 1.0, 0.5, 1.0);
            var green = Color.FromRgb(38, 127, 0);
            var blue = Color.FromRgba(0, 38, 255, 255);
            var indigo = Color.FromRgb(0, 72, 255);
            var violet = Color.FromHsla(0.82, 1, 0.25, 1);
            // Birkaç renk tanımladık ve onları bir liste içerisine attık.
            var colors = new List<Color> { red, orange, yellow, green, blue, indigo, violet };

            // 2.yontem
            //btnDondur.Clicked += BtnDondur_Clicked;

            // 3.yontem 
            /*
            btnDondur.Clicked += (sender, e) =>
            {
                // Buradaki sender nesnesi bir object ve onu button tipine dönüştürerek kullanabilirz.
                angle *= 1.15;
                lblMesaj.RotateTo(angle, 1000);
            };*/

            // 4.yontem async
            btnDondur.Clicked += async (sender, e) =>
            {
                var rnd = new Random();
                angle *= 1.15;
                await lblMesaj.RotateTo(angle, 1000);
                lblMesaj.TextColor = colors[rnd.Next(0, colors.Count)]; // lblMesaj ın rengi buttona her tıklandığında rastgele olarak değişecek. colors bir dizi olduğu için index değerini rastgele verdik. Gelen indexteki değeri  color a atayacak
                lblMesaj.FontSize = rnd.Next(10, 40);
                Button btn = (Button)sender;    // button nesnemze ulaştık ve
                btn.BackgroundColor= colors[rnd.Next(0, colors.Count)]; // arkaplan rengini değiştirdik.

                // DatetimePicker 
                var tarih = dtpTarih.Date; // Seçili tarihi alma
                var span=DateTime.Now - tarih;
                lblMesaj.Text=$"Fark {span.TotalDays} gündür";
            };

            
            cmbRenkler.SelectedIndexChanged += (sender, e) =>
            {
                if (cmbRenkler.SelectedItem == null) return;    // Renk sçilmediyse buradan donduruyoruz.
                string seciliRenk = cmbRenkler.SelectedItem.ToString(); // Seçilen rengin atama işlemini yaptık. 
                DisplayAlert("Renk Seçme İşlemi", $"Seçtiğiniz Renk: {seciliRenk}", "Tamam", "İptal"); // Ve seçilen rengin ne olduğunu alert ile ekranda gösterdik.
            };

            /* Combobox işlemleri 2.Yöntem
            cmbKisiler.ItemsSource = new MockData().Kullanicilar;   // Kullanicilar listemizi cmbKisiler adlı comboboxımıza atadık.
            cmbKisiler.SelectedIndexChanged += (sender, e) =>
            {
                if (cmbKisiler.SelectedItem == null) return;
                var seciliKisi = cmbKisiler.SelectedItem as Kullanici;
                lblMesaj.Text = $"{seciliKisi.Ad} {seciliKisi.Soyad} - {seciliKisi.Email}";
            };
            */

            // Combobox işlemleri 3.Yöntem
            cmbKisilerBinding.SetBinding(Picker.ItemsSourceProperty, "Kullanicilar");
            //cmbKisiler.ItemDisplayBinding = new Binding("Ad"); Displaymember gibi
            cmbKisilerBinding.SelectedIndexChanged += (sender, e) =>
            {
                if (cmbKisilerBinding.SelectedItem == null) return;
                var seciliKisi = cmbKisilerBinding.SelectedItem as Kullanici;
                lblMesaj.Text = $"{seciliKisi.Ad} {seciliKisi.Soyad} - {seciliKisi.Email}";
            }; 
        }
        // 2.yontem metodu
        /*
        private void BtnDondur_Clicked(object sender, EventArgs e)
        {
            angle *= 1.15;
            lblMesaj.RotateTo(angle, 1000);
        }*/

        private static double angle = 25;
        // View kısmında oluşturduğumuz buttonun buradan tetiklenebilmesi için iki yontem var 
        // 1.yontem View de burada kullanacağımız metodun ismini clicked propertysine yazıyoruz.
        public async void OnButtonClicked(object sender, EventArgs e)
        {
            angle*= 1.15;   // Tanımladığımız açıyı her defasında yuzde 15 arttırıyoruz.
            await lblMesaj.RotateTo(angle,1000); // Buttona her tıklandığında da labeldaki mesaj, verdiğimiz açı kadar dönecek.

            lblMesaj.Text = $"{dtpSaat.Time}";  // Seçilen saati yazdıracak.
        }
    }
}