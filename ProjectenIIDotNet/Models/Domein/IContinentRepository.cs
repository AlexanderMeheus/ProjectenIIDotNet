using System.Collections.Generic;
using System.Linq;

namespace ProjectenIIDotNet.Models.Domein
{
    public interface IContinentRepository
    {

        ICollection<Continent> GeefAlleContinentenAlfabetisch(Graad graad);

        ICollection<Land> GeefAlleLandenAlfabetisch(string continentNaam);

        ICollection<Locatie> GeefAlleLocatiesAlfabetisch(string continentNaam, string landNaam);

        Continent GeefContinent(string continentNaam);

        Land GeefLand(string continentNaam, string landNaam);

        Locatie GeefLocatie(string continentNaam, string landNaam, string locatieNaam);

    }
}
