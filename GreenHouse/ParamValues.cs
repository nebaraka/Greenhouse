public struct ParamValues
{
    public int timeSlice;
    public Corridor acidity;
    public Corridor light;
    public Corridor temperature;
    public Corridor wetness;
    public struct Corridor
    {
        double maxValue;
        double minValue;
    }
}