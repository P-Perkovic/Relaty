using Relaty.Models;

namespace Relaty.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public Title Title { get; set; }
    }
}
