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

### Ön Gereksinimler

Bu WEB API projesi .NET Core 2.1 Ortamında oluşturulup sırasıyla .NET Core 2.2 -> 3.0 -> 3.1 sürümlerine güncellenmiştir.

**Bu süreçte faydalandığım Microsoft dökümanları:**
- [Migrate from ASP.NET Core 2.1 to 2.2](https://docs.microsoft.com/tr-tr/aspnet/core/migration/21-to-22)
- [Migrate from ASP.NET Core 2.2 to 3.0](https://docs.microsoft.com/tr-tr/aspnet/core/migration/22-to-30)
- [Migrate from ASP.NET Core 3.0 to 3.1](https://docs.microsoft.com/tr-tr/aspnet/core/migration/30-to-31)

Projeyi başarılı bir şekilde derleyebilmek için **.NET Core 3.1 SDK paketinin** ve **.NET Core 3.1 runtime paketinin** bilgisayarınızda kurulu olması gerekiyor.

Bilgisayarınızda kurulu bulunan .NET Core SDK paketlerini bir komut satırı istemcisine (örn: CMD) aşağıdaki komutu girerek görüntüleyebilirsiniz.


* `dotnet --list-sdks`

Benim bilgisayarımda kurulu olan .NET Core SDK paketleri:
```bash
C:\Windows\system32> dotnet --list-sdks
2.1.813 [C:\Program Files (x86)\dotnet\sdk]
2.2.207 [C:\Program Files (x86)\dotnet\sdk]
3.0.103 [C:\Program Files (x86)\dotnet\sdk]
3.1.406 [C:\Program Files (x86)\dotnet\sdk]
```

Güncel SDK paketleri [Microsoft'un Web sitesi](https://dotnet.microsoft.com/download/dotnet) üzerinden indirip sisteminize kurabilirsiniz.

[Visual Studio 2019](https://visualstudio.microsoft.com/tr/downloads/) öncesi sürümler .NET Core Ortamında geliştirme yapmak için uygun değiller. Bu sebeple [Visual Studio 2019](https://visualstudio.microsoft.com/tr/downloads/) veya dengi güncellikle olan bir IDE kullanıyor olmanız gerekiyor.

Projede [Redis](https://redis.io/) hizmeti kullanılmıştır. Bu sebeple redis hizmetinin kurulu olması gerekmekte. Uzak bir sunucudaki redis hizmetine bağlanmak için redis bağlantı bilgilerini "appsettings.json" içerisinden güncelleyebilirsiniz.

Aşağıdaki komutu, komut satırı istemcisinde çalıştırarak redis hizmetini başatabilirsiniz
* `redis-server`

.NET Core 3.1 SDK ve Runtime paketleri konusunda bir eksik yok ve çalışan bir Redis hizmetine sahipseniz projenin ilk defa derlenme aşamasına geçebiliriz. 

### İlk Derleme

1. **Komut satırı istemcisi kullanarak**
	1. "ContactsAPI.sln" dosyasının bulunduğu dizine erişin	
      	- `cd .\GitHubRepos\ContactsAPI`
    2. Projeleri "restore" edin, ardından derleyin
        - `dotnet restore`
        - `dotnet build`
    3. ContactsAPI projesini çalıştırın
        - `cd .\ContactsAPI`
        - `dotnet run`
        
2. **Visual Studio 2019 kullanarak**
	1. Projenin ana dizininde bulunan "ContactsAPI.sln"	dosyasını Visual Studio 2019 ile açın
	2. Solution Explorer penceresinden mevcut Solution'a sağ tıklayıp "Restore NuGet Packages" seçeneğini seçin
    3. Yukarıdaki menü çubuğunda bulunan "Build" menüsü altındaki "Reuild Solution" seçeneğine tıklayın.
    4. Klavyenizden F5 tuşuna basarak veya debug tools kısmındaki [> ContactsAPI] yazına tıklayarak projeyi çalıştırın.

Bu noktaya kadar her şey yolundaysa, arkada bir hata bırakmadıysak, redis hizmeti çalışıyorsa; projedeki endpointlerin sergilendiği SwaggerUI sayfasına aşağıdaki bağlantıyı kullanarak erişebiliriz.
- `https://localhost:5001/swagger/index.html`
>Bu bağlantı proje için varsayılandır.

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
Tokeni girdikten sonra (eğer token geçerliyse) SwaggerUI sayfasında sergilenen endpoint'ler ile etkileşime geçmemiz mümkün olacaktır. Aksi taktirde [HTTP401 Unauthorized](https://developer.mozilla.org/tr/docs/Web/HTTP/Status/401) uyarısıyla karşılaşacaksınız.

Kullandığınız JWT'nin ömrü oluşturulduğu andan itibaren 2 Saattir. Token erişiminizi kaybetmeniz durumunda Login route üzerinden aynı formatta bir POST isteği yaparak üyeliğinize ait yeni bir JWT elde edebilirsiniz. Yeni JWT ile yine aynı yöntemle endpointler üzerinde yetki elde edebilirsiniz

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

* Redis Cache projede devre dışı bırakıldığında JWT Authentication gerçekleşmiyor
* Tüm testler aynı anda çalıştırıldığında JWT Authentication başarısız olabiliyor.
