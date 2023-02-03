namespace DefaultNamespace.GameData
{
    public static class DataBase
    {
        public static PickableCharacters[] PickableCharactersArray = new  PickableCharacters[] 
        {
            new ("test","testguy","frameImages/testguy")

        };
        
        
        
        public static LevelRecord[] LevelRecordsArray = new  LevelRecord[] 
        {
            //new ("test","testguy","frameImages/testguy")
            new("testLevel",new[] {
                "test","test","test","test",
                "test","test","test","test",
                "test","test","test","test"},
                new []{"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"})

        };
    }
}