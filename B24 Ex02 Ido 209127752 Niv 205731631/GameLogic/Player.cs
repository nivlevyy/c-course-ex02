using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Components
{
    internal struct Player
    {
        public enum PlayerTurn { FIRST = 1, SECONDE = 2 };
        private uint m_Score;
        private readonly string r_Name;
        private bool iscomputer;
        public uint playerturn;
        public Player(string i_NameOfUser, bool i_iscomputer)
        {
            r_Name = i_NameOfUser;
            iscomputer = i_iscomputer;
            m_Score = 0;
            playerturn = (uint)PlayerTurn.FIRST;
        }
        public uint Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string Name
        {
            get { return r_Name; }
        }
        public bool IsComputer
        {
            internal get { return iscomputer; }
            set { iscomputer = value; }
        }

    }
}
