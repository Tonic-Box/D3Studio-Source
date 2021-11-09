
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PvpMatchList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PvpMatchList : IExtensible
  {
    private List<PvpMatch> _matches = new List<PvpMatch>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "matches")]
    public List<PvpMatch> matches
    {
      get => this._matches;
      set => this._matches = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
