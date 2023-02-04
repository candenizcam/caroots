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
                "Çetin Bey bana bu şansı verdiğin için sana şükürler olsun! Asla unutamam o lanet günü.\nYağmur sonrası hava almaya çıkmıştık yapışık ikiz kardeşimle... Çıkmaz olaydık!\nBir kuş saldırısı vücutlarımızı ayırdı, su başmış sokakta farklı taraflara savrulduk.\nO hep denize meraklıydı, korsan filmleri izlerdi tüm gün, yüzdü gitti. Bense kayboldum.",
                "karahalka"),
            new("cater",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya başvurmaya çekindim Çetin Bey ama dayanamadım, dostumu çok özledim.\nÇocukluk arkadaşıyız biz, birlikte büyüdük, birlikte ne yapraklar yedik!\nAma son zamanlarda o çok değişti, bambaşka birine dönüştü.Paşamın burnu havalarda!\nO masum mahalle çocuğu gitti, yerini gösterişli biri aldı. Böyle lüks kılıklar...",
                "sümbül"),
            new("turtle",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Buraya, genç bir ninja olduğum günlerden olan ustamı aramaya geldim Çetin Bey.\nO bizi lağımlardan topladı ve eğitti. Ben ve kardeşlerim ona herşeyi borçluyuz.\nOnun sopasından çok dayak yedik ama onun elinden de çok peynir yedik.\nYaşlı ustamı tekrar görüp elini öpmek istiyorum!",
                "diken"),
            new("rooster",new[] {
                    "karahalka","ogulcan","sümbül","cabbar",
                    "diken","altintekme","saban","ramazan",
                    "abuzer","recep","tosun","nisa"},
                "Köyden göçeli kaç yıl oldu bilmiyorum ama köylümü arıyorum Çetin Abi.\nGörüşmeyeli mevsimler geçti, hiç de haber göndermedi ama ben ona küsmedim.\nDün yine oyunlarımızı andım... Köy meydanında şafak vakti düelloları oynardık.\nÇok özledim be arkadaşım, bir haber yolla!",
                "ramazan")

        };
    }
}