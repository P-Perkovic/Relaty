using Relaty.Models;
using System;

namespace Relaty.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DateOfStart { get; set; }

        public Status Status { get; set; }
    }
}
