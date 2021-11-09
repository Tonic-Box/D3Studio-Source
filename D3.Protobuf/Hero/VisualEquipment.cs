
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "VisualEquipment")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class VisualEquipment : IExtensible
  {
    private List<VisualItem> _visual_item = new List<VisualItem>();
        private List<VisualItem> _cosmetics = new List<VisualItem>();
        private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "visual_item")]
    public List<VisualItem> visual_item
    {
      get => this._visual_item;
      set => this._visual_item = value;
    }
        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "cosmetics")]
        public List<VisualItem> cosmetics
        {
            get => this._cosmetics;
            set => this._cosmetics = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
