using Acudir.Test.Domain;
using Acudir.Test.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Acudir.Test.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly string _filePath = "Test.json";

        public IEnumerable<Persona> GetAll(string nombre = "", int? edad = null)
        {
            var personas = LoadPersonas();
            if (!string.IsNullOrEmpty(nombre))
            {
                personas = personas.Where(p => p.Nombre == nombre).ToList();
            }
            if (edad.HasValue)
            {
                personas = personas.Where(p => p.Edad == edad).ToList();
            }
            return personas;
        }

        public void Add(Persona persona)
        {
            var personas = LoadPersonas();
            personas.Add(persona);
            SavePersonas(personas);
        }

        public void Update(Persona persona)
        {
            var personas = LoadPersonas();
            var index = personas.FindIndex(p => p.Id == persona.Id);
            if (index != -1)
            {
                personas[index] = persona;
                SavePersonas(personas);
            }
        }

        private List<Persona> LoadPersonas()
        {
            var json = File.ReadAllText(_filePath);
            var personas = JsonConvert.DeserializeObject<List<Persona>>(json);
            return personas ?? new List<Persona>(); // Retorna una lista vacía si el resultado es null
        }

        private void SavePersonas(List<Persona> personas)
        {
            var json = JsonConvert.SerializeObject(personas, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}