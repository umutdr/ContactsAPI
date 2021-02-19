# Contacts Web API

Web veya mobil uygulamaların kullanabileceği bir Web API projesi. Projenin, ReSTful mimarisine uygun olacak yapıda geliştirilmesine özen gösterilmiştir. 

Projede bir telefon rehberi senaryosu hayata geçirilmiştir. Bağımsız kullanıcıların telefon rehberlerine kişiler ekleyebilmesi,  bu kişileri yönetebilmesi ve rehberdeki her bir kişiye farklı türde iletişim bilgileri ekleyebilmesi sağlanmıştır.

## Projenin Çalıştırılması

Bu bölümde bulunan adımları uygulayarak projenin başarılı bir şekilde derlenmesini sağlayabilirsiniz

Öncelikle proje dosyalarını edinmiş olmanız gerekiyor.

Github CLI kullanarak projeyi bilgisayarınıza kopyalamak için aşağıdaki satırı kullanabilirsiniz.
* `
gh repo clone umutdr/ContactsAPI
`

Ya da, aşağıdaki bağlantıyı kullanarak proje dosyalarını indirmeniz mümkün.
* `
https://github.com/umutdr/ContactsAPI/archive/master.zip
`

## Ön Gereksinimler

Bu WEB API projesi .NET Core 2.1 Ortamında oluşturulup sırasıyla .NET Core 2.2 -> 3.0 -> 3.1 sürümlerine güncellenmiştir.

