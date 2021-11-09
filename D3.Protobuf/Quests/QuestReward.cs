
using PB.Items;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Quests
{
  [ProtoContract(Name = "QuestReward")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestReward : IExtensible
  {
    private int _xp_granted = 0;
    private int _gold_granted = 0;
    private Generator _item = (Generator) null;
    private int _sno_quest = -1;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "xp_granted")]
    [DefaultValue(0)]
    public int xp_granted
    {
      get => this._xp_granted;
      set => this._xp_granted = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "gold_granted")]
    [DefaultValue(0)]
    public int gold_granted
    {
      get => this._gold_granted;
      set => this._gold_granted = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "item")]
    [DefaultValue(null)]
    public Generator item
    {
      get => this._item;
      set => this._item = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "sno_quest")]
    [DefaultValue(-1)]
    public int sno_quest
    {
      get => this._sno_quest;
      set => this._sno_quest = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
