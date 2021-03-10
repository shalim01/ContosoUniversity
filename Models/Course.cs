//tinfo200:[2021-02-27-shalim01-dykstra1] -- Creation of Course class which contains accessor informaiton such as CoureseID,Title,etc. Indicate statement also used
//                                           so that the value is not used outside of code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //tinfo200:[2021-02-27-shalim01-dykstra1] -- To indicate that that the value is only used internally. (and not into any database)
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        //four accessors for object Course informations.
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
       public ICollection<Enrollment> Enrollments { get; set; }
    }
}
