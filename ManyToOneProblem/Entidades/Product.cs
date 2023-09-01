namespace ManyToOneProblem.Entidades
{
    public class Product : object
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
