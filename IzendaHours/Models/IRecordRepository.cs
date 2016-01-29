using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzendaHours.Models
{
    public interface IRecordRepository
    {
        IEnumerable<Record> SelectAll();
        Record SelectByID(int id);
        void Insert(Record obj);
        void Update(Record obj);
        void Delete(string id);
        void Save();
    }
}
