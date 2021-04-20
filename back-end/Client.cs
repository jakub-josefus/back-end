using System.ComponentModel.DataAnnotations;


namespace back_end
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }

    }
}
