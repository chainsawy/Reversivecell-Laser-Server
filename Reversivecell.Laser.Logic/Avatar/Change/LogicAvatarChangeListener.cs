namespace Reversivecell.Laser.Logic.Avatar.Change
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    public class LogicAvatarChangeListener
    {
        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        public void Destruct()
        {
            // Destruct.
        }

        public virtual void ExpLevelGained(int count)
        {
            ;
        }

        public virtual void DebugToggleNewbieCoop()
        {
            ;
        }

        public virtual void BuyLives(int count)
        {
            ;
        }

        public virtual void DebugPurchaseIAPOffer(int offerBundle, LogicCharacterData characterData)
        {
            ;
        }

        public virtual void DebugToggleMapPreviewResult()
        {
            ;
        }

        public virtual void HeroUnlocked(LogicCharacterData character)
        {
            ;
        }

        public virtual void PlayerAgeSet(int age)
        {
            ;
        }

        public virtual int GetCurrentTimestamp()
        {
            return LogicTimeUtil.GetTimestamp();
        }

        public virtual void CommodityCountChanged(int a1, LogicData a2, int a3, int a4, int a5)
        {
            ;
        }

        public virtual void BattlePartyChanged()
        {
            ;
        }

        public virtual void PermanentShopOfferPurchased()
        {
            ;
        }

        public virtual void DebugChampionshipChallengeWinAdded()
        {
            ;
        }

        public virtual void DebugSetHeroScoreSumRewardClaimedUpToLevel(int level)
        {
            ;
        }

        public virtual void DebugChangeRankedElo(int a1, bool a2, int a3)
        {
            ;
        }

        public virtual void DebugScoreChanged(LogicCharacterData character, int newScore)
        {
            ;
        }

        public virtual void TailRewardClaimed(int a1, int a2, int a3)
        {
            ;
        }

        public virtual void DiamondPurchaseMade(int a1, int a2, int a3, int a4, int a5)
        {
            ;
        }

        public virtual void StarPowerDropped(LogicCardData data)
        {
            ;
        }

        public virtual void SkinChanged(LogicSkinData data)
        {
            ;
        }

        public virtual void SkinUnlocked(LogicSkinData data)
        {
            ;
        }

        public virtual void ScoreChanged(int a1, int a2, int a3, bool a4)
        {
            ;
        }

        public virtual void brawlpassPointsClaimed(int a1, int a2)
        {
            ;
        }

        public virtual void HeroUpgraded(LogicCharacterData character)
        {
            ;
        }

        public virtual void AttackRatingChanged(int oldRating, int newRating)
        {
            ;
        }

        public virtual void QuestsSeen()
        {
            ;
        }

        public virtual void HeroSelected(LogicCharacterData characterData)
        {
            ;
        }

        public virtual void ShareReplay(LogicLong id, string a2)
        {
            ;
        }
    }
}
