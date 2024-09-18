using System.ComponentModel.DataAnnotations;

namespace DotnetTask.Model
{
    public class User
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
        public string Name
        {
            get; set;
        }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth
        {
            get; set;
        }

        [Required(ErrorMessage = "Residential Address is required.")]
        public string ResidentialAddress
        {
            get; set;
        }

        [Required(ErrorMessage = "Permanent Address is required.")]
        public string PermanentAddress
        {
            get; set;
        }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters.")]
        public string PhoneNumber
        {
            get; set;
        }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(255, ErrorMessage = "Email Address cannot be longer than 255 characters.")]
        public string EmailAddress
        {
            get; set;
        }

        [StringLength(50, ErrorMessage = "Marital Status cannot be longer than 50 characters.")]
        public string MaritalStatus
        {
            get; set;
        }

        [StringLength(10, ErrorMessage = "Gender cannot be longer than 10 characters.")]
        public string Gender
        {
            get; set;
        }

        [StringLength(100, ErrorMessage = "Occupation cannot be longer than 100 characters.")]
        public string Occupation
        {
            get; set;
        }

        [StringLength(12, ErrorMessage = "Aadhar Card Number cannot be longer than 12 characters.")]
        public string AadharCardNumber
        {
            get; set;
        }

        [StringLength(10, ErrorMessage = "PAN Number cannot be longer than 10 characters.")]
        public string PanNumber
        {
            get; set;
        }

        public string Image
        {
            get; set;
        }


        public IFormFile ImageFile
        {
            get; set;
        }
    }
}
