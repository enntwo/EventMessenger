using System.Collections.Generic;

namespace Data
{
    public class Player
    {
        public Player()
        {
            Events = new List<int>();
        }

        public string FullName { get; set; }
        public string DCINumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool SendTexts { get; set; }
        public string EmailAddress { get; set; }
        public bool SendEmails { get; set; }
        public List<int> Events { get; set; }
    }
}
