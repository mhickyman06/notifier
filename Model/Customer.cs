using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace NotificationApi.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool EmailNotificationEnable { get; set; }
        [Required]
        public bool SmsNotificationEnable { get; set; }
        [Required]
        public bool InAppNotificationEnable { get; set; }

    }
}
