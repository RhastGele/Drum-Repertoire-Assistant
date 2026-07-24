using System.IO;

List<string> sarkiIsimleri = new List<string>();
List<int> bpmDegerleri = new List<int>();
List<string> zorlukDereceleri = new List<string>();
bool wantExit = false;

VerileriOku();

while (!wantExit)
{
    AnaMenuListele();
    string? anaMenuSecim = Console.ReadLine();
    switch (anaMenuSecim)
    {
        case "1":
            TumRepertuvariListele();
            break;

        case "2":
            YeniSarkıEkle();
            break;

        case "3":
            BPMFiltrele();
            break;

        case "4":
            ismeGoreFiltere();
            break;

        case "5":
            Console.WriteLine("Çıkış Yapılıyor...");
            Thread.Sleep(1000);
            wantExit = true;
            break;
    }

}

/* ######################## METHODLAR ############################# */

void AnaMenuListele()
{
    Console.WriteLine("Bateri repertuvarına hoşgeldin! Ne yapmak istersin ?");
    Console.WriteLine("1 - Tüm Repertuvarı Listele");
    Console.WriteLine("2 - Yeni Şarkı Ekle");
    Console.WriteLine("3 - BPM'e Göre Filtrele(Ör: 120 BPM Üstü)");
    Console.WriteLine("4 - Şarkı Adına Göre Ara");
    Console.WriteLine("5 - Çıkış");
}

void TumRepertuvariListele()
{
    if (sarkiIsimleri.Count == 0)
    {
        Console.WriteLine("Henüz repertuvarda hiç şarkı yok!");
        Thread.Sleep(1000);
        return;
    }
    else
    {
        for (int i = 0; i < sarkiIsimleri.Count(); i++)
        {
            Console.WriteLine($"{i + 1}.Şarkı: {sarkiIsimleri[i]}, {bpmDegerleri[i]}BPM | Zorluk Derecesi: {zorlukDereceleri[i]}");
            Thread.Sleep(750);
            if (i == sarkiIsimleri.Count() - 1)
            {
                Console.WriteLine("Başka Şarkı Kalmadı!");
                Thread.Sleep(1000);
            }
        }
    }

}

void YeniSarkıEkle()
{
    Console.WriteLine("Hangi Şarkıyı Eklemek İstersin: ");
    string? istekIsim = Console.ReadLine();
    Console.WriteLine("Şarkı İsmi Eklendi!");
    Thread.Sleep(1000);
    Console.WriteLine("Şarkının BPM Değerini Giriniz: ");
    string? istekBPM = Console.ReadLine();
    if (int.TryParse(istekBPM, out int intIstekBPM))
    {
        Console.WriteLine("BPM Değeri Başarı İle Eklendi!");
        Thread.Sleep(1000);
    }
    else
    {
        Console.WriteLine("Hatalı Bir Giriş Yaptın! Lütfen BPM Değerini 'SAYI' olarak giriniz...");
        Thread.Sleep(1500);
        return;
    }
    Console.WriteLine("Lütfen Şarkının Zorluk Derecesini Yazınız: ");
    string? zorlukInput = Console.ReadLine();
    Console.WriteLine("Zorluk Derecesi Başarıyla Eklendi!");
    Thread.Sleep(700);
    sarkiIsimleri.Add(istekIsim ?? "İsimsiz Şarkı");
    bpmDegerleri.Add(intIstekBPM);
    zorlukDereceleri.Add(zorlukInput ?? "Bilinmiyor");
    VerileriKaydet();
    Console.WriteLine("Ana Menüye Aktarılıyorsunuz...");
    Thread.Sleep(1000);
}

void BPMFiltrele()
{
    Console.WriteLine("Kaç BPM Üstü Arıyorsun ?");
    string? BPMIstek = Console.ReadLine();
    if (int.TryParse(BPMIstek, out int BPMIstekInt))
    {

        bool sarkiBulundu = false;

        for (int i = 0; i < bpmDegerleri.Count(); i++)
        {
            if (bpmDegerleri[i] >= BPMIstekInt)
            {
                Console.WriteLine($"{i + 1} - {sarkiIsimleri[i]} | {bpmDegerleri[i]} BPM");
                Thread.Sleep(1000);
                sarkiBulundu = true;
            }
        }

        if (sarkiBulundu == false)
        {
            Console.WriteLine("Aradığınız değerde şarkı bulunamadı!");
            Thread.Sleep(1000);
        }
    }
    else
    {
        Console.WriteLine("Lütfen Geçerli Bir Değer Giriniz...");
        return;
    }
}

void ismeGoreFiltere()
{
    Console.WriteLine("Aradığınız Şarkıyı Giriniz: ");
    string? sarkiInput = (Console.ReadLine() ?? "").ToLower();

    bool sarkiBulundu = false;

    for (int i = 0; i < sarkiIsimleri.Count(); i++)
    {
        if (sarkiIsimleri[i].ToLower().Contains(sarkiInput ?? ""))
        {
            Console.WriteLine($"{sarkiIsimleri[i]} | {bpmDegerleri[i]} BPM | Zorluk Derecesi: {zorlukDereceleri[i]} ");
            Thread.Sleep(1500);
            sarkiBulundu = true;
        }
    }

    if (sarkiBulundu == false)
    {
        Console.WriteLine("Aradığınız şarkı bulunamadı..");
        return;
    }
    Console.WriteLine();
}

void VerileriKaydet()
{
    List<string> kayitListesi = new List<string>();
    for (int i = 0; i < sarkiIsimleri.Count; i++)
    {
        kayitListesi.Add($"{sarkiIsimleri[i]}|{bpmDegerleri[i]}|{zorlukDereceleri[i]}");
    }
    File.WriteAllLines("repertuvar.txt", kayitListesi);
}

void VerileriOku()
{
    if (File.Exists("repertuvar.txt"))
    {
        string[] satirlar = File.ReadAllLines("repertuvar.txt");

        for (int i = 0; i < satirlar.Length; i++)
        {
            string[] parcalar = satirlar[i].Split('|');
            if (parcalar.Length == 3)
            {
                if (int.TryParse(parcalar[1], out int okunanBPM))
                {
                    sarkiIsimleri.Add(parcalar[0]);
                    bpmDegerleri.Add(int.Parse(parcalar[1]));
                    zorlukDereceleri.Add(parcalar[2]);
                }
                else
                {
                    Console.WriteLine($"[UYARI] Dosyadaki '{parcalar[0]}' isimli şarkının BPM verisi bozuk. Şarkı atlandı.");
                }
            }
            else
            {
                Console.WriteLine($"[UYARI] Dosyadaki {i + 1}. satırın formatı bozuk. Bu satır atlandı.");
            }
        }
    }
}