**Bu süreçte faydalandığım Microsoft dökümanları:**
- [Migrate from ASP.NET Core 2.1 to 2.2](https://docs.microsoft.com/tr-tr/aspnet/core/migration/21-to-22)
- [Migrate from ASP.NET Core 2.2 to 3.0](https://docs.microsoft.com/tr-tr/aspnet/core/migration/22-to-30)
- [Migrate from ASP.NET Core 3.0 to 3.1](https://docs.microsoft.com/tr-tr/aspnet/core/migration/30-to-31)

Projeyi başarılı bir şekilde derleyebilmek için **.NET Core 3.1 SDK paketinin** ve **.NET Core 3.1 runtime paketinin** bilgisayarınızda kurulu olması gerekiyor.

Bilgisayarınızda kurulu bulunan .NET Core SDK paketlerini bir komut satırı istemcisine (örn: CMD) aşağıdaki komutu girerek görüntüleyebilirsiniz.


* `dotnet --list-sdks`

Benim bilgisayarımda kurulu olan .NET Core SDK paketleri:

> ![image](https://user-images.githubusercontent.com/42785142/108565040-18a66e80-7315-11eb-98d3-efd00400daa2.png)

Güncel SDK paketlerini [Microsoft'un Web sitesi](https://dotnet.microsoft.com/download/dotnet) üzerinden indirip sisteminize kurabilirsiniz.

[Visual Studio 2019](https://visualstudio.microsoft.com/tr/downloads/) öncesi sürümler .NET Core Ortamında geliştirme yapmak için uygun değiller. Bu sebeple [Visual Studio 2019](https://visualstudio.microsoft.com/tr/downloads/) veya dengi güncellikle olan bir IDE kullanıyor olmanız gerekiyor.

Projede [Redis](https://redis.io/) hizmeti kullanılmıştır. Bu sebeple redis hizmetinin kurulu olması gerekmekte. Uzak bir sunucudaki redis hizmetine bağlanmak için redis bağlantı bilgilerini "appsettings.json" içerisinden güncelleyebilirsiniz.

Aşağıdaki komutu, komut satırı istemcisinde çalıştırarak redis hizmetini başatabilirsiniz
* `redis-server`
> ![image](https://user-images.githubusercontent.com/42785142/108565186-54413880-7315-11eb-898d-e6187efb555a.png)
- Redis kullanmadan projeyi çalıştırmak istiyorsanız appsettings.json içerisinde bulunan RedisCacheConfig.IsEnabled değerini false olarak atayabilirsiniz.

.NET Core 3.1 SDK ve Runtime paketleri konusunda bir eksik yok ve çalışan bir Redis hizmetine sahipseniz projenin ilk defa derlenme aşamasına geçebiliriz. 

## İlk Derleme

1. **Komut satırı istemcisi kullanarak**
	1. "ContactsAPI.sln" dosyasının bulunduğu dizine erişin	
      	- `cd .\GitHubRepos\ContactsAPI`
    2. Projeleri "restore" edin, ardından derleyin
        - `dotnet restore`
        - `dotnet build`
    3. Veritabanının migration üzerinden güncelleyin
    	- `dotnet ef database update`
    4. ContactsAPI projesini çalıştırın
        - `cd .\ContactsAPI`
        - `dotnet run`
               
2. **Visual Studio 2019 kullanarak**
	1. Projenin ana dizininde bulunan "ContactsAPI.sln"	dosyasını Visual Studio 2019 ile açın
	2. Solution Explorer penceresinden mevcut Solution'a sağ tıklayıp "Restore NuGet Packages" seçeneğini seçin
    3. Yukarıdaki menü çubuğunda bulunan "Build" menüsü altındaki "Reuild Solution" seçeneğine tıklayın.
    4. Menü çubuğundan "View" menüsü altındaki "Other Windows" seçeneği üzerine gelin ve "Package Manager Console" seçeneğini tıklayın
    5. Açılan Package Manager Console penceresine aşağıdaki komutu girin. Bu komut oluşturulan en son migration üzerinden veritabanını güncelleyecektir/oluşturacaktır. 
        - `Update-Database`
    6. Klavyenizden F5 tuşuna basarak veya debug tools kısmındaki [> ContactsAPI] yazına tıklayarak projeyi çalıştırın.

Bu noktaya kadar her şey yolundaysa, arkada bir hata bırakmadıysak, redis hizmeti çalışıyorsa; projedeki endpointlerin sergilendiği SwaggerUI sayfasına aşağıdaki bağlantıyı kullanarak erişebiliriz.
- `https://localhost:5001/swagger/index.html`
>Bu bağlantı proje için varsayılandır.

![image](https://user-images.githubusercontent.com/42785142/108564836-cc5b2e80-7314-11eb-936c-e0ffc736f2d8.png)

Web API'nin sahip olduğu endpointler ile etkileşime geçebilmek için öncelikle bir kullanıcı kaydı gerçekleştirilmeli ve JWT oluşturulması sağlanmalıdır.

Bu işlem için "Identity" controller'i altında bulunan "/api/v1/identity/register" route üzerine aşağıdaki formatta bir POST isteği yaparak üyelik işlemini gerçekleştirebilir ve geçerli bir JWT oluşmasını sağlayabilirsiniz.

```json
{
  "email": "user@example.com",
  "password": "string"
}
```

Başarılı bir istek sonrası API'dan dönen JWT:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyMkBleGFtcGxlLmNvbSIsImp0aSI6WyI0ZjNkNGFkZi1mY2UxLTQ1YzItOTUxOC01MjRjMGQ0MTFkNzYiLCIyZDUxYjk5NC0xNDg4LTQyYzctOGI4Yi0wYmZjMzE3MWRlMmEiXSwidXNlcklkIjoiOTUxYWIwYWUtMzk0Yi00OTViLWIwMzAtZjQ4NzA0MDYzM2RiIiwibmJmIjoxNjEzNzU1NDc4LCJleHAiOjE2MTM3NjI2NzgsImlhdCI6MTYxMzc1NTQ3OH0.q-0m3Zxwpyhy19tzlnO1c_ZDiAhOPBmez1Chn56PC3M"
}
```
Bu tokeni kullanarak SwaggerUI sayfasındayken herhangi bir endpointin sağ tarafında yer alan kilit simgesine tıklayarak veya sayfanın başında sağ tarafta yer alan "Authorize" butonuna tıklayarak açılan popup'a aşağıdaki formatta girmeliyiz.
```
bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyMkBleGFtcGxlLmNvbSIsImp0aSI6WyI0ZjNkNGFkZi1mY2UxLTQ1YzItOTUxOC01MjRjMGQ0MTFkNzYiLCIyZDUxYjk5NC0xNDg4LTQyYzctOGI4Yi0wYmZjMzE3MWRlMmEiXSwidXNlcklkIjoiOTUxYWIwYWUtMzk0Yi00OTViLWIwMzAtZjQ4NzA0MDYzM2RiIiwibmJmIjoxNjEzNzU1NDc4LCJleHAiOjE2MTM3NjI2NzgsImlhdCI6MTYxMzc1NTQ3OH0.q-0m3Zxwpyhy19tzlnO1c_ZDiAhOPBmez1Chn56PC3M
```
![image](https://user-images.githubusercontent.com/42785142/108565377-9ff3e200-7315-11eb-8cf9-d6bb32138dca.png)

Tokeni girdikten sonra (eğer token geçerliyse) SwaggerUI sayfasında sergilenen endpoint'ler ile etkileşime geçmemiz mümkün olacaktır. Aksi taktirde [HTTP401 Unauthorized](https://developer.mozilla.org/tr/docs/Web/HTTP/Status/401) uyarısıyla karşılaşacaksınız.

Kullandığınız JWT'nin ömrü oluşturulduğu andan itibaren 2 Saattir. Token erişiminizi kaybetmeniz durumunda Login route üzerinden aynı formatta bir POST isteği yaparak üyeliğinize ait yeni bir JWT elde edebilirsiniz. Yeni JWT ile yine aynı yöntemle endpointler üzerinde yetki elde edebilirsiniz

### Hazır Verilerin Veritabanına Eklenmesi
Web API üzerinde bulunan endpointlere istek attığımızda içi boş sonuçlar yerine anlamlı veriler görmek için "ContactsAPI_DummyData.sql" dosyasında bulunan scripti kullanarak tablolara veri eklenmesini sağlayabiliriz.

Verileri ekledikten sonra eklenen veriler üzerinde değişiklik yapabilmek için aşağıdaki bilgileri kullanarak login routu üzerinden bir POST isteği yapmalısınız. İstek sonucunda oluşan JWT'yi kullanarak endpointler üzerinde yetki sahibi olabilir ve sql script'i aracılığıyla eklediğiniz verileri düzenleyebilirsiniz.

```json
{
  "email": "admin@mail.com",
  "password": "Admin123#"
}
```

## Testlerin Gerçekleştirilmesi

> Testler çalıştırıldığı anda appsettings.json içerisinde bulunan RedisCacheConfig.IsEnabled değeri true ise proje istekleri önbelleklemek için Redis hizmetini kullanacak demektir. Bu sebeple redis hizmetinin çalışır durumda olması gerekmektedir.
> Redis kullanmadan testleri çalıştırmak istiyorsanız appsettings.json içerisinde bulunan RedisCacheConfig.IsEnabled değerini false olarak atayabilirsiniz.

1. **Komut satırı istemcisi kullanarak**
	1. "ContactsAPI.sln" dosyasının bulunduğu dizine erişin	
		- `cd .\GitHubRepos\ContactsAPI`
	2. ContactsAPI.Test projesini çalıştırın
		- `cd .\ContactsAPI.Test`
		- `dotnet test`
> ![image](https://user-images.githubusercontent.com/42785142/108567102-9f107f80-7318-11eb-9d22-65cd72ca36ad.png)
               
2. **Visual Studio 2019 kullanarak**
	1. Projenin ana dizininde bulunan "ContactsAPI.sln" dosyasını Visual Studio 2019 ile açın
    2. Yukarıdaki menü çubuğunda bulunan "Test" menüsü altındaki "Test Explorer" seçeneğine tıklayın.
    3. Açılan panelde mevcut olan testleri ayrı ayrı veya grup halinde çalıştırabilirsiniz.
    4. Çalıştırmak istediğiniz testin üstüne sağ tıklayıp "Run" seçeneğini tıklayın.
> ![image](https://user-images.githubusercontent.com/42785142/108567255-f151a080-7318-11eb-9693-8e6aba377b8e.png)

## Kullanılan Teknolojiler

* .NET Core 3.1
	* Swagger
	* JWT
* Entity Framework Core 
	* Code-First
* MsSQL
* Redis
* xUnit.NET Testing
	* Fluent Assertions

## Bilinen hatalar

* ~~Redis Cache projede devre dışı bırakıldığında JWT Authentication gerçekleşmiyor~~
* ~~Tüm testler aynı anda çalıştırıldığında JWT Authentication başarısız olabiliyor.~~
