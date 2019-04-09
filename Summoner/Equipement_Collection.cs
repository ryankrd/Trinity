﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Equipement_Collection
    {
        readonly Dictionary<string, Equipement> _equipements;

        internal Equipement_Collection()
        {

            _equipements = new Dictionary<string, Equipement>();
        }

        public Hat Create_Hat(string name , Dictionary<string,int> stats )
        {
           
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Hat hat = new Hat(name,stats);

            _equipements.Add(name, hat);
            return hat;
        }
        public Breastplate Create_Breastplate(string name, Dictionary<string, int> stats)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Breastplate breastplate = new Breastplate(name, stats);

            _equipements.Add(name, breastplate);
            return breastplate;
        }


        public Leg Create_leg(string name, Dictionary<string, int> stats)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Leg leg = new Leg(name, stats);

            _equipements.Add(name, leg);
            return leg;
        }


            public Boots Create_Boots(string name, Dictionary<string, int> stats)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Boots boots = new Boots(name, stats);

            _equipements.Add(name, boots);
            return boots;
        }

        public Weapon Create_Weapon(string name,  uint power)
        {
            //type = type de l'arme, arc, baton , epée ...
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            Weapon weapon = new Weapon(name, type, power);

            _equipements.Add(name, weapon);
            return weapon;
        }

        public Gem Create_Gem(string name, uint ratio, Spell spell, string description)
        {
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            Gem gem = new Gem(name, ratio, spell, description);

            _equipements.Add(name, gem);
            return gem;
        }




    }
}
