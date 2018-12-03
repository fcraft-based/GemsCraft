using System.Collections.Generic;

namespace GemsCraft.Drawing.nbt.Tags
{
    internal interface INbtTagList
    {
        List<NbtTag> Tags { get; }

        T Get<T>(int tagIdx) where T : NbtTag;
    }
}
