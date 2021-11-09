
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "KillerInfo")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class KillerInfo : IExtensible
  {
    private int _sno_killer = -1;
    private uint _rarity = 0;
    private List<int> _rare_name_gbids = new List<int>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "sno_killer")]
    [DefaultValue(-1)]
    public int sno_killer
    {
      get => this._sno_killer;
      set => this._sno_killer = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "rarity")]
    [DefaultValue(0)]
    public uint rarity
    {
      get => this._rarity;
      set => this._rarity = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, Name = "rare_name_gbids")]
    public List<int> rare_name_gbids
    {
      get => this._rare_name_gbids;
      set => this._rare_name_gbids = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
