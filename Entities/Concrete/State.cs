using Core.Entities;

namespace Entities.Concrete
{
    public class State : IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
