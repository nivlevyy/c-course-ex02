using System;

namespace Logics
{
    public class Player
    {
  
        private uint m_Score;
        private readonly string r_Name;
        private bool iscomputer;

        public Player(string i_NameOfUser, bool i_iscomputer = false)
        {
            r_Name = i_NameOfUser;
            iscomputer = i_iscomputer;
            m_Score = 0;
        }
        public uint incrementScore
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string Name
        {
            get { return r_Name; }
        }

    }
    
}
