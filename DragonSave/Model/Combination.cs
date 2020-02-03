using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    enum Combinations
    {
        MotherMother,
        FatherFather,
        MotherFatherNest,
        Villain

    }
    class Combination
    {
        public Combinations Name { set; get; }
        public bool IsCombPossible { set; get; }
    }
}
