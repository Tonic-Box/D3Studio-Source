
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "SavedConversations")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedConversations : IExtensible
  {
    private byte[] _played_conversations_bitfield;
    private List<int> _sno_saved_conversations = new List<int>();
    private byte[] _sno_saved_conversations_bitfield = (byte[]) null;
    private int _bitfield_leading_null_bytes = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "played_conversations_bitfield")]
    public byte[] played_conversations_bitfield
    {
      get => this._played_conversations_bitfield;
      set => this._played_conversations_bitfield = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, Name = "sno_saved_conversations")]
    public List<int> sno_saved_conversations
    {
      get => this._sno_saved_conversations;
      set => this._sno_saved_conversations = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "sno_saved_conversations_bitfield")]
    [DefaultValue(null)]
    public byte[] sno_saved_conversations_bitfield
    {
      get => this._sno_saved_conversations_bitfield;
      set => this._sno_saved_conversations_bitfield = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "bitfield_leading_null_bytes")]
    [DefaultValue(0)]
    public int bitfield_leading_null_bytes
    {
      get => this._bitfield_leading_null_bytes;
      set => this._bitfield_leading_null_bytes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
