namespace ManyToOneProblem.Entidades
{
    public class Product
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Category Category { get; set; }
    }
}
