using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms.Controls.Model
{
    public class MockData
    {
        // Kullanıcılar listesi oluşturduk ve içine birkaç kullanici ekledik.
        public List<Kullanici> Kullanicilar { get; set; }

        public MockData()
        {
            this.Kullanicilar = new List<Kullanici>();
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Kamil",
                Email = "kamil@fidil.com",
                Soyad = "Fidil"
            });
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Hakkı",
                Email = "hakki@fidil.com",
                Soyad = "Fidil"
            });
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Kerim",
                Email = "kerim@fidil.com",
                Soyad = "Fidil"
            });
        }
    }
}
