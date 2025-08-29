using Gameplay;
using System;
using UnityEngine;

namespace UI
{
    public partial class HpBarView
    {
        [Serializable]
        private struct FactionFillImage
        {
            public Faction faction;
            public Sprite sprite;
        }
    }
}