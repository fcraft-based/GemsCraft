namespace fCraft.Drawing.nbt.Tags
{
    internal interface INbtTagValue<T>
    {
        T Value { get; set; }
    }
}
