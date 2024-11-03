# Creational Design Patterns

Tasarım desenleri, yazılım geliştirmede karşılaşılan yaygın sorunlara tekrar kullanılabilir ve test edilmiş çözümler sunar. Bu desenler, belirli sorunları çözmek için yazılım tasarımında kullanılan en iyi yöntemler olarak kabul edilir. Belirli bir teknolojiye veya dile bağlı olmadan uygulanabilirler ve kodun daha modüler, esnek, okunabilir ve sürdürülebilir olmasını sağlar.

## Neden Oluşturucu Tasarım Desenlerine İhtiyaç Duyuyoruz?

`new` operatörü, nesne oluşturma için en temel yöntem olsa da, özellikle karmaşık ve maliyetli nesneler söz konusu olduğunda bazı sorunlara yol açabilir. Her nesne oluşturma işlemi kodda ekstra maliyetlere yol açabilir ve bu da performans sorunlarına neden olabilir. 

Creational Design Patterns, bu maliyetleri yönetmek ve nesne oluşturmayı daha esnek ve kontrol edilebilir hale getirmek için geliştirilmiştir. 

## Oluşturucu Tasarım Desenleri: 

Bu desenler, nesne oluşturma sürecini kontrol etmek ve soyutlamak için farklı stratejiler kullanır:

### 1. Singleton Design Pattern:

Uygulamada sadece tek bir örnek olması gereken nesneleri oluşturmak için kullanılır. Bu desen, bir sınıfın sadece tek bir örneğinin oluşturulmasını ve bu örneğe uygulama çapında merkezi bir erişim noktası sağlamasını garanti eder.

**Örnek:** Bir veritabanı bağlantısı yöneticisi veya global bir ayarlar dosyası gibi, uygulamanızda tek bir instance'a ihtiyaç duyulan sınıflarda kullanılır.

**Avantajlar:**

* Tek bir instance'ın varlığını garanti eder.
* Merkezi bir erişim noktası sağlar.

**Dezavantajlar:**

* Tek sorumluluk ilkesini ihlal edebilir.
* Asenkron süreçlerde birden fazla instance oluşturabilir.
* Test edilebilirliği zorlaştırabilir.

### 2. Multiton Design Pattern:

Uygulamada sınırlı sayıda örnek olması gereken nesneleri oluşturmak için kullanılır. Bu desen, bir sınıfın belirli sayıda örneğinin oluşturulmasını ve bu örneklerin uygulama çapında yönetilmesini sağlar.

**Örnek:** Farklı kullanıcı profilleri için, belirli bir sınırdan daha fazla örneğe izin verilmeyen özel senaryolarda kullanılabilir.

**Avantajlar:**

* Belirli sayıda instance'ın varlığını garanti eder.
* Yönetimi ve erişimi kolaylaştırır.

**Dezavantajlar:**

* Yüksek karmaşıklık.
* Singleton'ın dezavantajlarını paylaşabilir.

### 3. Factory Method Design Pattern:

Nesne oluşturma sorumluluğunu yardımcı bir sınıfa devretmek için kullanılır. Bu desen, nesne oluşturma kodunu, nesneyi gerçekten kullanacağımız koddan ayırır ve nesne oluşturma sürecini standart hale getirir.

**Örnek:** Farklı türde database bağlantıları oluşturmak için, her bir bağlantı türü için farklı factory metotları kullanılabilir.

**Avantajlar:**

* Sıkı bağımılıktan kaçınmak.
* Kodun okunabilirliğini ve sürdürülebilirliğini iyileştirmek.
* Nesne oluşturma kodunun genişletilmesini kolaylaştırmak.

**Dezavantajlar:**

* Factory sınıfının yönetimi ve genişletilmesi karmaşık olabilir.

### 4. Abstract Factory Design Pattern:

Birden fazla ürün ailesi ile çalışmak zorunda kalındığı durumlarda, geliştiriciyi bu yapılardan soyutlamak için kullanılır. Bu desen, ilişkisel olan bir dizi nesneyi üretmek için kullanılır ve her bir ürün ailesi için farklı bir arayüz tanımlar.

**Örnek:** Farklı platformlar için (Windows, Linux, macOS) kullanıcı arayüzleri oluşturmak için kullanılabilir.

**Avantajlar:**

* Ürün aileleri arasındaki bağımlılıkları kaldırır.
* Kodun genişletilmesini ve değiştirilmesini kolaylaştırır.

**Dezavantajlar:**

* Karmaşık yapı ve çok sayıda sınıf gerektirir.

### 5. Prototype Design Pattern:

Üretimi çok zaman ve kaynak gerektiren nesneleri klonlayarak oluşturmak için kullanılır. Bu desen, önceden oluşturulmuş bir nesnenin klonunu alarak yeni bir instance oluşturur ve bu da maliyetli nesnelerin tekrar tekrar oluşturulmasını engeller.

**Örnek:** Bir veritabanında kullanılan büyük bir veri yapısını klonlamak için kullanılabilir.

**Avantajlar:**

* Maliyetli nesneleri oluşturma sürecini hızlandırır.
* Nesnelerin klonlanmasıyla daha esnek tasarım sağlar.

**Dezavantajlar:**

* Karmaşık nesnelerin klonlanması zor olabilir.
* Derin kopyalama ve dairesel referansların yönetimi karmaşık olabilir.

### 6. Object Pool Design Pattern:

Tekrar kullanılan nesnelerin üretim ve imha süreçlerindeki maliyetleri en aza indirmek için kullanılır. Bu desen, önceden oluşturulmuş nesneleri bir havuzda tutar ve gerektiğinde bu havuza geri döner.

**Örnek:** Veritabanı bağlantıları, ağ bağlantıları ve diğer maliyetli kaynaklar için kullanılabilir.

**Avantajlar:**

* Nesne oluşturma ve imha maliyetlerini azaltır.
* Kaynak kullanımını optimize eder.
* Performansı artırır.

**Dezavantajlar:**

* Havuz yönetimi ve senkronizasyon karmaşık olabilir.
* Asenkron operasyonlarda dikkatli kullanılması gerekir.

### 7. Builder Design Pattern:

Bir nesnenin adım adım oluşturulmasını ve bu sürecin soyutlanmasını sağlar. Bu desen, karmaşık nesnelerin farklı konfigürasyonlarını oluşturmayı kolaylaştırır.

**Örnek:** Bir araba oluşturmak için, farklı motor, renk, donanım ve diğer seçenekler kullanarak farklı araba yapıları oluşturulabilir.

**Avantajlar:**

* Karmaşık nesneleri oluşturmayı kolaylaştırır.
* Kodun okunabilirliğini ve sürdürülebilirliğini artırır.
* Nesne oluşturma sürecini kontrol etmeyi sağlar.

**Dezavantajlar:**

* Yüksek karmaşıklık.
* Çok sayıda sınıf ve metot gerektirir.

## Sonuç:

Oluşturucu tasarım desenleri, nesne oluşturma işlemini basitleştirmek, kodun okunabilirliğini ve sürdürülebilirliğini artırmak ve uygulama performansını iyileştirmek için güçlü araçlardır. Bu desenleri kullanarak, nesne oluşturma sürecini kontrol edebilir, soyutlayabilir ve uygulama kodunu daha esnek ve genişletilebilir hale getirebilirsiniz.
