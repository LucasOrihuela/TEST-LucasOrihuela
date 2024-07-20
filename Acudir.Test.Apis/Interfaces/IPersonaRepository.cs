using Acudir.Test.Domain;
using System.Collections.Generic;

namespace Acudir.Test.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll(string nombre = null, int? edad = null);
        void Add(Persona persona);
        void Update(Persona persona);
    }
}
