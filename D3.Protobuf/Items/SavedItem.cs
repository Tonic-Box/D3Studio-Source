
using PB.OnlineService;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Items
{
    [ProtoContract(Name = "SavedItem")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SavedItem : IExtensible
    {
        private ItemId _id;
        private EntityId _owner_entity_id = (EntityId)null;
        private ItemId _socket_id = (ItemId)null;
        private int _hireling_class;
        private int _item_slot;
        private int _square_index;
        private uint _used_socket_count;
        private Generator _generator = (Generator)null;
        private Friend _friend = (Friend)null;
        private List<int> _augment;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "id")]
        public ItemId id
        {
            get => this._id;
            set => this._id = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "owner_entity_id")]
        [DefaultValue(null)]
        public EntityId owner_entity_id
        {
            get => this._owner_entity_id;
            set => this._owner_entity_id = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "socket_id")]
        [DefaultValue(null)]
        public ItemId socket_id
        {
            get => this._socket_id;
            set => this._socket_id = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "hireling_class")]
        public int hireling_class
        {
            get => this._hireling_class;
            set => this._hireling_class = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "item_slot")]
        public int item_slot
        {
            get => this._item_slot;
            set => this._item_slot = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "square_index")]
        public int square_index
        {
            get => this._square_index;
            set => this._square_index = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "used_socket_count")]
        public uint used_socket_count
        {
            get => this._used_socket_count;
            set => this._used_socket_count = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.Default, IsRequired = false, Name = "generator")]
        [DefaultValue(null)]
        public Generator generator
        {
            get => this._generator;
            set => this._generator = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = false, Name = "friend")]
        [DefaultValue(null)]
        public Friend friend
        {
            get => this._friend;
            set => this._friend = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.Default, IsRequired = false, Name = "custom_name")]
        [DefaultValue("")]
        [Browsable(false)]
        public string custom_name { get; set; }

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = false, Name = "custom_description")]
        [DefaultValue("")]
        [Browsable(false)]
        public string custom_description { get; set; }

        /*[ProtoMember(10, DataFormat = DataFormat.Default, IsRequired = false, Name = "augment")]
        [DefaultValue(null)]
        public List<int> augment
        {
            get => this._augment;
            set => this._augment = value;
        }*/

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
