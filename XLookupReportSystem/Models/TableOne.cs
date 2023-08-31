namespace XLookupReportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableOne")]
    public class TableOne
    {
        [Key]
        [StringLength(50)]
        public string TableOne_ID { get; set; }

        public int NoOfSI_Students { get; set; }

        public int NoOfSI_Students_Passed { get; set; }

        public decimal SI_Students_Pass_Rate { get; set; }

        public decimal AverageSI_Students_Pass_Rate { get; set; }

        public int No_SI_Of_A_Symbols { get; set; }

        public int No_SI_Of_B_Symbols { get; set; }

        public int No_SI_Of_C_Symbols { get; set; }

        public int No_SI_Of_D_Symbols { get; set; }

        public int No_SI_Of_F_Symbols { get; set; }

        public int Total_SI_Students { get; set; }

        public int NoOfNon_SI_Students { get; set; }

        public int NoOfNon_SI_Students_Passed { get; set; }

        public decimal Non_SI_Students_Pass_Rate { get; set; }

        public decimal AverageNon_SI_Students_Pass_Rate { get; set; }

        public int No_Non_SI_Of_A_Symbols { get; set; }

        public int No_Non_SI_Of_B_Symbols { get; set; }

        public int No_Non_SI_Of_C_Symbols { get; set; }

        public int No_Non_SI_Of_D_Symbols { get; set; }

        public int No_Non_SI_Of_F_Symbols { get; set; }

        public int Total_Non_SI_Students { get; set; }

        [StringLength(50)]
        public string Project_ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime modifiedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}