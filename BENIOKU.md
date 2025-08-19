# Yılan Oyunu

Bu proje, Windows Forms tabanlı bir Yılan oyunudur. Bu proje benzersiz bir mekanikle çalışır: Bir ödül (elma) tüketildiğinde, görsel olarak aynı olan ancak oyunu bitiren bir engel de oluşur. Bu, oyuncuları güvenli ve tehlikeli nesneler arasında ayrım yapmaya zorlayarak bir risk ve ödül katmanı ekler.

## İçindekiler

- [Proje Özellikleri](#proje-özellikleri)
- [Mimari](#mimari)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Kod Yapısı ve Organizasyon](#kod-yapısı-ve-organizasyon)
- [Temel Bileşenler](#temel-bileşenler)
- [İş Mantığı](#iş-mantığı)
- [Kurulum ve Çalıştırma Talimatları](#kurulum-ve-çalıştırma-talimatları)
- [Yapılandırma ve Ayarlar](#yapılandırma-ve-ayarlar)
- [Kod Kalitesi ve Standartlar](#kod-kalitesi-ve-standartlar)
- [Değişiklik Yapma Rehberi](#değişiklik-yapma-rehberi)
- [Proje Kuralları](#proje-kuralları)
- [Lisans](#lisans)

## Proje Özellikleri

- **Klasik Yılan Oynanışı**: Elmaları yemek ve uzamak için bir yılanı kontrol edin.
- **Dinamik Zorluk**: Yenen her elma yılanın uzunluğunu artırır ve haritada yeni bir "zehirli elma" (engel) oluşturur.
- **Risk-Ödül Mekaniği**: Zehirli elmalar, normal elmalarla görsel olarak aynıdır ve oyuncunun oyunu kaybetmemek için konumlarını hatırlamasını gerektirir.
- **Skor Takibi**: Oyuncunun skoru gerçek zamanlı olarak takip edilir ve görüntülenir.
- **Çarpışma Tespiti**: Yılan duvarlara veya zehirli bir elmaya çarparsa oyun sona erer.
- **Basit Arayüz**: Windows Forms ile oluşturulmuş temiz ve anlaşılır bir kullanıcı arayüzü.
- **Arka Plan Müziği**: Oyun başladığında çalan bir arka plan müziği içerir.

## Mimari

Proje, basit Windows Forms uygulamaları için yaygın olan monolitik ve olay tabanlı bir mimariyi takip eder.

- **Sunum Katmanı**: Tüm uygulama mantığı, kullanıcı arayüzünü, oyun durumunu ve kullanıcı girdisini yöneten `Form1.cs` sınıfı içinde yer alır.
- **İş Mantığı**: Yılan hareketi, elma tüketimi, engel oluşturma ve çarpışma kontrolleri gibi oyun mekanikleri `Form1.cs` içindeki metotlar tarafından yönetilir.
- **Veri Katmanı**: Ayrı bir veri katmanı yoktur; oyun durumu (yılan konumu, skor vb.) bellekte yönetilir.

## Kullanılan Teknolojiler

- **Dil**: C#
- **Framework**: .NET 6.0
- **Arayüz**: Windows Forms

## Kod Yapısı ve Organizasyon

- **Dizin Yapısı**:
    - `Form1.cs`: Oyunun tüm ana mantığını (hareket, çarpışma, puanlama vb.) içeren ana kod dosyasıdır.
    - `Form1.Designer.cs`: Arayüz bileşenlerinin programatik olarak oluşturulduğu ve ayarlandığı dosyadır.
    - `Program.cs`: Uygulamanın başlangıç noktasıdır, `Form1`'i çalıştırır.
    - `yılan oyunu.csproj`: Proje ayarlarını ve bağımlılıklarını içeren C# proje dosyasıdır.
    - `portal-2-end-credits-song-want-you-gone-by-jonathan-coulton-1080p-hd.wav`: Oyun başladığında çalan ses dosyasıdır.
    - `.vs/`, `bin/`, `obj/`: Visual Studio ve derleme süreçleri tarafından oluşturulan standart dizinlerdir.
- **Dosya İsimlendirme**: Standart Visual Studio Windows Forms proje isimlendirme kuralları kullanılmıştır.
- **Kod Stili**: Metot isimleri Türkçe'dir (`elmaYeme`, `carpisma`). Değişken isimleri ise kısaltılmış İngilizce (`locX`, `locY`) ve Türkçe (`yon`, `yilan`) karışık bir şekilde kullanılmıştır. Kod, `Form1` sınıfı içinde prosedürel bir yapıda ilerler.

## Temel Bileşenler

- **Ana Modüller**:
    - `Form1`: Projenin tek ve ana sınıfıdır.
    - `timer1_Tick`: Oyunun kalbidir. Her 110 milisaniyede bir tetiklenerek oyunun bir sonraki karesini (frame) oluşturur. Yılanın hareketini, elma yeme kontrolünü ve çarpışma denetimini bu metot tetikler.
    - `Form1_KeyDown`: Klavye girdilerini dinleyerek yılanın yönünü (`yon` değişkeni) ayarlar.
    - `label3_Click`: "BAŞLA" etiketine tıklandığında oyunu başlatan metottur.
- **Veri Modelleri**:
    - `List<Panel> yilan`: Yılanın her bir parçasını temsil eden `Panel` nesnelerinden oluşan bir listedir. Yılanın başı `yilan[0]`'dır.
    - `Panel elma`, `Panel odul`, `Panel duvar`, `Panel engel`: Oyundaki diğer tüm nesneler (elma, ödül, duvar, engel) de `Panel` bileşenleri olarak temsil edilmektedir.
    - Oyun durumu (puan, yön) form seviyesindeki değişkenlerde (`label2.Text`, `yon`) tutulur.

## İş Mantığı

- **Ana Akışlar**:
    1. Kullanıcı "BAŞLA" etiketine tıklar.
    2. `label3_Click` metodu tetiklenir: Oyun alanı temizlenir, başlangıç sesi çalınır, yılan oluşturulur, `timer1` başlatılır, ilk elmalar ve duvarlar yaratılır.
    3. `timer1` her tetiklendiğinde (`timer1_Tick`):
        - Yılanın başının yeni konumu `yon` değişkenine göre hesaplanır.
        - `hareket()` metodu ile yılanın vücudunun geri kalanı başı takip eder.
        - `elmaYeme()` metodu, yılanın bir elma ile temasını denetler. Temas halinde: Puan artırılır, yılan uzatılır ve oyun alanı yeni elmalarla güncellenir.
        - `engeller()` metodu, elmalarla aynı görünüme sahip (`Color.Red`) fakat çarpıldığında oyunu sonlandıran bir `engel` nesnesini oyun alanına ekler.
        - `carpisma()` metodu, yılanın duvarlara, kendi kendine veya önceden oluşturulmuş bu engellere çarpıp çarpmadığını kontrol eder.
- **Veri İşleme**: Tüm veri işleme, `Panel` nesnelerinin `Location` (konum) özelliklerinin güncellenmesi ve `label2`'nin `Text` özelliğinde tutulan puanın değiştirilmesi üzerine kuruludur.

## Kurulum ve Çalıştırma Talimatları

### Ön Gereksinimler

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- **.NET masaüstü geliştirme** iş yükü yüklü [Visual Studio](https://visualstudio.microsoft.com/).

### Projeyi Çalıştırma

1. **Depoyu klonlayın** veya kaynak kodunu yerel makinenize indirin.
2. **Çözüm dosyasını** (`yılan oyunu.sln`) Visual Studio'da açın.
3. `Ctrl+Shift+B` tuşlarına basarak veya menüden `Build > Build Solution` seçeneğini seçerek **çözümü derleyin**.
4. `F5` tuşuna basarak veya Visual Studio araç çubuğundaki "Başlat" düğmesine tıklayarak **projeyi çalıştırın**.
5. Oyuna başlamak için "BAŞLA" etiketine tıklayın.

## Yapılandırma ve Ayarlar

- **Config Dosyaları**: Projede harici bir konfigürasyon dosyası bulunmamaktadır.
- **Sabit Değerler**:
    - Oyun hızı: `timer1.Interval = 110` (milisaniye).
    - Oyun alanı boyutu: `panel1.Size = new System.Drawing.Size(600, 600)`.
    - Yılan ve elma parçalarının boyutu: `new Size(20, 20)`. Bu değerler kod içinde sabit olarak tanımlanmıştır.

## Kod Kalitesi ve Standartlar

- **Kullanılan Pattern'ler**: Olay Tabanlı Programlama (Event-Driven) ve Oyun Döngüsü (Game Loop) desenleri kullanılmıştır.
- **Hata Yönetimi**: Belirgin bir `try-catch` gibi hata yönetimi mekanizması yoktur. Oyunun bitmesi bir "hata" değil, bir durum değişikliğidir ve `timer1.Stop()` ile yönetilir.
- **Logging**: Projede herhangi bir loglama yapısı bulunmamaktadır.

## Değişiklik Yapma Rehberi

- **Yeni Özellik Eklemek İçin**: (Örn: Yeni bir "altın elma" eklemek)
    1. `Form1.cs` içine yeni bir `Panel` nesnesi (örn: `private Panel altinElma = new Panel();`) eklenmelidir.
    2. Bu elmayı oluşturacak bir metot yazılmalıdır (örn: `altinElmaOlustur()`).
    3. `timer1_Tick` veya `elmaYeme` içinde yılanın bu yeni nesneyle çarpışmasını kontrol eden bir mantık eklenmelidir.
    4. Çarpışma durumunda ne olacağı (örn: ekstra puan, hızlanma vb.) kodlanmalıdır.
- **Mevcut Özellik Değiştirmek İçin**: (Örn: Yılanın hızını artırmak)
    - `Form1.Designer.cs` dosyasındaki `timer1.Interval` değeri düşürülmelidir.
- **Dikkat Edilmesi Gerekenler**:
    - **Sıkı Bağımlılık (Tight Coupling)**: Oyun mantığı, UI elemanlarına doğrudan erişir ve onları manipüle eder.
    - **Koordinat Sistemi**: Tüm oyun 20x20'lik bir grid (ızgara) sistemi üzerine kuruludur.
    - **Tek Sorumluluk Prensibi İhlali**: `Form1` sınıfı hem arayüzü yönetir, hem oyunun durumunu tutar, hem de tüm oyun mantığını çalıştırır.

## Proje Kuralları

- **Uyulması Gereken Standartlar**: Projenin mevcut yapısına sadık kalınmalıdır. Yeni oyun nesneleri `Panel` olarak oluşturulmalı, oyun mantığı `timer1_Tick` olayına bağlı kalmalıdır.
- **Değiştirilmemesi Gerekenler**: `timer1`'in oyun döngüsü olarak kullanılması ve yılanın `List<Panel>` olarak temsil edilmesi gibi temel mimari kararlar.
- **Esnek Olan Kısımlar**: Puanlama sistemi, elma/engel sayısı, renkler, oyun hızı gibi parametreler.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Ayrıntılar için [LICENSE](LICENSE) dosyasına bakın.
