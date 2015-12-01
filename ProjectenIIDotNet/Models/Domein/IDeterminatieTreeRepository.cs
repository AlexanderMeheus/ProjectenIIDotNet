using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectenIIDotNet.Models.Domein.Determinatie;

namespace ProjectenIIDotNet.Models.Domein
{
    public interface IDeterminatieTreeRepository
    {
        DeterminatieTree FindBy(int ID);

        ICollection<DeterminatieTree> FindByGraad(Graad graad);

        ICollection<DeterminatieTree> FindAll();
    }
}
