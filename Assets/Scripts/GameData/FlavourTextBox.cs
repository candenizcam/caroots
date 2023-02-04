namespace DefaultNamespace.GameData
{
    public record FlavourTextBox(FlavourTextPos TextPos, string L1, string L2, string L3, string L4);
    public enum FlavourTextPos{Host, Guest}
}