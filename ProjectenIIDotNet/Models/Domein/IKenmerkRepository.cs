using ProjectenIIDotNet.Models.Domein.Determinatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectenIIDotNet.Models.Domein
{
    public interface IKenmerkRepository
    {
        Kenmerk FindBy(int ID);

        ICollection<Kenmerk> FindAll();

    }
}