using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public partial class Villager : GameItem
    {
        static public void Engage(Villager woman, Villager man)
        {
            if (woman.Gender == man.Gender) { throw new InvalidOperationException("these villagers have the same gender"); }
            Debug.Assert(woman.StatusInFamily == Status.SINGLE, "the woman is not single");
            Debug.Assert(man.StatusInFamily == Status.SINGLE, "the man is not single");

            woman.SetFiance(man);
            man.SetFiance(woman);
            woman.StatusInFamily = Status.ENGAGED;
            man.StatusInFamily = Status.ENGAGED;
        }      

         public void UnEngage()
        {
            if (StatusInFamily != Status.ENGAGED) { throw new InvalidOperationException("this villager is not engaged"); }

            _fiance.StatusInFamily = Status.SINGLE;
            _fiance.DeleteFiance();
            _statusInFamily.Current = Status.SINGLE;
            DeleteFiance();

        }


         internal void Mourn()
         {
             Debug.Assert(_statusInFamily.Current == Status.MARRIED);
             Debug.Assert(_fiance!=null);

             _fiance.StatusInFamily = Status.MOURNING;
             _statusInFamily.Current = Status.MOURNING;
             _fiance.DeleteFiance();
             DeleteFiance();

         }

        public void Engage(Villager villager)
        {
            if(villager.Gender == _gender) { throw new InvalidOperationException("these villagers have the same gender"); }
            if (villager.StatusInFamily != Status.SINGLE || _statusInFamily.Current != Status.SINGLE) { throw new InvalidOperationException("villager is not single(Engage)"); }
            
            SetFiance(villager);
            villager.SetFiance(this);
            _statusInFamily.Current = Status.ENGAGED;
            villager.StatusInFamily = Status.ENGAGED;
             Villager man;
            if(_gender==Genders.MALE){man=this;}
            else{man=villager;}
            if (Game.SingleMen.Contains(man)) { Game.RemoveSingleMan(man); }

        }
        public Villager GetFiance()
        {
            if (_statusInFamily.Current == Status.SINGLE) { throw new InvalidOperationException("villager is single"); }
            if (_statusInFamily.Current == Status.MOURNING) { throw new InvalidOperationException("villager is mourning"); }
            if (_fiance == null) { throw new NullReferenceException("null fiance!(GetFiance)"); }
            return _fiance;
        }

        internal void SetFiance(Villager fiance)
        {
            if (StatusInFamily != Status.SINGLE) { throw new InvalidOperationException("villager is not single!(SetFiance)"); }
            if (fiance == null) { throw new ArgumentNullException("fiance is null"); }
            _fiance = fiance;
        }
        internal void DeleteFiance()
        {
            Debug.Assert(_statusInFamily.Current == Status.SINGLE || _statusInFamily.Current == Status.MOURNING);
            Debug.Assert(_fiance != null, "there already is no fiance");
            _fiance = null;
        }

        private void Engage(Villager woman, Family parentFamily)
        {
            Debug.Assert(woman.Gender ==Genders.FEMALE , "not a woman !");
            
            int i = 0;
            while (i < Game.SingleMen.Count)
            {
                if (parentFamily != Game.SingleMen[i].ParentFamily)
                {
                    Debug.Assert(Game.SingleMen[i].StatusInFamily == Status.SINGLE, "the man you're trying to marry is not single!");
                    woman.Engage(Game.SingleMen[i]);
                    /*woman.StatusInFamily = Status.ENGAGED;
                    Game.SingleMen[i].StatusInFamily = Status.ENGAGED;
                    tmpSingleMan = Game.SingleMen[i];
                    Game.RemoveSingleMan(tmpSingleMan);//
                    Debug.Assert(Game.SingleMen.Contains(tmpSingleMan));
                    Debug.Assert(parentFamily != Game.SingleMen[i].ParentFamily);*/
                    /*Timer timer = new Timer;
                    timer.Interval=5000;
                    timer.Start*/

                    break;
                }
                i++;
            }
        }

        internal void FianceDestroyed()
        {
            Debug.Assert(_fiance != null);
            Debug.Assert(_fiance.IsDead());
            Debug.Assert(_fiance.GetFiance() == this);
            Debug.Assert(_statusInFamily.Current != Status.MOURNING);

            
            if (_statusInFamily.Current == Status.ENGAGED)
            {
                UnEngage();
                if (_gender == Genders.MALE)
                {
                    Game.AddSingleMan(this);
                }
            }
            if (_statusInFamily.Current == Status.MARRIED)
            {
                Mourn();
            }
            Debug.Assert(_fiance == null);
            //DeleteFiance();
        }
    }
}
