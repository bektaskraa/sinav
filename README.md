# Web Sınavı Çalışma
## Database İşlemleri
Bu durum her sınıf için farklı olduğundan siz bildiğiniz yoldan oluşturun. Aşağıda anlatılan **Tamer Hoca**'nın sınıfına göredir.

### Oluşturma

 1. **SQL Server Management Studio**'yu açın.
 2. Yeni bir database oluşturun.
 3. Oluşturduğunuz database'in kalsörlerini açın isterseniz direkt tablo oluşturun veya diagram oluşturun.
 4. Tablo oluşturmak için **tables** klasörüne sağ tıklayın ve **new table** ifadesine basın. Eğer diagram oluşturmak istiyorsanız aynı işlemi **diagrams** klasörüne uygulayın. 
 5. Sınav sorusuna göre yapılandırdığınız database'i eğer tamamen bittiğine eminseniz **ctrl + s** ile kaydedin.

### Bağlanma

Bu işlemde herkes için farklı olabilir. Eğer bağlama işlemini yapabiliyorsanız bu adımı atlayın. Bu örnek **Tamer Hoca**'nın sınıfına göre hazırlanmıştır

 1. Projenize **Microsoft.EntityFrameworkCore.Design , Microsoft. EntityFrameworkCore.Sq|Server , Microsoft. EntityFrameworkCore.Tools** nuget ile yükleyin. Paket yöneticisini açmak için üstütte bulunan **araçlar** ı seçin ve nuget bölümünden 2. seçeneği seçin.
 2. Bu kez **araçlar** nuget bölümünden **paket yöneticisi konsolu** nu seçin 3. olan.
 3. Açılan konsola (**DİKKAT** **Server** ve **Database** parametrelerini kendinize göre düzenleyin eğer Tamer hoca da iseniz sadece database parametresine kendi database adınızı yazmanız yeterli): **Scaffold-DbContext "Server=LAB7SERVER;Database=Databaseadı;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models** yazınız.
 4. Biraz bekledikten sonra **Build succeeded.** ifadesini konsola yazıldığını göreceksiniz.
 5. Artık database kullanmaya hazır.
 
### Kullanma
Örnek olarak **Yemekler** ismindeki bir database i kullandığımızı düşünelim.

**Controllers** klasörü içindeki **HomeController.cs** dosyası:

```c#
YemeklerContext db = new YemeklerContext();
```
bu kodu
```c#
private readonly ILogger<HomeController> _logger;
```
altına yapıştırın. Verileri göstermek istediğimiz actionı bu şekilde değiştirin. Biz **Index** için yapıyoruz.
```c#
public IActionResult Index()
{
    var yemekler = db.Yemeklers.ToList();
    return View(yemekler);
}
```
 Burada **db** üzerinden **yemekler** değişkeni tüm yemekleri çekiyoruz. Ve View'e gönderiyoruz.

 **Views/Home** klasörü içindeki **Index.cshtml** dosyası:
 ```cshtml
 @model List<deneme.Models.Yemeklers>
 ```
bunu dosyamızın en ütüne ekleyelim. burada ki **deneme** yazısını kendi proje adınıza göre değiştirelim.
Tekrar eden yeri bularak verilerimizi yazdıralım. Örnek olarak:
```cshtml
@foreach (var item in model)
{
  <div>@item.YemekAdi</div>
}
```
Bu şekilde tüm yemeklerimizin adını yazdırmış olduk.

