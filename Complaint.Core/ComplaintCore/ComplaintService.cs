using Complaint.Data;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complaint.Core.ComplaintCore
{
    public class ComplaintService : IComplaintService
    {
        private readonly RepositoryContext _repositoryContext;

        public ComplaintService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public bool Create(ComplaintModel complaint)
        {
            try
            {
                _repositoryContext.Complaint.Add(complaint);
                _repositoryContext.SaveChanges();

                if (complaint.Id > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ComplaintModel FindById(int complaintId)
        {
            ComplaintModel complaint = null;
            try
            {
                complaint = _repositoryContext.Complaint.Find(complaintId);
            }
            catch (Exception)
            {

                throw;
            }

            return complaint;
        }
    }
}
