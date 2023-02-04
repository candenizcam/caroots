namespace DefaultNamespace.GameData
{
    public static class DataBase
    {
        public static PickableCharacters[] PickableCharactersArray = new  PickableCharacters[] 
        {
            new ("karahalka","karahalka","frameImages/testguy"),
            new ("ogulcan","oğulcan","frameImages/testguy"),
            new ("sümbül","sümbül","frameImages/testguy"),
            new ("cabbar","cabbar","frameImages/testguy"),
            new ("diken","diken","frameImages/testguy"),
            new ("altintekme","altıntekme","frameImages/testguy"),
            new ("saban","şaban","frameImages/testguy"),
            new ("ramazan","ramazan","frameImages/testguy"),
            new ("abuzer","abuzer","frameImages/testguy"),
            new ("recep","recep","frameImages/testguy"),
            new ("tosun","tosun","frameImages/testguy"),
            new ("nisa","nisa","frameImages/testguy")
        };
        
        
        
        public static LevelRecord[] LevelRecordsArray = new  LevelRecord[] 
        {
            //new ("test","testguy","frameImages/testguy")
            new("worm",new[] {
                "karahalka","ogulcan","sümbül","cabbar",
                "diken","altintekme","saban","ramazan",
                "abuzer","recep","tosun","nisa"},
                "Çetin Bey bana bu şansı verdiğin için sana şükürler olsun! Asla\nunutamam o lanet günü.Yağmur sonrası hava almaya çıkmıştık\nyapışık ikiz kardeşimle... Çıkmaz olaydık! Bir kuş saldırısı\nvücutlarımızı ayırdı, su başmış sokakta farklı taraflara\nsavrulduk. O hep denize meraklıydı, korsan filmleri izlerdi\ntüm gün, yüzdü gitti. Bense battım sulara ve kayboldum..",
                "karahalka"),
            new("cater",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya başvurmaya çekindim Çetin Bey ama dayanamadım, dostumu\nçok özledim. Çocukluk arkadaşıyız biz, birlikte büyüdük,\nbirlikte ne yapraklar yedik! Ama son zamanlarda o çok değişti,\nbambaşka birine dönüştü.Paşamın burnu havalarda! O masum\nmahalle çocuğu gitti, yerini gösterişli biri aldı. Böyle lüks\nkılıklar, aksesuarlar falan...",
                "sümbül"),
            new("turtle",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya, genç bir ninja olduğum günlerden olan ustamı aramaya\ngeldim Çetin Bey. O bizi lağımlardan topladı ve eğitti. Ben ve\nkardeşlerim ona herşeyi borçluyuz. Onun sopasından çok dayak\nyedik ama onun elinden de çok peynir yedik. Yaşlı ustamı\ntekrar görüp elini öpmek istiyorum!",
                "diken"),
            new("rooster",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Köyden göçeli kaç yıl oldu bilmiyorum ama köylümü arıyorum\nÇetin Abi. Görüşmeyeli mevsimler geçti, hiç de haber göndermedi\nama ben ona küsmedim. Dün yine oyunlarımızı andım... Köy\nmeydanında şafak vakti düelloları oynardık. Çok özledim be\narkadaşım, bir haber yolla!",
                "ramazan")

        };
    }
}