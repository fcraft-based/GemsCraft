namespace GemsCraft.Drawing.nbt.Tags
{
    internal interface INbtTagValue<T>
    {
        T Value { get; set; }
    }
}
