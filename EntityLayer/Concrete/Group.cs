using CoreLayer.Entities;

namespace EntityLayer.Concrete
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public double CoursePrice { get; set; }
        public bool IsDeactive { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow.AddHours(4);
        public DateTime StartTime { get; set; }
        public Category Category { get; set; }
        public Teacher Teacher { get; set; }    
    }
}
