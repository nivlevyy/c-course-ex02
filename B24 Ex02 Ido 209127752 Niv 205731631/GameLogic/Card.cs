using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Components
{
    public class Card
    {
        private readonly uint xCordinate;
        private readonly uint yCordinate;
        private readonly object realObject;
        private bool isRevealed;

        public Card(object i_realobj, uint x, uint y)
        {
            realObject = i_realobj;
            isRevealed = false;
            xCordinate = x;
            yCordinate = y;
        }
        public Card GetCard
        {
            get
            {
                Card newcopypointer = new Card(realObject, xCordinate, yCordinate);
                return newcopypointer;
            }
        }
        public bool IsRevealed
        {
            get { return isRevealed; }
            set { isRevealed = value; }
        }
        public object RealObject
        {
            get { return realObject; }
        }
        public uint getXCordinate
        {
            get { return xCordinate; }
        }
        public uint getYCordinate
        {
            get { return yCordinate; }
        }

        public static bool operator ==(Card firstCard, Card secondeCard)
        {
            return firstCard.realObject == secondeCard.realObject;
        }
        public static bool operator !=(Card firstCard, Card secondeCard)
        {
            return !(firstCard == secondeCard);
        }
        public override bool Equals(object obj)
        {
            return this.realObject == ((Card)obj).realObject;
        }
    }
}
