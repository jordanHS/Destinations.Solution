namespace Destinations.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public virtual Destination Destination { get; set; }
        public int DestinationId { get; set; }
    }
}