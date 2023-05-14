namespace lab4.Models
{
    public class MyBeer
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Alchool { set; get; }
        public string Description { set; get; }

        public string Country { set; get; }

        public override string ToString()
        {
            return Title;
        }
    }
}
