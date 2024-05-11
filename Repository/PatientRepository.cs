using blogbackend.DataContext;
using blogbackend.Model;

namespace blogbackend.Repository
{
    public class PatientRepository
    {
        private readonly ApplicationDataContext _context;

        public PatientRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public void Create(Patient patient)
        {
            _context.Patient.Add(patient);
            _context.SaveChanges();
        }

        // Read all products
        public IEnumerable<Patient> GetAll()
        {
            return _context.Patient.ToList();
        }

        // Read a product by Id
        public Patient GetById(int id)
        {
            var patient = _context.Patient.Find(id);
     
            if (patient != null)
            {
                return patient;
            }
            else
            {
                throw new InvalidOperationException($"Product with id {id} not found.");
            }
        }

        // Update a product
        public void Update(Patient product)
        {
            _context.Patient.Update(product);
            _context.SaveChanges();
        }

        // Delete a product
        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Patient.Remove(product);
                _context.SaveChanges();
            }
        }


    }
}
