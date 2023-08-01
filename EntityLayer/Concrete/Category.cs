using CoreLayer.Entities;

namespace EntityLayer.Concrete
{
    public class Category : IEntity
    { 
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Group>? Groups { get; set; }
    }
}
