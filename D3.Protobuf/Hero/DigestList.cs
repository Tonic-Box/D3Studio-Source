
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "DigestList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class DigestList : IExtensible
  {
    private List<Digest> _digests = new List<Digest>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "digests")]
    public List<Digest> digests
    {
      get => this._digests;
      set => this._digests = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
