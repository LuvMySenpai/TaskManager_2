using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_2.DB_data
{
    internal class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string CreatedDateFormatted => CreatedDate.ToString("dd.MM.yyyy");

        public DateTime DeadlineDate { get; set; }

        [NotMapped]
        public string DeadlineDateFormatted => DeadlineDate.ToString("dd.MM.yyyy");

        public string Priority { get; set; }
        public int FulfillmentType { get; set; }
    }
}
