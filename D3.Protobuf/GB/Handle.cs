
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.GameBalance
{
  [ProtoContract(Name = "Handle")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Handle : IExtensible
  {
    private int _game_balance_type;
    private int _gbid;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "game_balance_type")]
    public int game_balance_type
    {
      get => this._game_balance_type;
      set => this._game_balance_type = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "gbid")]
    public int gbid
    {
      get => this._gbid;
      set => this._gbid = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
