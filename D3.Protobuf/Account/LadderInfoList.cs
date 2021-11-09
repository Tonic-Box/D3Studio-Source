
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "LadderInfoList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class LadderInfoList : IExtensible
  {
    private List<LadderInfo> _info = new List<LadderInfo>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "info")]
    public List<LadderInfo> info
    {
      get => this._info;
      set => this._info = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
