
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "Currency")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Currency : IExtensible
  {
    private int _tab = -1;
    private ulong _amount = 0;
        private int _index;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "tab")]
    [DefaultValue(-1691237125)]
    public int tab
    {
      get => this._tab;
      set => this._tab = value;
    }

        [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "amount")]
        [DefaultValue(0)]
        public ulong amount
        {
            get => this._amount;
            set => this._amount = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "index")]
        [DefaultValue(0)]
        public int index
        {
            get => this._index;
            set => this._index = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
