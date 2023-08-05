using CoreLayer.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public string Mail { get; set; }
        public double Salary { get; set; }
        public string Phone { get; set; }
        public List<Group> Groups { get; set; }
    }
}
