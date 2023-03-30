namespace StudentAdminPortal.API.DataModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Email { get; set; }
        public long mobile { get; set; }
        public String  ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }
        //Navigtion property
        public Gender Gender { get; set; }
        public Address Address { get; set; }        
    }
}
