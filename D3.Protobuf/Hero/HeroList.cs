
using PB.OnlineService;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "HeroList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class HeroList : IExtensible
  {
    private List<EntityId> _hero_ids = new List<EntityId>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "hero_ids")]
    public List<EntityId> hero_ids
    {
      get => this._hero_ids;
      set => this._hero_ids = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
