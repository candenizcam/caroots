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
            new ("altıntekme","altıntekme","frameImages/testguy"),
            new ("saban","şaban","frameImages/testguy"),
            new ("ramazan","ramazan","frameImages/testguy"),
            new ("abuzer","abuzer","frameImages/testguy"),
            new ("recep","recep","frameImages/testguy"),
            new ("tosun","tosun","frameImages/testguy"),
            new ("nisa","nisa","frameImages/testguy"),
        };
        
        
        
        public static LevelRecord[] LevelRecordsArray = new  LevelRecord[] 
        {
            //new ("test","testguy","frameImages/testguy")
            new("testLevel",new[] {
                "test","test","test","test",
                "test","test","test","test",
                "test","test","test","test"},
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                "test")

        };
    }
}