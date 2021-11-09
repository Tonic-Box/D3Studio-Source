
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PassiveSkills")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PassiveSkills : IExtensible
  {
    private List<int> _sno_traits = new List<int>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, Name = "sno_traits")]
    public List<int> sno_traits
    {
      get => this._sno_traits;
      set => this._sno_traits = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
