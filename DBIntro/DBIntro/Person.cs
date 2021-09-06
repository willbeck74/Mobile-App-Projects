using System;
using SQLite;

namespace DBIntro
{
    [Table("person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(200), Unique]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DOB { get; set; }

        [MaxLength(15), Unique]
        public string SSN { get; set; }

        public int Income { get; set; }

        public override string ToString()
        {
            string gender = "M";
            if (Gender)
                gender = "F";

            return string.Format("{0} ({1}) {2} {3} {4} {5}", Name, Id, Income, gender, DOB, SSN);
        }
    }
}
