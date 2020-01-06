using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.User
{
    public class UserEdit
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Max lenght of username is 30")]
        public string Username { get; set; }
        [RegularExpression("[a-zA-Z]{2,30}", ErrorMessage = "Only characters, max length 30")]
        public string FirstName { get; set; }
        [RegularExpression("[a-zA-Z]{2,40}", ErrorMessage = "Only characters, max length 40")]
        public string LastName { get; set; }
        [MaxLength(30, ErrorMessage = "Max lenght of City name is 30")]
        public string City { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public string Password { get; set; }
    }
}
