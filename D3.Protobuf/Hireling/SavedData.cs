
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hireling
{
  [ProtoContract(Name = "SavedData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedData : IExtensible
  {
    private List<Info> _hirelings = new List<Info>();
    private uint _active_hireling = 0;
    private uint _available_hirelings_bitfield = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "hirelings")]
    public List<Info> hirelings
    {
      get => this._hirelings;
      set => this._hirelings = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "active_hireling")]
    [DefaultValue(0)]
    public uint active_hireling
    {
      get => this._active_hireling;
      set => this._active_hireling = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "available_hirelings_bitfield")]
    [DefaultValue(0)]
    public uint available_hirelings_bitfield
    {
      get => this._available_hirelings_bitfield;
      set => this._available_hirelings_bitfield = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
