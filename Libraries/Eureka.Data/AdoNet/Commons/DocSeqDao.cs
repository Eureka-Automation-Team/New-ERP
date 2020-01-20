using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;

namespace Eureka.Data.AdoNet
{
    public class DocSeqDao : IDocSeqDao
    {
        private static Db db = new Db("ms_sql");

        public void Delete(SequenceDocModel doc)
        {
            string sql =
            @"DELETE FROM doc_sequences_define
               WHERE DOC_SEQUENCE_ID = @DOC_SEQUENCE_ID";

            db.Update(sql, Take(doc));
        }

        public List<SequenceDocModel> GetAll()
        {
            string sql =
            @"SELECT DOC_SEQUENCE_ID, PREFIX, DOC_TYPE_CODE, 
                     NEXTVAL, RUNNING_DIGIT, CREATED_BY,  
                     CREATION_DATE, LAST_UPDATED_BY, LAST_UPDATE_DATE
                FROM doc_sequences_define";

            return db.Read(sql, Make).ToList();
        }

        public SequenceDocModel GetByType(string type)
        {
            string sql =
            @"SELECT DOC_SEQUENCE_ID, PREFIX, DOC_TYPE_CODE, 
                     NEXTVAL, RUNNING_DIGIT, CREATED_BY,  
                     CREATION_DATE, LAST_UPDATED_BY, LAST_UPDATE_DATE
                 FROM doc_sequences_define
                WHERE DOC_TYPE_CODE = @DOC_TYPE_CODE";

            object[] parms = { "@DOC_TYPE_CODE", type };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public void Insert(SequenceDocModel doc)
        {
            string sql =
            @"INSERT INTO doc_sequences_define (SRM_NAME, LOADER, 
                                 ROWS, CREATED_BY, CREATION_DATE, 
                                 LAST_UPDATED_BY, LAST_UPDATE_DATE, STATUS)
              VALUES (@SRM_NAME, @LOADER, 
                      @ROWS, @CREATED_BY, @CREATION_DATE, 
                      @LAST_UPDATED_BY, @LAST_UPDATE_DATE, @STATUS)";

            doc.Id = db.Insert(sql, Take(doc));
        }

        public void Update(SequenceDocModel doc)
        {
            string sql =
            @"UPDATE doc_sequences_define
                SET LAST_UPDATE_DATE = @LAST_UPDATE_DATE,
                    CREATION_DATE = @CREATION_DATE,
                    LAST_UPDATED_BY = @LAST_UPDATED_BY,
                    PREFIX = @PREFIX,
                    NEXTVAL = @NEXTVAL,
                    RUNNING_DIGIT = @RUNNING_DIGIT
               WHERE DOC_SEQUENCE_ID = @DOC_SEQUENCE_ID";

            db.Update(sql, Take(doc));
        }

        // creates a Member object based on DataReader

        private static Func<IDataReader, SequenceDocModel> Make = reader =>
             new SequenceDocModel
             {
                 Id = reader["DOC_SEQUENCE_ID"].AsId(),
                 Prefix = reader["PREFIX"].AsString(),
                 DocTypeCode = reader["DOC_TYPE_CODE"].AsString(),
                 NextVal = reader["NEXTVAL"].AsInt(),
                 RunningDigit = reader["RUNNING_DIGIT"].AsInt(),
                 LastUpdateDate = reader["LAST_UPDATE_DATE"].AsDateTime(),
                 LastUpdatedBy = reader["LAST_UPDATED_BY"].AsInt(),
                 CreationDate = reader["CREATION_DATE"].AsDateTime(),
                 CreatedBy = reader["CREATED_BY"].AsInt()
             };

        private object[] Take(SequenceDocModel srm)
        {
            return new object[]
            {
                "@DOC_SEQUENCE_ID", srm.Id,
                "@PREFIX", srm.Prefix,
                "@DOC_TYPE_CODE", srm.DocTypeCode,
                "@NEXTVAL", srm.NextVal,
                "@RUNNING_DIGIT", srm.RunningDigit,
                "@LAST_UPDATE_DATE", srm.LastUpdateDate,
                "@LAST_UPDATED_BY", srm.LastUpdatedBy,
                "@CREATION_DATE", srm.CreationDate,
                "@CREATED_BY", srm.CreatedBy
            };
        }
    }
}
