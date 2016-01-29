using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace IzendaHours.Models
{
    public class RecordRepository : IRecordRepository
    {
        private IzendaHoursEntities dbtest = null;

        public RecordRepository()
        {
            this.dbtest = new IzendaHoursEntities();
        }

        public RecordRepository(IzendaHoursEntities dbtest)
        {
            this.dbtest = dbtest;
        }

        public IEnumerable<Record> SelectAll()
        {
            return dbtest.Records.ToList();
        }

        public Record SelectByID(int EntryId)
        {
            return dbtest.Records.Find(EntryId);
        }

        public void Insert(Record obj)
        {
            dbtest.Records.Add(obj);
        }

        public void Update(Record obj)
        {
            dbtest.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string EntryId)
        {
            Record existing = dbtest.Records.Find(EntryId);
            dbtest.Records.Remove(existing);
        }

        public void Save()
        {
            dbtest.SaveChanges();
        }
    }
}