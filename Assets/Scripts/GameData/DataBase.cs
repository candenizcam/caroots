namespace DefaultNamespace.GameData
{
    public static class DataBase
    {
        public static PickableCharacters[] PickableCharactersArray = new  PickableCharacters[] 
        {
            new ("karahalka","karahalka","frameImages/karahalka"),
            new ("ogulcan","oğulcan","frameImages/ogulcan"),
            new ("sümbül","sümbül","frameImages/sümbül"),
            new ("cabbar","cabbar","frameImages/cabbar"),
            new ("diken","diken","frameImages/diken"),
            new ("altintekme","altıntekme","frameImages/altintekme"),
            new ("saban","şaban","frameImages/saban"),
            new ("ramazan","ramazan","frameImages/ramazan"),
            new ("abuzer","abuzer","frameImages/abuzer"),
            new ("recep","recep","frameImages/recep"),
            new ("tosun","tosun","frameImages/tosun"),
            new ("nisa","nisa","frameImages/nisa")
        };
        
        
        
        public static LevelRecord[] LevelRecordsArray = new  LevelRecord[] 
        {
            //new ("test","testguy","frameImages/testguy")
            new("worm",new[] {
                "karahalka","ogulcan","sümbül","cabbar",
                "diken","altintekme","saban","ramazan",
                "abuzer","recep","tosun","nisa"},
                "Çetin Bey bana bu şansı verdiğin için sana şükürler olsun! Asla\nunutamam o lanet günü.Yağmur sonrası hava almaya çıkmıştık\nyapışık ikiz kardeşimle... Çıkmaz olaydık! Bir kuş saldırısı\nvücutlarımızı ayırdı, su başmış sokakta farklı taraflara\nsavrulduk. O hep denize meraklıydı, korsan filmleri izlerdi\ntüm gün, yüzdü gitti. Bense battım sulara ve kayboldum..",
                "karahalka", new string[] {"İyi akşamlar, sevgili konuklar ve ekran başındaki izleyiciler!\nBen Çetin Tavşanoğlu, ama arkadaşlarım bana Tavşan Ç der.\nFilm gibi hayatların köklerini aradığımız programa,\nCa-Root'a hoşgeldiniz!","Bu akşam ve her akşam konuklarımız bu koltukta oturup hayat\nhikayelerini anlatacak koptukları kökleri bulmaya çalışacaklar.\nSonra da iş bizlere düşecek.Anlatımlarına göre\nkapıdan kimin gelmesi gerektiğini bulacağız.","Eğer doğru bulabilirsek kapı açıldığında stüdyomuzda\nbuluşacaklar ve hasretleri bitecek.\nEğer program bitmeden bulamazsak,\nmaalesef evlerine kolları boş dönecekler.\nHazırsak, ilk konuğumuz gelsin!","İlk konuğumuzun inanılmaz acıklı bir hikayesi var. Sadece\nhayatından değil vücudundan da kopup gitmiş birini,\nikiz kardeşini arıyor. Alkışlarınızla Solucanan Hanım!"},new string[] {}),
            new("cater",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya başvurmaya çekindim Çetin Bey ama dayanamadım, dostumu\nçok özledim. Çocukluk arkadaşıyız biz, birlikte büyüdük,\nbirlikte ne yapraklar yedik! Ama son zamanlarda o çok değişti,\nbambaşka birine dönüştü.Paşamın burnu havalarda! O masum\nmahalle çocuğu gitti, yerini gösterişli biri aldı. Böyle lüks\nkılıklar, aksesuarlar falan...",
                "sümbül", new string[] {"Hayat bu, en kandan candan yakınları bile yol ayrımlarıyla\nbambaşka yerlere gönderebiliyor. Sıradaki konuğumuzun hikayesi\nde böyle bir hikaye. Bambaşka hayatlar yaşayan eski\ndostuyla tekrar görüşmek isteyen Yaşar Bey gelsin!"},new string[] {}),
            new("turtle",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya, genç bir ninja olduğum günlerden olan ustamı aramaya\ngeldim Çetin Bey. O bizi lağımlardan topladı ve eğitti. Ben ve\nkardeşlerim ona herşeyi borçluyuz. Onun sopasından çok dayak\nyedik ama onun elinden de çok peynir yedik. Yaşlı ustamı\ntekrar görüp elini öpmek istiyorum!",
                "diken", new string[] {"En çok da en kötü durumlardan bizi çekip kurtaran köklerimizi\nunutmamak lazım. Bizi büyütüp eğitenlere sonsuz teşekkür\nborçluyuz. İsrafil Bey de kendisini ve kardeşlerini yetiştiren\ndeğerli bir büyüğünü arıyor, umuyoruz ki beraber bulacağız."},new string[] {}),
            new("rooster",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Köyden göçeli kaç yıl oldu bilmiyorum ama köylümü arıyorum\nÇetin Abi. Görüşmeyeli mevsimler geçti, hiç de haber göndermedi\nama ben ona küsmedim. Dün yine oyunlarımızı andım... Köy\nmeydanında şafak vakti düelloları oynardık. Çok özledim be\narkadaşım, bir haber yolla!",
                "ramazan", new string[] {"Hani derler ya, geldiğin yöreleri unutmayacaksın diye. Son\nkonuğumuz da biraz bunu söylemek için burada. Köylüsüyle\nbuluşmak için yol iz bilmeden buralara kadar gelen\nNecmi Bey'e gelsin alkışlar!"},new string[] {})

        };

        public static FlavourText[] FlavourTexts = new[]
        {
            new FlavourText("a1",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Bu akşam maç varmış,","hiç sevmem. Zaten bu","milleti bu hale takım","tutturup getirdiler.")
            }),
            new FlavourText("a2",new string[]
            {"worm"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Bu ülkede haydutlar","sokakları serbest","dolaştıkça kardeşler","çok kopar be dostlar!")
            }),
            new FlavourText("a3",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "","Kim bu yakışıklı?","Aaa benmişim.","")
            }),
            new FlavourText("a4",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "İnsanın aklı","kemirmiyor böyle","olayları yahu.","")
            }),
            new FlavourText("a5",new string[]
            {"cater"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Benim böyle değişip","kopan dostlarım oldu.","Şimdi televizyonda","görünce arar sorar"),
                new FlavourTextBox(FlavourTextPos.Host, "oldular yav Çetin'cim","nasılsın görüşmeyeli","diye tabii.","")
            }),
            new FlavourText("a6",new string[]
            {"turtle"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Büyüklerimiz çok","önemli efendim.","",""),
                new FlavourTextBox(FlavourTextPos.Host, "Umarım biz de","yaşlanınca bu","kapılarda bizleri","bekleyenler olur.")
            }),
            new FlavourText("a7",new string[]
            {"rooster"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Domates","Biber","Patlıcan","")
            }),
            new FlavourText("a8",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Geçen yeni bir kitaba","başladım, herkese","öneririm. Zaten bu","ülkeye okur lazım.")
            }),
            new FlavourText("a9",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Çok korkuyorum bir","gün kapıdan benim","anam babam çıkacak","diye.")
            }),
            new FlavourText("a10",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "","Favori yönetmeniniz","kim efendim?",""),
                new FlavourTextBox(FlavourTextPos.Guest, "","Kartal Tibet.","",""),
                new FlavourTextBox(FlavourTextPos.Host, "","Ben değilim yani :(","","")
            }),
            new FlavourText("a11",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Yıl 2000 olmadan","girer miyiz Avrupa","Birliği'ne? Kaç","senedir bekliyoruz.")
            }),
            new FlavourText("a12",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Biz Mehmet Ali gibi","Yılbaşı Özel yapsak","rating rekoru kırarız","bence.")
            }),
            new FlavourText("a13",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "","Film gibi hayatlar","gerçekten.","")
            }),
            new FlavourText("a14",new string[]
            {"worm"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Hala çıkar mısınız","topraktan peki","yağmur yağdığında?",""),
                new FlavourTextBox(FlavourTextPos.Guest, "Nasıl çıkmayalım","Çetin Bey, bizimki","solucanlık hali.","")
            }),
            new FlavourText("a15",new string[]
            {"turtle"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "","O bıçaklar gerçek","mi oyuncak mı?",""),
                new FlavourTextBox(FlavourTextPos.Guest, "","Gerçek.","",""),
                new FlavourTextBox(FlavourTextPos.Host, "","Vay be.","","")
            }),
            new FlavourText("a16",new string[]
            {"rooster"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Benim de alarm saatim","bozuk, sizi mi işe","alsam acaba.","")
            }),
            new FlavourText("a17",new string[]
            {"cater"
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "","Çoluk çocuk var mı?","",""),
                new FlavourTextBox(FlavourTextPos.Guest, "","Üç tane biri kozada,","ellerinizden öperler.","")
            }),
            new FlavourText("a18",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Onlarca kişiyi burada","buluşturduk, sıradaki","siz olabilirsiniz.","")
            }),
            new FlavourText("a19",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Bir alkış da","orkestramıza","gelmesin mi öyleyse?","")
            }),
            new FlavourText("a20",new string[]
            {
                
            },new[]
            {
                new FlavourTextBox(FlavourTextPos.Host, "Yine ekonomik kriz","yine yoksulluk. Havuç","aslanın ağzında","gerçekten.")
            })
            
        };
    }
}