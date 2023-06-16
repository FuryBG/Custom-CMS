using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DataAccess
{
    public class DatatoData
    {
        [ForeignKey("DataContentId")]
        public int DataId1 { get; set; }
        [ForeignKey("DataContentId")]
        public int DataId2 { get; set; }
    }
}
