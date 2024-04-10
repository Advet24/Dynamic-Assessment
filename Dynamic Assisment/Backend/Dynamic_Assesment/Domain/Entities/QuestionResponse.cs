using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string? UserResponse { get; set; }
        public int QuestionId { get; set; }
    }
}
