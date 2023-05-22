**Proje geliştirmesi devam ediyor...**
# Ekşi Sözlük Clone
Ekşi sözlük clone, Blazor ve REST API bilgilerinin pekiştirtirilmesi, Onion Architecture ve CQRS yapısının öğrenilmesi amacıyla geliştirildi.


### Proje Yapısı
- Proje **VS Code** ve **.NET6** sürümü ile geliştirildi.
- Frontend
    - Blazor
    - Bootstrap 5
- Backend
    - REST Api
    - **CQRS Pattern** dahil edilerek **Onion Architecture** dizayn kalıbı uygulandı
    - **Code First** yaklaşımı ve **SQL Server** veritabanı kullanıldı.

## Yapılandırma
### 1.Dependencies
- [.NET6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
- ~~[RabbitMQ](https://www.rabbitmq.com)~~
- [Node.js](https://nodejs.org/en) npm kaynağından javascript ve css paketlerini yüklemek için
##### Bağımlı paketlerin yüklenmesi
- Blazor `.../src/Client/Blazor/wwwroot> npm i`
- API `.../src/Server/Api> dotnet restore`
- Common `.../src/Common> dotnet restore`

### 2.Connection String
- `Server/Api/appsettings.json`
- `Server/Infrastructure/Persistence/Context/SozlukCloneContext.cs`

Dosyalarının içerisinde bulunan veritabanı bağlantı adresleri güncellenmeli.

##### `Server/Api/appsettings.json`
```json
"ConnectionStrings": {
    "SQLServer": "Server=...;Initial Catalog=EksiSozlukDb;Integrated Security=True;"
}
```

##### `Server/Infrastructure/Persistence/Context/SozlukCloneContext.cs`
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer("Server=...;Initial Catalog=EksiSozlukDb;Integrated Security=True;");
}
```
### 3.Fake Data
`Server/Infrastructure/Persistence/PersistenceRegistration.cs` içerisinde bulunan
```c#
public static IServiceCollection AddPersistenceDependencies(this IServiceCollection service, IConfiguration configuration){

    new FakeData().GenerateAsync().GetAwaiter().GetResult();

}
```
methodu ile bağımlılıkların eklendiği sırada `new FakeData().GenerateAsync()` fonksiyonu ile varsayılan olarak **25 kullanıcı** , **25 entry** , **500 entry yorumu** oluşturulup veritabanına ekleme işlemi gerçekleştirilir. 
- `GenerateAsync()` fonksiyonuna girilen parametre değerleri ile bu sayılar değiştirilebilir
- Ekleme işlemi yalnızca veritabanında ilgili alanlarda kayıt yok ise yapılır


### 4.Database Update
`Server/Infrastructure/Persistence/Migrations` altında bulunan migrations'ların uygulanması
```console
...\src\Server\Infrastructure\Persistence> dotnet ef database update
```
### 5.Projenin Çalıştırılması
1. `...\src\Server\Api> dotnet run`
2. `...\src\Client\Blazor> dotnet run`