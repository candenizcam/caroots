namespace DefaultNamespace.GameData
{
    /** record for pickable characters
     * Id, unique id shared with others
     * Name, name as displayed in the game
     * FramePath, path to the frame image on the game
     */
    public record PickableCharacters(string Id, string Name, string FramePath);
}