namespace andrewhaydendev.Models
{
    public class Resume_LineItems
    {
        public int ID { get; set; }
        public int ResumeID { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
    }
}