using FindInternship.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(GetStudents());
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();

            students.Add(new Student()
            {
                Id = "30b28597-2305-4f3b-a21a-95b287cae818", 
                UserId = "080a469a-b5a2-44cc-a660-eea8e6fd05a5", 
                ClassId = "0edc45cb-b2f1-48a2-8f6b-17910e09a147", 
            });

            return students;
        } 
    }
}
