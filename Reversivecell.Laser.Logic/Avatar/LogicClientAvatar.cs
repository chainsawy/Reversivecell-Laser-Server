namespace Reversivecell.Laser.Logic.Avatar
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Avatar.Change;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Logic.Util;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;
    using System;

    public class LogicClientAvatar : LogicAvatar
    {
        public const int COMMODITY_COUNT = 8;

        private LogicAvatarChangeListener _avatarChangeListener;

        private LogicLong _id;
        private LogicLong _accountId;
        private LogicLong _homeId;

        private string _name;
        private bool _nameSetByUser;

        private LogicArrayList<LogicDataSlot>[] _commodity;

        private int _diamonds; // 128
        private int _freeDiamonds; // 132
        private int _cumulativePurchasedDiamonds; // 136

        private int _battleCount; // 144
        private int _winCount; // 148
        private int _loseCount; // 152
        private int _winLooseStreak; // 156
        private int _npcWinCount; // 160
        private int _npcLoseCount; // 164
        private int _tutorialsCompletedCount; // 176

        public LogicClientAvatar() : base()
        {
            this._name = string.Empty;
            this._commodity = new LogicArrayList<LogicDataSlot>[COMMODITY_COUNT];
            for (int i = 0; i < COMMODITY_COUNT; i++)
            {
                this._commodity[i] = new LogicArrayList<LogicDataSlot>();
            }
        }

        public override void Encode(ChecksumEncoder encoder)
        {
            ByteStreamHelper.EncodeLogicLong(encoder, _id);
            ByteStreamHelper.EncodeLogicLong(encoder, _accountId);
            ByteStreamHelper.EncodeLogicLong(encoder, _homeId);

            encoder.WriteStringReference(_name);
            encoder.WriteBoolean(_nameSetByUser);
            encoder.WriteInt(0);

            encoder.WriteVInt(COMMODITY_COUNT);
            for (int i = 0; i != COMMODITY_COUNT; i++)
            {
                encoder.WriteVInt(_commodity[i].Count);
                for (int j = 0; j != _commodity[i].Count; j++)
                {
                    _commodity[i][j].Encode(encoder);
                }
            }

            encoder.WriteVInt(this._diamonds);
            encoder.WriteVInt(this._freeDiamonds);
            encoder.WriteVInt(0); // unk 88
            encoder.WriteVInt(0); // unk 92
            encoder.WriteVInt(this._cumulativePurchasedDiamonds);
            encoder.WriteVInt(this._battleCount);
            encoder.WriteVInt(this._winCount);
            encoder.WriteVInt(this._loseCount);
            encoder.WriteVInt(this._winLooseStreak);
            encoder.WriteVInt(this._npcWinCount);
            encoder.WriteVInt(this._npcLoseCount);
            encoder.WriteVInt(this._tutorialsCompletedCount);
        }
        
        public override void Decode(ByteStream stream)
        {
            this._id = ByteStreamHelper.DecodeLogicLong(stream);
            this._accountId = ByteStreamHelper.DecodeLogicLong(stream);
            this._homeId = ByteStreamHelper.DecodeLogicLong(stream);

            this._name = stream.ReadString();
            this._nameSetByUser = stream.ReadBoolean();
            int unknown172 = stream.ReadInt();

            int commodityCount = stream.ReadVInt();
            if (commodityCount != COMMODITY_COUNT)
            {
                Debugger.Error($"received commodity count:{commodityCount}, server commodity count:{COMMODITY_COUNT}");
            }

            for (int i = 0; i < commodityCount; i++)
            {
                int count = stream.ReadVInt();
                this._commodity[i] = new LogicArrayList<LogicDataSlot>(count);
                for (int j = 0; j < count; j++)
                {
                    LogicDataSlot dataSlot = new LogicDataSlot(null);
                    dataSlot.Decode(stream);
                    this._commodity[i].Add(dataSlot);
                }
            }

            this._diamonds = stream.ReadVInt();
            this._freeDiamonds = stream.ReadVInt();
            int unk88 = stream.ReadVInt();
            int unk92 = stream.ReadVInt();
            this._cumulativePurchasedDiamonds = stream.ReadVInt();
            this._battleCount = stream.ReadVInt();
            this._winCount = stream.ReadVInt();
            this._loseCount = stream.ReadVInt();
            this._winLooseStreak = stream.ReadVInt();
            this._npcWinCount = stream.ReadVInt();
            this._npcLoseCount = stream.ReadVInt();
            this._tutorialsCompletedCount = stream.ReadVInt();
        }

        public int GetCommodityCount(int index, LogicData data)
        {
            if (index >= COMMODITY_COUNT)
            {
                Debugger.Error("LogicClientAvatar::validateCommodityType.");
                return 0;
            }

            for (int i = 0; i < _commodity[index].Count; i++)
            {
                if (_commodity[index][i].GetData().Equals(data))
                {
                    return _commodity[index][i].GetCount();
                }
            }

            return 0;
        }

        public LogicArrayList<LogicCardData> GetAllHeroOrItemCards()
        {
            LogicArrayList<LogicCardData> list = new LogicArrayList<LogicCardData>();

            for (int i = 0; i < _commodity[0].Count; i++)
            {
                if (_commodity[0][i].GetData().GetDataType() == 23)
                {
                    list.Add((LogicCardData)_commodity[0][i].GetData());
                }
            }

            return list;
        }

        public bool ShouldGoToFirstTutorialBattle()
        {
            return _tutorialsCompletedCount == 0;
        }

        public bool IsTutorialState()
        {
            return _tutorialsCompletedCount < 2;
        }

        public void TutorialStepCompleted()
        {
            _tutorialsCompletedCount = LogicMath.Min(_tutorialsCompletedCount + 1, 2);
        }

        public void SkipTutorial()
        {
            _tutorialsCompletedCount = 2;
        }

        public int GetScore()
        {
            LogicArrayList<LogicCardData> cards = this.GetAllHeroOrItemCards();

            int result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                LogicCharacterData character = LogicDataTables.GetCharacterByName(cards[i].GetTarget());
                result += this.GetCommodityCount(1, character);
            }
            return result;
        }

        public int GetHighestScore()
        {
            LogicArrayList<LogicCardData> cards = this.GetAllHeroOrItemCards();

            int result = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                LogicCharacterData character = LogicDataTables.GetCharacterByName(cards[i].GetTarget());
                result += this.GetCommodityCount(2, character);
            }
            return result;
        }

        public void SetCommodityCount(int commodityIndex, LogicData data, int count)
        {
            if (commodityIndex > COMMODITY_COUNT)
            {
                Debugger.Error("LogicClientAvatar::validateCommodityType.");
                return;
            }

            LogicArrayList<LogicDataSlot> array = this._commodity[commodityIndex];
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].GetData().GetGlobalID() == data.GetGlobalID())
                {
                    array[i].SetCount(count);
                    return;
                }
            }

            LogicDataSlot dataSlot = new LogicDataSlot(data, count);
            array.Add(dataSlot);
        }

        public void UnlockHero(LogicCardData card)
        {
            this.SetCommodityCount(0, card, 1);

            LogicCharacterData character = LogicDataTables.GetCharacterByName(card.GetTarget());
            this.SetCommodityCount(7, character, 1);

            if (this._avatarChangeListener != null)
            {
                this._avatarChangeListener.HeroUnlocked(character);
            }
        }

        public static LogicClientAvatar GetDefaultAvatar()
        {
            LogicClientAvatar avatar = new LogicClientAvatar();

            avatar.SetName("Brawler");
            avatar.SetNameSetByUser(false);

            LogicData data = LogicDataTables.GetHeroLvlUpMaterialData();
            avatar.SetCommodityCount(0, data, 100);

            LogicCardData card = LogicDataTables.GetCardByName("ShotgunGirl_unlock");
            avatar.UnlockHero(card);
            LogicCharacterData character = LogicDataTables.GetCharacterByName(card.GetTarget());
            avatar.SetCommodityCount(7, character, 2);

            return avatar;
        }

        public JObject Save()
        {
            JObject json = new JObject();

            json["id_hi"] = _id.GetHigherInt();
            json["id_lo"] = _id.GetLowerInt();

            json["accountId_hi"] = _accountId.GetHigherInt();
            json["accountId_lo"] = _accountId.GetLowerInt();

            json["homeId_hi"] = _homeId.GetHigherInt();
            json["homeId_lo"] = _homeId.GetLowerInt();

            json["name"] = _name;
            json["name_set"] = _nameSetByUser;

            JArray arr = new JArray();
            for (int i = 0; i < COMMODITY_COUNT; i++)
            {
                JArray list = new JArray();
                for (int j = 0; j < _commodity[i].Count; j++)
                {
                    list.Add(_commodity[i][j].WriteToJSON());
                }
                arr.Add(list);
            }
            json["commodity"] = arr;

            json["diamonds"] = _diamonds;
            json["free_diamonds"] = _freeDiamonds;
            json["cumulative_diamonds"] = _cumulativePurchasedDiamonds;
            json["battle_count"] = _battleCount;
            json["win_count"] = _winCount;
            json["lose_count"] = _loseCount;
            json["win_loose_streak"] = _winLooseStreak;
            json["npc_win_count"] = _npcWinCount;
            json["npc_lose_count"] = _npcLoseCount;
            json["tutorials_completed_count"] = _tutorialsCompletedCount;

            return json;
        }

        public void Load(JObject json)
        {
            _id = new LogicLong((int)json["id_hi"], (int)json["id_lo"]);
            _accountId = new LogicLong((int)json["accountId_hi"], (int)json["accountId_lo"]);
            _homeId = new LogicLong((int)json["homeId_hi"], (int)json["homeId_lo"]);

            _name = (string)json["name"];
            _nameSetByUser = (bool)json["name_set"];

            JArray arr = (JArray)json["commodity"];
            for (int i = 0; i < COMMODITY_COUNT; i++)
            {
                JArray list = (JArray)arr[i];
                for (int j = 0; j < list.Count; j++)
                {
                    JObject obj = (JObject)list[j];

                    LogicDataSlot dataSlot = new LogicDataSlot(null);
                    dataSlot.ReadFromJSON(obj);
                    _commodity[i].Add(dataSlot);
                }
            }

            _diamonds = (int)json["diamonds"];
            _freeDiamonds = (int)json["free_diamonds"];
            _cumulativePurchasedDiamonds = (int)json["cumulative_diamonds"];
            _battleCount = (int)json["battle_count"];
            _winCount = (int)json["win_count"];
            _loseCount = (int)json["lose_count"];
            _winLooseStreak = (int)json["win_loose_streak"];
            _npcWinCount = (int)json["npc_win_count"];
            _npcLoseCount = (int)json["npc_lose_count"];
            _tutorialsCompletedCount = (int)json["tutorials_completed_count"];
        }

        public void SetId(LogicLong id)
        {
            _id = id;
        }

        public void SetAccountId(LogicLong accountId)
        {
            _accountId = accountId;
        }

        public void SetHomeId(LogicLong homeId)
        {
            _homeId = homeId;
        }

        public LogicLong GetId()
        {
            return _id;
        }

        public LogicLong GetAccountId()
        {
            return _accountId;
        }

        public LogicLong GetHomeId()
        {
            return _homeId;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetNameSetByUser(bool value)
        {
            _nameSetByUser = value;
        }

        public bool GetNameSetByUser()
        {
            return _nameSetByUser;
        }

        public void SetDiamonds(int diamonds)
        {
            _diamonds = diamonds;
        }

        public int GetDiamonds()
        {
            return _diamonds;
        }
    }
}
