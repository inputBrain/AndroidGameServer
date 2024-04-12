using System.Collections.Generic;
using System.IO;
using Utf8Json;

namespace ProjectX.Server.Host.Services;

public class FileInfoFormatter<T> : IJsonFormatter<FileInfo>
{
    public void Serialize(ref JsonWriter writer, FileInfo value, IJsonFormatterResolver formatterResolver)
    {
        if (value == null) { writer.WriteNull(); return; }

        // if target type is primitive, you can also use writer.Write***.
        formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.FullName, formatterResolver);
    }

    public FileInfo Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
    {
        if (reader.ReadIsNull()) return null;

        // if target type is primitive, you can also use reader.Read***.
        var path = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, formatterResolver);
        return new FileInfo(path);
    }

    public List<T> DeserializeList(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
    {
        // check current state is null. when null, advanced offset. if not, do not.
        if (reader.ReadIsNull()) return null;

        var formatter = formatterResolver.GetFormatterWithVerify<T>();
        var list = new List<T>();

        var count = 0; // managing array-count state in outer(this is count, not index(index is always count - 1)

        // loop helper for Array or Object, you can use ReadIsInArray/ReadIsInObject.
        while (reader.ReadIsInArray(ref count)) // read '[' or ',' when until reached ']'
        {
            list.Add(formatter.Deserialize(ref reader, formatterResolver));
        }

        return list;
    }
}
