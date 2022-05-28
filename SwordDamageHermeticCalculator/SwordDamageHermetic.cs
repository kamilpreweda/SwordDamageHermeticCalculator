using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SwordDamageHermeticPrototype
{
    public class SwordDamageHermetic
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        private int roll;
        private bool flaming;
        private bool magic;

        /// <summary>
        /// Konstruktor oblicza obrażenia na podstawie domyślnych wartości właściwości
        /// Magic i Flaming oraz początkowego rzutu 3d6.
        /// </summary>
        /// <param name="startingRoll">Początkowy rzut 3d6</param>
       public SwordDamageHermetic(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();            
        }

        /// <summary>
        /// Ustawia lub pobiera wartość rzutu 3d6.
        /// </summary>
        public int Roll { get { return roll; } set { roll = value; CalculateDamage(); } }

        /// <summary>
        /// Zwraca true, jeśli miecz jest płonący, w przeciwnym razie zwraca false.
        /// </summary>
        public bool Flaming {get { return flaming; } set { flaming = value; CalculateDamage(); } }

        /// <summary>
        /// Zwraca true, jeśli miecz jest magiczny, w przeciwnym razie zwraca false.
        /// </summary>
        public bool Magic { get { return magic; } set { magic = value; CalculateDamage(); } }

        /// <summary>
        /// Zawiera obliczone obrażenia.
        /// </summary>
        public int Damage { get; private set; }
      
        /// <summary>
        /// Oblicza obrażenia na podstawie aktualnych wartości właściwości.
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
            Debug.WriteLine($"Po wykonaniu CalculateDamage: {Damage} (rzut: {Roll})");
        }

        

        

    }
}
